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
    document.getElementById('UserInfo').innerHTML += '<a>имя</a>';
}