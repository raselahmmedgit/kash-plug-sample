﻿
//-----------------------------------------------------
//start Ajax Get Methods

function AjaxJsonGet(getUrl) {

    $.ajax({
        url: getUrl,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            OpenAppProgressWindow();
        },
        success: function (result) {
            var messageType = result.messageType;
            var messageText = result.messageText;
            LoadAppMessageWindow(messageType, messageText);
        },
        error: function (objAjaxRequest, strError) {
            var respText = objAjaxRequest.responseText;
            var messageText = respText;
            LoadErrorAppMessageWindowWithText(messageText);
        }

    });

}

function AjaxJsonGetWithParam(getUrl, paramValue) {

    $.ajax({
        url: getUrl,
        type: 'GET',
        dataType: 'json',
        data: paramValue,
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            OpenAppProgressWindow();
        },
        success: function (result) {
            var messageType = result.messageType;
            var messageText = result.messageText;
            LoadAppMessageWindow(messageType, messageText);
        },
        error: function (objAjaxRequest, strError) {
            var respText = objAjaxRequest.responseText;
            var messageText = respText;
            LoadErrorAppMessageWindowWithText(messageText);
        }

    });

}

//end Ajax Get Methods
//-----------------------------------------------------

//-----------------------------------------------------
//start Ajax Post Methods

function AjaxJsonPost(postUrl) {

    $.ajax({
        url: postUrl,
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            OpenAppProgressWindow();
        },
        success: function (result) {
            var messageType = result.messageType;
            var messageText = result.messageText;
            LoadAppMessageWindow(messageType, messageText);
        },
        error: function (objAjaxRequest, strError) {
            var respText = objAjaxRequest.responseText;
            var messageText = respText;
            LoadErrorAppMessageWindowWithText(messageText);
        }

    });

}

function AjaxJsonPostWithParam(postUrl, paramValue) {

    $.ajax({
        url: postUrl,
        type: 'POST',
        dataType: 'json',
        data: paramValue,
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            OpenAppProgressWindow();
        },
        success: function (result) {
            var messageType = result.messageType;
            var messageText = result.messageText;
            LoadAppMessageWindow(messageType, messageText);
        },
        error: function (objAjaxRequest, strError) {
            var respText = objAjaxRequest.responseText;
            var messageText = respText;
            LoadErrorAppMessageWindowWithText(messageText);
        }

    });

}

//end Ajax Post Methods
//-----------------------------------------------------

//-----------------------------------------------------
//start Common
function AppCommonWindowBegin() {

    OpenAppProgressWindow();

}

function AppCommonWindowComplete() {

    CloseAppProgressWindow();

}

function AppCommonWindowSuccess() {

    var updateTargetIdValue = $("#updateTargetId").html().trim();

    var updateTargetIdValueList = updateTargetIdValue.split("|");

    var statusValue = updateTargetIdValueList[0];
    var messageTypeValue = updateTargetIdValueList[1];
    var messageTextValue = updateTargetIdValueList[2];

    if (statusValue == "True") {

        //close kendo ui window
        CloseAppCommonWindow();

        LoadAppMessageWindow(messageTypeValue, messageTextValue);

    }
    else {

        $("#updateTargetId").html("");
        $("#updateTargetId").html(messageTextValue);
        $("#updateTargetId").show();
    }
}

function AppCommonWindowFormValidation(fromId) {

    //validation
    var $form = $("#" + fromId);
    // Unbind existing validation
    $form.unbind();
    $form.data("validator", null);
    // Check document for changes
    $.validator.unobtrusive.parse(document);
    // Re add validation with changes
    $form.validate($form.data("unobtrusiveValidation").options);

}

function LoadAddOrEditAppCommonWindow(viewUrl, windowTitle, windowForm) {

    TitleAppCommonWindow(windowTitle);

    $.get(viewUrl, function (data) {

        //kendo ui window content
        ContentAppCommonWindow(data);

        AppCommonWindowFormValidation(windowForm);

        //kendo ui window open
        OpenAppCommonWindow();
    });

};

