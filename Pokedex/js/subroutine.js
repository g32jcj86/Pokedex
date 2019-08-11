//< !--鍵盤輸入Enter開始搜尋-->
function keyCode(val) {
    if (val.keyCode == 13) {
        search();
    }
}
//<!--鍵盤輸入Enter開始搜尋-->

//< !--點選後跳至資訊頁-->
function jump(val) {
    document.location.href = "Paging.html?num=" + parseInt(val.id);
    document.cookie = "Number=" + val.id;
}

function jumpP(num) {
    document.location.href = "Paging.html?num=" + parseInt(num);
}

function jump2() {
    document.location.href = "Paging.html?num=1";
    document.cookie = "Number=" + "001";
}

function jumpIndex() {
    document.location.href = "index.html";
}

function goLogin() {
    document.location.href = "login.html";
}
function goRegister() {
    document.location.href = "register.html";
}

function logout() {
    document.cookie = "cName" + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
    document.cookie = "login" + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
    document.cookie = "uid" + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
    document.location.href = "index.html";
}
//<!--點選後跳至資訊頁-->


