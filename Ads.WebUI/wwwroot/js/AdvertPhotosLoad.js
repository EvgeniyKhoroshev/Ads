//@if (item.Images.Count() > 0) {
//    @foreach(var i in item.Images)
//    {
//        var src = string.Format("data:image/gif;base64,{0}", i.Content);
//        if (i == item.Images.First()) {
//            <div class="carousel-item active">
//                <img class="d-block w-100" src='@src' width="320" height="240">
//                                            </div>
//                }
//                else
//                                        {
//                    <div class="carousel-item">
//                        <img class="d-block w-100" src='@src' width="320" height="240">
//                                            </div>
//                        }
//                    }
//                }
//                else
//                                {
//                            <div class="carousel-item active">
//                                <img class="img-responsive details" width="320" height="240" src="~/images/default.jpg" alt="Default image" />
//                            </div>
//                        }
var API_ENDPOINT = 'https://localhost:44396/api/';
var AdvertId;
document.onload = GetAdvertPhotos(AdvertId = document.getElementsByClassName('AdvertId')[0].value);
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
        photoActive[0].innerHTML = '<div class="carousel-item ' + AdvertId + ' active"><img class="d-block w-100" id="details"width="560" height="350" src="/images/default.jpg" alt="Default image" /></div>';
        return;
    }
    var count = photos.length;
    var i = 0;
    photoLi[0].innerHTML = '<li data-target="' + AdvertId + '" data-slide-to="0" class="active"></li>';
    photoActive[0].innerHTML = ''; 
    ++i;
    for (i; i < count; ++i)
        photoLi[0].innerHTML += '<li data-target="' + AdvertId + '" data-slide-to="' + i + '"></li>';
    i = 0;
    photos[i].content = 'data:image/png;base64,' + photos[i].content;
    photoActive[0].innerHTML += '<div class="carousel-item active ' + AdvertId + '"><img class="d-block w-100" id="details" width="560" height="350" src="' + photos[i].content + '" alt="Default image" /></div>';
    i++;
    for (i; i < count; ++i) 
    {
        photos[i].content = 'data:image/png;base64,' + photos[i].content;

        photoActive[0].innerHTML += '<div class="carousel-item ' + AdvertId + '"><img class="d-block w-100" id="details" width="560" height="350" src="' + photos[i].content + '" alt="Default image" /></div>';
    }
        console.log(photos[i]);

}