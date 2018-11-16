var categories;
fetch_category = function () {
    categories = fetch('https://localhost:44396/api/info/1')
        .then(response => response.json())
        .then(json => categories = json)
        .then(() => DropdownCategories())
        .then(() => NavbarCategories())
        .then(() => ModalWindowCategory());
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


function ChangeCategory() {
    var selectBox = document.getElementById("selectCategories");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;

    document.getElementById('inputCategory').value = selectedValue;
}

function NavbarCategories() {
    var perentCategoryArray = new Array;//.from(categories);
    for (var i = 0; i < categories.length; i++) {
        if (categories[i].parentCategoryId == null)
            perentCategoryArray.push(categories[i]);
    }
    var perentCategoryArrayRandom = shuffleArray(perentCategoryArray);

    for (var i = 0; i < 4; i++) {
        document.getElementById('categoryNavbar').innerHTML += '<a class="nav-link" href="https://localhost:44382/?CategoryId=' + perentCategoryArrayRandom[i].id + '">' + perentCategoryArrayRandom[i].name + '</a>';
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

function ModalWindowCategory() {
    var categoryArray = Array.from(categories);
    for (var i = 0; i < categoryArray.length; i++) {
        if (categoryArray[i].parentCategoryId == null)
            document.getElementById('' + categoryArray[i].id + '').innerHTML += '<li><h6><a class="link" href="https://localhost:44382/?CategoryId=' + categoryArray[i].id + '">' + categoryArray[i].name +'</a></h6></li>';
        if (categoryArray[i].parentCategoryId != null)
            document.getElementById(''+ categoryArray[i].parentCategoryId +'').innerHTML += '<li><a class="link" href="https://localhost:44382/?CategoryId='+ categoryArray[i].id +'">'+ categoryArray[i].name +'</a></li>';
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