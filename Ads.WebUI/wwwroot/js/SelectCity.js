//var cities;
//var regions;
//fetch_regions = function () {
//    regions = fetch('https://localhost:44396/api/info/')
//        .then(response => response.json())
//        .then(json => regions = json.regions);
//}
//fetch_city = function () {
//    cities = fetch('https://localhost:44396/api/info/')
//        .then(response => response.json())
//        .then(json => cities = json.cities)
//        .then(() => DropdownRegions());
//}
//document.onloadstart = fetch_regions();
//document.onloadstart = fetch_city();

//function DropdownRegions() {
//    var r = Array.from(regions);

//    for (var i = 0, len = r.length; i < len; i++)
//        document.getElementById('selectRegion').innerHTML += '<option class="bg-light" value="' + r[i].id + '">' + r[i].name + '</option>';
//}

//function GetCities() {
//    var cityArray = new Array;
//    for (var i = 0; i < cities.length; i++)
//        cityArray.push(cities[i]);

//    return cityArray;
//}

////function changeRegion() {
////    var selectBox = document.getElementById("selectRegion");
////    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
////    var c = GetCities();

////    for (var i = 0; i < c.length; i++)
////        if (selectedValue == c[i].regionId)
////        document.getElementById('selectRegion').innerHTML += '<option class="bg-light" value="' + c[i].id + '">' + c[i].name + '</option>';
////}

//////let dropdown = document.getElementById('selectCity');
//////dropdown.length = 0;

//////let defaultOption = document.createElement('option');
//////defaultOption.text = 'Choose State/Province';

//////dropdown.add(defaultOption);
//////dropdown.selectedIndex = 0;

//////const url = 'https://localhost:44396/api/info/';

//////fetch(url)
//////    .then(
//////        function (response) {
//////            if (response.status !== 200) {
//////                console.warn('Looks like there was a problem. Status Code: ' +
//////                    response.status);
//////                return;
//////            }

//////            // Examine the text in the response  
//////            response.json().then(function (data) {
//////                let option;

//////                for (let i = 0; i < data.length; i++) {
//////                    option = document.createElement('option');
//////                    option.text = data[i].name;
//////                    option.value = data[i].abbreviation;
//////                    dropdown.add(option);
//////                }
//////            });
//////        }
//////    )
//////    .catch(function (err) {
//////        console.error('Fetch Error -', err);
//////    });