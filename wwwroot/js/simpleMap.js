function initMap() {
  // Roughly the center of USA
  const position = { lat: 40, lng: -100 };

  // The map, centered in USA
  const map = new google.maps.Map(document.getElementById("map"), {
    zoom: 4,
    center: position
  });
  // Initialize geocoder for finding lat/long of cities.
  geocoder = new google.maps.Geocoder();
}
