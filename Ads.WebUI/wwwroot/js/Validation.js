var users;
$.getJSON('https://localhost:44396/api/Authorization/GetUsers',
    function (data) {
        users = data;
    });

function Validation() {
    $('.invalid-feedback').remove();
    var valid = 0;
    if (!nameValidation(document.getElementById('firstName_input')))
        valid++;
    if (!nameValidation(document.getElementById('lastName_input')))
        valid++;
    if (!phoneValidation(document.getElementById('phoneNumber_input')))
        valid++;
    if (!emailValidation(document.getElementById('email_input')))
        valid++;
    if (!loginValidation(document.getElementById('userName_input')))
        valid++;
    if (!firstPasswordValidation(document.getElementById('startPassword_input')))
        valid++;
    if (!passwordValidation(document.getElementById('startPassword_input'),
        document.getElementById('password_input')))
        valid++;
    if (valid > 0)
        return false;
    return true;
}

function nameValidation(elem) {
    if (!elem.value) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Поле обязательно к заполнению!</div>';
        return false;
    }

    if (/[^a-zA-Zа-яА-я]/.test(elem.value)) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Используйте допустимые символы (a-zA-Zа-яА-я)!</div>';
        return false;
    }

    elem.classList = 'form-control is-valid';
    return true;       
}
function phoneValidation(elem) {
    if (!phonenumber(elem.value)) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Номер введен не корректно!</div>';
        return false;
    }
    var isBusy = false;
    for (var i = 0; i < users.length; i++)
        if (elem.value == users[i].phoneNumber)
            isBusy = true;
    if (isBusy) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Этот номер уже кто-то использует.</div>';
    }
    elem.classList = 'form-control is-valid';
    return true;
}
function emailValidation(elem) {
    var valid = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if (elem.value.length == 0) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Поле обязательно к заполнению!</div>';
        return false;
    }
    if (!valid.test(elem.value)) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Email введен не корректно!</div>';
        return false;
    }
    var isBusy = false;
    for (var i = 0; i < users.length; i++)
        if (elem.value == users[i].email)
            isBusy = true;
    if (isBusy) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Этот email уже кто-то использует.</div>';
    }
    elem.classList = 'form-control is-valid';
    return true;
}
function loginValidation(elem) {
    if (elem.value.length == 0) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Поле обязательно к заполнению!</div>';
        return false;
    }
    if (/[^a-zA-Z0-9]/.test(elem.value)) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Логин введен не корректно!</div>';
        return false;
    }
    var isBusy = false;
    for (var i = 0; i < users.length; i++)
        if (elem.value == users[i].userName)
            isBusy = true;
    if (isBusy) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Этот логин уже кто-то использует.</div>';
    }
    elem.classList = 'form-control is-valid';
    return true;
}
function firstPasswordValidation(elem) {
    if (elem.value.length == 0) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Поле обязательно к заполнению!</div>';
        return false;
    }
    if (elem.value.length < 8 || elem.value.length > 16) {
        console.log(elem.value.length);
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Пароль должен содержать 8-16 символов!</div>';
        return false;
    }
    if (elem.value.search(/[A-Z]/) < 0) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Пароль должен содержать минимум один заглавный символ</div>';
        return false;
    }
    if (elem.value.search(/[0-9]/) < 0) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Пароль должен содержать минимум одну цифру</div>';
        return false;
    }
    if (elem.value.search(/[\.]/) < 0) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Пароль должен содержать "."</div>';
        return false;
    }
    
    elem.classList = 'form-control is-valid';
    return true;
}
function passwordValidation(elem, passwordElem) {
    if (passwordElem.value.length == 0) {
        passwordElem.classList = 'form-control is-invalid';
        passwordElem.parentNode.innerHTML += '<div class="invalid-feedback">Поле обязательно к заполнению!</div>';
        return false;
    }
    if (elem.value != passwordElem.value) {
        passwordElem.classList = 'form-control is-invalid';
        passwordElem.parentNode.innerHTML += '<div class="invalid-feedback">Поля не соотверствуют!</div>';
        return false;
    }
    passwordElem.classList = 'form-control is-valid';
    return true;
}
function phonenumber(inputPhoneNumber) {
    var valid = /^[\+]?[0-9]{11}$/im;
    if (inputPhoneNumber.match(valid))
        return true;
    if (inputPhoneNumber.length == 0)
        return true;

    return false;
}

function CreateAdvertValidation() {
    $('.invalid-feedback').remove();
    var valid = 0;
    if (!advertName(document.getElementById('inputName')))
        valid++;
    if (!advertCategory(document.getElementById('inputCategory')))
        valid++;
    if (!advertPrice(document.getElementById('inputPrice')))
        valid++;
    if (!advertCity(document.getElementById('inputCity')))
        valid++;

    if (valid > 0)
        return false;
    return true;
}
function advertName(elem) {
    if (!elem.value) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Поле обязательно к заполнению!</div>';
        return false;
    }
    return true;
}
function advertPrice(elem) {
    if (!elem.value) {
        elem.classList = 'form-control is-invalid';
        elem.parentNode.innerHTML += '<div class="invalid-feedback">Поле обязательно к заполнению!</div>';
        return false;
    }
    return true;
}
function advertCategory(elem) {
    if (!elem.value) {
        var selectP = document.getElementById('selectParentCategory');
        if (selectP.selectedIndex == 0 || selectP.selectedIndex == null) {
            selectP.classList = 'form-control is-invalid';
            selectP.parentNode.innerHTML += '<div class="invalid-feedback">Выбирите категорию</div>';
            return false;
        }
        var selectC = document.getElementById('selectCategories');
        if (selectC.selectedIndex == 0 || selectC.selectedIndex == null) {
            selectC.classList = 'form-control is-invalid';
            selectС.parentNode.innerHTML += '<div class="invalid-feedback">Выбирите подкатегорию</div>';
            return false;
        }
        
    }
}
function advertCity(elem) {
    if (!elem.value) {
        var selectP = document.getElementById('selectRegion');
        if (selectP.selectedIndex == 0 || selectP.selectedIndex == null) {
            selectP.classList = 'form-control is-invalid';
            selectP.parentNode.innerHTML += '<div class="invalid-feedback">Выбирите регион</div>';
            return false;
        }
        var selectC = document.getElementById('selectCity');
        if (selectC.selectedIndex == 0 || selectC == null) {
            selectC.classList = 'form-control is-invalid';
            document.getElementById('city').innerHTML += '<div class="invalid-feedback">Выбирите город</div>';
            return false;
        }

    }
}