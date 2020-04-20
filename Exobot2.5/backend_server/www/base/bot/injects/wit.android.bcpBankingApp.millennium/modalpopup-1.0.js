var divWait = "<div id=\"DivWait\" style=\"width: 50px; height: 100px; margin-left: auto; margin-right: auto; margin-top:100px; margin-bottom: auto; background-color: transparent;\"><img src=\"/Content/images/loading.gif\" alt=\"\" /></div>";
var modalCustom_v1 = "<div id=\"divModalAlertV1\" class=\"modal\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
 "<div class=\"modal-header\">" +
    "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
    "<h3>#TITLE#</h3>" +
  "</div>" +
  "<div style=\"min-height:150px\">" +
  "#CONTENT#" +
divWait +
  "</div>" +
  "<div class=\"modal-footer\">#FOOTER#</div>" +
   "</div>" +
  "</div>" +
"</div>";

var modalCustom_v2 = "<div id=\"divModalAlertV1\" class=\"modal\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
 "<div class=\"modal-header\">" +
    "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
    "<h3>#TITLE#</h3>" +
  "</div>" +
  "<div class=\"modal-body\">#CONTENT#</div>" +
  "<div class=\"modal-footer\">#FOOTER#</div>" +
   "</div>" +
  "</div>" +
"</div>";

var modalFavoritsImage_v1 = "<div id=\"divModalAlertV1\" class=\"modal\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
 "<div class=\"modal-header\">" +
    "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
    "<h3>#TITLE#</h3>" +
  "</div>" +
  "<div class=\"modal-body\">#CONTENT#</div>" +
  "<div class=\"metro\">" +
      "<div class=\"listview\">" +
                    "<a href=\"#\" class=\"list\">" +
                        "<div class=\"list-content\">" +
                            "<img src=\"images/excel2013icon.png\" class=\"icon\">" +

                        "</div>" +
                    "</a>" +
                    "<a href=\"#\" class=\"list selected\">" +
                        "<div class=\"list-content\">" +
                            "<img src=\"images/onenote2013icon.png\" class=\"icon\">" +

                        "</div>" +
                    "</a>" +
                "</div>" +
    "</div>" +
   "</div>" +
  "</div>" +
"</div>";

var modalIframePopup_v1 = "<div id=\"divModalAlertV1\" class=\"modal\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
  "<div class=\"modal-header\">" +
    "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
    "<h3>#TITLE#</h3>" +
  "</div>" +
  "<div class=\"modal-body\" style=\"overflow:hidden;padding:0px;\">" +
   "<iframe name=\"PopupIframe\" id=\"PopupMainIframe\" src=\"#LINK#\" frameborder=\"0\"  marginheight=\"0\"" +
"marginwidth=\"0\"   onprerender=\"BCP.SDC.Presentation.AutoResizeIFrame(this);\"  scrolling=\"no\" style=\"display:none;height:auto;width:100%;background-color: white;\" onload=\"this.style.display='block';BCP.SDC.Presentation.AutoResizeIFrame(this); \"" +
"></iframe>" +
 divWait +
  "</div>" +
  "<div class=\"modal-footer #SHOW_FOOTER#\">" +
    "<a href=\"#\" onclick=\"bcpcore_ui.HideModal();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Close") + "</a>" +
  "</div>" +
   "</div>" +
  "</div>" +
"</div>";

var modalIframePopupWithCustomAction_v1 = "<div id=\"divModalAlertV1\" class=\"modal\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
  "<div class=\"modal-header\">" +
    "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
    "<h3>#TITLE#</h3>" +
  "</div>" +
  "<div class=\"modal-body\" style=\"overflow:hidden;padding:0px;\">" +
   "<iframe name=\"PopupIframe\" id=\"PopupMainIframe\" src=\"#LINK#\" frameborder=\"0\"  marginheight=\"0\"" +
"marginwidth=\"0\"   onprerender=\"BCP.SDC.Presentation.AutoResizeIFrame(this);\"  scrolling=\"no\" style=\"display:none;height:auto;width:99%;background-color: white;\" onload=\"this.style.display='block';BCP.SDC.Presentation.AutoResizeIFrame(this); \"" +
"></iframe>" +
 divWait +
  "</div>" +
  "<div class=\"modal-footer #SHOW_FOOTER#\">" +
    "<a href=\"#\" onclick=\"bcpcore_ui.HideModal();\" class=\"btn btn-default\">" + BCP.SDC.Presentation.GetResource("Cancel") + "</a>" +
    "<a href=\"#\" id=\"btnyes\" onclick=\"#CALLBACKMETHOD;bcpcore_ui.HideModal();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Save") + "</a>" +
  "</div>" +
   "</div>" +
  "</div>" +
"</div>";

var modalIframeClassPopup_v1 = "<div id=\"divModalAlertV1\" class=\"modal\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
  "<div class=\"modal-header\">" +
    "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
    "<h3>#TITLE#</h3>" +
  "</div>" +
  "<div class=\"modal-body\" style=\"overflow:hidden;padding:0px;\">" +
   "<iframe name=\"PopupIframe\" id=\"PopupMainIframe\" class=\"#IFRAME_CLASS#\" src=\"#LINK#\" frameborder=\"0\"  marginheight=\"0\"" +
"marginwidth=\"0\"   onprerender=\"BCP.SDC.Presentation.AutoResizeIFrame(this);\"  scrolling=\"no\" style=\"display:none;height:auto;width:100%;background-color: white;\" onload=\"this.style.display='block';BCP.SDC.Presentation.AutoResizeIFrame(this); \"" +
"></iframe>" +
 divWait +
  "</div>" +
  "<div class=\"modal-footer #SHOW_FOOTER#\">" +
    "<a href=\"#\" onclick=\"bcpcore_ui.HideModal();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Close") + "</a>" +
  "</div>" +
   "</div>" +
  "</div>" +
"</div>";

var modalPopup_v1 = "<div id=\"divModalAlertV1\" class=\"modal\">" +
    "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
  "<div class=\"modal-header\">" +
    "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
    "<h3>#TITLE#</h3>" +
  "</div>" +
  "<div class=\"modal-body\">" +
    "<p>#CONTENT#</p>" +
  "</div>" +
  "<div class=\"modal-footer\">" +
    "<a href=\"#\" onclick=\"bcpcore_ui.HideModal();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Close") + "</a>" +
  "</div>" +
  "</div>" +
  "</div>" +
"</div>";

var modalConfirmPopup_v1 = "<div id=\"divModalAlertV1\" class=\"modal\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
  "<div class=\"modal-header\">" +
    "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
    "<h3>#TITLE#</h3>" +
  "</div>" +
  "<div class=\"modal-body\">" +
    "<p>#CONTENT#</p>" +
  "</div>" +
  "<div class=\"modal-footer\">" +
    "<a href=\"#\" onclick=\"bcpcore_ui.HideModal();\" class=\"btn btn-default\">" + BCP.SDC.Presentation.GetResource("No") + "</a>" +
    "<a href=\"#\" id=\"btnyes\" onclick=\"#CALLBACKMETHOD;bcpcore_ui.HideModal();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Yes") + "</a>" +
   "</div>" +
    "</div>" +
  "</div>" +
