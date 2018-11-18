function ExtraOptions() {
    var select = document.getElementById('extraOptions');
    select.remove();

    document.getElementById('filterForm').innerHTML += '<br />\
        <div class="nav nav-underline" >\
            <div class="form-check-inline col-4">\
                <label class="form-check-label col" for="exampleCheck1">Цена от:</label>\
                <input name="Min" type="text" class="form-control form-control-sm col" aria-label="Small" aria-describedby="inputGroup-sizing-sm">\
                <label class="form-check-label col-2" for="exampleCheck1">до:</label>\
                <input max="Max" type="text" class="form-control form-control-sm col" aria-label="Small" aria-describedby="inputGroup-sizing-sm">\
            </div>\
            <div class="form-check-inline col-2">\
                <input name="onlyName" type="checkbox" class="form-check-input" id="exampleCheck1" value="true">\
                <label class="form-check-label" for="exampleCheck1">Только в названиях</label>\
            </div>\
            <div class="form-check-inline col-2">\
                <input name="onlyPhoto" type="checkbox" class="form-check-input" id="exampleCheck1" value="true">\
                <label class="form-check-label" for="exampleCheck1">Только с фото</label>\
            </div>\
         </div>'
}