user_adverts = function (id) {
    console.log(id);
    var url = 'https://localhost:44396/api/Adverts/UserAdverts/' + id + '';
    $.getJSON(url,
        function (data) {
            adverts = Array.from(data);
            AdverdsArray(adverts);
            
        });
}
user_info = function (id) {
    var url = 'https://localhost:44396/api/Authorization/GetUserInfo/' + id + '';
    $.getJSON(url,
        function (data) {
            user = data;
            UserInfo(user);
        });
}
document.onloadstart = user_adverts(document.getElementById('UserId').value);
document.onloadstart = user_info(document.getElementById('UserId').value);

function AdverdsArray(array) {
    if (array.length != 0) {
        for (var i = 0; i < array.length; i++) {
            document.getElementById('adverts').innerHTML += '<a href="https://localhost:44382/Adverts/Details?id=' + array[i].id + '">' + array[i].name + '<br/><a/>';
        }
    }
    else {
        document.getElementById('adverts').innerHTML += '\
            <a>У вас пока нет объявлений. Вы можете перейти по\
            <a class="link" href = "https://localhost:44382/Adverts/Create" > этой </a >\
            ссылке, чтобы создать объявление.\
            <a />';
    }
}

function UserInfo(user) {
    var date = new Date(user.created);
    document.getElementById('user_info').innerHTML += '\
        <div class="form-group form-row">\
            <p class="col-5" > Имя:</p>\
            <p class="col-7 h6">'+ user.firstName +'</p>\
        </div>\
        <div class="form-group form-row">\
            <p class="col-5">Фамилия:</p>\
            <p class="col-7 h6">'+ user.lastName +'</p>\
        </div>\
        <div class="form-group form-row">\
            <p class="col-5">Номер телефона:</p>\
            <p class="col-7 h6">'+ user.phoneNumber +'</p>\
        </div>\
        <div class="form-group form-row">\
            <p class="col-5">Email:</p>\
            <p class="col-7 h6">'+ user.email +'</p>\
        </div>\
        <div class="form-group form-row">\
            <p class="col-5">Зарегистрирован:</p>\
            <p class="col-7 h6">'+ date.toLocaleDateString('ru') +'</p>\
        </div>'
}