"</div>";

var modalProofPopup_v1 = "<div id=\"divModalProofV1\" class=\"modal\" data-focus-on=\"input:first\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
"<div class=\"modal-header\">" +
  "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
  "<h3>" + BCP.SDC.Presentation.GetResource("ProofHeader") + "</h3>" +
"</div>" +
"<div id=\"divProofSucess\" class=\"alert alert-success\">" +
" <div>" + BCP.SDC.Presentation.GetResource("ProofSucessfulMessage") + "</div>" +
"</div>" +
"<div id=\"divProofError\" class=\"alert alert-error\">" +
" <div>" + BCP.SDC.Presentation.GetResource("ProofErrorMessage") + "</div>" +
"</div>" +
"<div id=\"divWaitProof\" style=\"width: 50px; height: 50px; margin-left: auto; margin-right: auto; margin-top: 20px; margin-bottom: 20px; background-color: transparent;\">" +
"<img src=\"/Content/images/loading.gif\" alt=\"\" />" +
"</div>" +
"<div id=\"divProofContainer\" class=\"modal-body form-horizontal\">" +
"<input type=\"hidden\" id=\"hdnTrxId\" />" +
 "<input type=\"hidden\" id=\"hdnProofSessionGuid\" />" +
  "<input type=\"hidden\" id=\"hdnProofInteractionId\" />" +
   "<input type=\"hidden\" id=\"hdnProofType\" />" +
    "<input type=\"hidden\" id=\"hdnHasOperation\" />" +
"<div class=\"control-group\" id=\"divGroupProofEmail\">" +
  "<div class=\"control-tab tab-select\" onclick=\"bcpcore_ui.SelectTab(this,'1');\"><label class=\"control-label\">" + BCP.SDC.Presentation.GetResource("ProofMyEmail") + "</label></div>" +
  "<div class=\"control-tab\" onclick=\"bcpcore_ui.SelectTab(this,'2');\"><label class=\"control-label\">" + BCP.SDC.Presentation.GetResource("ProofEmail") + "</label></div>" +
  "<div class=\"control-tab\" onclick=\"bcpcore_ui.SelectTab(this,'3');\"><label class=\"control-label\">" + BCP.SDC.Presentation.GetResource("ProofSMS") + "</label></div>" +
  "<div id=\"divMyEmail\" class=\"control-input input-select\"><div class=\"fiel\"><input id=\"txtProofMyEmail\" disabled=\"true\" onkeyup=\"bcpcore_ui.ResetControl('divGroupProofEmail');\" onblur=\"bcpcore_ui.ValidateEmail(this);\" type=\"text\" /></div>" +
  "<a id=\"lnkproofMy\" href=\"#\" onclick=\"bcpcore_ui.SendProof();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Send") + "</a></div>" +
  "<div id=\"divEmail\" class=\"control-input\"><div class=\"fiel\"><input id=\"txtProofEmail\" onkeyup=\"bcpcore_ui.ResetControl('divGroupProofEmail');\" onblur=\"bcpcore_ui.ValidateEmail(this);\" type=\"text\" /></div>" +
  "<a id=\"lnkproof\" href=\"#\" onclick=\"bcpcore_ui.SendProof();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Send") + "</a></div>" +
 "<div id=\"divSMS\" class=\"control-input control-sms\"><label class=\"control-sms\">#SMSCONTENT#</label>" +
  "<a id=\"lnkproof\" href=\"#\" onclick=\"bcpcore_ui.HideModal();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("No") + "</a><a id=\"lnkproof\" href=\"#\" onclick=\"bcpcore_ui.SendProof();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Yes") + "</a></div>" +
 "</div>" +
  "</div>" +
  "</div>" +
"</div>";

var modalProofPopup_v1_noMyemail = "<div id=\"divModalProofV1\" class=\"modal\" data-focus-on=\"input:first\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
"<div class=\"modal-header\">" +
  "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
  "<h3>" + BCP.SDC.Presentation.GetResource("ProofHeader") + "</h3>" +
"</div>" +
"<div id=\"divProofSucess\" class=\"alert alert-success\">" +
" <div>" + BCP.SDC.Presentation.GetResource("ProofSucessfulMessage") + "</div>" +
"</div>" +
"<div id=\"divProofError\" class=\"alert alert-error\">" +
" <div>" + BCP.SDC.Presentation.GetResource("ProofErrorMessage") + "</div>" +
"</div>" +
"<div id=\"divWaitProof\" style=\"width: 50px; height: 50px; margin-left: auto; margin-right: auto; margin-top: 20px; margin-bottom: 20px; background-color: transparent;\">" +
"<img src=\"/Content/images/loading.gif\" alt=\"\" />" +
"</div>" +
"<div id=\"divProofContainer\" class=\"modal-body form-horizontal\">" +
"<input type=\"hidden\" id=\"hdnTrxId\" />" +
 "<input type=\"hidden\" id=\"hdnProofSessionGuid\" />" +
  "<input type=\"hidden\" id=\"hdnProofInteractionId\" />" +
   "<input type=\"hidden\" id=\"hdnProofType\" />" +
    "<input type=\"hidden\" id=\"hdnHasOperation\" />" +
"<div class=\"control-group\" id=\"divGroupProofEmail\">" +
  "<div class=\"control-tab tab-select\" onclick=\"bcpcore_ui.SelectTab(this,'2');\"><label class=\"control-label\">" + BCP.SDC.Presentation.GetResource("ProofEmail") + "</label></div>" +
  "<div class=\"control-tab\" onclick=\"bcpcore_ui.SelectTab(this,'3');\"><label class=\"control-label\">" + BCP.SDC.Presentation.GetResource("ProofSMS") + "</label></div>" +
  "<div id=\"divEmail\" class=\"control-input input-select\"><div class=\"fiel\"><input id=\"txtProofEmail\" onkeyup=\"bcpcore_ui.ResetControl('divGroupProofEmail');\" onblur=\"bcpcore_ui.ValidateEmail(this);\" type=\"text\" /></div>" +
  "<a id=\"lnkproof\" href=\"#\" onclick=\"bcpcore_ui.SendProof();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Send") + "</a></div>" +
 "<div id=\"divSMS\" class=\"control-input control-sms\"><label class=\"control-sms\">#SMSCONTENT#</label>" +
  "<a id=\"lnkproof\" href=\"#\" onclick=\"bcpcore_ui.HideModal();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("No") + "</a><a id=\"lnkproof\" href=\"#\" onclick=\"bcpcore_ui.SendProof();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Yes") + "</a></div>" +
 "</div>" +
  "</div>" +
  "</div>" +
"</div>";

