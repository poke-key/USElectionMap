let map;

window.initializeMap = function () {
    map = L.map('map').setView([37.8, -96], 4);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 18,
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);
}

window.loadCountyData = async function (year) {
    const response = await fetch('https://raw.githubusercontent.com/deldersveld/topojson/master/countries/us-counties.json');
    const data = await response.json();

    L.geoJSON(topojson.feature(data, data.objects.counties), {
        style: function (feature) {
            return {
                fillColor: '#FFF',
                weight: 1,
                opacity: 1,
                color: '#666',
                fillOpacity: 0.7
            };
        },
        onEachFeature: function (feature, layer) {
            layer.bindPopup(`County: ${feature.properties.name}`);
        }
    }).addTo(map);
}