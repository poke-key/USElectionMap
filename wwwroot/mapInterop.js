let map;

window.initializeMap = function () {
    if (!map) {
        map = L.map('map').setView([37.8, -96], 4);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 18,
            attribution: '© OpenStreetMap contributors'
        }).addTo(map);
    }
}

window.updateMap = function (data) {
    // This function will be implemented later to update the map with election data
    console.log("Updating map with data:", data);
}