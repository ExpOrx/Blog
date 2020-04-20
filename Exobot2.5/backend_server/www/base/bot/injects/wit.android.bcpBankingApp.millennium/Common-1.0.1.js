/**
 * Protect window.console method calls, e.g. console is not defined on IE
 * unless dev tools are open, and IE doesn't define console.debug
 */
(function () {
    if (!window.console) {
        window.console = {};
    }
    // union of Chrome, FF, IE, and Safari console methods
    var m = [
      "log", "info", "warn", "error", "debug", "trace", "dir", "group",
      "groupCollapsed", "groupEnd", "time", "timeEnd", "profile", "profileEnd",
      "dirxml", "assert", "count", "markTimeline", "timeStamp", "clear"
    ];
    // define undefined methods as noops to prevent errors
    for (var i = 0; i < m.length; i++) {
        if (!window.console[m[i]]) {
            window.console[m[i]] = function () { };
        }
    }

})();
jQuery.extend({
    parseQuerystring: function () {
        var nvpair = {};
        var qs = window.location.search.replace('?', '');
        var pairs = qs.split('&');
        $.each(pairs, function (i, v) {
            var pair = v.split('=');
            nvpair[pair[0]] = pair[1];
        });
        return nvpair;
    }
});

jQuery.fn.textdropdown = function () {
    var obj = $(this);

    $(".txtdrop li").click(function () {
        var val = $(this).find('input').val();
        obj.val(val);
    });

    with ($(this)) {
        with (next('ul:first')) {
            find('li').click(function () {
                obj.attr('value', $(this).find('input').val());
                obj.focus();
                $(this).parent().hide();
            });
            hide();
        }

        click(function () {
            var p = $(this);

            with (p.next('ul:first')) {
                css('position', 'absolute');
                css('width', p.width());
                css('left', p.position().left);
                css('z-index', '1000');
                css('top', p.position().top + p.height() + 1);
                toggle();
            }
        });
    }
}

Type.registerNamespace('BCP.SDC.Presentation');

BCP.SDC.Presentation.Stringformat = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }
    return s;
}

BCP.SDC.Presentation.AjaxErrorParse = function (errorObj, divError, message) {
    var errorMessage;
    //alert("status: " + errorObj.status);
    switch (errorObj.status) {
        case 500:
        case 700: // service or internal error
            //alert("message: " + errorObj.responseText);
            if (message != null && message != "") {
                errorMessage = message;
            }
            else if (errorObj.responseText != null && errorObj.responseText != "") {
                //alert("errorObj: " + errorObj.responseText);
                errorMessage = errorObj.responseText;
            }
            else {
                //alert("passou");
                errorMessage = BCP.SDC.Presentation.GetResource("ErrorPleaseTryAgainLater");
            }
            if (divError != null) {
                divError.html(errorMessage);
            }

            break;
        case 401: // session timout or invalid
        case 701: // session timout or invalid
        case 0:
            BCP.SDC.Presentation.GoToExpired("/SessionTimeOut.aspx?ReturnUrl=" + encodeURIComponent(window.location.href));
            break;
        case 702: // error page
            document.location.href = "/GenericErrorPage.aspx";
            break;
        default:
            //
            break;
    }
}

BCP.SDC.Presentation.MouseX = 0;
BCP.SDC.Presentation.MouseY = 0;
BCP.SDC.Presentation.GetResource = function (key) {
    var res = "[JS:" + key + "]";
    if (typeof (Resources != undefined) && (Resources != null)) {
        if (typeof (Resources["JS"]["JS_" + key] != undefined) && (Resources["JS"]["JS_" + key] != null)) {
            res = Resources["JS"]["JS_" + key]
        }
    }

    return res
}

BCP.SDC.Presentation.NavigateTo = function (url) {
    $('body').block();
    document.location.href = url;
}

BCP.SDC.Presentation.DownloadPdf = function (guid, acc, file) {
    var idDoc = guid;

    var url = '/security/Documents.aspx?GetPdfVia=PDF_VIA_HCB&Serv=2&DirectDownload=false&ids=' + encodeURIComponent(idDoc) + '&acc=' + encodeURIComponent(acc) + '&filename=' + encodeURIComponent(file) + '&ShwPpOnEr=true';

    //bcpcore_ui.ShowTopPopupIframe(url, BCP.SDC.Presentation.GetResource("DownloadMessageTitle"), '', false, null, 1200);



    var uagent = navigator.userAgent.toLowerCase();

    if (uagent.toLowerCase().search("iemobile") > -1) {

        BCP.SDC.Presentation.DownloadDocumentV2(url, BCP.SDC.Presentation.GetResource("PDFError"));
    }
    else {

        BCP.SDC.Presentation.DownloadDocument(url, BCP.SDC.Presentation.GetResource("PDFError"));
    }

}

BCP.SDC.Presentation.DownloadErrorMessage = "";
BCP.SDC.Presentation.OnDownloadDocError = function () {
    var uagent = navigator.userAgent.toLowerCase();
    bcpcore_ui.ShowTopPopupWarning(BCP.SDC.Presentation.DownloadErrorMessage, BCP.SDC.Presentation.GetResource("DownloadErrorMessageTitle"), '');
}

BCP.SDC.Presentation.OnDownloadDocSuccess = function () {
    console.info(5);
    var uagent = navigator.userAgent.toLowerCase();
    if (uagent.search("iphone") > -1 || uagent.search("ipad") > -1) {
        bcpcore_ui.ShowTopPopupWarning(BCP.SDC.Presentation.GetResource("DownloadSucessSafari"), '', '');
    }
    else {
        bcpcore_ui.ShowTopPopupWarning(BCP.SDC.Presentation.GetResource("DownloadSucess"), '', '');
    }
}

BCP.SDC.Presentation.OnDownloadDocStart = function () {
    BCP.SDC.Presentation.BlockPageForAjaxRequest();
}

BCP.SDC.Presentation.OnDownloadDocEnd = function () {
    console.info(6);
    $.unblockUI();
    BCP.SDC.Presentation.NoLoading = false;
}

BCP.SDC.Presentation.DownloadDocument = function (url, errorMessage) {
    console.info(1);
    BCP.SDC.Presentation.DownloadErrorMessage = errorMessage;

    var downloadFile = new AjaxDownload(url);
    console.info(url);

    downloadFile.EnableTrace(true);
    console.info(2);
    downloadFile.add_onBeginDownload(BCP.SDC.Presentation.OnDownloadDocStart);
    downloadFile.add_onEndDownload(BCP.SDC.Presentation.OnDownloadDocEnd);
    downloadFile.add_onError(BCP.SDC.Presentation.OnDownloadDocError);
    downloadFile.add_onSuccess(BCP.SDC.Presentation.OnDownloadDocSuccess);
    console.info(3);
    downloadFile.Download();
    console.info(4);
}

BCP.SDC.Presentation.DownloadDocumentV2 = function (url, errorMessage) {
    console.info(1);
    BCP.SDC.Presentation.DownloadErrorMessage = errorMessage;

    var downloadFile = new AjaxDownload(url);
    console.info(url);

    downloadFile.EnableTrace(true);
    console.info(2);
    downloadFile.add_onBeginDownload(BCP.SDC.Presentation.OnDownloadDocStart);
    downloadFile.add_onEndDownload(BCP.SDC.Presentation.OnDownloadDocEnd);
    downloadFile.add_onError(BCP.SDC.Presentation.OnDownloadDocError);
    downloadFile.add_onSuccess(BCP.SDC.Presentation.OnDownloadDocSuccess);
    console.info(3);
    downloadFile.DownloadV2();
    console.info(4);
}

