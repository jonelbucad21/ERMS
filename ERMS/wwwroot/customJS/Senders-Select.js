$(function () {
    var senderSelect = $("#Sender-Select");
    $.ajax({
        type: "GET",
        url: "api/Senders",
        success: function (senders) {
            $.each(senders, function (i,sender) {
                senderSelect.append("<option>" + sender.Name + "</option>");
            });
        }

    });
});