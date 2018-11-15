var map;

var longitude = null;
var latitude = null;

function InitializeMap() {

    var latlng = new google.maps.LatLng(-19.919102, -43.938583);

    var options = {
        zoom: 15,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        mapTypeControl: true,
        mapTypeControlOptions: {
            style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
            position: google.maps.ControlPosition.LEFT_BOTTOM
        },
        zoomControl: true,
        zoomControlOptions: {
            position: google.maps.ControlPosition.RIGHT_BOTTOM 
        },
        scaleControl: true,
        streetViewControl: true,
        streetViewControlOptions: {
            position: google.maps.ControlPosition.RIGHT_TOP
        },
        fullscreenControl: true
    };

    map = new google.maps.Map(document.getElementById("mapa"), options);

    //#region .: Busca :.

    // Create the search box and link it to the UI element.
    var input = document.getElementById('buscaEndereco');
    var searchBox = new google.maps.places.SearchBox(input);
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    // Bias the SearchBox results towards current map's viewport.
    map.addListener('bounds_changed', function () {
        searchBox.setBounds(map.getBounds());
    });

    var markers = [];

    // Listen for the event fired when the user selects a prediction and retrieve
    // more details for that place.
    searchBox.addListener('places_changed', function () {
        var places = searchBox.getPlaces();

        if (places.length == 0) {
            return;
        }

        // Clear out the old markers.
        markers.forEach(function (marker) {
            marker.setMap(null);
        });

        markers = [];

        // For each place, get the icon, name and location.
        var bounds = new google.maps.LatLngBounds();

        places.forEach(function (place) {

            if (!place.geometry) {
                console.log("Returned place contains no geometry");
                return;
            }

            if (place.geometry.viewport) {
                // Only geocodes have viewport.
                bounds.union(place.geometry.viewport);
            } else {
                bounds.extend(place.geometry.location);
            }

        });

        map.fitBounds(bounds);
    });

    //#endregion

    //#region .: Marcação :.

    google.maps.event.addListener(map, 'click', function (event) {

        // Clear out the old markers.
        markers.forEach(function (marker) {
            marker.setMap(null);
        });

        //Create a marker for each place.
        markers.push(new google.maps.Marker({
            map: map,
            //icon: icon,
            //title: 'Foi aqui!',
            position: event.latLng
        }));

        map.setCenter(event.latLng);

        latitude = event.latLng.lat();
        longitude = event.latLng.lng();
    });

    //#endregion

}