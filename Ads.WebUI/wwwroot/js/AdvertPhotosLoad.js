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
function GetAdvertPhotos(advertId) {
    fetch(API_ENDPOINT + 'adverts/GetAdvertImages/' + advertId + '/')
        .then(res => res.json())
        .then(json => SetPhotosToCarousel(json));
}
function SetPhotosToCarousel(photos) {
    var photoContainer = document.getElementsByClassName(photos.advertId)[0];
    for (var i in photos)
        console.log(photos[i]);

}