function LoadDetailsAppCommonWindow(viewUrl, windowTitle, windowForm) {

    TitleAppCommonWindow(windowTitle);

    $.get(viewUrl, function (data) {

        //kendo ui window content
        ContentAppCommonWindow(data);

        //kendo ui window open
        OpenAppCommonWindow();
    });

};

function LoadAppCommonWindow(viewUrl, windowTitle, windowForm) {

    TitleAppCommonWindow(windowTitle);

    $.get(viewUrl, function (data) {

        //kendo ui window content
        ContentAppCommonWindow(data);

        AppCommonWindowFormValidation(windowForm);

        //kendo ui window open
        OpenAppCommonWindow();
    });

};

function TitleAppCommonWindow(title) {

    //title kendo ui window
    $("#appCommonWindow").data("kendoWindow").title(title);
}

function ContentAppCommonWindow(content) {

    //content kendo ui window
    $("#appCommonWindow").data("kendoWindow").content(content);

}

function OpenAppCommonWindow() {

    //open kendo ui window
    $("#appCommonWindow").data("kendoWindow").center().open();

}

function CloseAppCommonWindow() {

    //open kendo ui window
    $("#appCommonWindow").data("kendoWindow").close();

}
//end Common
//-----------------------------------------------------

//-----------------------------------------------------
//start Delete
function LoadAppDeleteWindow(viewUrl, windowTitle) {

    TitleAppDeleteWindow(windowTitle);

    //hidden field value
    $("#hdDeleteId").val("");
    $("#hdDeletePostUrl").val("");
    $("#hdDeleteId").val(viewUrl);
    $("#hdDeletePostUrl").val(viewUrl);

    //kendo ui window open
    OpenAppDeleteWindow();

};

function TitleAppDeleteWindow(title) {

    //title kendo ui window
    $("#appDeleteWindow").data("kendoWindow").title(title);
}

function ContentAppDeleteWindow(content) {

    //content kendo ui window
    $("#appDeleteWindow").data("kendoWindow").content(content);

}

function OpenAppDeleteWindow() {

    //open kendo ui window
    $("#appDeleteWindow").data("kendoWindow").center().open();

}

function CloseAppDeleteWindow() {

    //open kendo ui window
    $("#appDeleteWindow").data("kendoWindow").close();

}

function YesDelete() {

    var hdDeleteIdValue = $("#hdDeleteId").val().trim();
    var hdDeletePostUrlValue = $("#hdDeletePostUrl").val().trim();

    AjaxJsonPost(hdDeletePostUrlValue);

    //close kendo ui window
    CloseAppDeleteWindow();

}

function NoDelete() {

    $("#hdDeleteId").val("");
    $("#hdDeletePostUrl").val("");

    //close kendo ui window
    CloseAppDeleteWindow();

}
//end Delete
//-----------------------------------------------------

//-----------------------------------------------------
//start Message

//Info Message Window
function LoadInfoAppMessageWindowWithText(messageText) {

    var windowTitle = "Info";

    TitleAppMessageWindow(windowTitle);

    var windowContent = GetAppMessageWindowContent(windowTitle, messageText);

    ContentAppMessageWindow(windowContent);

    //kendo ui window open
    OpenAppMessageWindow();

};

//Warn Message Window
function LoadWarnAppMessageWindowWithText(messageText) {

    var windowTitle = "Warn";

    TitleAppMessageWindow(windowTitle);

    var windowContent = GetAppMessageWindowContent(windowTitle, messageText);

    ContentAppMessageWindow(windowContent);

    //kendo ui window open
    OpenAppMessageWindow();

};

//Success Message Window
function LoadSuccessAppMessageWindowWithText(messageText) {

    var windowTitle = "Success";

    TitleAppMessageWindow(windowTitle);

    var windowContent = GetAppMessageWindowContent(windowTitle, messageText);

    ContentAppMessageWindow(windowContent);

    //kendo ui window open
    OpenAppMessageWindow();

};

