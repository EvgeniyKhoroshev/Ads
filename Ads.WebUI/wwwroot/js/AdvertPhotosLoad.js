var API_ENDPOINT = 'https://localhost:44396/api/';
var AdvertIdList = [];
var Background;
document.onload = function () {
    GetAdvertIdList();
    LoadAdvertPhotos();
}();

function GetAdvertPhotos(advertId) {
    fetch(API_ENDPOINT + 'adverts/GetAdvertImages/' + advertId + '/')
        .then((res) => {
            if (res.status == 204) {
                SetPhotosToCarousel(null, advertId);
                return;
            }
            else (res.json().then(json => SetPhotosToCarousel(json, advertId)))
        });
}
function SetPhotosToCarousel(photos, AdvertId) {
    var photoActive = document.getElementsByClassName('carousel-inner ' + AdvertId);
    var photoLi = document.getElementsByClassName('carousel-indicators ' + AdvertId);
    photoActive.innerHTML = '';
    if (photos == null) {
        photoActive[0].innerHTML = '<div class="carousel-item ' + AdvertId + ' active"><img class="d-block w-100" id="' + Background + '"width="560" height="350" src="/images/default.jpg" alt="Default image" /></div>';
        return;
    }
    var count = photos.length;
    photoLi[0].innerHTML = '<li data-target="#advert' + AdvertId + '" data-slide-to="0" class="active"></li>';
    photoActive[0].innerHTML = ''; 
    var i = 1;
    for (i; i < count; ++i)
        photoLi[0].innerHTML += '<li data-target="#advert' + AdvertId + '" data-slide-to="' + i + '"></li>';
    i = 0;
    photos[i].content = 'data:image/png;base64,' + photos[i].content;
    photoActive[0].innerHTML += '<div class="carousel-item active ' + AdvertId + '"><img class="d-block w-100" id="' + Background + '" width="560" height="350" src="' + photos[i].content + '" alt="Default image" /></div>';
    i++;
    for (i; i < count; ++i) 
    {
        photos[i].content = 'data:image/png;base64,' + photos[i].content;

        photoActive[0].innerHTML += '<div class="carousel-item ' + AdvertId + '"><img class="d-block w-100" id="' + Background + '" width="560" height="350" src="' + photos[i].content + '" alt="Default image" /></div>';
    }
}

function GetAdvertIdList() {
    var advIdList = [];
    var buf = document.getElementsByClassName('carousel slide');
    for (var i = 0; i < buf.length; ++i) {
        advIdList.push(buf[i].id.substr(6)); 
    }
    if (advIdList.length > 1)
        Background = "index";
    else
        Background = "details";
    AdvertIdList = advIdList;
}

function LoadAdvertPhotos() {
    var count = AdvertIdList.length;
    for (var i = 0; i < count; ++i) {
        GetAdvertPhotos(AdvertIdList[i]);
    }
}