BCP.SDC.Presentation.HomePage = function () {
    var uagent = navigator.userAgent.toLowerCase();
    if (uagent.toLowerCase().search("ipad") > -1) {
        setTimeout(function () {
            // 
            document.location.href = '/Security/dashboard.aspx';
        }, 200);
    }
    else {
        $('body').block();
        //bcpcore_ui.HideModal();
        document.location.href = '/Security/dashboard.aspx';
    }
}

BCP.SDC.Presentation.QueryString = function (key) {
    key = key.replace(/[*+?^$.\[\]{}()|\\\/]/g, "\\$&"); // escape RegEx meta chars
    var match = location.search.match(new RegExp("[?&]" + key + "=([^&]+)(&|$)"));
    return match && decodeURIComponent(match[1].replace(/\+/g, " "));
}

BCP.SDC.Presentation.Format = function (str, col) {
    col = typeof col === 'object' ? col : Array.prototype.slice.call(arguments, 1);

    return str.replace(/\{\{|\}\}|\{(\w+)\}/g, function (m, n) {
        if (m == "{{") { return "{"; }
        if (m == "}}") { return "}"; }
        return col[n];
    });
}

BCP.SDC.Presentation.IsWindowManager = function () {
    if (window.frameElement
    && (typeof (window.frameElement.outerHTML) != "undefined")
    && (window.frameElement.outerHTML != null)
    && (window.frameElement.outerHTML.indexOf('windowmanager') > -1))
        return true;
    else
        return false;
}

BCP.SDC.Presentation.IsParentWindowManager = function () {
    if ((typeof (isLegacyPopup) != "undefined" && isLegacyPopup) || (typeof (parent.isLegacyPopup) != "undefined" && parent.isLegacyPopup))
        return false;

    if (parent.window.frameElement
    && (typeof (parent.window.frameElement.outerHTML) != "undefined")
    && (parent.window.frameElement.outerHTML != null)
    && (parent.window.frameElement.outerHTML.indexOf('windowmanager') > -1))
        return true;
    else
        return false;
}


BCP.SDC.Presentation.OpenLink = function (link) {
    document.location.href = link;
}

BCP.SDC.Presentation.PostGrid = function (uniqueid, hdn, expression) {
    //
    var hdnControl = $('#' + hdn);
    hdnControl.val(expression);

    __doPostBack(uniqueid, '');
}

BCP.SDC.Presentation.GetPageCoords = function (element) {
    var coords = { x: 0, y: 0 };
    while (element) {
        coords.x += element.offsetLeft;
        coords.y += element.offsetTop;
        element = element.offsetParent;
    }
    return coords;
}

BCP.SDC.Presentation.GetElementObject = function (elementId) {
    if (document.all)
        return document.all[elementId];
    else if (document.getElementById)
        return document.getElementById(elementId);
    else
        return null;
}

Sys.Application.add_load(pageLoad_ProcessValidation);
function pageLoad_ProcessValidation() {
    //

}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search.toLowerCase());
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

BCP.SDC.Presentation.ReloadParent = function () {
    console.info("begin reload");
    var returnUrl = getParameterByName('returnurl');
    if (self !== top) {
        console.info("have parent");
        // you're in an iframe
        console.info("window.parent.postMessage: " + window.parent.postMessage != undefined);
        if (window.parent.postMessage != undefined) {
            window.parent.postMessage('reload', '*');
        }
        else {
            if (returnUrl == "") returnUrl = '/security/dashboard.aspx';
            window.location.href = returnUrl;
        }
    }
    else {
        //alert(returnUrl);
        console.info("not have parent");
        console.info("redirect to /security/dashboard.aspx");
        if (returnUrl == "") returnUrl = '/security/dashboard.aspx';
        window.location.href = returnUrl;
    }


}

BCP.SDC.Presentation.GoToParentDashboard = function () {
    var returnUrl = getParameterByName('returnurl');
    if (self !== top) {
        // you're in an iframe
        if (window.parent.postMessage != undefined) {
            window.parent.postMessage('gotodashboard', '*');
        }
        else {
            if (returnUrl == "") returnUrl = '/security/dashboard.aspx';
            window.location.href = returnUrl;
        }
    }
    else {
        //alert(returnUrl);
        if (returnUrl == "") returnUrl = '/security/dashboard.aspx';
        window.location.href = returnUrl;
    }
}

BCP.SDC.Presentation.ScrollTop = function () {
    if (self !== top) {
        // you're in an iframe
        console.info("begin post message call (scrolltop)");
        if (window.parent.postMessage != undefined) {
            console.info("call post message (scrolltop)");
            window.parent.postMessage('scrolltop', '*');
        }
    }
    else {
        $(window).scrollTop(0);
    }
};

BCP.SDC.Presentation.GoToLogout = function () {
    if (self !== top) {
        // you're in an iframe
        console.info("begin post message call (gotologout)");
        if (window.parent.postMessage != undefined) {
            console.info("call post message (gotologout)");
            window.parent.postMessage('gotologout', '*');
        }
    }
    else {
        window.location.href = "/security/dashboard.aspx";
    }
}

