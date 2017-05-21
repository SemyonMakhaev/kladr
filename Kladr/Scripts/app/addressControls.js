'use strict';

function requestRegions() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', '/Address/GetRegions');
    xhr.onreadystatechange = function () {
        if (xhr.readyState !== 4 || xhr.status !== 200) {
            return;
        }
        var regionsSelect = document.getElementById('Region');
        var documentFragment = document.createDocumentFragment();
        JSON.parse(xhr.responseText).forEach(function (regionName) {
            var option = Object.assign(document.createElement('option'), {
                innerText: regionName,
                value: regionName
            });
            if (regionName === defaultValues.regionName) {
                option.selected = 'true';
            }
            documentFragment.appendChild(option);
        });
        regionsSelect.appendChild(documentFragment);
    };
    xhr.send();
}

function requestSettlements(regionName, defaultValue) {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', '/Address/GetRegionSettlements?regionName=' + regionName);
    xhr.onreadystatechange = function () {
        if (xhr.readyState !== 4 || xhr.status !== 200) {
            return;
        }
        var settlementsSelect = document.getElementById('Settlement');
        var documentFragment = document.createDocumentFragment();
        JSON.parse(xhr.responseText).forEach(function (settlementName) {
            var settlement = Object.assign(document.createElement('option'), {
                innerText: settlementName,
                value: settlementName
            });
            if (settlement.value === defaultValue) {
                settlement.selected = 'true';
            }
            documentFragment.appendChild(settlement);
        });
        settlementsSelect.appendChild(documentFragment);
    };
    xhr.send();
}

function requestStreets(settlementName, regionName, defaultValue) {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', '/Address/GetSettlementStreets?regionName=' + regionName + '&settlementName=' + settlementName);
    xhr.onreadystatechange = function () {
        if (xhr.readyState !== 4 || xhr.status !== 200) {
            return;
        }
        var streetsSelect = document.getElementById('Street');
        var documentFragment = document.createDocumentFragment();
        JSON.parse(xhr.responseText).forEach(function (streetName) {
            var street = Object.assign(document.createElement('option'), {
                innerText: streetName,
                value: streetName
            });
            if (street.value === defaultValue) {
                street.selected = 'true';
            }
            documentFragment.appendChild(street);
        });
        streetsSelect.appendChild(documentFragment);
    };
    xhr.send();
}

function requestIndex(regionName, settlementName, streetName, houseNumber) {
    var idx = document.getElementById('index');
    var xhr = new XMLHttpRequest();
    xhr.open('GET', '/Address/GetIndex?regionName=' + regionName + '&settlementName=' + settlementName +
            '&streetName=' + streetName + '&houseNumber=' + houseNumber);
    xhr.onreadystatechange = function () {
        if (xhr.readyState !== 4 || xhr.status !== 200) {
            return;
        }
        idx.value = xhr.responseText || '';
    };
    xhr.send();
}

var defaultValues = {
    regionName: 'Свердловская обл',
    settlementName: 'Екатеринбург',
    streetName: 'ул Антона Валека'
};

addEventListener('load', function () {
    var regionsSelect = document.getElementById('Region');
    var settlementsSelect = document.getElementById('Settlement');
    var streetsSelect = document.getElementById('Street');
    var houseInput = document.getElementById('house-input');
    var index = document.getElementById('index');

    requestRegions(defaultValues.regionName);
    requestSettlements(defaultValues.regionName, defaultValues.settlementName);
    requestStreets(defaultValues.settlementName, defaultValues.regionName, defaultValues.streetName);
    requestIndex(defaultValues.regionName, defaultValues.settlementName, defaultValues.streetName);

    houseInput.addEventListener('change', function () {
        index.value = '';
        requestIndex(regionsSelect.value, settlementsSelect.value, streetsSelect.value, this.value);
    });

    streetsSelect.addEventListener('change', function () {
        houseInput.value = '';
        index.value = '';
        requestIndex(regionsSelect.value, settlementsSelect.value, this.value);
    });

    settlementsSelect.addEventListener('change', function () {
        [].slice.call(streetsSelect.children).forEach(function (option) {
            streetsSelect.removeChild(option);
        });
        houseInput.value = '';
        index.value = '';
        requestStreets(this.value, regionsSelect.value);
        requestIndex(regionsSelect.value, this.value);
        streetsSelect.removeAttribute('disabled');
    });

    regionsSelect.addEventListener('change', function () {
        [].slice.call(settlementsSelect.children).forEach(function (option) {
            settlementsSelect.removeChild(option);
        });
        [].slice.call(streetsSelect.children).forEach(function (option) {
            streetsSelect.removeChild(option);
        });
        houseInput.value = '';
        index.value = '';
        requestSettlements(this.value);
        requestIndex(this.value);
        streetsSelect.disabled = 'disabled';
    });
});
