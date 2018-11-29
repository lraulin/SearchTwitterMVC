/* eslint-disable no-console */
/* eslint-disable no-unused-vars */
/* eslint-disable no-undef */
// Initialize and add the map
function initMap() {
  // The location of Uluru
  const lat = parseFloat(document.getElementById("lat").getAttribute("data"));
  const lng = parseFloat(document.getElementById("long").getAttribute("data"));
  var position = { lat, lng };

  // The map, centered at Uluru
  var map = new google.maps.Map(document.getElementById("map"), {
    zoom: 4,
    center: position
  });
  // The marker, positioned at Location
  var marker = new google.maps.Marker({ position, map });
}
