// Fetching comments from the API
var CommentsTagName = 'advert_comments';
var info, categories;
fetch_info = function () {
    categories = fetch('https://localhost:44396/api/comments/')
        .then(response => response.json())
        .then(json => categories = json.categories)
        .then(() => SelectCategory(GetCategoryLevel(null)));
}
document.onloadstart = fetch_info();