// Fetching comments from the API
var CommentsTagName = 'advert_comments';                                        // Tag to print the comments
var comments;                                                                   // Variable with a comments after FetchComments()
var CurrentUserId;                                                              // Current user Id
// F-n fetching comments from the mvc client
FetchComments = function (id) {
    var f = 'https://localhost:44382/adverts/' + id + '/comments/';
    categories = fetch(f)
        .then(response => response.json())
        .then(json => comments = json)
        .then(() => display_comments());
}
document.onload = FetchComments(document.getElementsByClassName('AdvertId')[0].value);
// F-n to display the comments to CommentsTagName tag in web page 
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
// F-n to show comments in html
function ShowComment(comment) {
    var s = document.getElementById(CommentsTagName).innerHTML;
    var date = comment.created.split('T')[0];
    var time = comment.created.split('T')[1].split(':');
    if (CurrentUserId == comment.userId) {
        document.getElementById(CommentsTagName).innerHTML = '\
            <li class="list-group-item nav-item" id='+ comment.id + ' style="margin-top:10px;">\
            <div class="comment__rating-box">\
            <span class="comment__rating-up" onclick="SetRating('+ comment.id + ', true)">&#9650;</span>\
            <span class="comment__rating-count">'+ comment.rating + '</span>\
            <span class="comment__rating-down" onclick="SetRating('+ comment.id + ', false)">&#9660;</span>\
            </div>\
            <p class="CommentBody">'+ comment.body + '</p> <hr/>\
            <p>'+ date + ' ' + time[0] + ':' + time[1] + ' \
            <br/>\
            <button class="btn btn-primary comment" onclick="DeleteComment('+ comment.id + ')">Удалить комментарий</button>\
            <button class="btn btn-primary comment" onclick="ShowEditComment('+ comment.id + ')">Редактировать комментарий</button>\
            <span class="comment__rating-box"></span>\
            </p ></li > ';
    }
    else {
        document.getElementById(CommentsTagName).innerHTML = '\
            <li class="list-group-item nav-item" id='+ comment.id + ' style="margin-top:10px;">\
            <div class="comment__rating-box">\
            <span class="comment__rating-up" onclick="SetRating('+ comment.id + ',true)">&#9650;</span>\
            <span class="comment__rating-count">'+ comment.rating + '</span>\
            <span class="comment__rating-down" onclick="SetRating('+ comment.id + ',false)">&#9660;</span>\
            </div>\
            <p class="CommentBody">'+ comment.body + '</p> <hr/>\
            <p>'+ date + ' ' + time[0] + ':' + time[1] + ' \
            </p > <hr /></li > ';
    }
    if (s != '')
        document.getElementById(CommentsTagName).innerHTML += s;
}
// On edit click function. Creating a input filled by the current comment body on the place of a current comment body text.
function ShowEditComment(commentId) {
    var comment = GetCommentByID(commentId);
    document.getElementById(commentId).innerHTML = 'Редактирование комментария: \
    <input id="Body" class="form-control" required value="' + comment.body + '" /><br/>\
    <button class="btn btn-primary comment" onclick="UpdateComment('+ comment.id + ')">Сохранить изменения</button>\
    <button class="btn btn-primary comment" onclick="CancelEdition('+ comment.id + ')">Отменить изменения</button>';
}
// On Save Changes click f-n. Trying to update the 
function RestoreComment(commentIndex) {
    document.getElementById(comments[commentIndex].id).id = 0;
    comments[commentIndex].id = 0;
    var buf = comments[commentIndex];

    fetch('https://localhost:44382/comments/saveorupdate', {
        method: 'POST',
        body: JSON.stringify(buf),
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then((json) => {
            document.getElementById(0).id = json.id;
            comments[commentIndex] = json;
            CancelEdition(json.id);
        });
}
// On Save Changes click f-n. Trying to update the 
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
        mode: 'cors',
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
        } fetch('https://localhost:44382/comments/deletecomment/', {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(comments[commentIndex])
        })
            .then(() => {
                document.getElementById(comments[commentIndex].id).innerHTML = '\
                <button class="btn btn-primary" onclick=" RestoreComment('+ commentIndex + ')">Восстановить комментарий.</button>';
            });
}
function add_comment() {
    var body = document.getElementsByName('Body')[0].value;
    document.getElementsByName('Body')[0] = '';
    var advertId = document.getElementsByName('AdvertId')[0].value;
    var comment = { 'Body': body, 'AdvertId': advertId };
    fetch('https://localhost:44382/comments/saveorupdate', {
        method: 'POST',
        mode: 'cors',
        body: JSON.stringify(comment),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(res => res.json())
        .then(json => comments.push(json))
        .then(() => ShowComment(comments[comments.length - 1]));
}
function GetCommentByID(commentId) {
    for (var i in comments)
        if (comments[i].id == commentId)
            return comments[i];
}
function SetRating(id, IsRated) {
    ratingDto = { Id: '0', UserId: CurrentUserId, PostId: id, IsRated: IsRated };
    fetch('https://localhost:44382/setrating/', {
        method: 'POST',
        mode: 'cors',
        body: JSON.stringify(ratingDto),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then((json) => {
            console.log(json);
        })

}