
function changeClock() {
    var d = new Date();
    document.getElementById("clock").innerHTML = "服务器时间：" + d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();
}
window.setInterval(changeClock, 1000);

function BindEnter(obj) {

    //使用document.getElementById获取到按钮对象    

    var button = document.getElementById('btnSubmit');
    if (obj.keyCode == 13) {
        button.click();
        obj.returnValue = false;
    }

}