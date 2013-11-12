$(function () {
    $("#pass").click(function () {
        $("#reason").hide(1000);
        $("#SecondAuditReason").val("");
    });

    $("#nopass").click(function () {
        $("#reason").show(1000);
        $("#SecondAuditReason").val($("#hidereason").val());
    });

    $("#checkForm").click(function () {
        if ($("#nopass").prop("checked") && $("#SecondAuditReason").val() == "") {
            alert("请填写不通过原因！");
            return false;
        }
    });
})