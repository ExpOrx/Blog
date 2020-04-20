<fieldset>
    <?php
    $commands = file_get_contents("config/commands.json");
    $commands = json_decode($commands, TRUE);
    ?>
    <script>
        function command_choose (){
            <?php
            foreach ($commands as $key => $value){
                echo '$(\'#'.$key.'_form\').css({\'display\':\'none\'});';
            }
            ?>

            var command = "#"+$('#chosen_cmd').val()+"_form";
            $(command).css({'display':'block'});
        }
    </script>

    <div class="form-group">
        <label>Commands </label>
        <select name="state" class="form-control selectpicker" id="chosen_cmd" required onchange="command_choose()">
            <option value=" " >Please select a command</option>
            <?php
            foreach ($commands as $key => $value){
                echo '<option value="'.$key.'">' . $key . '</option>';
            }
            ?>
        </select>
    </div>
    <div>
        <?php
        foreach ($commands as $key => $value) {
            echo '<form class="form" action="" method="post" id="'.$key.'_form" enctype="multipart/form-data" style="display:none;">';
            echo '<input type="hidden" name="action" value="'.$key.'">';
            if ($key == 'StartSocks'){
                $select = array('id', 'ip', 'forward_user', 'forward_pass');
                $db->where('status', 1);
                $servers = $db->get('proxy_servers');
                ?><div class="form-group">
                        <label for="StartSocksid">Server id</label>
                        <select name="server-id" class="form-control selectpicker" id="StartSocksid" required>
                            <option value=" " >Please select a server</option>
                            <?php
                            foreach ($servers as $server){
                                $sid = $server['id'];
                                $sip = $server['ip'];
                                echo '<option value="'.$sid.'">id: ' . $sid . ' ip: '.$sip.'</option>';
                            }
                            ?>
                        </select>
                    </div><?php
            }
            foreach ($value as $param => $description) {
                if ($key != 'StartSocks') echo '<div class="form-group">
                        <label for="'.$key.$param.'">'.$param.'</label>
                            <input value="" placeholder="'.$description.'" name="'.$param.'" class="form-control" id="'.$key.$param.'">
                    </div>';
            }
            echo '<div class="form-group text-center">
                    <label></label>
                    <button type="submit" class="btn btn-warning" >Send <span class="glyphicon glyphicon-send"></span></button>
                </div> ';
            echo '</form>';
        }
        ?>
    </div>

</fieldset>