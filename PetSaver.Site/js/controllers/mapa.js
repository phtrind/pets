var map;
 
function initialize() {
    var latlng = new google.maps.LatLng(-18.8800397, -47.05878999999999);
 
    var options = {
        zoom: 5,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
 
    map = new google.maps.Map(document.getElementById("mapa"), options);

    google.maps.event.addListener(map, 'click', function(event) {
        placeMarker(event.latLng);
      });
}
 
function placeMarker(location) {
    var marker = new google.maps.Marker({
        position: location, 
        map: map
    });
  
    map.setCenter(location);
  }

initialize();