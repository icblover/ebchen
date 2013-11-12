$(function () {

});

//级联选择特效 
function setCasCase(obj) {
    var val = $(obj).val();
    //如果是父级栏目 value值的形式如 1
    if (val.indexOf("-") <= 0) {
        //如果父栏目勾选，则子栏目也勾选
        if ($(obj).prop("checked")) {
            $('.operate[value^="' + val + '-"]').prop("checked", true);
        }
        else if (!$(obj).prop("checked")) {
            $('.operate[value^="' + val + '-"]').prop("checked", false);
        }
    }
    else {  //如果是子级栏目 value值的形式如 1-2
        val = val.substring(0, val.indexOf("-"));
        //勾选后，程式再次设定当前元素状态
        if ($(obj).prop("checked")) {
            $('.operate[value="' + val + '"]').prop("checked", true);
        }
        else if (!$(obj).prop("checked")) {
            var hasOtherCheckedFlag;
            //遍历父元素下的子元素，既 1- 元素，如果有一个子元素勾选，则父元素仍勾选
            $('.operate[value^="' + val + '-"]').each(function (index) {
                if ($($('.operate[value^="' + val + '-"]')[index]).prop("checked")) {
                    hasOtherCheckedFlag = true;
                    $(obj).prop("checked", false);
                    return false;
                } else {
                    hasOtherCheckedFlag = false;
                }
            });
            if (!hasOtherCheckedFlag) {
                $('.operate[value="' + val + '"]').prop("checked", false);
            }
        }
    }
}

//提交前获取选中值value，并拼接在一起
function setCheckValueList() {
    var idlist = "";
    $(".operate").each(function (index) {
        if ($($(".operate")[index]).prop("checked")) {
            var val = $($(".operate")[index]).val();
            if (val.indexOf("-") < 1) {
                idlist += val + ",";
            } else {
                idlist += val.substring(val.indexOf("-") + 1) + ",";
            }
        }
    });
    if (idlist.length > 1) {
        idlist = idlist.substring(0, idlist.length - 1);
    }
    $("#OperateList").val(idlist);
}