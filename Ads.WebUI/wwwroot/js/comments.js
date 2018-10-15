// Fetching comments from the API
var CommentsTagName = 'advert_comments';
var comments;
fetch_info = function (id) {
    var f = 'https://localhost:44396/api/adverts/' + id + '/advertcomments/';
    categories = fetch(f)
        .then(response => response.json())
        .then(json => comments = json)
        .then(() => DisplayComments());
}
document.onload = fetch_info(document.getElementById('comment_id').value);

function DisplayComments() {
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