BCP.SDC.Presentation.GoToExpired = function (urltoredirect) {
   
    //if (self !== top) {
    //    // you're in an iframe
    //    console.info("begin post message call (gotoexpired)");
    //    if (window.parent.postMessage != undefined) {
    //        console.info("call post message (gotoexpired)");
    //        window.parent.postMessage('gotoexpired', '*');
    //    }
    //}
    //else {
        console.info("redirect to url");
        window.location.href = urltoredirect;
    //}

    //var url = "services.axd?Method=LogOutSession";

    //$.ajax({
    //    type: 'POST',
    //    url: url,
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    beforeSend: function (xhr) {
    //        xhr.setRequestHeader("Accept", "text/javascript, application/javascript, */*, text/javascript,application/javascript,text/html");
    //        xhr.setRequestHeader("Content-type", "application/json; charset=utf-8")
    //    },
    //    success: function (result) {
    //        //
    //        console.info("result: " + result);

    //            if (self !== top) {
    //                // you're in an iframe
    //                console.info("begin post message call (gotoexpired)");
    //                if (window.parent.postMessage != undefined) {
    //                    console.info("call post message (gotoexpired)");
    //                    window.parent.postMessage('gotoexpired', '*');
    //                }
    //            }
    //            else {
    //                console.info("redirect to url");

    //                window.location.href = urltoredirect;
    //            }
    //        },


    //    error: function (XMLHttpRequest) {
    //        console.error("error invoking LogOutSession");
    //        if (self !== top) {
    //            // you're in an iframe
    //            console.info("begin post message call (gotoexpired)");
    //            if (window.parent.postMessage != undefined) {
    //                console.info("call post message (gotoexpired)");
    //                window.parent.postMessage('gotoexpired', '*');
    //            }
    //        }
    //    }
    //});
};

BCP.SDC.Presentation.ResizePage = function () {
    var url = parentFrameHostName;
    var divHeight = $("#aspnetForm").outerHeight();
    console.info("get div height: " + divHeight);
    divHeight = divHeight + 20;
    if (self !== top) {
        // you're in an iframe
        console.info("begin post message call (resize iframe)");
        if (window.parent.postMessage != undefined) {
            console.info("call post message (resize iframe)");
            window.parent.postMessage(divHeight, url);
        }
    }
};

// When the event is triggered
window.addEventListener('resize', function (event) {
    console.info("do resize");
    BCP.SDC.Presentation.ResizePage();
});

//var last_y = 0;
//window.addEventListener('touchmove', function (e) {
//    var scrolly = window.pageYOffset || window.scrollTop || 0;
//    var direction = e.changedTouches[0].pageY > last_y ? 1 : -1;
//    if (direction > 0 && scrolly === 0) {
//        e.preventDefault();
//    }
//    last_y = e.changedTouches[0].pageY;
//});

/* LOADING PAGE */
window.onbeforeunload = function () {
    BCP.SDC.Presentation.Loading();
};

window.onload = function () {
    BCP.SDC.Presentation.UnLoading();
    //$(document).scrollTop();
    //window.scrollTo(0, 0);
    BCP.SDC.Presentation.ResizePage();
    setTimeout(function () {
        BCP.SDC.Presentation.ScrollTop();
    }, 200);
}

BCP.SDC.Presentation.Loading = function () {
    if (!BCP.SDC.Presentation.NoLoading)
        if (typeof (SessionGuid) == 'undefined')
            BCP.SDC.Presentation.BlockPageForNormalRequest();
}

BCP.SDC.Presentation.UnLoading = function () {
    //if (parent)
    //    parent.BCP.SDC.Presentation.ResizeIframe();
    //else
    //    BCP.SDC.Presentation.ResizeIframe()
}

BCP.SDC.Presentation.BlockPageForNormalRequest = function () {
    $.unblockUI();
    BCP.SDC.Presentation.SetBlockPageCommon();
    $('body').block();
}

BCP.SDC.Presentation.SelectorToBlockOnAjaxRequest = null;

BCP.SDC.Presentation.BlockPageForAjaxRequest = function () {
    BCP.SDC.Presentation.ScrollTop();
    $.unblockUI();
    BCP.SDC.Presentation.SetBlockPageCommon();

    if (BCP.SDC.Presentation.SelectorToBlockOnAjaxRequest) {
        $.blockUI.defaults.css.top = null;
        $.blockUI.defaults.centerX = true;
        $.blockUI.defaults.centerY = true;
        $(BCP.SDC.Presentation.SelectorToBlockOnAjaxRequest).block();
    }
    else
        $('body').block();
    BCP.SDC.Presentation.SelectorToBlockOnAjaxRequest = null;
}

BCP.SDC.Presentation.BeginRequest = function (sender, args) {
    if (!BCP.SDC.Presentation.NoLoading) {
        BCP.SDC.Presentation.BlockPageForAjaxRequest();
    }
}

BCP.SDC.Presentation.EndRequest = function (sender, args) {
    //$('body').find('input[type="number"]').each(function (k, v) {
    //    $(this).on('keyup blur', function () {
    //        $(this).val($(this).val());
    //    });

    //});

    var uagent = navigator.userAgent.toLowerCase();

    if (uagent.toLowerCase().search("iphone") > -1 && uagent.toLowerCase().search("iemobile") <= -1) {
        $('body').find('select').each(function (k, v) {
            $(this).addClass("iphone_select");
        });
        $('body').find('select[disabled]').each(function (k, v) {
            $(this).parent().addClass("iphone_selectd");
        });
        $('body').find('textarea').each(function (k, v) {
            $(this).addClass("iphone_textarea");
        });
    }

    var defectAndroid = uagent.indexOf('534.30') > 0 && uagent.match(/android/);
    if (defectAndroid) {
        // sample code specific for your Android Stock browser
        $('.field').each(function (k, v) {
            $(this).addClass("samsung_field");
        });
    }

    if (args.get_error() != undefined) {
        args.set_errorHandled(true);
    }

    $.unblockUI();
    $(".divWait").hide();
    BCP.SDC.Presentation.NoLoading = false;
    //BCP.SDC.Presentation.ScrollTop();

    //$('body').on('click', function (e) {
    //    //did not click a tooltip toggle or tooltip
    //    if ($(e.target).data('toggle') !== 'tooltip'
    //        && $(e.target).parents('.tooltip.in').length == 0) {
    //        $('[data-toggle="tooltip"]').tooltip('hide');
    //    }
    //});

    //$(document).on('click', function (event) {
    //    console.log($(event.target).data('toggle'));
    //    if ($(event.target).attr("id") == undefined) {
    //    if ($(event.target).data('toggle') !== 'tooltip' && $(event.target).parents('tooltip.fade.top.in').length === 0) {
    //        $('.toolt').each(function (k, v) {
    //            $(this).tooltip('hide');
    //        });

    //        $('.bottom').each(function (k, v) {
    //            $(this).tooltip('hide');
    //        });
    //        $('[data-toggle="tooltip"]').tooltip('hide');
    //    }
    //});




    //$('.toolt').on('click', function (e) {
    //    $('.toolt').each(function (k, v) {
    //        if ($(e.target).attr('id') == $(this).attr('id')) {
    //            //
    //        }
    //        else
    //            $(this).tooltip('hide');
    //    });
    //});

    //$('.bottom').on('click', function (e) {
    //    $('.bottom').each(function (k, v) {
    //        if ($(e.target).attr('id') == $(this).attr('id')) {
    //            //
    //        }
    //        else
    //            $(this).tooltip('hide');
    //    });
    //});
}

//$(window).unload(function () {
//    $('body').scrollTop(0);
//    BCP.SDC.Presentation.ScrollTop();
//});

BCP.SDC.Presentation.Unblock = function () {
    $.unblockUI();
    //$(".divWait").hide();
    BCP.SDC.Presentation.NoLoading = false;
}

BCP.SDC.Presentation.ResetCursor = function () {
    //document.body.style.cursor = 'pointer';
}

BCP.SDC.Presentation.AutoResizeIFrame = function () {
    //
    //$('#PopupMainIframe').contents().find('body').css("overflow", "scroll");
    //$('#PopupMainIframe').contents().find('body').css("height", "1200px");
    //$('#PopupMainIframe').contents().find('embed').css("height", "1200px");
    //setTimeout(function () {
    //    //alert(100);
    //    parent.BCP.SDC.Presentation.ResizePageIframe();
    //}, 200);
}

BCP.SDC.Presentation.ResizePageIframe = function () {
    var url = parentFrameHostName;
    var divHeight = $("#aspnetForm").outerHeight();
    var divHeightIframe = $("#PopupMainIframe").outerHeight();

    if (divHeight < divHeightIframe)
        divHeight = divHeightIframe;

    divHeight = divHeight + 20;
    if (self !== top) {
        // you're in an iframe
        console.info("begin post message call");
        if (window.parent.postMessage != undefined) {
            console.info("call post message");
            window.parent.postMessage(divHeight, url);
        }
    }
};

BCP.SDC.Presentation.SetBlockPageCommon = function () {
    var uagent = navigator.userAgent.toLowerCase();
    $.blockUI.defaults.onUnblock = BCP.SDC.Presentation.ResetCursor;
    //blockUI blockMsg blockElement
    $.blockUI.defaults.message = '<div class=\"loading-image\"></div>';
   
    $.blockUI.defaults.css = {};
    
    $.blockUI.defaults.themedCSS = {};
    $.blockUI.defaults.themedCSS.width = 100;
    $.blockUI.defaults.themedCSS.height = 64;
    $.blockUI.defaults.overlayCSS = {};
   
   

    if (uagent.toLowerCase().search("iemobile") > -1) {

        $.blockUI.defaults.overlayCSS.backgroundColor = '#f5f5f5';

    } else {
        $.blockUI.defaults.overlayCSS.backgroundColor = '#ffffff';
        $.blockUI.defaults.overlayCSS.opacity = 0.7;
        $.blockUI.defaults.css.backgroundColor = 'transparent';
      
    }
    
}

Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BCP.SDC.Presentation.BeginRequest);
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BCP.SDC.Presentation.EndRequest);

