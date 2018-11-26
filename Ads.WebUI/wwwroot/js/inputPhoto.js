function handleFileSelectMulti(evt) {
    var files = evt.target.files; // FileList object
    document.getElementById('outputMulti').innerHTML = "";
    for (var i = 0, f; f = files[i]; i++) {

      // Only process image files.
      if (!f.type.match('image.*')) {
        alert("Только изображения....");
      }

      var reader = new FileReader();

      // Closure to capture the file information.
      reader.onload = (function(theFile) {
        return function(e) {
          // Render thumbnail.
          var span = document.createElement('span');
            span.innerHTML = ['<img class="img-preview" src="', e.target.result,
                            '" title="', escape(theFile.name), '"/>'].join('');
          document.getElementById('outputMulti').insertBefore(span, null);
        };
      })(f);

      // Read in the image file as a data URL.
      reader.readAsDataURL(f);
    }

  }


function handleFileSelectSingle(evt) {
    var file = evt.target.files; // FileList object

    var f = file[0]

    // Only process image files.
    if (!f.type.match('image.*')) {
        alert("Только изображения....");
    }

    var reader = new FileReader();

    // Closure to capture the file information.
    reader.onload = (function (theFile) {
        return function (e) {
            // Render thumbnail.
            var span = document.createElement('span');
            span.innerHTML = ['<img class="img-preview" src="', e.target.result,
                '" title="', escape(theFile.name), '"/>'].join('');
            document.getElementById('output').innerHTML = "";
            document.getElementById('output').insertBefore(span, null);
        };
    })(f);

    // Read in the image file as a data URL.
    reader.readAsDataURL(f);
}

function getLocation() {
    var location = window.location;
    var urlSignUp = 'https://localhost:44382/Authentication/SignUp';
    var urlCreate = 'https://localhost:44382/Adverts/Create';
    if (location == urlSignUp)
        document.getElementById('file').addEventListener('change', handleFileSelectSingle, false);
    if (location == urlCreate)
        document.getElementById('fileMulti').addEventListener('change', handleFileSelectMulti, false);
}

document.onloadstart = getLocation();
