
BCP.SDC.Presentation.DownloadDOC = function (url, errorMessage, parameters) {
    BCP.SDC.Presentation.DownloadErrorMessage = errorMessage;
    var downloadFile = new AjaxDownload(url);

    downloadFile.EnableTrace(false);
    if (parameters != null) {
        for (var n = 0; n < parameters.length; n++) {
            downloadFile.AddParameter(parameters[n]["Name"], parameters[n]["Value"]);
        }
    }
    downloadFile.add_onBeginDownload(BCP.SDC.Presentation.OnDownloadDocStart);
    downloadFile.add_onEndDownload(BCP.SDC.Presentation.OnDownloadDocEnd);
    downloadFile.add_onError(BCP.SDC.Presentation.OnDownloadDocError);
    downloadFile.add_onSuccess(BCP.SDC.Presentation.OnDownloadDocSuccess);


    downloadFile.Download();


}

BCP.SDC.Presentation.DownloadDOCV2 = function (url, errorMessage, parameters) {
    BCP.SDC.Presentation.DownloadErrorMessage = errorMessage;
    var downloadFile = new AjaxDownload(url);

    downloadFile.EnableTrace(false);
    if (parameters != null) {
        for (var n = 0; n < parameters.length; n++) {
            downloadFile.AddParameter(parameters[n]["Name"], parameters[n]["Value"]);
        }
    }
    downloadFile.add_onBeginDownload(BCP.SDC.Presentation.OnDownloadDocStart);
    downloadFile.add_onEndDownload(BCP.SDC.Presentation.OnDownloadDocEnd);
    downloadFile.add_onError(BCP.SDC.Presentation.OnDownloadDocError);
    downloadFile.add_onSuccess(BCP.SDC.Presentation.OnDownloadDocSuccess);


    downloadFile.DownloadV2();


}

BCP.SDC.Presentation.ExportToPdf = function (title, type) {
    var jsonTable;

    if (type == 1)
        jsonTable = BCP.SDC.Presentation.StripHTML($('[id$=hdnToJSON]').val());
    else
        jsonTable = BCP.SDC.Presentation.GetPrintFieldsPDF(title);

    var parameters = new Array();
    parameters[0] = new Array();
    parameters[0]["Name"] = "PDFObject";
    console.info(jsonTable);
    parameters[0]["Value"] = encodeURIComponent(jsonTable);
    parameters[1] = new Array();
    parameters[1]["Name"] = "PrintID";
    parameters[1]["Value"] = $('[id$=hdnPrntId]').val();
    parameters[2] = new Array();
    parameters[2]["Name"] = "OperationDate";
    parameters[2]["Value"] = $('[id$=hdnOperationDate]').val();
    parameters[3] = new Array();
    parameters[3]["Name"] = "OperationId";
    parameters[3]["Value"] = $('[id$=hdnOperationId]').val();

    BCP.SDC.Presentation.DownloadDOC("/security/PrintToPdf.aspx", BCP.SDC.Presentation.GetResource("PDFErrorPrint"), parameters);
}

BCP.SDC.Presentation.ExportToExcel = function (title, exportType) {
    var url = "services.axd?Method=DownloadExcel";
    var uagent = navigator.userAgent.toLowerCase();
    var listData = "&ExportType=" + encodeURIComponent(exportType) + "&title=" + encodeURIComponent(title);
    $.ajax({
        type: "POST",
        url: url + listData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Accept", "text/javascript, application/javascript, */*, text/javascript,application/javascript,text/html");
            xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
        },
        success: function (uri) {
            //var uagent = navigator.userAgent.toLowerCase();
            //if (uagent.toLowerCase().search("ipad") > -1) {

            //    window.open("/security/excelfile.aspx?uri=" + uri, '_blank')

            //}
            //else {
            BCP.SDC.Presentation.DownloadDOCV2("excelfile.axd?" + uri, BCP.SDC.Presentation.GetResource("PDFErrorPrint"));
            //}
        },
        error: function (XMLHttpRequest) {
            //
            //BCP.SDC.Presentation.AjaxErrorParse(XMLHttpRequest,"");
        }
    });
}

BCP.SDC.Presentation.ExportToCSV = function (title, exportType) {
    console.info(title);
    console.info(title);
    console.info(exportType);

    var url = "services.axd?Method=DownloadExcel";
    var listData = "&ExportType=" + encodeURIComponent(exportType) + "&title=" + encodeURIComponent(title) + "&ExportCSV=true";
    $.ajax({
        type: "POST",
        url: url + listData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Accept", "text/javascript, application/javascript, */*, text/javascript,application/javascript,text/html");
            xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
        },
        success: function (uri) {
            BCP.SDC.Presentation.DownloadDOCV2("excelfile.axd?" + uri);
        },
        error: function (XMLHttpRequest) {
            //
        }
    });
}

