var regions;
fetch_regions = function () {
    regions = fetch('https://localhost:44396/api/info/5')
        .then(response => response.json())
        .then(json => regions = json)
        .then(() => DropdownRegions());
}
document.onloadstart = fetch_regions();

function DropdownRegions() {
    var regionsArray = Array.from(regions);

    for (var i = 0, len = regionsArray.length; i < len; i++)
        document.getElementById('selectRegion').innerHTML += '<option value="' + regionsArray[i].id + '">' + regionsArray[i].name + '</option>';
}

function DropdownCities(regionId) {

    var cities = fetch('https://localhost:44396/api/info/2/' + regionId + '')
        .then(response => response.json())
        .then((json) => {
            cities = json;

            var select = document.getElementById('selectCity');
            while (select.firstChild) {
                select.removeChild(select.firstChild);
            }
            document.getElementById('selectCity').innerHTML += '<option>Любой город</option>';
            for (var i = 0; i < cities.length; i++)
                document.getElementById('selectCity').innerHTML += '<option value="' + cities[i].id + '">' + cities[i].name + '</option>';
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