//Error Message Window
function LoadErrorAppMessageWindowWithText(messageText) {

    var windowTitle = "Error";

    TitleAppMessageWindow(windowTitle);

    var windowContent = GetAppMessageWindowContent(windowTitle, messageText);

    ContentAppMessageWindow(windowContent);

    //kendo ui window open
    OpenAppMessageWindow();

};

function GetAppMessageWindowContent(messageType, messageText) {

    var content = "<div class='" + messageType + "'><div>" + messageText + "</div></div>";

    return content;

}

function TitleAppMessageWindow(title) {

    var upperTitle = title.toLowerCase().replace(/\b[a-z]/g, function (letter) {
        return letter.toUpperCase();
    });

    //title kendo ui window
    $("#appMessageWindow").data("kendoWindow").title(upperTitle);
}

function ContentAppMessageWindow(content) {

    //content kendo ui window
    $("#appMessageWindow").data("kendoWindow").content(content);

}

function OpenAppMessageWindow() {

    //open kendo ui window
    $("#appMessageWindow").data("kendoWindow").center().open();

}

function CloseAppMessageWindow() {

    //open kendo ui window
    $("#appMessageWindow").data("kendoWindow").close();

}

//end Message
//-----------------------------------------------------

//-----------------------------------------------------
//start Progress

function OpenAppProgressWindow() {

    //open kendo ui window
    $("#appProgressWindow").data("kendoWindow").center().open();

}

function CloseAppProgressWindow() {

    //open kendo ui window
    $("#appProgressWindow").data("kendoWindow").close();

}

//end Progress
//-----------------------------------------------------

//-----------------------------------------------------
//start Refresh Kendo Grid Funtion
function KendoGridRefresh() {
    //Get Grid
    var kdGrid = $('#grid').data('kendoGrid');
    kdGrid.dataSource.read();
}

function KendoGridRefresh(gridId) {
    var _id = "#" + gridId;
    //Get Grid
    var kdGrid = $(_id).data('kendoGrid');
    kdGrid.dataSource.read();
}
//end Refresh Kendo Grid Funtion
//-----------------------------------------------------

$(document).ready(function () {

    $("#appCommonWindow").kendoWindow({
        //actions: ["Custom", "Minimize", "Maximize", "Close"],
        actions: ["Minimize", "Maximize", "Close"],
        draggable: true,
        modal: true,
        resizable: false,
        pinned: true,
        position: { top: 100 },
        visible: false
    })

    $("#appDeleteWindow").kendoWindow({
        actions: ["Minimize", "Maximize", "Close"],
        draggable: true,
        modal: true,
        resizable: false,
        pinned: true,
        position: { top: 100 },
        visible: false
    })

    $("#appMessageWindow").kendoWindow({
        draggable: false,
        modal: true,
        resizable: false,
        minHeight: 100,
        minWidth: 300,
        visible: false
    })

    $("#appProgressWindow").kendoWindow({
        title: false,
        draggable: false,
        modal: true,
        resizable: false,
        visible: false,
        close: function (e) {

            e.preventDefault();
            return false;

            console.log(e);

        }
    })

    //-----------------------------------------------------
    //add Common
    $('#lnkAddCommon').live('click', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var viewUrl = linkObj.attr('href');
        var windowTitle = linkObj.attr('title');
        var windowForm = "appCommonWindowForm";

        LoadAppCommonWindow(viewUrl, windowTitle, windowForm);

        return false;

    });
    //-----------------------------------------------------

    //-----------------------------------------------------
    //edit Common
    $('.lnkEditCommon').live('click', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var viewUrl = linkObj.attr('href');
        var windowTitle = linkObj.attr('title');
        var windowForm = "appCommonWindowForm";

        LoadAppCommonWindow(viewUrl, windowTitle, windowForm);

        return false;

    });
    //-----------------------------------------------------

    //-----------------------------------------------------
    //delete Common
    $('.lnkDeleteCommon').live('click', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var viewUrl = linkObj.attr('href');
        var windowTitle = linkObj.attr('title');

        LoadAppDeleteWindow(viewUrl, windowTitle);

        return false;

    });
    //-----------------------------------------------------

});