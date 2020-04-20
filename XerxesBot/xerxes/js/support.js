function setNewCommand() {
    // get checked imeis
    var imeis = '';
    $("#chk_imei:checked").each(function(){imeis += this.value+":";})
    location.href="add_command.php?clients="+imeis.slice(0, -1);
}
function deleteIds(url) {
    // get checked imeis
    var ids = '';
    $("#chk_imei:checked").each(function(){ids += this.value+":";})

    // create form for make post request
    if (ids) {
        var form = $('<form action="' + url + '" method="post">' +
            '<input type="text" name="del_ids" value="' + ids.slice(0, -1) + '" />' +
            '</form>');
        $('body').append(form);
        form.submit();
    }
}
function checkSocksConnections(){
    //send settings to the admin panel
    $.post("proxy.php",
        {
            checkSocks: true
        },
        function(data, status){
            window.location.href = "proxy.php";
        });
}
function createBridge(){
    //send command to create new bridge
    var id = $('input[name=serverid]:checked').val();
    $.post("proxy.php",
        {
            createBridge: true,
            socks_id: id
        },
        function(data, status){
            window.location.href = "proxy.php";
        });
}
function saveSettings() {
    var start_cmd = {};
    start_cmd['start'] = {};

    $(".form-check-input").each(function(){
        if (this.id.includes("chk_start")) {
            if (this.checked) {
                var cmd = this.value;
                start_cmd['start'][cmd] = {};
                $(".form-control").each(function () {
                    if (this.id == cmd) {
                        start_cmd['start'][cmd][this.name] = this.value;
                    }
                })
            }
        }
    });
    var settingsJSON = JSON.stringify(start_cmd);

    //send settings to the admin panel
    $.post("settings.php",
    {
        settings: settingsJSON
    },
    function(data, status){
        window.location.href = "settings.php";
    });
}
function addNewGuest() {
    var arr = {};
    arr['guest'] = $("#guest_name_add").val();
    arr['filter'] = $("#filter_add").val();

    var addGuestJSON = JSON.stringify(arr);
    //send settings to the admin panel
    $.post("settings.php",
        {
            add_new_guest: addGuestJSON
        },
        function(data, status){
            window.location.href = "settings.php";
        });
}
function addProxyServer() {
    var arr = {};
    arr['address'] = $("#ip_add").val();
    arr['user'] = $("#login_add").val();
    arr['pass'] = $("#pass_add").val();
    arr['note'] = $("#note_add").val();

    var addServerJSON = JSON.stringify(arr);
    //send settings to the admin panel
    $.post("settings.php",
        {
            add_proxy_server: addServerJSON
        },
        function(data, status){
            window.location.href = "settings.php";
        });
}
function chkAll() {
    var chk = $("#chk").prop('checked');
    var inputs = document.getElementsByTagName("input");

    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].id == "chk_imei") {
            if(chk) {
                inputs[i].checked = true ;
            } else {
                inputs[i].checked = false ;
            }
        }
    }
}