BCP.SDC.Presentation.PrintContainer = function (title, type) {
    //
    var jsonTable;

    if (type == 1)
        jsonTable = BCP.SDC.Presentation.GetHtmlResultPrintFields(title);
    else
        jsonTable = BCP.SDC.Presentation.GetHtmlPrintFields(title);

    console.info(jsonTable);
    var frm = document.getElementById('frmPrint').contentWindow;
    frm.SetContainerData(jsonTable);
    frm.focus();// focus on contentWindow is needed on some ie versions
    frm.print();
    return false;
}

BCP.SDC.Presentation.GetHtmlResultPrintFields = function (title) {
    //
    var jsonTable = "";

    jsonTable += "<h2>" + title + "</h2>";

    var message = $(".alert-heading");
    jsonTable += "<h3>" + message.text() + "</h3>";

    jsonTable += "<ul>";

    $(".field", ".bs-container ").each(function () {
        var label = $(this).find(".label-left");
        var value = $(this).find(".label-right");

        jsonTable += "<li>";
        jsonTable += "<div class=\"field-label\">" + label.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "</div>";
        jsonTable += "<div class=\"field-value\">" + value.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "</div>";

        jsonTable += "</li>";
    });

    jsonTable += "<li class=\"proof-sep\"></li>";
    jsonTable += "<li class=\"proof-footer\"><div>" + BCP.SDC.Presentation.GetResource("OperationId") + "</div><div>" + $('[id$=hdnOperationId]').val() + "</div></li>";
    jsonTable += "<li class=\"proof-footer\"><div>" + BCP.SDC.Presentation.GetResource("OperationDate") + "</div><div>" + $('[id$=hdnOperationDate]').val() + "</div></li>";
    jsonTable += "<li class=\"proof-footer\"><div>" + BCP.SDC.Presentation.GetResource("PrintID") + "</div><div>" + $('[id$=hdnPrntId]').val() + "</div></li>";
    jsonTable += "<li class=\"proof-footer\"><div>" + BCP.SDC.Presentation.GetResource("Date") + "</div><div>" + $('[id$=hdnPrintDate]').val() + "</div></li>";

    jsonTable += "</ul>";
    jsonTable += "<div style=\"clear: both;\"></div>";

    console.info(jsonTable);

    return jsonTable;
}

BCP.SDC.Presentation.GetHtmlPrintFields = function (title) {
    var jsonTable = "";

    jsonTable += "<h2>" + title + "</h2>";

    jsonTable += "<ul>";

    var selectedId;
    if ($(".slider_tab_menu") != undefined) {
        $("li", ".slider_tab_menu").each(function () {
            if ($(this).hasClass("selected")) {
                selectedId = $(this).attr("id");
                return false;
            }
        });
    }
    console.info(selectedId);

    if (selectedId != undefined) {
        $(".field-proof", "[id$=container_" + selectedId + "]").each(function () {
            var label = $(this).find(".field-proof-label");
            var value = $(this).find(".field-proof-value");
            var smsvalue = $(this).find(".field-proof-sms");
            var currency = $(this).find(".field-proof-currency");
            jsonTable += "<li>";
            jsonTable += "<div class=\"field-label\">" + label.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "</div>";
            if (currency != undefined) {
                jsonTable += "<div class=\"field-value\">" + value.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + " " + currency.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "</div>";
            }
            else
                jsonTable += "<div class=\"field-value\">" + value.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "</div>";
            jsonTable += "</li>";
        });
    }
    else {
        $(".field-proof-title", "#container_generic").each(function () {
            jsonTable += "<li>";
            jsonTable += "<div class=\"field-title\">" + $(this).text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "</div>";
            jsonTable += "</li>";
        });

        $(".field-proof", "#container_generic").each(function () {
            var label = $(this).find(".field-proof-label");
            var value = $(this).find(".field-proof-value");
            var currency = $(this).find(".field-proof-currency");
            var smsvalue = $(this).find(".field-proof-sms");
            jsonTable += "<li>";
            jsonTable += "<div class=\"field-label\">" + label.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "</div>";
            if (currency != undefined) {
                jsonTable += "<div class=\"field-value\">" + value.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + " " + currency.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "</div>";
            }
            else
                jsonTable += "<div class=\"field-value\">" + value.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "</div>";
            jsonTable += "</li>";
        });
    }

    jsonTable += "<li class=\"proof-sep\"></li>";
    jsonTable += "<li class=\"proof-footer\"><div>" + BCP.SDC.Presentation.GetResource("PrintID") + "</div><div>" + $('[id$=hdnPrntId]').val() + "</div></li>";
    jsonTable += "<li class=\"proof-footer\"><div>" + BCP.SDC.Presentation.GetResource("Date") + "</div><div>" + $('[id$=hdnPrintDate]').val() + "</div></li>";

    jsonTable += "</ul>";
    jsonTable += "<div style=\"clear: both;\"></div>";

    return jsonTable;
}

