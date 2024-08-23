let map;
let marker;
let autocomplete;

function initMap() {
    const southWest = new google.maps.LatLng(-85, -180);
    const northEast = new google.maps.LatLng(85, 180);
    const bounds = new google.maps.LatLngBounds(southWest, northEast);

    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 40, lng: 0 },
        zoom: 3,
        minZoom: 3,
        restriction: {
            latLngBounds: bounds,
            strictBounds: false,
        },
        streetViewControl: false,
        fullscreenControl: false,
        mapTypeControl: false,
        styles: [
            {
                featureType: "poi",
                elementType: "labels",
                stylers: [{ visibility: "off" }],
            },
            {
                featureType: "transit",
                elementType: "labels.icon",
                stylers: [{ visibility: "off" }],
            },
        ],
    });

    marker = new google.maps.Marker({
        map: map,
        draggable: true,
    });

    autocomplete = new google.maps.places.Autocomplete(document.getElementById("autocomplete"));
    autocomplete.bindTo("bounds", map);

    autocomplete.addListener("place_changed", () => {
        const place = autocomplete.getPlace();

        if (!place.geometry || !place.geometry.location) {
            alert("No details available for the input: '" + place.name + "'");
            return;
        }

        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);
        }

        marker.setPosition(place.geometry.location);
        updateLatLng(place.geometry.location);
    });

    marker.addListener("dragend", () => {
        updateLatLng(marker.getPosition());
    });

    map.addListener("click", (event) => {
        marker.setPosition(event.latLng);
        updateLatLng(event.latLng);
    });
}

function updateLatLng(location) {
    document.getElementById("lat").value = location.lat(); 
    document.getElementById("lng").value = location.lng(); 
}

function submitForm() {
    const lat = document.getElementById("lat").value; 
    const lng = document.getElementById("lng").value; 
    if (lat && lng) {
        const param = `${lat},${lng}&days=3`;
        document.getElementById("paramField").value = param;
        document.getElementById("weatherForm").submit();
    } else {
        alert("Please select a location on the map.");
    }
}

window.onload = initMap;