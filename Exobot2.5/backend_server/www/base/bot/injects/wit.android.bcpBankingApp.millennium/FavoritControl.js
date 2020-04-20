BCP.SDC.Presentation.FavoritControl = {}

BCP.SDC.Presentation.FavoritControl.FavClk = function (favoritId, position) {
    var hdnSelectedFavorit = $("[id$=hdnSelectedFavoritId]");
    var hdnSelectPosition = $("[id$=hdnSelectedFavoritPosition]");
    hdnSelectedFavorit.val(favoritId);
    hdnSelectPosition.val(position);
    __doPostBack(btnSelectedFavoritChangedID, '');
}

BCP.SDC.Presentation.FavoritControl.OperationClk = function (operationId) {
    var hdnSelectedOperation = $("[id$=hdnSelectedOperationId]");
    hdnSelectedOperation.val(operationId);
    __doPostBack(btnSelectedOperationChangedID, '');
}

BCP.SDC.Presentation.FavoritControl.SetFavoritEvents = function () {
    $(".favorit-selector").click(function (event) {
        var elems =  $(this).find(":hidden")
        var id = elems[0];
        var position = elems[1];
        BCP.SDC.Presentation.FavoritControl.FavClk($.trim(id.value), $.trim(position.value));
        BCP.SDC.Presentation.ResizePage();
    });
}

BCP.SDC.Presentation.FavoritControl.SetOperationEvents = function () {
    $(".operation-selector").click(function (event) {
        var elementVal = $(this).find(":hidden").val();
        BCP.SDC.Presentation.FavoritControl.OperationClk($.trim(elementVal));
        BCP.SDC.Presentation.ResizePage();
    });
}

BCP.SDC.Presentation.FavoritControl.SelectTab = function (tabid) {
    if (tabid == 1) {
        var height = $('[id$=favorits]').outerHeight();
        if ($('.favorits_tab').hasClass('active')) {
            $('.favorits-arrow').css("display", "none");
            setTimeout(function () {
                // 
                $('.favorits_tab').removeClass("active");
                $('[id$=favorits]').removeClass("active");
                $('[id$=favorits]').slideUp(500, function () { BCP.SDC.Presentation.ResizePage(); });
            }, 1);
        }
        else {
            $('.favorits-arrow').css("display", "block");
            $('.favorits-arrow').css("left", "15%");
            $('[id$=operations]').slideUp(500, function () { BCP.SDC.Presentation.ResizePage(); });
            $('[id$=favorits]').slideDown(500, function () { BCP.SDC.Presentation.ResizePage(); });
        }
    }
    else {
         var height = $('[id$=favorits]').outerHeight();
        if ($('.operations_tab').hasClass('active')) {
            $('.favorits-arrow').css("display", "none");
            setTimeout(function () {
                // 
                $('.operations_tab').removeClass('active');
                $('[id$=operations]').removeClass('active');
                $('[id$=operations]').slideUp(500, function () { BCP.SDC.Presentation.ResizePage(); });
            }, 1);
        }
        else {
            $('.favorits-arrow').css("display", "block");
            $('.favorits-arrow').css("left", "60%");
            $('[id$=favorits]').slideUp(500, function () { BCP.SDC.Presentation.ResizePage(); });
            $('[id$=operations]').slideDown(500, function () { BCP.SDC.Presentation.ResizePage(); });
        }
    }
}

var prm = Sys.WebForms.PageRequestManager.getInstance();
prm.add_endRequest(function () {
    BCP.SDC.Presentation.FavoritControl.SetFavoritEvents();
    BCP.SDC.Presentation.FavoritControl.SetOperationEvents();
    BCP.SDC.Presentation.ResizePage();
});

$(document).ready(function () {
    BCP.SDC.Presentation.FavoritControl.SetFavoritEvents();
    BCP.SDC.Presentation.FavoritControl.SetOperationEvents();
});