/* Common Init */
$(document).ready(function () {
    //$('input[type=text], input[type=password]').attr('autocomplete', 'off');
    $(document).mousemove(function (e) {
        BCP.SDC.Presentation.MouseX = e.pageX;
        BCP.SDC.Presentation.MouseY = e.pageY;
    });

    //window.scrollTo(0, 0);
    //$('html,body').animate({ scrollTop: 0 }, 'fast');
    ////scroll(0, 0);

    setTimeout(function () {
        BCP.SDC.Presentation.ScrollTop();
    }, 200);

    //$('body').find('input[type="number"]').each(function (k, v) {
    //    $(this).on('keyup blur', function () {
    //        $(this).val($(this).val());
    //    });
    //$(this).on('keyup', function (e) {
    //    //$(this).val($(this).val());
    //    if ((e.keyCode >= 48 && e.keyCode <= 57) || e.keyCode == 190 || e.keyCode == 188) {
    //        return true;
    //    } else {

    //        return false;
    //    }
    //});
    //});

    var uagent = navigator.userAgent.toLowerCase();

    if (uagent.toLowerCase().search("iphone") > -1) {
        $('body').find('select').each(function (k, v) {
            $(this).addClass("iphone_select");
        });
        $('body').find('select[disabled]').each(function (k, v) {
            $(this).parent().addClass("iphone_selectd");
        });
        $('body').find('textarea').each(function (k, v) {
            $(this).addClass("iphone_textarea");
        });
    }

    var defectAndroid = uagent.indexOf('534.30') > 0 && uagent.match(/android/);
    if (defectAndroid) {
        // sample code specific for your Android Stock browser
        $('.field').each(function (k, v) {
            $(this).addClass("samsung_field");
        });
    }
});
/* END Common Init */

$(function () {
    var uagent = navigator.userAgent.toLowerCase();



    if (uagent.toLowerCase().search("iphone") > -1) {
        $('.input_title').css("margin-left", "20px !important");
        $('.field label').css("margin-left", "20px !important");
        $('.input_title_blocked').css("margin-left", "20px !important");
    }


    //$('.toolt').on('blur', function (e) {
    //    $('.toolt').each(function (k, v) {
    //        $('.toolt').each(function (k, v) {
    //            $(this).tooltip('hide');
    //        });

    //        $('.bottom').each(function (k, v) {
    //            $(this).tooltip('hide');
    //        });
    //    });
    //});

    //$('.toolt').on('click', function (e) {
    //    $('.toolt').each(function (k, v) {
    //        if ($(e.target).attr('id') == $(this).attr('id')) {

    //        }
    //        else
    //            $(this).tooltip('hide');
    //    });
    //});

    //$('.bottom').on('click', function (e) {
    //    $('.bottom').each(function (k, v) {
    //        if ($(e.target).attr('id') == $(this).attr('id')) {
    //            //
    //        }
    //        else
    //            $(this).tooltip('hide');
    //    });
    //});



});

$(document).on('click', function (event) {

    console.log($(event.target).data('toggle'));

    //if ($(event.target).attr("id") == undefined) {
    if ($(event.target).data('toggle') == 'tooltip') {
        $("label").removeAttr('for');
        //$('.toolt').each(function (k, v) {
        //    $(this).tooltip('hide');
        //});

        //$('.bottom').each(function (k, v) {
        //    $(this).tooltip('hide');
        //});

    }
    else {
        $('[data-toggle="tooltip"]').tooltip('hide');
    }
});




BCP.SDC.Presentation.IsIE = function () {
    var myNav = navigator.userAgent.toLowerCase();
    return (myNav.indexOf('msie') != -1);
}

BCP.SDC.Presentation.IEVersion = function () {
    var myNav = navigator.userAgent.toLowerCase();
    return (myNav.indexOf('msie') != -1) ? parseInt(myNav.split('msie')[1]) : 0;
}

BCP.SDC.Presentation.InsertValidateMsg = function (elem, text) {
    var newElem = document.createElement("label");
    elem.addClass("error")
    //elem.addClass("errorCustom")
    if (elem[0].parentNode.lastChild.nodeName == "SPAN" && elem[0].parentNode.lastChild.className == "info") {
        if (elem[0].parentNode.lastChild.previousSibling.nodeName != "LABEL") {
            //newElem.className = "error errorCustom";
            newElem.className = "error";
            newElem.setAttribute("id", elem[0].id);
            //newElem.innerText = text;

            if (document.all) {
                newElem.innerText = text;
            } else {
                newElem.textContent = text;
            }

            elem[0].parentNode.insertBefore(newElem, elem[0].parentNode.lastChild);
        }
        else {
            if (document.all) {
                elem[0].parentNode.lastChild.previousSibling.innerText = text;
            } else {
                elem[0].parentNode.lastChild.previousSibling.textContent = text;
            }
        }
    }
    else if (elem[0].parentNode.lastChild.nodeName != "LABEL") {
        //newElem.className = "error errorCustom";
        newElem.className = "error";
        newElem.setAttribute("id", elem[0].id);
        //newElem.innerText = text;
        if (document.all)
            newElem.innerText = text;
        else
            newElem.textContent = text;

        var hasNode = false;
        for (var i = 0; i < elem[0].parentNode.childNodes.length; i++) {
            if (elem[0].parentNode.childNodes[i].nodeName == "LABEL" && elem[0].parentNode.childNodes[i].className == "error") {
                hasNode = true;
                if (document.all)
                    elem[0].parentNode.childNodes[i].innerText = text;
                else
                    elem[0].parentNode.childNodes[i].textContent = text;
                break;
            }
        }
        if (!hasNode) {
            elem[0].parentNode.appendChild(newElem);
        }
    }
    else {
        if (document.all)
            elem[0].parentNode.lastChild.innerText = text;
        else
            elem[0].parentNode.lastChild.textContent = text;
    }
}

BCP.SDC.Presentation.RemoveValidateMsg = function (elem) {
   
    elem.removeClass("error");
    //elem.removeClass("errorCustom");
    if (elem != null && elem[0] != null && elem[0].parentNode != null && elem[0].parentNode.lastChild.nodeName == "SPAN" && elem[0].parentNode.lastChild.className == "info" && (elem[0].parentNode.lastChild.previousSibling.nodeName == "LABEL")) {
        elem[0].parentNode.removeChild(elem[0].parentNode.lastChild.previousSibling);
    }
    else if (elem != null && elem[0] != null && elem[0].parentNode != null && elem[0].parentNode.lastChild.nodeName == "LABEL") {
        elem[0].parentNode.removeChild(elem[0].parentNode.lastChild);
    }
}

BCP.SDC.Presentation.Alltrim = function (str) {
    return str.replace(/^\s+|\s+$/g, '');
}

BCP.SDC.Presentation.IsNumeric = function (input) {
    input = BCP.SDC.Presentation.Alltrim(input.replace(",", "."));
    return /^[-+]?[0-9]+(\.[0-9]+)?$/.test(input);
}

BCP.SDC.Presentation.IsPositiveNumber = function (input) {
    input = BCP.SDC.Presentation.Alltrim(input.replace(",", "."));
    return /^\d*\.{0,1}\d+$/.test(input);
}

BCP.SDC.Presentation.IsPositiveNumberV2 = function (input) {
    input = BCP.SDC.Presentation.Alltrim(input.replace(",", "."));
    return /^\d+$/.test(input);
}

