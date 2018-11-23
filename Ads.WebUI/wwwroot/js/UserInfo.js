var user;
user_info = function (id) {
    var url = 'https://localhost:44396/api/Authorization/GetUserInfo/' + id + '';
    $.getJSON(url,
        function (data) {
            user = data;
            UserInfo();
        });
}
document.onloadstart = user_info(document.getElementById('UserId').value);

function UserInfo() {
    document.getElementById('UserInfo').innerHTML += '<a class="col">Контактное лицо:<br/></a>';
    document.getElementById('UserInfo').innerHTML += '<a class="col h6">' + user.firstName +'<hr/></a>';
}

function ShowPhoneNumber() {
    if (user.phoneNumber != null) {
        document.getElementById('btn_showPhoneNumber').value = '' + user.phoneNumber + '';
        document.getElementById('btn_showPhoneNumber').className = 'btn btn-outline-primary btn-lg btn-block';
    }
    else {
        document.getElementById('btn_showPhoneNumber').value = 'Информация отсутствует';
        document.getElementById('btn_showPhoneNumber').className = 'btn btn-outline-primary btn-lg btn-block';

    }
}

function ShowEmail() {
    document.getElementById('btn_showEmail').value = '' + user.email + '';
    //document.getElementById('btn_showEmail').className = 'btn btn btn-outline-secondary btn-lg btn-block';  
}