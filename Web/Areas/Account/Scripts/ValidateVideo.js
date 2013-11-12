$(function () {

    $("#validateFileBtn").click(function () {
        var file = $("#VideoPath").val();
        $.get("/Account/Video/ValidateFileExist", { file: file }, function (data) {
            if (data == 1) {
                $("#showMsg").html("<font color='green'>文件已正确放置</font>");
                $("#checkValidate").val("1");
            } else {
                $("#showMsg").html("<font color='red'>文件不存在，请检查！</font>");
                $("#hasVideo").val("0");
            }
        });
    });

    $("#pass").click(function () {
        $("#reason").hide(1000);
    });

    $("#nopass").click(function () {
        $("#reason").show(1000);
    });

    $("#checkForm").click(function () {
        if ($("#nopass").prop("checked") && $("input[name='SecondAuditReason']").val() == "") {
            alert("请填写不通过原因！");
            return false;
        }
        if ($("#checkValidate").val() != "1" || $("#hasVideo").val() == "0") {
            alert("未检测文件是否存在或放置正确，请检测！");
            return false;
        }
    });

})