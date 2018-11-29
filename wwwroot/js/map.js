/* eslint-disable no-console */
/* eslint-disable no-unused-vars */
/* eslint-disable no-undef */
// Initialize and add the map
function initMap() {
  // The location of Uluru
  var uluru = { lat: -25.344, lng: 131.036 };
  // The map, centered at Uluru
  var map = new google.maps.Map(document.getElementById("map"), {
    zoom: 4,
    center: uluru
  });
  // The marker, positioned at Uluru
  var marker = new google.maps.Marker({ position: uluru, map: map });

  // Try HTML5 geolocation.
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(
      function(position) {
        var pos = {
          lat: position.coords.latitude,
          lng: position.coords.longitude
        };

        map.setCenter(pos);
        map.zoom = 6;
        placeMarker(pos);
      },
      function() {
        handleLocationError(true, infoWindow, map.getCenter());
      }
    );
  } else {
    // Browser doesn't support Geolocation
    // handleLocationError(false, infoWindow, map.getCenter());
    console.log("Error: Browser doesn't support geolocation.");
  }

  // function handleLocationError(browserHasGeolocation, infoWindow, pos) {
  //   infoWindow.setPosition(pos);
  //   infoWindow.setContent(
  //     browserHasGeolocation
  //       ? "Error: The Geolocation service failed."
  //       : "Error: Your browser doesn't support geolocation."
  //   );
  //   infoWindow.open(map);
  // }

  // (re)set marker
  function placeMarker(position) {
    //If the marker hasn't been added.
    if (marker === false) {
      //Create the marker.
      marker = new google.maps.Marker({
        position: pos,
        map: map,
        draggable: true //make it draggable
      });
      //Listen for drag events!
      google.maps.event.addListener(marker, "dragend", function(event) {
        markerLocation();
      });
    } else {
      //Marker has already been added, so just change its location.
      marker.setPosition(position);
    }
    markerLocation();
  }

  //Listen for any clicks on the map.
  google.maps.event.addListener(map, "click", function(event) {
    //Get the location that the user clicked.
    var clickedLocation = event.latLng;
    placeMarker(clickedLocation);
  });

  //This function will get the marker's current location and then add the lat/long
  //values to our textfields so that we can save the location.
  function markerLocation() {
    //Get location.
    var currentLocation = marker.getPosition();
    //Add lat and lng values to a field that we can save.
    document.getElementById("Lat").value = currentLocation.lat(); //latitude
    document.getElementById("Long").value = currentLocation.lng(); //longitude
  }
}