var modalProofPopup_v1_email = "<div id=\"divModalProofV1\" class=\"modal\" data-focus-on=\"input:first\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
"<div class=\"modal-header\">" +
  "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
  "<h3>" + BCP.SDC.Presentation.GetResource("ProofHeader") + "</h3>" +
"</div>" +
"<div id=\"divProofSucess\" class=\"alert alert-success\">" +
" <div>" + BCP.SDC.Presentation.GetResource("ProofSucessfulMessage") + "</div>" +
"</div>" +
"<div id=\"divProofError\" class=\"alert alert-error\">" +
" <div>" + BCP.SDC.Presentation.GetResource("ProofErrorMessage") + "</div>" +
"</div>" +
"<div id=\"divWaitProof\" style=\"width: 50px; height: 50px; margin-left: auto; margin-right: auto; margin-top: 20px; margin-bottom: 20px; background-color: transparent;\">" +
"<img src=\"/Content/images/loading.gif\" alt=\"\" />" +
"</div>" +
"<div id=\"divProofContainer\" class=\"modal-body form-horizontal\">" +
"<input type=\"hidden\" id=\"hdnTrxId\" />" +
 "<input type=\"hidden\" id=\"hdnProofSessionGuid\" />" +
  "<input type=\"hidden\" id=\"hdnProofInteractionId\" />" +
   "<input type=\"hidden\" id=\"hdnProofType\" />" +
    "<input type=\"hidden\" id=\"hdnHasOperation\" />" +
"<div class=\"control-group\" id=\"divGroupProofEmail\">" +
  "<div class=\"control-tab tab-select\" onclick=\"bcpcore_ui.SelectTab(this,'1');\"><label class=\"control-label\">" + BCP.SDC.Presentation.GetResource("ProofMyEmail") + "</label></div>" +
  "<div class=\"control-tab\" onclick=\"bcpcore_ui.SelectTab(this,'2');\"><label class=\"control-label\">" + BCP.SDC.Presentation.GetResource("ProofEmail") + "</label></div>" +
  "<div id=\"divMyEmail\" class=\"control-input input-select\"><div class=\"fiel\"><input id=\"txtProofMyEmail\" disabled=\"true\" onkeyup=\"bcpcore_ui.ResetControl('divGroupProofEmail');\" onblur=\"bcpcore_ui.ValidateEmail(this);\" type=\"text\" /></div>" +
  "<a id=\"lnkproofMy\" href=\"#\" onclick=\"bcpcore_ui.SendProof();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Send") + "</a></div>" +
  "<div id=\"divEmail\" class=\"control-input\"><div class=\"fiel\"><input id=\"txtProofEmail\" onkeyup=\"bcpcore_ui.ResetControl('divGroupProofEmail');\" onblur=\"bcpcore_ui.ValidateEmail(this);\" type=\"text\" /></div>" +
  "<a id=\"lnkproof\" href=\"#\" onclick=\"bcpcore_ui.SendProof();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Send") + "</a></div>" +
 "</div>" +
  "</div>" +
  "</div>" +
"</div>";

var modalProofPopup_v1_emailNoMy = "<div id=\"divModalProofV1\" class=\"modal\" data-focus-on=\"input:first\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
"<div class=\"modal-header\">" +
  "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
  "<h3>" + BCP.SDC.Presentation.GetResource("ProofHeader") + "</h3>" +
"</div>" +
"<div id=\"divProofSucess\" class=\"alert alert-success\">" +
" <div>" + BCP.SDC.Presentation.GetResource("ProofSucessfulMessage") + "</div>" +
"</div>" +
"<div id=\"divProofError\" class=\"alert alert-error\">" +
" <div>" + BCP.SDC.Presentation.GetResource("ProofErrorMessage") + "</div>" +
"</div>" +
"<div id=\"divWaitProof\" style=\"width: 50px; height: 50px; margin-left: auto; margin-right: auto; margin-top: 20px; margin-bottom: 20px; background-color: transparent;\">" +
"<img src=\"/Content/images/loading.gif\" alt=\"\" />" +
"</div>" +
"<div id=\"divProofContainer\" class=\"modal-body form-horizontal\">" +
"<input type=\"hidden\" id=\"hdnTrxId\" />" +
 "<input type=\"hidden\" id=\"hdnProofSessionGuid\" />" +
  "<input type=\"hidden\" id=\"hdnProofInteractionId\" />" +
   "<input type=\"hidden\" id=\"hdnProofType\" />" +
    "<input type=\"hidden\" id=\"hdnHasOperation\" />" +
"<div class=\"control-group\" id=\"divGroupProofEmail\">" +
  "<div class=\"control-tab tab-select\" onclick=\"bcpcore_ui.SelectTab(this,'2');\"><label class=\"control-label\">" + BCP.SDC.Presentation.GetResource("ProofEmail") + "</label></div>" +
  "<div id=\"divEmail\" class=\"control-input input-select\"><div class=\"fiel\"><input id=\"txtProofEmail\" onkeyup=\"bcpcore_ui.ResetControl('divGroupProofEmail');\" onblur=\"bcpcore_ui.ValidateEmail(this);\" type=\"text\" /></div>" +
  "<a id=\"lnkproof\" href=\"#\" onclick=\"bcpcore_ui.SendProof();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Send") + "</a></div>" +
 "</div>" +
  "</div>" +
  "</div>" +
"</div>";

var modalProofPopup_v1_sms = "<div id=\"divModalProofV1\" class=\"modal\" data-focus-on=\"input:first\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
"<div class=\"modal-header\">" +
  "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
  "<h3>" + BCP.SDC.Presentation.GetResource("ProofHeader") + "</h3>" +
"</div>" +
"<div id=\"divProofSucess\" class=\"alert alert-success\">" +
" <div>" + BCP.SDC.Presentation.GetResource("ProofSucessfulMessage") + "</div>" +
"</div>" +
"<div id=\"divProofError\" class=\"alert alert-error\">" +
" <div>" + BCP.SDC.Presentation.GetResource("ProofErrorMessage") + "</div>" +
"</div>" +
"<div id=\"divWaitProof\" style=\"width: 50px; height: 50px; margin-left: auto; margin-right: auto; margin-top: 20px; margin-bottom: 20px; background-color: transparent;\">" +
"<img src=\"/Content/images/loading.gif\" alt=\"\" />" +
"</div>" +
"<div id=\"divProofContainer\" class=\"modal-body form-horizontal\">" +
"<input type=\"hidden\" id=\"hdnTrxId\" />" +
 "<input type=\"hidden\" id=\"hdnProofSessionGuid\" />" +
  "<input type=\"hidden\" id=\"hdnProofInteractionId\" />" +
   "<input type=\"hidden\" id=\"hdnProofType\" />" +
    "<input type=\"hidden\" id=\"hdnHasOperation\" />" +
