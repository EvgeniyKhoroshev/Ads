$.getJSON('https://localhost:44396/api/info/5',
    function (data) {
        DropdownRegions(data);
    });

function DropdownRegions(regions) {
    for (var i = 0, len = regions.length; i < len; i++)
        document.getElementById('selectRegion').innerHTML += '<option value="' + regions[i].id + '">' + regions[i].name + '</option>';
}

function DropdownCities(regionId) {
    $.getJSON('https://localhost:44396/api/info/2/' + regionId + '',
        function (data) {
            var select = document.getElementById('selectCity');
            while (select.firstChild) {
                select.removeChild(select.firstChild);
            }
            document.getElementById('selectCity').innerHTML += '<option>Любой город</option>';
            for (var i = 0; i < data.length; i++)
                document.getElementById('selectCity').innerHTML += '<option value="' + data[i].id + '">' + data[i].name + '</option>';
        });
}

function ChangeRegion() {
    var selectBox = document.getElementById("selectRegion");
    var selectedRegionId = selectBox.options[selectBox.selectedIndex].value;

    var inputRegion = document.getElementById("inputRegion");
    if (inputRegion != null)
        document.getElementById('inputRegion').value = selectedRegionId;
    DropdownCities(selectedRegionId);
}

function ChangeCity() {
    var selectBox = document.getElementById("selectCity");
    var selectedCityId = selectBox.options[selectBox.selectedIndex].value;

    document.getElementById('inputCity').value = selectedCityId;
}