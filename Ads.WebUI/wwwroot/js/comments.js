// Fetching comments from the API
var CommentsTagName = 'advert_comments';
var comments;
fetch_info = function (id) {
    var f = 'https://localhost:44382/adverts/' + id + '/comments/';
    categories = fetch(f)
        .then(response => response.json())
        .then(json => comments = json)
        .then(() => display_comments());
}
document.onload = fetch_info(document.getElementById('comment_id').value);

function display_comments() {
    var i = 0;
    if (comments.length > 0)
        for (i; i < comments.length; ++i) {
            document.getElementById(CommentsTagName).innerHTML += '\
            <li class="list-group-item nav-item" style="margin-top:10px;">\
            <p>'+ comments[i].body + '</p> <hr/>\
            <p>'+ comments[i].created + ' ' + comments[i].rating + ' ' + '</p><hr/></li>';

        }
    else {
        document.getElementById(CommentsTagName).innerHTML = '<p>Комментариев пока нет. </p> ';
    }
}
function add_comment() {
    var body = document.getElementById('Body').value;
    var advertId = document.getElementById('AdvertId').value;
    var o = { 'Body': body, 'AdvertId': advertId };
    //document.getElementById('add').submit();
    fetch('https://localhost:44382/adverts/' + advertId + '/comments/add/' + body + '/');
}

//, {
//    method: 'get',
//        body: JSON.stringify(o),
//            Headers: {
//        'Content-Type': 'application/jsonp',
//            'Accepts': 'application/json'
//    }
//}