BCP.SDC.Presentation.GetPrintFieldsPDF = function (title) {
    var jsonTable = "[";

    var textTitle = "TITLE";
    jsonTable += "{\"key\":\"" + textTitle + "\",\"evalues\":[";
    jsonTable += "{\"val\": \"" + title.replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\"},";
    jsonTable = jsonTable.replace(/,*$/, "");
    jsonTable += "]},";

    var textReturn = "RETURN";
    jsonTable += "{\"key\":\"" + textReturn + "\",\"evalues\":[";
    var contentMessage = $(".content-message");
    if (contentMessage != undefined) {
        jsonTable += "{\"val\":\"" + contentMessage.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\"},";
    }
    else
        jsonTable += "{\"val\":\"\"},";
    jsonTable = jsonTable.replace(/,*$/, "");
    jsonTable += "]},";

    jsonTable += BCP.SDC.Presentation.GetPrintFields(title);

    jsonTable += "]";

    return jsonTable;
}

BCP.SDC.Presentation.GetPrintFields = function (title) {


    var jsonTable = "";

    var textTBody = "TBODYDETAIL";
    jsonTable += "{\"title\":\"" + title + "\",";
    jsonTable += "\"printId\":\"" + $('[id$=hdnPrntId]').val() + "\",";
    jsonTable += "\"operationDate\":\"" + $('[id$=hdnOperationDate]').val() + "\",";
    jsonTable += "\"operationId\":\"" + $('[id$=hdnOperationId]').val() + "\",";
    jsonTable += "\"printDate\":\"" + $('[id$=hdnPrintDate]').val() + "\",";

    jsonTable += "\"key\":\"" + textTBody + "\",\"evalues\":[";

    var selectedId;
    if ($(".slider_tab_menu") != undefined) {
        $("li", ".slider_tab_menu").each(function () {
            if ($(this).hasClass("selected")) {
                selectedId = $(this).attr("id");
                return false;
            }
        });
    }
    console.info(selectedId);

    if (selectedId != undefined) {

        var statementDetailPanel = $("[id$=container_statement_details]");

        if (selectedId == "statements" && statementDetailPanel.is(":visible")) {
            //
            $(".field-proof", "#container_statement_details").each(function () {
                if ($(this).is(":visible")) {
                    var label = $(this).find(".field-proof-label");
                    var value = $(this).find(".field-proof-value");
                    var valuesms = $(this).find(".field-proof-sms");

                    var number = $(this).find(".field-proof-sms-1");
                    var nib = $(this).find(".field-proof-sms-2");
                    var iban = $(this).find(".field-proof-sms-3");
                    var swift = $(this).find(".field-proof-sms-4");
                    var name = $(this).find(".field-proof-sms-5");

                    var currency = $(this).find(".field-proof-currency");
                    jsonTable += "{\"Text\":\"" + label.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\",";
                    jsonTable += "\"val\":\"" + value.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\",";
                    if (valuesms != undefined && valuesms.html() != undefined) {
                        jsonTable += "\"smsv\":\"" + valuesms.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\",";
                        if (number != undefined && number.html() != undefined) {
                            jsonTable += "\"typ\":1,";
                        }
                        else if (nib != undefined && nib.html() != undefined) {
                            jsonTable += "\"typ\":2,";
                        }
                        else if (iban != undefined && iban.html() != undefined) {
                            jsonTable += "\"typ\":3,";
                        }
                        else if (swift != undefined && swift.html() != undefined) {
                            jsonTable += "\"typ\":4,";
                        }
                        else if (name != undefined && name.html() != undefined) {
                            jsonTable += "\"typ\":5,";
                        }
                    }
                    else {
                        jsonTable += "\"smsv\":null,";
                        jsonTable += "\"typ\":0";
                        if (currency != undefined) {
                            jsonTable += ",";
                        }
                    }
                    if (currency != undefined) {
                        jsonTable += "\"curr\":\"" + currency.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\"},";
                    }
                    else
                        jsonTable += "}";

                    jsonTable = jsonTable.replace(/,*$/, "");
                    jsonTable += ",";
                }
            });
        }
        else {
            $(".field-proof", "[id$=container_" + selectedId + "]").each(function () {
                var label = $(this).find(".field-proof-label");
                var value = $(this).find(".field-proof-value");
                var valuesms = $(this).find(".field-proof-sms");

                var number = $(this).find(".field-proof-sms-1");
                var nib = $(this).find(".field-proof-sms-2");
                var iban = $(this).find(".field-proof-sms-3");
                var swift = $(this).find(".field-proof-sms-4");
                var name = $(this).find(".field-proof-sms-5");

                var currency = $(this).find(".field-proof-currency");
                jsonTable += "{\"Text\":\"" + label.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\",";
                jsonTable += "\"val\":\"" + value.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ").replace(/<br\s*\/?>/mg, "\\n") + "\",";
                if (valuesms != undefined && valuesms.html() != undefined) {
                    jsonTable += "\"smsv\":\"" + valuesms.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ").replace(/<br\s*\/?>/mg, "\\n") + "\",";
                    if (number != undefined && number.html() != undefined) {
                        jsonTable += "\"typ\":1,";
                    }
                    else if (nib != undefined && nib.html() != undefined) {
                        jsonTable += "\"typ\":2,";
                    }
                    else if (iban != undefined && iban.html() != undefined) {
                        jsonTable += "\"typ\":3,";
                    }
                    else if (swift != undefined && swift.html() != undefined) {
                        jsonTable += "\"typ\":4,";
                    }
                    else if (name != undefined && name.html() != undefined) {
                        jsonTable += "\"typ\":5,";
                    }
                }
                else {
                    jsonTable += "\"smsv\":null,";
                    jsonTable += "\"typ\":0";
                    if (currency != undefined) {
                        jsonTable += ",";
                    }
                }
                if (currency != undefined) {
                    jsonTable += "\"curr\":\"" + currency.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\"},";
                }
                else
                    jsonTable += "}";

                jsonTable = jsonTable.replace(/,*$/, "");
                jsonTable += ",";
            });
        }
    }
    else {

        $(".field-proof-title", "#container_generic").each(function () {
            jsonTable += "{\"Text\":\"\",";
            jsonTable += "\"val\":\"\",";
            jsonTable += "\"Title\":\"" + $(this).text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\",";
            jsonTable += "\"curr\":\"\"";
            jsonTable += "},";
        });

        $(".field-proof", "#container_generic").each(function () {
            var label = $(this).find(".field-proof-label");
            var value = $(this).find(".field-proof-value");
            var valuesms = $(this).find(".field-proof-sms");
            var currency = $(this).find(".field-proof-currency");

            var number = $(this).find(".field-proof-sms-1");
            var nib = $(this).find(".field-proof-sms-2");
            var iban = $(this).find(".field-proof-sms-3");
            var swift = $(this).find(".field-proof-sms-4");
            var name = $(this).find(".field-proof-sms-5");

            jsonTable += "{\"Text\":\"" + label.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\",";
            jsonTable += "\"val\":\"" + value.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\",";
            if (valuesms != undefined && valuesms.html() != undefined) {
                jsonTable += "\"smsv\":\"" + valuesms.html().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\",";
                if (number != undefined && number.html() != undefined) {
                    jsonTable += "\"typ\":1,";
                }
                else if (nib != undefined && nib.html() != undefined) {
                    jsonTable += "\"typ\":2,";
                }
                else if (iban != undefined && iban.html() != undefined) {
                    jsonTable += "\"typ\":3,";
                }
                else if (swift != undefined && swift.html() != undefined) {
                    jsonTable += "\"typ\":4,";
                }
                else if (name != undefined && name.html() != undefined) {
                    jsonTable += "\"typ\":5,";
                }
            }
            else {
                jsonTable += "\"smsv\":null,";
                jsonTable += "\"typ\":0";
                if (currency != undefined) {
                    jsonTable += ",";
                }
            }
            if (currency != undefined) {
                jsonTable += "\"curr\":\"" + currency.text().replace(/(\r\n|\n|\r)/gm, " ").replace(/\s+/g, " ") + "\"},";
            }
            else
                jsonTable += "}";

            jsonTable = jsonTable.replace(/,*$/, "");
            jsonTable += ",";
        });
    }

    jsonTable = jsonTable.replace(/,*$/, "");
    jsonTable += "]}";

    jsonTable = jsonTable.replace(/,*$/, "");
    console.info(jsonTable);

    $('[id$=hdnToJSON]').val(jsonTable);

    return jsonTable;
}