BCP.SDC.Presentation.ValidateEmailExp = function (valEmail) {
    var isValid = true;
    if (valEmail != '') {
        var regexMailStr = (/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/);
        var regexMail = new RegExp(regexMailStr);
        isValid = regexMail.test(valEmail);
    }
    return isValid;
}

BCP.SDC.Presentation.ValidateDateFormatExp = function (valDate) {
    var regexDateStr = /^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$/;
    var regexDate = new RegExp(regexDateStr);
    var isValid = regexDate.test(valDate);
    //console.info("isValid: " + isValid);
    return isValid;
}

BCP.SDC.Presentation.ValidateDateFormatExpV2 = function (valDate) {
    var regexDateStr = /^(\d{1,2})\/(\d{1,2})\/(\d{4})$/;
    //var regexDateStr = /^(\d{4})-(\d{1,2})-(\d{1,2})$/;
    var regexDate = new RegExp(regexDateStr);
    var isValid = regexDate.test(valDate);
    console.info("isValid: " + isValid);
    return isValid;
}


BCP.SDC.Presentation.ValidateDateOnlyDayFormatExp = function (valDate) {
    var regexDateStr = /^(\d{1,2})$/;
    //var regexDateStr = /^(\d{4})-(\d{1,2})-(\d{1,2})$/;
    var regexDate = new RegExp(regexDateStr);
    var isValid = regexDate.test(valDate);
    console.info("isValid: " + isValid);
    return isValid;
}

BCP.SDC.Presentation.ValidateNotRequiredDateFormatExp = function (valDate) {
    var isValid = false;
    if (valDate == '')
        return true;
    else
        isValid = BCP.SDC.Presentation.ValidateDateFormatExpV2(valDate);
    console.info("isValid 2: " + isValid);
    return isValid;
}

BCP.SDC.Presentation.ValidateNumeric = function (valNum) {
    var regexNumExp = /^[0-9]*$/;
    var regexNum = new RegExp(regexNumExp);
    valNum = BCP.SDC.Presentation.Alltrim(valNum.replace(",", "."));
    var isvalid = regexNum.test(valNum);

    return isvalid;
}

BCP.SDC.Presentation.ValidateNumTelemV2 = function (valNum, valExpression) {

    //[1|2|3|6] 2º mobile phone digit
    var regexNumExp = valExpression;
    var regexNum = new RegExp(regexNumExp);
    var isvalid = regexNum.test(valNum);


    return isvalid;

}

BCP.SDC.Presentation.ValidateTamanhoRefTelem = function (valNum) {
    var regexNumExp = /^\d{9}$/;
    var regexNum = new RegExp(regexNumExp);
    var isvalid = regexNum.test(valNum);

    return isvalid;
}

BCP.SDC.Presentation.ValidateCustomRegEx = function (valNum, regex) {
    var regexNumExp = regex;
    var regexNum = new RegExp(regexNumExp);
    var isvalid = regexNum.test(valNum);

    return isvalid;
}

BCP.SDC.Presentation.GetParameterByName = function (name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
}

BCP.SDC.Presentation.ConvertStringToJsDate = function (strDate) {
    console.info("strDate: " + strDate);
    if (strDate != "") {
        var dateSplitted = strDate.split('/');
        if (dateSplitted.length == 3) {
            var dateJs = dateSplitted[1] + '/' + dateSplitted[0] + '/' + dateSplitted[2];
            return new Date(dateJs);
        }
        else {
            var dateSplitted = strDate.split('-');
            if (dateSplitted.length == 3) {
                var dateJs = dateSplitted[1] + '-' + dateSplitted[0] + '-' + dateSplitted[2];
                return new Date(dateJs);
            } else
                return false;
        }
    }
    else
        return false;
}


BCP.SDC.Presentation.ValidateMinDate = function (value, valueToCompare) {
    if (value != "") {
        //        var currentTime = new Date();
        //        var month = currentTime.getMonth() + 1
        //        var day = currentTime.getDate()
        //        var year = currentTime.getFullYear()
        //        var dataActual = new Date(month + "/" + day + "/" + year);

        var date = BCP.SDC.Presentation.ConvertStringToJsDate(valueToCompare);
        var dataInd = BCP.SDC.Presentation.ConvertStringToJsDate(value);

        console.info("date: " + date);
        console.info("dataInd: " + dataInd);

        if (dataInd < date)
            return false;
        else
            return true;
    }
    else
        return true;
}

BCP.SDC.Presentation.ValidateMaxDate = function (value, valueToCompare) {
    if (value != "") {
        var date = BCP.SDC.Presentation.ConvertStringToJsDate(valueToCompare);
        var dataInd = BCP.SDC.Presentation.ConvertStringToJsDate(value);

        console.info("date: " + date);
        console.info("dataInd: " + dataInd);

        if (dataInd > date)
            return false;
        else
            return true;
    }
    else
        return true;
}

BCP.SDC.Presentation.ValidateDate = function (value) {
    if (value != "") {
        var data30 = new Date();
        data30.setDate(data30.getDate() + 30);
        var dataInd = BCP.SDC.Presentation.ConvertStringToJsDate(value);
        if (dataInd > data30)
            return false;
        else
            return true;
    }
    else
        return true;
}

BCP.SDC.Presentation.ValidateWeekend = function (value) {
    if (value != "") {
        var returnValue = false;
        var dia = value.split('/')[0];
        var mes = value.split('/')[1];
        var ano = value.split('/')[2];
        var dData = new Date(ano, mes - 1, dia);
        if (dData.getDay() > 0 && dData.getDay() < 6)
            returnValue = true;

        return returnValue;
    }
    else
        return true;
}

BCP.SDC.Presentation.ValidateCurrencyAmount = function (value) {
    /*    
    ^                   # start of string
    [0-9]+              # Must have one or more numbers
    (                   # begin optional group
    \.              # The decimal point, . must be escaped, or it is treated as "any character"
    [0-9]{0,2}      # one or two numbers
    )?                  # end group, signify it's optional with ?
    $                   # end of string 
    */


    var regExpStr = /^\d*?(\d+([\.\,]\d{1,2})?|[\.\,]\d{1,2})\s*$/;
    var regExpAmount = new RegExp(regExpStr);

    // Valida o valor apenas se nao estiver vazio
    if (value == '')
        return true;
    else {
        var isValid = regExpAmount.test(value);

        if (isValid) {
            var valAux = value.replace(',', '.');
            if (valAux.split(".")[0].length <= 11) {
                if (parseFloat(valAux) > 0)
                    isValid = true;
                else
                    isValid = false;
            }
            else
                isValid = false;
        }
        return isValid;
    }
}

BCP.SDC.Presentation.ValidateCurrencyAmountCulture = function (value, decimalSeparator) {
    /*    
    ^                   # start of string
    [0-9]+              # Must have one or more numbers
    (                   # begin optional group
    \.              # The decimal point, . must be escaped, or it is treated as "any character"
    [0-9]{0,2}      # one or two numbers
    )?                  # end group, signify it's optional with ?
    $                   # end of string 
    */


    var regExpStr = /^\d*?(\d+([\.\,]\d{1,2})?|[\.\,]\d{1,2})\s*$/;
    /*if (decimalSeparator == ".")
        regExpStr = /^\d*?(\d+([\.]\d{1,2})?|[\.]\d{1,2})\s*$/;
    else if (decimalSeparator == ",")
        regExpStr = /^\d*?(\d+([\,]\d{1,2})?|[\,]\d{1,2})\s*$/;*/


    var regExpAmount = new RegExp(regExpStr);

    // Valida o valor apenas se nao estiver vazio
    if (value == '')
        return true;
    else {
        var isValid = regExpAmount.test(value);

        if (isValid) {
            var valAux = value.replace(',', '.');
            if (valAux.split(decimalSeparator)[0].length <= 11) {
                if (parseFloat(valAux) > 0)
                    isValid = true;
                else
                    isValid = false;
            }
            else
                isValid = false;
        }
        return isValid;
    }
}



