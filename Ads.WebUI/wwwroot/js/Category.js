var categoryArray;
var changeCategory = true;
var currentAdvertCategoryId;
$.getJSON('https://localhost:44396/api/info/1',
    function (data) {
        var page = document.getElementById('create');
        if (page == null) {
            DropdownCategories(data);
            NavbarCategories(data);
            ModalWindowCategory(data);
        }
        else {
            categoryArray = data;
            ParentCategory(data);
            NavbarCategories(data);
            ModalWindowCategory(data);
        }
    });
function DropdownCategories(categories) {
    for (var i = 0, len = categories.length; i < len; i++) {
        if (categories[i].parentCategoryId == null)
            document.getElementById('selectCategories').innerHTML +=
                '<option class="bg-light" value="' + categories[i].id + '">' + categories[i].name + '</option>';
        else
            document.getElementById('selectCategories').innerHTML +=
                '<option value="' + categories[i].id + '">' + categories[i].name + '</option>';
    }  
}
function ChangeCategory() {
    var selectBox = document.getElementById("selectCategories");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
    document.getElementById('inputCategory').value = selectedValue;
}
function NavbarCategories(categories) {
    var parentCategoryArray = new Array;//.from(categories);
    for (var i = 0; i < categories.length; i++) {
        if (categories[i].parentCategoryId == null)
            parentCategoryArray.push(categories[i]);
    }
    var parentCategoryArrayRandom = shuffleArray(parentCategoryArray);

    var url = 'https://localhost:44382/Adverts/Create';
    if (window.location == url) {
        var select = document.getElementById('categoryNavbar');
        while (select.firstChild) {
            select.removeChild(select.firstChild);
        }
    }

    document.getElementById('categoryNavbar').innerHTML += '<a class="nav-link active" href="#">ЛОГО</a>';
    for (var i = 0; i < 4; i++) {
        document.getElementById('categoryNavbar').innerHTML += '<a class="nav-link" href="https://localhost:44382/?CategoryId=' + parentCategoryArrayRandom[i].id + '">' + parentCategoryArrayRandom[i].name + '</a>';
    }
    document.getElementById('categoryNavbar').innerHTML += '<button type="button" class="btn btn-link" data-toggle="modal" data-target="#exampleModal">\
        Ещё...\
    </button >\
        <div class="modal fade bd-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="categoryModalLabel" aria-hidden="true">\
            <div class="modal-dialog modal-lg" role="document">\
                <div class="modal-content">\
                    <div class="modal-header">\
                        <h5 class="modal-title" id="categoryModalLabel"><a class="link" href="https://localhost:44382/?CategoryId=">Все категории</a></h5>\
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">\
                            <span aria-hidden="true">&times;</span>\
                        </button>\
                    </div>\
                    <div class="modal-body" >\
                        <div class="row">\
                            <div class="flex-column col-4">\
                                <ul class="list-unstyled" id="1"></ul>\
                                <ul class="list-unstyled" id="7"></ul>\
                                <ul class="list-unstyled" id="15"></ul>\
                                <ul class="list-unstyled" id="18"></ul>\
                            </div>\
                            <div class="flex-column col-4">\
                                <ul class="list-unstyled" id="20"></ul>\
                                <ul class="list-unstyled" id="28"></ul>\
                                <ul class="list-unstyled" id="36"></ul>\
                            </div>\
                            <div class="flex-columncol-4">\
                                <ul class="list-unstyled" id="46"></ul>\
                                <ul class="list-unstyled" id="54"></ul>\
                                <ul class="list-unstyled" id="61"></ul>\
                            </div>\
                        </div>\
                    </div>\
                </div>\
            </div>\
        </div>';
}
function ModalWindowCategory(categories) {
    for (var i = 0; i < categories.length; i++) {
        if (categories[i].parentCategoryId == null)
            document.getElementById('' + categories[i].id + '').innerHTML += '<li><h6><a class="link" href="https://localhost:44382/?CategoryId=' + categories[i].id + '">' + categories[i].name +'</a></h6></li>';
        if (categories[i].parentCategoryId != null)
            document.getElementById('' + categories[i].parentCategoryId + '').innerHTML += '<li><a class="link" href="https://localhost:44382/?CategoryId=' + categories[i].id + '">' + categories[i].name +'</a></li>';
    }
}
function shuffleArray(array) {
    for (var i = array.length - 1; i > 0; i--) {
        var j = Math.floor(Math.random() * (i + 1));
        var temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    return array;
}
function ChangeParentCategory() {
    var categoryIndex;
    var selectBox = document.getElementById("selectParentCategory");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
    if (selectedValue == 'Любая категория') {
        document.getElementById('childCategory').hidden = true;
        return;
    }
    var select = document.getElementById('selectCategories');
    while (select.firstChild) {
        select.removeChild(select.firstChild);
    }
    document.getElementById('childCategory').hidden = false;
    document.getElementById('selectCategories').innerHTML += '<option>Любая категория</option>';
    for (var i = 0; i < categoryArray.length; i++) {
        if (categoryArray[i].parentCategoryId == selectedValue) {
            document.getElementById('selectCategories').innerHTML +=
                '<option value="' + categoryArray[i].id + '">' + categoryArray[i].name + '</option>';
        }
    }
    if (currentAdvertCategoryId != 0 && (changeCategory)) {
        $("#selectCategories option[value=" + currentAdvertCategoryId+"]").attr('selected', 'selected');
        changeCategory = false;
    }
}
    function ParentCategory(categories) {
        var categoryId = GetParentCategoryId();
        var categoryIndex;
        for (var i = 0; i < categories.length; i++) {
            if (categories[i].parentCategoryId == null) {
                document.getElementById('selectParentCategory').innerHTML +=
                    '<option value="' + categories[i].id + '">' + categories[i].name + '</option>';
                if ((categoryId != 0) && (categories[i].id == categoryId)) {
                    categoryIndex = i;
                }
            }
        }
        if ((categoryId != 0) && (changeCategory)) {
            $("#selectParentCategory option[value=" + categories[categoryIndex].id + "]").attr('selected', 'selected');
            ChangeParentCategory();
        }

    }
// Getting the parent category id of a current selected category (selected from the database)
function GetParentCategoryId() {
    currentAdvertCategoryId = document.getElementById('category_id').value;
    if (currentAdvertCategoryId != 0)
        for (var i in categoryArray)
            if (categoryArray[i].id == currentAdvertCategoryId)
                return categoryArray[i].parentCategoryId;
            else
                continue;
    else
        return 0;
}