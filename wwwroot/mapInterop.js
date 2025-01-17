﻿let map;
let geojson;

window.initializeMap = async function () {
    if (!map) {
        map = L.map('map').setView([37.8, -96], 4);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 18,
            attribution: '© OpenStreetMap contributors'
        }).addTo(map);

        const response = await fetch('https://raw.githubusercontent.com/plotly/datasets/master/geojson-counties-fips.json');
        const countyData = await response.json();
        geojson = L.geoJSON(countyData, {
            style: {
                color: '#000',
                weight: 1,
                fillOpacity: 0.1
            },
            onEachFeature: function (feature, layer) {
                layer.bindPopup(`County: ${feature.properties.NAME}`);
            }
        }).addTo(map);
    }
}

window.updateMap = function (data) {
    console.log("Updating map with data:", data);
    if (geojson) {
        let matchCount = 0;
        geojson.eachLayer(function (layer) {
            const countyFips = layer.feature.properties.STATE + layer.feature.properties.COUNTY;
            const countyData = data.find(d => d.countyFips === countyFips);
            if (countyData) {
                matchCount++;
                const color = getColor(countyData.democratVotePercentage);
                layer.setStyle({ fillColor: color, fillOpacity: 0.7 });
                layer.bindPopup(`County: ${layer.feature.properties.NAME}<br>
                                 State: ${countyData.state}<br>
                                 Democrat: ${countyData.democratVotePercentage.toFixed(2)}%<br>
                                 Republican: ${countyData.republicanVotePercentage.toFixed(2)}%`);
            } else {
                layer.setStyle({ fillColor: '#CCCCCC', fillOpacity: 0.7 });
            }
        });
        console.log(`Matched ${matchCount} counties out of ${data.length} data points`);
    }
}

function getColor(democratPercentage) {
    return democratPercentage > 60 ? '#0000FF' :
        democratPercentage > 50 ? '#4169E1' :
            democratPercentage > 40 ? '#ADD8E6' :
                democratPercentage > 30 ? '#FFCCCB' :
                    '#FF0000';
}