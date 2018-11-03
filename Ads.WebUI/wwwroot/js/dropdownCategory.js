var itemId = 'perCarygory';
var categories;
fetch_category = function () {
    categories = fetch('https://localhost:44396/api/info/')
        .then(response => response.json())
        .then(json => categories = json.categories)
        .then(() => DropdownCategories());
}
document.onloadstart = fetch_category();

function DropdownCategories() {
    var p = GetParentCategoty();
    for (var i = 0; i < p.length; i++)
        document.getElementById(itemId).innerHTML += '<option>' + p[i].name +'</option>';
}

function GetParentCategoty() {

    var parentCategory = new Array;
    for (var i = 0; i < categories.length; i++)
            parentCategory.push(categories[i]);

    return parentCategory;
}