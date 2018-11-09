var categories;
fetch_category = function () {
    categories = fetch('https://localhost:44396/api/info')
        .then(response => response.json())
        .then(json => categories = json.categories)
        .then(() => DropdownCategories());
}
document.onloadstart = fetch_category();

function DropdownCategories() {
    var p = Array.from(categories);

    for (var i = 0, len = p.length; i < len; i++) {
        if (p[i].parentCategoryId == null)
            document.getElementById('selectCategories').innerHTML += '<option class="bg-light" value="' + p[i].id +'">' + p[i].name + '</option>';
        else
            document.getElementById('selectCategories').innerHTML += '<option value="' + p[i].id +'">' + p[i].name + '</option>';
    }  
}

function changeFunc() {
    var selectBox = document.getElementById("selectCategories");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;

    document.getElementById('inputCategory').value = selectedValue;
}