var user;
fetch_user = function (id) {
    var url = 'https://localhost:44396/api/Authorization/GetUserInfo/' + id + ''; 
    user = fetch(url)
        .then(response => response.json())
        .then(json => user = json)
        .then(() => UserInfo());
}

document.onloadstart = fetch_user(document.getElementById('UserId').value);

function UserInfo() {
    console.log(user);
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