"<div class=\"control-group\" id=\"divGroupProofEmail\">" +
  "<div class=\"control-tab tab-select\" onclick=\"bcpcore_ui.SelectTab(this,'3');\"><label class=\"control-label\">" + BCP.SDC.Presentation.GetResource("ProofSMS") + "</label></div>" +
  "<div id=\"divSMS\" class=\"control-input input-select control-sms\"><label class=\"control-sms\">#SMSCONTENT#</label>" +
  "<a id=\"lnkproof\" href=\"#\" onclick=\"bcpcore_ui.HideModal();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("No") + "</a><a id=\"lnkproof\" href=\"#\" onclick=\"bcpcore_ui.SendProof();\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Yes") + "</a></div>" +
 "</div>" +
  "</div>" +
  "</div>" +
"</div>";


var modalConfirmDdlPopup_v1 = "<div id=\"divModalAlertV1\" class=\"modal\">" +
      "<div class=\"modal-dialog\">" +
    "<div class=\"modal-content\">" +
  "<div class=\"modal-header\">" +
    "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>" +
    "<h3>#TITLE#</h3>" +
  "</div>" +
  "<div class=\"modal-body form-horizontal\">" +
    "<p>#CONTENT#</p>" +

    "<div class=\"control-group\" id=\"divGroupReason\" >" +
    "<label class=\"control-label\" for=\"ddlCheckCancelReason_dlField\">" + BCP.SDC.Presentation.GetResource("lblChooseCancelReason") + "</label>" +
    "<div class=\"controls field metro\">" +
    "<select name=\"ddlCheckCancelReason\" id=\"ddlCheckCancelReason_dlField\" class=\"cd-select valid has-error\" onchange=\"bcpcore_ui.RemoveErrorMessage();\" style=\"width: 100%;\">#OPTIONS#</select>" +
    "<label for=\"ddlCheckCancelReason_dlField\" class=\"error valid\" style=\"left:inherit; width:inherit;\"></label>" +
    "</div>" +
    "</div>" +
  "</div>" +

  "<div class=\"modal-footer\">" +
    "<a href=\"#\" onclick=\"bcpcore_ui.HideModal();\" class=\"btn btn-default\">" + BCP.SDC.Presentation.GetResource("No") + "</a>" +
    "<a href=\"#\" id=\"btnyes\" onclick=\"#CALLBACKMETHOD;\" class=\"btn btn-primary\">" + BCP.SDC.Presentation.GetResource("Yes") + "</a>" +
   "</div>" +
    "</div>" +
  "</div>" +
"</div>";

(function ($) {
    $.fn.GetScrollXY = function () {
        var x = 0, y = 0;
        if (typeof (window.pageYOffset) == 'number') {
            // Netscape
            x = window.pageXOffset;
            y = window.pageYOffset;
        } else if (document.body && (document.body.scrollLeft || document.body.scrollTop)) {
            // DOM
            x = document.body.scrollLeft;
            y = document.body.scrollTop;
        } else if (document.documentElement && (document.documentElement.scrollLeft || document.documentElement.scrollTop)) {
            // IE6 standards compliant mode
            x = document.documentElement.scrollLeft;
            y = document.documentElement.scrollTop;
        }
        return [x, y];
    };
    $.fn.resizeCount = 0;
    $.fn.ShowModalProof = function (idg, interactionid, proofmessage, type, myemail, hoperation, trxid, allowSMS, allowEmail) {
        var modalDiv = '#divModalProofV1';
        var maxHeight = 600;

        var sessionGuidObjectID = '#hdnProofSessionGuid';
        var interactionObjectID = '#hdnProofInteractionId';
        var proofTypeID = '#hdnProofType';
        var txtProofMyEmail = '#txtProofMyEmail';
        var hasOperation = "#hdnHasOperation";
        var trxId = "#hdnTrxId";

        window.$(sessionGuidObjectID).val(idg);
        window.$(interactionObjectID).val(interactionid);
        window.$(proofTypeID).val(type);
        window.$(txtProofMyEmail).val(myemail);
        window.$(hasOperation).val(hoperation);
        window.$(trxId).val(trxid);

        if (type == 'email') {
            window.$("#divGroupProofEmail").show();
            window.$("#divGroupProofSMS").hide();
        }
        else {
            window.$("#divGroupProofEmail").hide();
            window.$("#divGroupProofSMS").show();
        }

        window.$('#pnProofMessage').html(proofmessage);
        window.$('#divProofSucess').hide();
        window.$('#divProofError').hide();
        window.$('#divWaitProof').hide();

        window.$(modalDiv).modal({ keyboard: true, show: true });//.on('hide', callback);

        //window.$(modalDiv).css("top", $(document).scrollTop() + 20);
        $(".undefined").hide();

    };

    $.fn.ShowModalAlert = function (onTop, callback, onYes, onNo) {
        var modalDiv = '#divModalAlertV1';
        var maxHeight = 500;

        var top = $(this).GetScrollXY()[1];
        top = top + 50;
        console.info("passou 1");
        if (onTop == true) {
            console.info("passou 2");
            //window.$(modalDiv).css("top", top);
            window.$(modalDiv).modal({ keyboard: true, show: true });
            window.$(modalDiv).find('#btnyes').unbind().on('click', onYes);
            window.$(modalDiv).find('#btnno').unbind().on('click', onNo);
            window.$(modalDiv).find('.close').unbind().on('click', callback);
            //console.info("passou 4");
            //window.$(".undefined").hide();
            //console.info("passou 5");
            //window.$(modalDiv).find('#txtInputVal').focus();
            //console.info("passou 6");
        }
        else {
            console.info("passou 3");
            $(modalDiv).css("top", top);
            $(modalDiv).modal({ keyboard: true, show: true });;
            $(modalDiv).find('#btnyes').unbind().on('click', onYes);
            $(modalDiv).find('#btnno').unbind().on('click', onNo);
            $(modalDiv).find('.close').unbind().on('click', callback);

            //$(".undefined").hide();
        }
    };

    $.fn.HasScrollBar = function () {
        return this.get(0).scrollHeight > this.innerHeight();
    }

    $.fn.ResizeModal = function (opts) {

        $(this).contents().find('.no-dialog').hide();
        var options = $.extend({}, $.fn.ResizeModal.defaults, opts);
        var frameWidth = "";
        if (options.Width == "")
            frameWidth = window.innerWidth;// $(this).contents().width();
        else
            frameWidth = options.Width;

        if (typeof frameWidth === "undefined")
            frameWidth = $(this).contents().width();

        var frameHeight = $(this).contents().height();
        if ($(this).contents().find('body').height() > 0)
            frameHeight = $(this).contents().find('body').height();

        if (options.Height != undefined && options.Height != 'undefined')
            frameHeight = options.Height;

        var parentHeight = frameHeight;

        if (frameWidth > options.maxWidth) {
            frameWidth = options.maxWidth;
        }


        if (frameHeight > 0) {

            $(this).css({
                height: frameHeight + parseInt(options.iframeMargin),
                opacity: 1
            });
        }

        var top = $(this).GetScrollXY()[1];
        top = top + 50;

        console.info("ResizeModal#frameHeight:" + frameHeight);

        if (frameWidth > 0) {
            //$(this).width(frameWidth + 'px');
            var fullWidth = parseInt(frameWidth);// + parseInt(options.iframeMargin);

            //$(this).css('margin-left', parseInt(options.iframeMargin) / 2 + "px");
            $(this).closest(options.modalId).animate({
                width: 'auto',
                opacity: 1
                //marginLeft: "-" + fullWidth / 2 + "px",
                //top: 50
                //left: '50%'
            }, 1);
        }
    }

    $.fn.ResizeModal.defaults = {
        maxWidth: "500",
        maxHeight: "500",
        maxTries: 5,
        modalId: "#divModalAlertV1",
        iframeMargin: 0,
        isCustom: 0,
        Width: ""
    }

})(jQuery);