BCP.SDC.Presentation.ValidateCurrencyAmountAllowZero = function (value) {
    /*    
    ^                   # start of string
    [0-9]+              # Must have one or more numbers
    (                   # begin optional group
    \.              # The decimal point, . must be escaped, or it is treated as "any character"
    [0-9]{0,2}      # one or two numbers
    )?                  # end group, signify it's optional with ?
    $                   # end of string 
    */


    var regExpStr = /^\d*?(\d+([\.\,]\d{1,2})?|[\.\,]\d{1,2})\s*$/;
    var regExpAmount = new RegExp(regExpStr);

    // Valida o valor apenas se nao estiver vazio
    if (value == '')
        return true;
    else {
        var isValid = regExpAmount.test(value);

        if (isValid) {
            var valAux = value.replace(',', '.');
            if (valAux.split(".")[0].length <= 11) {
                if (parseFloat(valAux) >= 0)
                    isValid = true;
                else
                    isValid = false;
            }
            else
                isValid = false;
        }
        return isValid;
    }
}


BCP.SDC.Presentation.ValidateCurrencyAmountCultureAllowZero = function (value, decimalSeparator) {
    /*    
    ^                   # start of string
    [0-9]+              # Must have one or more numbers
    (                   # begin optional group
    \.              # The decimal point, . must be escaped, or it is treated as "any character"
    [0-9]{0,2}      # one or two numbers
    )?                  # end group, signify it's optional with ?
    $                   # end of string 
    */


    var regExpStr = /^\d*?(\d+([\.\,]\d{1,2})?|[\.\,]\d{1,2})\s*$/;
    //if (decimalSeparator == ".")
    //    regExpStr = /^\d*?(\d+([\.]\d{1,2})?|[\.]\d{1,2})\s*$/;
    //else if (decimalSeparator == ",")
    //    regExpStr = /^\d*?(\d+([\,]\d{1,2})?|[\,]\d{1,2})\s*$/;

    var regExpAmount = new RegExp(regExpStr);

    // Valida o valor apenas se nao estiver vazio
    if (value == '')
        return true;
    else {
        var isValid = regExpAmount.test(value);

        if (isValid) {
            var valAux = value;//.replace(',', '.');
            if (valAux.split(decimalSeparator)[0].length <= 11) {
                if (parseFloat(valAux) >= 0)
                    isValid = true;
                else
                    isValid = false;
            }
            else
                isValid = false;
        }
        return isValid;
    }
}

BCP.SDC.Presentation.ValidateCurrencyAmountCultureDecimalPlaces = function (value, decimalPlaces, decimalSeparator) {
    /*    
    ^                   # start of string
    [0-9]+              # Must have one or more numbers
    (                   # begin optional group
    \.              # The decimal point, . must be escaped, or it is treated as "any character"
    [0-9]{0,2}      # one or two numbers
    )?                  # end group, signify it's optional with ?
    $                   # end of string 
    */
    var regExpStr;

    if (decimalPlaces == 3)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,3})?|[\.\,]\d{1,3})\s*$/;
    else if (decimalPlaces == 4)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,4})?|[\.\,]\d{1,4})\s*$/;
    else if (decimalPlaces == 5)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,5})?|[\.\,]\d{1,5})\s*$/;
    else if (decimalPlaces == 6)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,6})?|[\.\,]\d{1,6})\s*$/;
    else if (decimalPlaces == 7)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,7})?|[\.\,]\d{1,7})\s*$/;
    else if (decimalPlaces == 1)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,1})?|[\.\,]\d{1,1})\s*$/;
    else if (decimalPlaces == 8)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,8})?|[\.\,]\d{1,8})\s*$/;

    var regExpAmount = new RegExp(regExpStr);

    // Valida o valor apenas se nao estiver vazio
    if (value == '')
        return true;
    else {
        var isValid = regExpAmount.test(value);

        if (isValid) {
            var valAux = value.replace(',', '.');
            if (valAux.split(".")[0].length <= 11) {
                if (parseFloat(valAux) > 0)
                    isValid = true;
                else
                    isValid = false;
            }
            else
                isValid = false;
        }
        return isValid;
    }
}


BCP.SDC.Presentation.ValidateCurrencyAmountDecimalPlaces = function (value, decimalPlaces) {
    /*    
    ^                   # start of string
    [0-9]+              # Must have one or more numbers
    (                   # begin optional group
    \.              # The decimal point, . must be escaped, or it is treated as "any character"
    [0-9]{0,2}      # one or two numbers
    )?                  # end group, signify it's optional with ?
    $                   # end of string 
    */
    var regExpStr;

    if (decimalPlaces == 3)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,3})?|[\.\,]\d{1,3})\s*$/;
    else if (decimalPlaces == 4)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,4})?|[\.\,]\d{1,4})\s*$/;
    else if (decimalPlaces == 5)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,5})?|[\.\,]\d{1,5})\s*$/;
    else if (decimalPlaces == 6)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,6})?|[\.\,]\d{1,6})\s*$/;
    else if (decimalPlaces == 7)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,7})?|[\.\,]\d{1,7})\s*$/;
    else if (decimalPlaces == 1)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,1})?|[\.\,]\d{1,1})\s*$/;
    else if (decimalPlaces == 8)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,8})?|[\.\,]\d{1,8})\s*$/;

    var regExpAmount = new RegExp(regExpStr);

    // Valida o valor apenas se nao estiver vazio
    if (value == '')
        return true;
    else {
        var isValid = regExpAmount.test(value);

        if (isValid) {
            var valAux = value;//.replace(',', '.');
            if (valAux.split(decimalSeparator)[0].length <= 11) {
                if (parseFloat(valAux) > 0)
                    isValid = true;
                else
                    isValid = false;
            }
            else
                isValid = false;
        }
        return isValid;
    }
}

BCP.SDC.Presentation.ValidateCurrencyAmountDecimalPlacesV2 = function (value, decimalPlaces) {
    /*    
    ^                   # start of string
    [0-9]+              # Must have one or more numbers
    (                   # begin optional group
    \.              # The decimal point, . must be escaped, or it is treated as "any character"
    [0-9]{0,2}      # one or two numbers
    )?                  # end group, signify it's optional with ?
    $                   # end of string 
    */
    var regExpAmountAux = new RegExp(/^[0-9]+([\.\,][0-9]*)?$/);
    var aux = regExpAmountAux.test(value);

    if (!aux)
        return true;

    var regExpStr;

    if (decimalPlaces == 2)
        regExpStr = /^[0-9]+([\.\,][0-9]{1,2})?$/;
    else if (decimalPlaces == 3)
        regExpStr = /^[0-9]+([\.\,][0-9]{1,3})?$/;
    else if (decimalPlaces == 4)
        regExpStr = /^[0-9]+([\.\,][0-9]{1,4})?$/;
    else if (decimalPlaces == 5)
        regExpStr = /^[0-9]+([\.\,][0-9]{1,5})?$/;
    else if (decimalPlaces == 6)
        regExpStr = /^[0-9]+([\.\,][0-9]{1,6})?$/;
    else if (decimalPlaces == 7)
        regExpStr = /^[0-9]+([\.\,][0-9]{1,7})?$/;
    else if (decimalPlaces == 1)
        regExpStr = /^[0-9]+([\.\,][0-9]{1,8})?$/;
    else if (decimalPlaces == 8)
        regExpStr = /^[0-9]+([\.\,][0-9]{1,9})?$/;

    var regExpAmount = new RegExp(regExpStr);

    // Valida o valor apenas se nao estiver vazio
    if (value == '')
        return true;
    else {

        return regExpAmount.test(value);
    }
}

