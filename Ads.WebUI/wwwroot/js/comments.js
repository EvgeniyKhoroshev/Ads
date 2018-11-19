// Fetching comments from the API
var CommentsTagName = 'advert_comments';
var comments;
var CurrentUserId;
FetchComments = function (id) {
    var f = 'https://localhost:44382/adverts/' + id + '/comments/';
    categories = fetch(f)
        .then(response => response.json())
        .then(json => comments = json)
        .then(() => display_comments());
}
document.onload = FetchComments(document.getElementsByClassName('AdvertId')[0].value);
function display_comments() {
    CurrentUserId = document.getElementsByClassName('UserId')[0].value;
    var i = 0;
    if (comments.length > 0)
        for (i; i < comments.length; ++i) {
            ShowComment(comments[i]);
        }
    else {
        document.getElementById(CommentsTagName).innerHTML = '<p>Комментариев пока нет. </p> ';
    }
}
// func to show comments in html
function ShowComment(comment) {
    var s = document.getElementById(CommentsTagName).innerHTML;
    var date = comment.created.split('T')[0];
    var time = comment.created.split('T')[1].split(':');
    if (CurrentUserId == comment.userId) {
        document.getElementById(CommentsTagName).innerHTML = '\
            <li class="list-group-item nav-item" id='+ comment.id + ' style="margin-top:10px;">\
            <p class="CommentBody">'+ comment.body + '</p> <hr/>\
            <p>'+ date + ' ' + time[0] + ':' + time[1] + ' ' + comment.rating + ' \
            <br/>\
            <button class="btn btn-primary comment" onclick="DeleteComment('+ comment.id + ')">Удалить комментарий</button>\
            <button class="btn btn-primary comment" onclick="ShowEditComment('+ comment.id + ')">Редактировать комментарий</button>\
            </p ></li > ';
    }
    else {
        document.getElementById(CommentsTagName).innerHTML = '\
            <li class="list-group-item nav-item" id='+ comment.id + ' style="margin-top:10px;">\
            <p class="CommentBody">'+ comment.body + '</p> <hr/>\
            <p>'+ date + ' ' + time[0] + ':' + time[1] + ' ' + comment.rating + ' \
            </p > <hr /></li > ';
    }
    if (s != '')
        document.getElementById(CommentsTagName).innerHTML += s;
}

function ShowEditComment(commentId) {
    var comment = GetCommentByID(commentId);
    document.getElementById(commentId).innerHTML = 'Редактирование комментария: \
    <input id="Body" class="form-control" value="' + comment.body + '" /><br/>\
    <button class="btn btn-primary comment" onclick="UpdateComment('+ comment.id + ')">Сохранить изменения</button>\
    <button class="btn btn-primary comment" onclick="CancelEdition('+ comment.id + ')">Отменить изменения</button>';
}
function UpdateComment(commentId) {
    var commentIndex;
    for (commentIndex in comments)
        if (comments[commentIndex].id == commentId) {
            break;
        }
    var buf = comments[commentIndex];
    if (buf.id != 0)
        buf.body = document.getElementsByTagName('input').Body.value;
    fetch('https://localhost:44382/comments/saveorupdate', {
        method: 'POST',
        body: JSON.stringify(buf),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then((json) => {
            document.getElementById(commentId).id = json.id;
            comments[commentIndex] = json;
            CancelEdition(json.id);
        });
}
function CancelEdition(commentId) {
    var comment = GetCommentByID(commentId);
    var date = comment.created.split('T')[0];
    var time = comment.created.split('T')[1].split(':');
    document.getElementById(commentId).innerHTML = '\
    <p class="CommentBody">'+ comment.body + '</p> <hr />\
    <p>'+ date + ' ' + time[0] + ':' + time[1] + ' ' + comment.rating + ' \
            <br />\
            <button class="btn btn-primary comment" onclick="DeleteComment('+ comment.id + ')">Удалить комментарий</button>\
            <button class="btn btn-primary comment" onclick="EditComment('+ comment.id + ')">Редактировать комментарий</button>\
    </p >';
}
// Deleting the comment.
function DeleteComment(commentId) {
    var commentIndex;
    for (commentIndex in comments)
        if (comments[commentIndex].id == commentId) {
            break;
        }    fetch('https://localhost:44382/comments/deletecomment/', {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        },
            body: JSON.stringify(comments[commentIndex])
    })
        .then(() => {
            document.getElementById(comments[commentIndex].id).innerHTML = '\
                <button class="btn btn-primary" onclick="UpdateComment(0)">Восстановить комментарий.</button>';
            document.getElementById(comments[commentIndex].id).id = 0;
            comments[commentIndex].id = 0;
        });
}
function add_comment() {
    var body = document.getElementsByName('Body')[0].value;
    var advertId = document.getElementsByName('AdvertId')[0].value;
    var comment = { 'Body': body, 'AdvertId': advertId };
    fetch('https://localhost:44382/comments/saveorupdate', {
        method: 'POST',
        body: JSON.stringify(comment),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(res => res.json())
        .then(json => ShowComment(json));
}
function GetCommentByID(commentId) {
    for (var i in comments)
        if (comments[i].id == commentId)
            return comments[i];
}
//// Fetching comments from the API
//var CommentsTagName = 'advert_comments';
//var comments;
//fetch_info = function (id) {
//    var f = 'https://localhost:44382/adverts/' + id + '/comments/';
//    categories = fetch(f)
//        .then(response => response.json())
//        .then(json => comments = json)
//        .then(() => display_comments());
//}
//document.onload = fetch_info(document.getElementById('comment_id').value);

//function display_comments() {
//    var i = 0;
//    if (comments.length > 0)
//        for (i; i < comments.length; ++i) {
//            ShowComment(comments)
//        }
//    else {
//        document.getElementById(CommentsTagName).innerHTML = '<p>Комментариев пока нет. </p> ';
//    }
//}

//function ShowComment(comment) {
//    var s = document.getElementById(CommentsTagName).value;
//    document.getElementById(CommentsTagName).innerHTML = '\
//            <li class="list-group-item nav-item" style="margin-top:10px;">\
//            <p>'+ comment.body + '</p> <hr/>\
//            <p>'+ comment.created + ' ' + comments.rating + ' ' + '</p><hr/></li>' + s;
//}
//function add_comment() {
//    var body = document.getElementsByName('Body')[0].value;
//    var advertId = document.getElementsByName('AdvertId')[0].value;
//    var comment = { 'Body': body, 'AdvertId': advertId };
//    fetch('https://localhost:44382/comments/saveorupdate', {
//        method: 'POST',
//        body: JSON.stringify(comment), // data can be `string` or {object}!
//        headers: {
//            'Content-Type': 'application/json'
//        }
//    })
//        .then(res => res.json())
//        .then(function (json) {
//            ShowComment(json);
//        }
//        );
//}