BCP.SDC.Presentation.StripHTML = function (dirtyString) {
    var container = document.createElement('div');
    container.innerHTML = dirtyString;
    return container.textContent.replace(/<(?:.|\n)*?>/gm, '') || container.innerText.replace(/<(?:.|\n)*?>/gm, '');
}

BCP.SDC.Presentation.SendOperation = function (proofType, email, title, interactionid, lnkproof, lnkcloseproof, divProofContainer, divProofSuccess, divWaitProof, divProofError) 
{
    //


    divWaitProof.show();
    divProofContainer.hide();
    divProofError.hide();
    divProofSuccess.hide();
    
   // var jsonTable = $('[id$=hdnToJSON]').val();

    var url = "services.axd?Method=SendEmail";
    var listData = "&email=" + encodeURIComponent(email) // + "&jt=" + encodeURIComponent(BCP.SDC.Presentation.StripHTML(jsonTable)); // + "&rm="
    $.ajax({
        type: "POST",
        url: url + listData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
       // data: jsonTable,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Accept", "text/javascript, application/javascript, */*, text/javascript,application/javascript,text/html");
            xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
        },
        success: function (sended) {
            if (sended == "True") {
                //
                divWaitProof.hide();
                divProofSuccess.show();
                divWaitProof.hide();
                divProofContainer.hide();
            }
            else {
                divWaitProof.hide();
                divProofSuccess.hide();
                divProofError.show();
                divProofContainer.show();
            }
        },
        error: function (XMLHttpRequest) {
            //
            divWaitProof.hide();
            divProofSuccess.hide();
            divProofError.show();
            divProofContainer.show();
        }
    });
}