var bcpcore_ui = {

    DIV_MODAL: "#divModalAlertV1",
    INPUT_USERNAME: "#txtUserNameLogin",
    INPUT_PASSWORD: "#txtPasswordLogin",
    REPLACE_TAG_CONTENT: "#CONTENT#",
    REPLACE_TAG_TITLE: "#TITLE#",
    REPLACE_TAG_SMSMESSAGE: "#SMSCONTENT#",
    REPLACE_TAG_LINK: "#LINK#",
    REPLACE_TAG_SHOW_FOOTER: "#SHOW_FOOTER#",
    REPLACE_TAG_FOOTER: "#FOOTER#",
    REPLACE_TAG_OPTIONS: "#OPTIONS#",
    CALLBACKMETHOD: "#CALLBACKMETHOD",
    CALLBACKMETHOD2: "#CALLBACKMETHOD2",
    DIV_MODAL_PROOF: "#divModalProofV1",
    PROOF_MESSAGE: "#pnProofMessage",
    INPUT_EMAIL: "#txtProofEmail",
    INPUT_MYEMAIL: "#txtProofMyEmail",
    INPUT_SMS: "#txtProofSMS",
    INPUT_CONFIRM: "#txtInputVal",
    REPLACE_IFRAME_CLASS: "#IFRAME_CLASS#",

    SelectTab: function (obj, id) {
        var o = $(obj);
        $('.control-tab').each(function () {
            $(this).removeClass('tab-select');
        });

        o.addClass('tab-select');

        $('.control-input').each(function () {
            $(this).removeClass('input-select');
        });

        if (id == 1) {
            $("#divMyEmail").addClass('input-select');
        }
        else if (id == 2) {
            $("#divEmail").addClass('input-select');
        }
        else {
            $("#divSMS").addClass('input-select');
        }

        $("#divGroupProofEmail").removeClass("error");
    },
    ShowTopPopupProof: function (idg, idInteraction, message, type, myemail, trxid, allowSMS, allowEmail, smsContentTrue, smsContentFalse) {
        try {

            if (allowSMS == 1 && allowEmail == 1) {

                BCP.SDC.Presentation.BlockPageForAjaxRequest();

                var url = "services.axd?Method=AccountForSmsIsOk";
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("Accept", "text/javascript, application/javascript, */*, text/javascript,application/javascript,text/html");
                        xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
                    },
                    success: function (smsIsOk) {

                        if (smsIsOk == true) {
                            //
                            if (BCP.SDC.Presentation.Alltrim(myemail) != '')
                                window.$(".topModalcontainer").html(modalProofPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentTrue));
                            else {

                                window.$(".topModalcontainer").html(modalProofPopup_v1_noMyemail.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentTrue));
                            }
                        }
                        else {
                            //
                            if (BCP.SDC.Presentation.Alltrim(myemail) != '')
                                window.$(".topModalcontainer").html(modalProofPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentFalse));
                            else {

                                window.$(".topModalcontainer").html(modalProofPopup_v1_noMyemail.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentFalse));
                            }
                        }

                        $.unblockUI();
                        $(".divWait").hide();
                        BCP.SDC.Presentation.NoLoading = false;

                        $(this).ShowModalProof(idg, idInteraction, message, type, myemail, 0, trxid, allowSMS, allowEmail);
                    },
                    error: function (XMLHttpRequest) {
                        //   
                        $(this).ShowModalProof(idg, idInteraction, message, type, myemail, 0, trxid, false, allowEmail);
                        //bcpcore_ui.ShowTopPopupWarning(BCP.SDC.Presentation.GetResource("AccountForSmsIsOkMessage"), BCP.SDC.Presentation.GetResource("AccountForSmsIsOkTitle"), '');
                    }
                });

            }
            else if (allowSMS == 1 && allowEmail == 0) {

                BCP.SDC.Presentation.BlockPageForAjaxRequest();

                var url = "services.axd?Method=AccountForSmsIsOk";
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("Accept", "text/javascript, application/javascript, */*, text/javascript,application/javascript,text/html");
                        xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
                    },
                    success: function (smsIsOk) {

                        if (smsIsOk == true) {
                            //
                            window.$(".topModalcontainer").html(modalProofPopup_v1_sms.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentTrue));
                        }
                        else {
                            //
                            window.$(".topModalcontainer").html(modalProofPopup_v1_sms.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentFalse));
                        }

                        $.unblockUI();
                        $(".divWait").hide();
                        BCP.SDC.Presentation.NoLoading = false;

                        $(this).ShowModalProof(idg, idInteraction, message, type, myemail, 0, trxid, allowSMS, allowEmail);
                    },
                    error: function (XMLHttpRequest) {
                        //   
                        $(this).ShowModalProof(idg, idInteraction, message, type, myemail, 0, trxid, false, allowEmail);
                        //bcpcore_ui.ShowTopPopupWarning(BCP.SDC.Presentation.GetResource("AccountForSmsIsOkMessage"), BCP.SDC.Presentation.GetResource("AccountForSmsIsOkTitle"), '');
                    }
                });

            }
            else if (allowSMS == 0 && allowEmail == 1) {
                if (BCP.SDC.Presentation.Alltrim(myemail) != '')
                    window.$(".topModalcontainer").html(modalProofPopup_v1_email.toString());
                else
                    window.$(".topModalcontainer").html(modalProofPopup_v1_emailNoMy.toString());

                $(this).ShowModalProof(idg, idInteraction, message, type, myemail, 0, trxid, allowSMS, allowEmail);
            }
        }
        catch (ex) {
            alert("bcpcore_ui.ShowTopPopupProof Error: " + ex.message);
        }
    },

    ShowTopPopupProofWithFlows: function (idg, idInteraction, message, type, myemail, trxid, allowSMS, allowEmail, smsContentTrue, smsContentFalse) {
        try {
            if (allowSMS == 1 && allowEmail == 1) {
                BCP.SDC.Presentation.BlockPageForAjaxRequest();

                var url = "services.axd?Method=AccountForSmsIsOk";
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("Accept", "text/javascript, application/javascript, */*, text/javascript,application/javascript,text/html");
                        xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
                    },
                    success: function (smsIsOk) {
                        if (smsIsOk == true) {
                            //
                            if (BCP.SDC.Presentation.Alltrim(myemail) != '')
                                window.$(".topModalcontainer").html(modalProofPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentTrue));
                            else
                                window.$(".topModalcontainer").html(modalProofPopup_v1_noMyemail.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentTrue));
                        }
                        else {
                            //
                            if (BCP.SDC.Presentation.Alltrim(myemail) != '')
                                window.$(".topModalcontainer").html(modalProofPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentFalse));
                            else
                                window.$(".topModalcontainer").html(modalProofPopup_v1_noMyemail.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentFalse));
                        }

                        $.unblockUI();
                        $(".divWait").hide();
                        BCP.SDC.Presentation.NoLoading = false;

                        $(this).ShowModalProof(idg, idInteraction, message, type, myemail, 1, trxid, allowSMS, allowEmail);

                    },
                    error: function (XMLHttpRequest) {
                        //
                        $.unblockUI();
                        $(".divWait").hide();
                        BCP.SDC.Presentation.NoLoading = false;

                        $(this).ShowModalProof(idg, idInteraction, message, type, myemail, 1, trxid, false, allowEmail);
                        //bcpcore_ui.ShowTopPopupWarning(BCP.SDC.Presentation.GetResource("AccountForSmsIsOkMessage"), BCP.SDC.Presentation.GetResource("AccountForSmsIsOkTitle"), '');
                    }
                });

            }
            else if (allowSMS == 1 && allowEmail == 0) {

                BCP.SDC.Presentation.BlockPageForAjaxRequest();

                var url = "services.axd?Method=AccountForSmsIsOk";
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("Accept", "text/javascript, application/javascript, */*, text/javascript,application/javascript,text/html");
                        xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
                    },
                    success: function (smsIsOk) {
                        if (smsIsOk == true) {
                            //
                            window.$(".topModalcontainer").html(modalProofPopup_v1_sms.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentTrue));
                        }
                        else {
                            //
                            window.$(".topModalcontainer").html(modalProofPopup_v1_sms.toString().replace(bcpcore_ui.REPLACE_TAG_SMSMESSAGE, smsContentFalse));
                        }

                        $.unblockUI();
                        $(".divWait").hide();
                        BCP.SDC.Presentation.NoLoading = false;

                        $(this).ShowModalProof(idg, idInteraction, message, type, myemail, 1, trxid, allowSMS, allowEmail);
                    },
                    error: function (XMLHttpRequest) {
                        //  
                        $.unblockUI();
                        $(".divWait").hide();
                        BCP.SDC.Presentation.NoLoading = false;

                        $(this).ShowModalProof(idg, idInteraction, message, type, myemail, 1, trxid, false, allowEmail);
                        //bcpcore_ui.ShowTopPopupWarning(BCP.SDC.Presentation.GetResource("AccountForSmsIsOkMessage"), BCP.SDC.Presentation.GetResource("AccountForSmsIsOkTitle"), '');
                    }
                });
            }
            else if (allowSMS == 0 && allowEmail == 1) {
                if (BCP.SDC.Presentation.Alltrim(myemail) != '')
                    window.$(".topModalcontainer").html(modalProofPopup_v1_email.toString());
                else
                    window.$(".topModalcontainer").html(modalProofPopup_v1_emailNoMy.toString());

                $(this).ShowModalProof(idg, idInteraction, message, type, myemail, 1, trxid, allowSMS, allowEmail);
            }
        }
        catch (ex) {
            alert("bcpcore_ui.ShowTopPopupProof Error: " + ex.message);
        }
    },

    ShowCustom: function (message, title, footer, onYes, onNo, ocClose, autoResize, ifHeight, ifWidth, noblock) {
        try {
            message = unescape(message);
            if (message.indexOf("<iframe") != -1) {
                window.$(".topModalcontainer").html(modalCustom_v1.toString().replace(bcpcore_ui.REPLACE_TAG_CONTENT, message).replace(bcpcore_ui.REPLACE_TAG_TITLE, title).replace(bcpcore_ui.REPLACE_TAG_FOOTER, footer));
                $("#divModalAlertV1").find("iframe").hide();
            }
            else {
                window.$(".topModalcontainer").html(modalCustom_v2.toString().replace(bcpcore_ui.REPLACE_TAG_CONTENT, message).replace(bcpcore_ui.REPLACE_TAG_TITLE, title).replace(bcpcore_ui.REPLACE_TAG_FOOTER, footer));
            }
            if (!footer) {
                $(".modal-footer").remove();
            }

            $(this).ShowModalAlert(true, ocClose, onYes, onNo);

            $("#divModalAlertV1 iframe").on("load", function () {
                $("#divModalAlertV1").find("#DivWait").hide('fast');
                $("#divModalAlertV1").find("iframe").show();
                //if (autoResize == 0) {

                //    $(this).ResizeModal.defaults.maxHeight = ifHeight;
                //    $(this).ResizeModal.defaults.maxWidth = ifWidth;
                //    $(this).ResizeModal.defaults.isCustom = 1;
                //}
                //else {
                //    $(this).ResizeModal.defaults.maxHeight = "500";
                //    $(this).ResizeModal.defaults.maxWidth = "1200";
                //}

                //$(this).ResizeModal();

                ////if (noblock && window.interactionIframe != null && window.interactionIframe.MainIframeInner != null) {
                ////    window.interactionIframe.MainIframeInner.$.unblockUI();
                ////}

            });
            BCP.SDC.Presentation.ScrollTop();

        }
        catch (ex) {
            alert("bcpcore_ui.ShowCustom Error: " + ex.message);
        }
    },

    ShowFavoritImagev1: function (title, content, onCloseDelegate) {
        try {
            window.$(".topModalcontainer").html(modalFavoritsImage_v1.toString().replace(bcpcore_ui.REPLACE_TAG_CONTENT, content).replace(bcpcore_ui.REPLACE_TAG_TITLE, title));
            $(this).ShowModalAlert(true, onCloseDelegate);
        }
        catch (ex) {
            alert("bcpcore_ui.ShowCustom Error: " + ex.message);
        }
    },

    ShowTopPopupWarning: function (message, headerTitle, onCloseDelegate) {
        console.info("show top popup!");
        try {
            console.info(BCP.SDC.Presentation.GetResource("Close"));
            //console.info(modalPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_CONTENT, message).replace(bcpcore_ui.REPLACE_TAG_TITLE, headerTitle));
            window.$(".topModalcontainer").html(modalPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_CONTENT, message).replace(bcpcore_ui.REPLACE_TAG_TITLE, headerTitle));
            $(this).ShowModalAlert(true, onCloseDelegate);
            BCP.SDC.Presentation.ScrollTop();
        }
        catch (ex) {
            alert("bcpcore_ui.ShowTopPopupWarning Error: " + ex.message);
        }
    },

    ShowTopPopupConfirm: function (message, headerTitle, onYes) {
        try {
            window.$(".topModalcontainer").html(modalConfirmPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_CONTENT, message).replace(bcpcore_ui.REPLACE_TAG_TITLE, headerTitle).replace(bcpcore_ui.CALLBACKMETHOD, onYes));
            $(this).ShowModalAlert(true);
            BCP.SDC.Presentation.ScrollTop();
        }
        catch (ex) {
            alert("bcpcore_ui.ShowTopPopupConfirm Error: " + ex.message);
        }
    },

    ShowTopPopupConfirmDropDownList: function (message, headerTitle, optionsList, selectedOptIndex, onYes) {
        try {
            var optionsString = "";
            if (Array.isArray(optionsList)) {
                for (i = 0; i < optionsList.length; ++i) {
                    optionsString = optionsString.concat("<option value=\"" + optionsList[i].value + "\" class=\"optionitem\"" + ((selectedOptIndex != null && selectedOptIndex == i) ? " selected=\"selected\"" : "") + ">" + optionsList[i].name + "</option>");
                }
            }

            window.$(".topModalcontainer").html(modalConfirmDdlPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_CONTENT, message).replace(bcpcore_ui.REPLACE_TAG_TITLE, headerTitle).replace(bcpcore_ui.REPLACE_TAG_OPTIONS, optionsString).replace(bcpcore_ui.CALLBACKMETHOD, onYes));
            $(this).ShowModalAlert(true);
        }
        catch (ex) {
            alert("bcpcore_ui.ShowTopPopupConfirm Error: " + ex.message);
        }
    },

    ShowPopupWarning: function (message, headerTitle, onCloseDelegate) {
        try {
            if (window.$(".topModalcontainer").length == 0)
                window.$('<div class="topModalcontainer" />').appendTo("body");
            window.$(".topModalcontainer").html(modalPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_CONTENT, message).replace(bcpcore_ui.REPLACE_TAG_TITLE, headerTitle));
            window.$(this).ShowModalAlert(false, onCloseDelegate);
            BCP.SDC.Presentation.ScrollTop();
        }
        catch (ex) {
            alert("bcpcore_ui.Show Error: " + ex.message);
        }
    },

    ShowPopupIframe: function (link, headerTitle, onClose, showFooter) {
        try {
            //$(this).ResizeModal.defaults.maxHeight = "500";
            //$(this).ResizeModal.defaults.maxWidth = "1200";
            console.info("ShowPopupIframe");
            if (window.$(".topModalcontainer").length == 0)
                window.$('<div class="topModalcontainer" />').appendTo("body");
            if (showFooter != true) {
                console.info("ShowPopupIframe 2");
                window.$(".topModalcontainer").html(modalIframePopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_SHOW_FOOTER, ""));
            }

            window.$("#PopupMainIframe").unbind("load");
            console.info(window.$(".topModalcontainer").html());

            console.info("ShowPopupIframe 3");
            window.$(".topModalcontainer").html(modalIframePopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_SHOW_FOOTER, "undefined").replace(bcpcore_ui.REPLACE_TAG_TITLE, headerTitle).replace(bcpcore_ui.REPLACE_TAG_LINK, link));

            window.$(this).ShowModalAlert(false, onClose);

            window.$("#PopupMainIframe").one("load", function () {
                $(this).ResizeModal();
            });
        }

        catch (ex) {
            alert("ShowPopupIframe Error: " + ex.message);
        }
    },


    OpenSimpleWindow: function (url, extension) {
        setTimeout($.unblockUI, 500);

        if (extension == 'pdf' || extension == 'png') {
            window.open(url, '', 'statusbar=0 ,resizable=0,scrollbars=1,titlebar=0,personalbar=0,status=0,menubar=0, toolbar=0');
        }
        else {
            window.location.href = url;
        }
    },

    ShowTopPopupIframe: function (link, headerTitle, onClose, showFooter, callback, cwidth, cheight) {
        try {
            if (cheight != undefined && cheight != "undefined") {
                $(this).ResizeModal.defaults.Height = cheight;
            }

            //if (cwidth != undefined && cwidth != "undefined") {
            //    $(this).ResizeModal.defaults.maxWidth = cwidth;
            //    $(this).ResizeModal.defaults.Width = cwidth;
            //}
            //else
            //    $(this).ResizeModal.defaults.maxWidth = "1200";
            console.info("ShowTopPopupIframe");
            if (showFooter === true) {
                window.$(".topModalcontainer").html(modalIframePopupWithCustomAction_v1.toString().replace(bcpcore_ui.REPLACE_TAG_SHOW_FOOTER, ""));
            }

            window.$("#PopupMainIframe").unbind("load");

            window.$(".topModalcontainer").html(modalIframePopupWithCustomAction_v1.toString().replace(bcpcore_ui.REPLACE_TAG_SHOW_FOOTER, "undefined").replace(bcpcore_ui.REPLACE_TAG_TITLE, headerTitle).replace(bcpcore_ui.REPLACE_TAG_LINK, link).replace(bcpcore_ui.CALLBACKMETHOD, callback));
            window.$("#divModalAlertV1").find("iframe").hide();
            if (showFooter === true) {
            } else {
                window.$(".topModalcontainer").find(".modal-footer").remove();
            }

            $(this).ShowModalAlert(true, onClose);


            window.$("#PopupMainIframe").on("load", function () {
                //setTimeout(function () {
                //$(this).ResizeModal();
                window.$("#divModalAlertV1").find("#DivWait").hide('fast');
                window.$("#divModalAlertV1").find("iframe").show();
                $(this).ResizeModal();
                //}, 100);
            });
        }
        catch (ex) {
            alert("bcpcore_ui.Show Error: " + ex.message);
        }
    },



    ShowResizeTopPopupIframe: function (link, headerTitle, onClose, showFooter, iframeClass) {
        try {

            //$(this).ResizeModal.defaults.maxHeight = "600";
            //if (cwidth != undefined && cwidth != "undefined") {
            //    $(this).ResizeModal.defaults.maxWidth = cwidth;
            //    $(this).ResizeModal.defaults.Width = cwidth;
            //}
            //else
            //    $(this).ResizeModal.defaults.maxWidth = "1200";

            if (showFooter === true) {
                window.$(".topModalcontainer").html(modalIframeClassPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_SHOW_FOOTER, ""));
            }

            window.$("#PopupMainIframe").unbind("load");

            window.$(".topModalcontainer").html(modalIframeClassPopup_v1.toString().replace(bcpcore_ui.REPLACE_TAG_SHOW_FOOTER, "undefined").replace(bcpcore_ui.REPLACE_TAG_TITLE, headerTitle).replace(bcpcore_ui.REPLACE_TAG_LINK, link).replace(bcpcore_ui.REPLACE_IFRAME_CLASS, iframeClass));
            window.$("#divModalAlertV1").find("iframe").hide();
            if (showFooter === true) {
            } else {
                window.$(".topModalcontainer").find(".modal-footer").remove();
            }

            $(this).ShowModalAlert(true, onClose);


            window.$("#PopupMainIframe").on("load", function () {
                //setTimeout(function () {
                //$(this).ResizeModal();
                window.$("#divModalAlertV1").find("#DivWait").hide('fast');
                window.$("#divModalAlertV1").find("iframe").show();
                $(this).ResizeModal();
                //}, 100);
            });
        }
        catch (ex) {
            alert("bcpcore_ui.Show Error: " + ex.message);
        }
    },


    ConfirmOkPress: function (e) {
        if (e.which != 13) {
            console.info("keypress: " + e.which);
            return false;
        }
        else {
            console.info("keypress: " + e.which);
            return true;
        }
    },

    HideModal: function () {
        $(bcpcore_ui.DIV_MODAL).modal('hide');
        $(bcpcore_ui.DIV_MODAL_PROOF).modal('hide');
    },

    PasswordLoginPress: function (e) {
        if (e.which == 13) {
            bcpcore_ui.Login();
        }
    },

    SendProof: function () {
        //
        console.info("send 1");
        var ret = false;
        var email = $(bcpcore_ui.INPUT_EMAIL);
        var myemail = $(bcpcore_ui.INPUT_MYEMAIL);
        var sms = $(bcpcore_ui.INPUT_SMS);
        var hasoperation = $("#hdnHasOperation");
        var trxId = $("#hdnTrxId");
        var sessionid = $("#hdnProofSessionGuid");
        var interactionid = $("#hdnProofInteractionId");
        var proofType = $("#hdnProofType");
        var divWaitProof = $('#divWaitProof');
        var lnkcloseproof = $("#lnkcloseproof");
        var lnkproof = $("#lnkproof");
        console.info("send 2");
        var divProofContainer = $("#divProofContainer");
        var divProofSuccess = $("#divProofSucess");
        var divProofError = $("#divProofError");
        var divMyEmail = $("#divMyEmail");
        var divEmail = $("#divEmail");
        var divSMS = $("#divSMS");
        var emailValue;
        var phoneValue;
        var isSMS = false;

        console.info("send type:" + proofType.val());
        if (proofType.val() == 'email') {
            if (divMyEmail.hasClass("input-select")) {
                if (myemail.val() == "") {
                    console.info("myemail.val: " + myemail.val());
                    $("#divGroupProofEmail").addClass("error");
                    ret = false;
                }
                else {
                    console.info("myemail.val: " + myemail.val());
                    emailValue = myemail.val();
                    ret = window.BCP.SDC.Presentation.ValidateEmailExp(myemail.val());
                    if (ret == false) {
                        $("#divGroupProofEmail").addClass("error");
                    }
                    else {
                        $("#divGroupProofEmail").removeClass("error");
                    }
                }
            }
            else if (divEmail.hasClass("input-select")) {

                if (email.val() == "") {
                    $("#divGroupProofEmail").addClass("error");
                    ret = false;
                }
                else {
                    emailValue = email.val();
                    ret = window.BCP.SDC.Presentation.ValidateEmailExp(email.val());
                    if (ret == false) {
                        $("#divGroupProofEmail").addClass("error");
                        window.BCP.SDC.Presentation.InsertValidateMsg(email, BCP.SDC.Presentation.GetResource("InvalidEmailMessage"));
                    }
                    else {
                        $("#divGroupProofEmail").removeClass("error");
                        window.BCP.SDC.Presentation.RemoveValidateMsg(email);
                    }
                }
            }
            else {
                ret = true;
                isSMS = true;
            }
        }

        if (!ret)
            return;
        else {
            if (isSMS) {
                //
                window.BCP.SDC.Presentation.SendSMS(proofType.val(), '', sessionid.val(), interactionid.val(), lnkproof, lnkcloseproof, divProofContainer, divProofSuccess, divWaitProof, divProofError, trxId.val());
            }
            else {
                if (hasoperation.val() == '1')
                    window.BCP.SDC.Presentation.SendOperation(proofType.val(), emailValue, sessionid.val(), interactionid.val(), lnkproof, lnkcloseproof, divProofContainer, divProofSuccess, divWaitProof, divProofError);
                else
                    window.BCP.SDC.Presentation.Send(proofType.val(), emailValue, sessionid.val(), interactionid.val(), lnkproof, lnkcloseproof, divProofContainer, divProofSuccess, divWaitProof, divProofError);
            }
        }
    },

    ValidateEmail: function (elem) {
        var email = $("#" + elem.id);
        ret = window.BCP.SDC.Presentation.ValidateEmailExp(email.val());
        if (ret == false) {
            $("#divGroupProofEmail").addClass("error");
            //window.BCP.SDC.Presentation.InsertValidateMsg(email, BCP.SDC.Presentation.GetResource("InvalidEmailMessage"));
        }
        else {
            $("#divGroupProofEmail").removeClass("error");
            //window.BCP.SDC.Presentation.RemoveValidateMsg(email);
        }
    },

    ValidateNumber: function (elem) {
        var number = $("#" + elem.id);
        ret = window.BCP.SDC.Presentation.ValidateNumeric(number.val());
        if (ret == false) {
            $("#divGroupProofSMS").addClass("error");
            //window.BCP.SDC.Presentation.InsertValidateMsg(number, BCP.SDC.Presentation.GetResource("InvalidPhoneMessage"));
        }
        else {
            $("#divGroupProofSMS").addClass("error");
            //window.BCP.SDC.Presentation.RemoveValidateMsg(number);
        }
    },

    CallBackConfirm: function (funct) {
        var inconfirm = $(bcpcore_ui.INPUT_CONFIRM);
        var f = funct + "('" + inconfirm.val() + "');";
        eval(f);
    },

    ResetControl: function (groupId) {
        var group = $("#" + groupId);
        if (group != undefined) {
            group.removeClass("error");
        }
    },

    GetSelectedReasonValue: function () {
        var divGroupReason = $("#divGroupReason");
        var ddlCheckCancelReason = $("#ddlCheckCancelReason_dlField");
        var selectedNumber = ddlCheckCancelReason.val();

        ret = (selectedNumber != "-1");
        if (ret == false) {
            selectedNumber = null;
            window.BCP.SDC.Presentation.InsertValidateMsg(ddlCheckCancelReason, BCP.SDC.Presentation.GetResource("InvalidCancelReason"));
        }
        else {
            window.BCP.SDC.Presentation.RemoveValidateMsg(ddlCheckCancelReason);
        }

        return selectedNumber;
    },

    RemoveErrorMessage: function () {
        var ddlCheckCancelReason = $("#ddlCheckCancelReason_dlField");

        window.BCP.SDC.Presentation.RemoveValidateMsg(ddlCheckCancelReason);
    }
}


