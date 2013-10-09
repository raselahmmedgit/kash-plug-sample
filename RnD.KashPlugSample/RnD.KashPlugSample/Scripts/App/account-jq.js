//-----------------------------------------------------
//start Add, Edit, Delete - Success Funtion
// Add Account Success Function
function AddAccountSuccess() {
    alert("AddAccountSuccess");
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#addAccountDialog').dialog('close');
        //twitter type notification
        $('#commonMessage').html("Account Added.");
        $('#commonMessage').delay(400).slideDown(400).delay(3000).slideUp(400);
        //Refresh Kendo Grid
        KendoGridRefresh();
    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Edit Account Success Function
function EditAccountSuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#editAccountDialog').dialog('close');
        //twitter type notification
        $('#commonMessage').html("Account Updated.");
        $('#commonMessage').delay(400).slideDown(400).delay(3000).slideUp(400);
        //Refresh Kendo Grid
        KendoGridRefresh();
    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Delete Account Success Function
function DeleteAccountSuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#deleteAccountDialog').dialog('close');
        //twitter type notification
        $('#commonMessage').html("Task deleted");
        $('#commonMessage').delay(400).slideDown(400).delay(3000).slideUp(400);
        //Refresh Kendo Grid
        KendoGridRefresh();
    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}
//end Add, Edit, Delete - Success Funtion
//-----------------------------------------------------

//-----------------------------------------------------
//start Refresh Kendo Grid Funtion
function KendoGridRefresh() {
    //Get Account Grid
    var catGrid = $('#categoryGrid').data('kendoGrid');
    catGrid.dataSource.read();
}
//end Refresh Kendo Grid Funtion
//-----------------------------------------------------

$(document).ready(function () {

    //-------------------------------------------------------
    //start Add, Edit, Delete - Dialog, Click Event

    $("#addAccountDialog").dialog({
        autoOpen: false,
        width: 600,
        resizable: false,
        modal: true,
        buttons: {
            "Add": function () {
                //make sure there is nothing on the message before we continue 
                $("#updateTargetId").html('');
                $("#addAccountForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    //add Account
    $('.lnkAddAccount').live('click', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#addAccountDialog');
        var viewUrl = linkObj.attr('href');

        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#addAccountForm");
            // Unbind existing validation
            $form.unbind();
            $form.data("validator", null);
            // Check document for changes
            $.validator.unobtrusive.parse(document);
            // Re add validation with changes
            $form.validate($form.data("unobtrusiveValidation").options);
            //open dialog
            dialogDiv.dialog('open');
        });
        return false;

    });

    //edit Account
    $("#editAccountDialog").dialog({
        autoOpen: false,
        width: 600,
        resizable: false,
        closeOnEscape: false,
        modal: true,
        close: function (event, ui) {
            $(".popover").hide();
        },
        buttons: {
            "Edit": function () {
                //make sure there is nothing on the message before we continue   
                $("#updateTargetId").html('');
                $("#editAccountForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }

    });

    $('#categoryGrid tbody tr td a.lnkEditAccount').live('click', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#editAccountDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#editAccountForm");
            // Unbind existing validation
            $form.unbind();
            $form.data("validator", null);
            // Check document for changes
            $.validator.unobtrusive.parse(document);
            // Re add validation with changes
            $form.validate($form.data("unobtrusiveValidation").options);
            //open dialog
            dialogDiv.dialog('open');
        });
        return false;

    });

    //delete Account
    $("#deleteAccountDialog").dialog({
        autoOpen: false,
        width: 600,
        resizable: false,
        modal: true,
        buttons: {
            "Yes": function () {
                //make sure there is nothing on the message before we continue                         
                $("#updateTargetId").html('');
                $("#deleteAccountForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#categoryGrid tbody tr td a.lnkDeleteAccount').live('click', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#deleteAccountDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#deleteAccountForm");
            // Unbind existing validation
            $form.unbind();
            $form.data("validator", null);
            // Check document for changes
            $.validator.unobtrusive.parse(document);
            // Re add validation with changes
            $form.validate($form.data("unobtrusiveValidation").options);
            //open dialog
            dialogDiv.dialog('open');
        });
        return false;

    });

    //For details Account
    $("#detailsAccountDailog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true,
        buttons: {
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#categoryGrid tbody tr td a.lnkDetailAccount').live('click', function () {

        var linkObj = $(this);
        var dialogDiv = $('#detailsAccountDailog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            dialogDiv.dialog('open');
        });
        return false;

    });

    //end Add, Edit, Delete - Dialog, Click Event
    //-------------------------------------------------------

});