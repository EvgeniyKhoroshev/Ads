var categories;
fetch_info = function () {
    categories = fetch('https://localhost:44396/api/info/')
        .then(response => response.json())
        .then(json => categories = json.categories)
        .then(() => SelectCategory(GetCategoryLevel(null)));
}
document.onloadeddata = fetch_info();
function DrawTree(tree) {
    console.log(tree);
    var index = tree.length -1 ;
    for (index; index >= 0; --index) {
        DrawLevel(GetCategoryLevel(tree[index].parentCategoryId));
    }
}
function DrawLevel(level) {
    console.log(level);
    var i = 0;
    for (i; i < level.length; ++i) {
        DrawCategory(level[i]);
    }
}
function GetTree(init) {
    var index = init;
    var tree = new Array;
    var cat;

    while (true) {
        if ((index == null) || (index == 0))
            return tree;
        else {
            cat = FindCatById(index);
            tree.push(cat);
            index = cat.parentCategoryId;
        }
    }
    return tree;

}

function FindCatById(id) {
    var i = 0;
    for (i; i < categories.length; ++i) {
        if (categories[i].id == id)
            return categories[i];
    }
    return null;
}
function GetCategoryLevel(level) {
    console.log(level);

    var result = new Array;
    var i = 0;
    for (i; i < categories.length; ++i)
        if (categories[i].parentCategoryId === level) {
            result.push(categories[i]);
        }
    return result;

}
function SelectCategory(item) {
    console.log(item);    
    var index = 0;
    for (index; index < item.length; ++index)
    {
        DrawCategory(item[index]);
    }
    document.getElementById('test').innerHTML += '<br>';
}
function DrawCategory(cat) {
    document.getElementById('test').innerHTML += '\
        <li class="list-group-item nav-item" style="padding: 0px; ">\
            <input type="hidden" value="'+ cat.id + '"\>\
            <button class="btn btn-default btn-xs btn-block" style="border: none;" onclick="SelectCategory(GetCategoryLevel('+ cat.id + '))">' + cat.name + '</button>\
        </li>';
}