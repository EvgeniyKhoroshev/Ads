var categories;
fetch_category = function () {
    categories = fetch('https://localhost:44396/api/info/')
        .then(response => response.json())
        .then(json => categories = json.categories)
        .then(() => DropdownCategories());
}
document.onloadstart = fetch_category();

function DropdownCategories() {
    var p = GetCategories();

    for (var i = 0; i < p.length; i++) {
        if (p[i].parentCategoryId == null)
            document.getElementById('selectCategories').innerHTML += '<option class="bg-light" value="' + p[i].id +'">' + p[i].name + '</option>';
        else
            document.getElementById('selectCategories').innerHTML += '<option value="' + p[i].id +'">' + p[i].name + '</option>';
    }  
}

function GetCategories() {

    var categoryArray = new Array;
    for (var i = 0; i < categories.length; i++)
        categoryArray.push(categories[i]);

    return categoryArray;
}

function changeFunc() {
    var selectBox = document.getElementById("selectCategories");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;

    document.getElementById('inputCategory').value = selectedValue;
}