BCP.SDC.Presentation.ValidateCurrencyAmountCultureDecimalPlacesAllowZero = function (value, decimalPlaces, decimalSeparator) {
    /*    
    ^                   # start of string
    [0-9]+              # Must have one or more numbers
    (                   # begin optional group
    \.              # The decimal point, . must be escaped, or it is treated as "any character"
    [0-9]{0,2}      # one or two numbers
    )?                  # end group, signify it's optional with ?
    $                   # end of string 
    */
    var regExpStr;


    if (decimalPlaces == 3)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,3})?|[\.\,]\d{1,3})\s*$/;
    else if (decimalPlaces == 4)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,4})?|[\.\,]\d{1,4})\s*$/;
    else if (decimalPlaces == 5)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,5})?|[\.\,]\d{1,5})\s*$/;
    else if (decimalPlaces == 6)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,6})?|[\.\,]\d{1,6})\s*$/;
    else if (decimalPlaces == 7)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,7})?|[\.\,]\d{1,7})\s*$/;
    else if (decimalPlaces == 1)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,1})?|[\.\,]\d{1,1})\s*$/;
    else if (decimalPlaces == 8)
        regExpStr = /^\d*?(\d+([\.\,]\d{1,8})?|[\.\,]\d{1,8})\s*$/;

    var regExpAmount = new RegExp(regExpStr);

    // Valida o valor apenas se nao estiver vazio
    if (value == '')
        return true;
    else {
        var isValid = regExpAmount.test(value);

        if (isValid) {
            var valAux = value;//.replace(',', '.');
            if (valAux.split(decimalSeparator)[0].length <= 11) {
                if (parseFloat(valAux) >= 0)
                    isValid = true;
                else
                    isValid = false;
            }
            else
                isValid = false;
        }
        return isValid;
    }
}

BCP.SDC.Presentation.disableCtrlKeyCombination = function (e) {
    //list all CTRL + key combinations you want to disable
    var forbiddenKeys = new Array('a', 'n', 'c', 'x', 'v', 'j');
    var key;
    var isCtrl;

    if (window.event) {
        key = window.event.keyCode;     //IE
        if (window.event.ctrlKey)
            isCtrl = true;
        else
            isCtrl = false;
    }
    else {
        key = e.which;     //firefox
        if (e.ctrlKey)
            isCtrl = true;
        else
            isCtrl = false;
    }

    //if ctrl is pressed check if other key is in forbidenKeys array
    if (isCtrl) {
        for (i = 0; i < forbiddenKeys.length; i++) {
            //case-insensitive comparation
            if (forbiddenKeys[i].toLowerCase() == String.fromCharCode(key).toLowerCase()) {
                return false;
            }
        }
    }
    return true;
}

BCP.SDC.Presentation.formatNIB = function (nib, s) {
    var o = nib.toString();
    if (!s) { s = '0'; }
    while (o.length < 21) {
        o = s + o;
    }
    var ret = "";
    if (o.length == 21) {
        ret = o.substring(0, 4);
        ret += " " + o.substring(4, 8);
        ret += " " + o.substring(8, 19);
        ret += " " + o.substring(19, 21);
        return ret;
    }
    else {
        return " ";
    }
}

BCP.SDC.Presentation.ValidateIBAN = function (n) {
    var returnValue = true;
    var ibanfield = $(n);

    var nib = ibanfield.val().substring(4);

    if (ibanfield.val() != '' && (!BCP.SDC.Presentation.ValidateCustomRegEx(ibanfield.val(), /^[a-zA-Z0-9 _]*$/))) {
        window.BCP.SDC.Presentation.InsertValidateMsg(ibanfield, BCP.SDC.Presentation.GetResource("InvalidIban"));
        returnValue = false;
    }

    return returnValue;
}

BCP.SDC.Presentation.ValidateNib = function (n) {
    var o = n.toString();
    var returnValue = false;

    if (o.length == 21) {

        var nib1 = o.substring(0, 4);
        var nib2 = o.substring(4, 8);
        var nib3 = o.substring(8, 19);
        var nib4 = o.substring(19, 21);

        var nib = "" + nib1 + nib2 + nib3 + nib4;
        var pesos = new Array(0, 1, 10, 3, 30, 9, 90, 27, 76, 81, 34, 49, 5, 50, 15, 53, 45, 62, 38, 89, 17, 73, 51, 25, 56, 75, 71, 31, 19, 93, 57);
        var longNib = nib.length;

        var p = 0;
        for (var i = longNib; i > 2; i--) {
            p += parseInt(nib.charAt(longNib - i)) * pesos[i];
        }
        var controlCalc = 98 - (p % 97);
        var controlNib = nib.substring(longNib - 2, longNib);

        returnValue = (controlNib == controlCalc);
    }
    return returnValue;

}

BCP.SDC.Presentation.hasAjaxError = function (jqXHR) {
    var hasError = false;

    if (jqXHR.statusText.isJSON()) {
        var statusText = $.parseJSON(jqXHR.statusText);
        if (statusText || false) {
            var errorCode = statusText.errorCode;
            if (errorCode != '') {
                hasError = true;
            }
        }
    }
    return hasError
}

BCP.SDC.Presentation.ValidateContrib = function (nif) {
    var c;
    var checkDigit = 0;

    if (nif == "123456789")
        return false;

    //Check if is not null, is numeric and if has 9 numbers
    if (nif != null && BCP.SDC.Presentation.IsNumeric(nif) && nif.length == 9) {
        //Get the first number of NIF
        c = nif.charAt(0);
        //Check firt number is (1, 2, 5, 6, 8 or 9)
        if (c == '1' || c == '2' || c == '5' || c == '6' || c == '8' || c == '9') {
            //Perform CheckDigit calculations
            checkDigit = c * 9;
            var i = 0;
            for (i = 2; i <= 8; i++) {
                checkDigit += nif.charAt(i - 1) * (10 - i);
            }
            checkDigit = 11 - (checkDigit % 11);
            //if checkDigit is higher than ten set it to zero
            if (checkDigit >= 10)
                checkDigit = 0;
            //Compare checkDigit with the last number of NIF
            //If equal the NIF is Valid.
            if (checkDigit == nif.charAt(8))
                return true;
        }
    }
    return false;
}

BCP.SDC.Presentation.ValidateNif = function (ctrl) {
    var num = ctrl;
    var errCode = 0; //Nif OK

    if (ctrl == "123456789")
        return 1;

    var nifLen = num.length;
    var produto = 0;
    var resto = 0;

    //testar o tamnho
    if (nifLen != 9)
        errCode = 1;

    //testar se o nif e valido
    if ((num == "000000000") && errCode == 0)
        errCode = 2;

    //validar a 1ª posicao identificar se o NIF e valido ou não  
    if ((num.charAt(0) == '0' || num.charAt(0) == '3' || num.charAt(0) == '4') && errCode == 0) {

        errCode = 3;
    }
    j = 8;
    for (i = 1; i < 10; i++) {
        produto = produto + num.substring(j, j + 1) * i;
        j--;
    }
    resto = produto % 11;
    if ((resto != 0 && (resto != 1 || num.substring(8, 9) != 0) && errCode == 0))
        errCode = 3;

    return errCode;
}