BCP.SDC.Presentation.Send = function (proofType, email, title, interactionid, lnkproof, lnkcloseproof, divProofContainer, divProofSuccess, divWaitProof, divProofError) {
    //

    divWaitProof.show();
    divProofContainer.hide();
    divProofError.hide();
    divProofSuccess.hide();
   
    var jsonTable = BCP.SDC.Presentation.GetPrintFields(title);
    
    var myEscapedjSOsTRING = jsonTable.replace(/\\n/g, "\\n")
                                      .replace(/\\'/g, "\\")
                                      .replace(/\\"/g, '\\"')
                                      .replace(/\\&/g, "\\&")
                                      .replace(/\\r/g, "\\r")
                                      .replace(/\\t/g, "\\t")
                                      .replace(/\\b/g, "\\b")
                                      .replace(/\\f/g, "\\f");

    var url = "services.axd?Method=SendEmail";

    var listData = "&email=" + encodeURIComponent(email)  // + "&jt=" + encodeURIComponent(jsonTable);
    $.ajax({
        type: "POST",
        url: url + listData,
        contentType: "application/text; charset=utf-8",
        dataType: "json",
        data: btoa(myEscapedjSOsTRING),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Accept", "text/javascript, application/javascript, */*, text/javascript,application/javascript,text/html");
            xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
        },
        success: function (sended) {
            if (sended == "True") {
                //
                divWaitProof.hide();
                divProofSuccess.show();
                divWaitProof.hide();
                divProofContainer.hide();
            }
            else {
                divWaitProof.hide();
                divProofSuccess.hide();
                divProofError.show();
                divProofContainer.show();
            }
        },
        error: function (XMLHttpRequest) {
            //
            divWaitProof.hide();
            divProofSuccess.hide();
            divProofError.show();
            divProofContainer.show();
        }
    });
}

BCP.SDC.Presentation.SendSMS = function (proofType, email, title, interactionid, lnkproof, lnkcloseproof, divProofContainer, divProofSuccess, divWaitProof, divProofError, trxId) {
    //
    divWaitProof.show();
    divProofContainer.hide();
    divProofError.hide();
    divProofSuccess.hide();

    var jsonTable = BCP.SDC.Presentation.GetPrintFields(title);

    var url = "services.axd?Method=SendSMS";
    var listData = "&tr=" + encodeURIComponent(trxId); //"&jt=" + encodeURIComponent(jsonTable) +
    $.ajax({
        type: "POST",
        url: url + listData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: jsonTable,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Accept", "text/javascript, application/javascript, */*, text/javascript,application/javascript,text/html");
            xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
        },
        success: function (sended) {
            if (sended == "True") {
                //
                divWaitProof.hide();
                divProofSuccess.show();
                divWaitProof.hide();
                divProofContainer.hide();
            }
            else {
                divWaitProof.hide();
                divProofSuccess.hide();
                divProofError.show();
                divProofContainer.show();
            }
        },
        error: function (XMLHttpRequest) {
            //
            divWaitProof.hide();
            divProofSuccess.hide();
            divProofError.show();
            divProofContainer.show();
        }
    });
}