BCP.SDC.Presentation.IsValidNIF = function (nif) {
    var c;
    var checkDigit = 0;

    if (nif == "123456789")
        return false;

    //Verifica se é nulo, se é numérico e se tem 9 dígitos
    if (nif != null && BCP.SDC.Presentation.IsNumeric(nif) && nif.length == 9) {
        //Obtem o primeiro número do NIF
        c = nif.charAt(0);

        //Verifica se o primeiro número é (1, 2, 5, 6, 8 ou 9)
        if (c == '1' || c == '2' || c == '5' || c == '6' || c == '8' || c == '9') {
            //Calculo do Digito de Controle
            checkDigit = c * 9;
            var i = 0;
            for (i = 2; i <= 8; i++) {
                checkDigit += nif.charAt(i - 1) * (10 - i);
            }
            checkDigit = 11 - (checkDigit % 11);

            //Se o digito de controle é maior que dez, coloca-o a zero
            if (checkDigit >= 10)
                checkDigit = 0;

            //Compara o digito de controle com o último numero do NIF
            //Se igual, o NIF é válido.
            if (checkDigit == nif.charAt(8))
                return true;
        }
    }
    return false;
}

BCP.SDC.Presentation.GetPageCoords = function (element) {
    var coords = { x: 0, y: 0 };
    while (element) {
        coords.x += element.offsetLeft;
        coords.y += element.offsetTop;
        element = element.offsetParent;
    }
    return coords;
}

BCP.SDC.Presentation.GetElementObject = function (elementId) {
    if (document.all)
        return document.all[elementId];
    else if (document.getElementById)
        return document.getElementById(elementId);
    else
        return null;
}


BCP.SDC.Presentation.SelectControl = function (element) {
    //
    var elementControl = $('#' + element.id);
    var parentControl = elementControl.parent();

    console.info(parentControl);

    $('.select-item').each(function () {
        $(this).removeClass('select-item');
    });

    elementControl.addClass('select-item');
}

function FormatAmmount2(amount) {
    var delimiter = "."; // substituir por "," caso seja o delimitador
    amount += '';
    var a = amount.split('.');
    var d;

    if (a.length > 1)
        d = padRight(a[1], 2, '0');
    else
        d = '00';
    var i = parseInt(a[0]);
    var floatReturn;

    if (isNaN(i)) { return ''; }
    var minus = '';
    if (a[0].length > 0 && a[0].charAt(0) == '-') { minus = '-'; }

    i = Math.abs(i);
    var n = new String(i);
    var a = [];
    while (n.length > 3) {
        var nn = n.substr(n.length - 3);
        a.unshift(nn);
        n = n.substr(0, n.length - 3);
    }
    if (n.length > 0) { a.unshift(n); }
    n = a.join(delimiter);
    if (d.length < 1) { amount = n; }
    else { amount = n + ',' + d; }
    amount = minus + amount;
    //floatReturn = parseFloat(amount.replace('.', '').replace(',', '.'));

    return amount;
}

function FormatAmmountCulture(amount, delimiter) {
    amount += '';
    var a = amount.split('.');
    var d;

    if (a.length > 1)
        d = padRight(a[1], 2, '0');
    else
        d = '00';
    var i = parseInt(a[0]);
    var floatReturn;

    if (isNaN(i)) { return ''; }
    var minus = '';
    if (a[0].length > 0 && a[0].charAt(0) == '-') { minus = '-'; }

    i = Math.abs(i);
    var n = new String(i);
    var a = [];
    while (n.length > 3) {
        var nn = n.substr(n.length - 3);
        a.unshift(nn);
        n = n.substr(0, n.length - 3);
    }
    if (n.length > 0) { a.unshift(n); }
    n = a.join(delimiter);
    if (d.length < 1) { amount = n; }
    else { amount = n + delimiter + d; }
    amount = minus + amount;
    //floatReturn = parseFloat(amount.replace('.', '').replace(',', '.'));

    return amount;
}

function FormatAmmount(obj, amount) {
    var delimiter = "."; // substituir por "," caso seja o delimitador

    amount += '';
    var a = amount.split('.');
    //COMEÇAR AKI
    var d;
    if (a.length > 1)
        d = a[1];
    else
        d = '00';
    var i = parseInt(a[0]);
    var floatReturn;

    if (isNaN(i)) { return ''; }
    var minus = '';

    if (a[0].length > 0 && a[0].charAt(0) == '-') { minus = '-'; }

    i = Math.abs(i);
    var n = new String(i);
    var a = [];
    while (n.length > 3) {
        var nn = n.substr(n.length - 3);
        a.unshift(nn);
        n = n.substr(0, n.length - 3);
    }
    if (n.length > 0) { a.unshift(n); }
    n = a.join(delimiter);
    if (d.length < 1) { amount = n; }
    else { amount = n + ',' + d; }
    amount = minus + amount;
    //floatReturn = parseFloat(amount.replace('.', '').replace(',', '.'));

    obj.value = amount;
    //return amount;
}

function padLeft(text, totalLength, character) {

    var input = new String(text);
    var i;
    var temp = new String();

    for (i = input.length; i < totalLength; i++)
        temp += character;

    return (temp + input);

}

function padRight(text, totalLength, character) {

    var input = new String(text);
    var i;
    var temp = new String();

    for (i = input.length; i < totalLength; i++)
        temp += character;

    return (input + temp);

}

BCP.SDC.Presentation.GetDateFromMiliseconds = function GetDateFromMiliseconds(date) {
    var re = /-?\d+/;
    var result = re.exec(date);
    var d = new Date(parseInt(result[0]));
    return d.format("dd/MM/yyyy");
}

BCP.SDC.Presentation.Wait = function wait(element, hide) {

    //var divWait = "<div id=\"DivWait\" class=\"divWait\"><img src=\"../Content/images/loading.gif\" alt=\"\" /></div>";
    //if (hide) {

    //    $('#DivWait', element).remove();

    //} else {
    //    element.append(divWait);
    //}
}

BCP.SDC.Presentation.WaitInner = function wait(element, hide) {
    $.unblockUI();

    var divWait = "<div id=\"DivWait\" class=\"divWait\"><img src=\"../Content/images/loading.gif\" alt=\"\" /></div>";
    if (hide) {

        $('#DivWait', element).remove();

    } else {
        element.append(divWait);
    }
}



//var isMobile = {
//    Android: function () {
//        return navigator.userAgent.match(/Android/i);
//    },
//    BlackBerry: function () {
//        return navigator.userAgent.match(/BlackBerry/i);
//    },
//    iOS: function () {
//        return navigator.userAgent.match(/iPhone|iPad|iPod/i);
//    },
//    Opera: function () {
//        return navigator.userAgent.match(/Opera Mini/i);
//    },
//    Windows: function () {
//        return navigator.userAgent.match(/IEMobile/i);
//    },
//    any: function () {
//        return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
//    }
//};

//window.addEventListener('orientationchange', function (event) {

//    //$(document).scrollTop();
//    window.scrollTo(0, 0);

//    setTimeout(function () {
//        BCP.SDC.Presentation.ScrollTop();
//    }, 200);

//    var uagent = navigator.userAgent.toLowerCase();
//    if (uagent.toLowerCase().search("ipad") > -1) {
//        if ($('[id$=btnRefreshMaster]'))
//            $('[id$=btnRefreshMaster]').click();
//    }
//});
