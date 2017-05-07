document.addEventListener('load', function () {
    var regions = [];
    var settlements = [];
    var streets = [];
    var houses = [];
    var flats = [];

    loadRegions();

    function loadRegions() {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', '/Address/GetRegions');
        xhr.onreadystatechange = function () {
            if (xhr.readyState !== 4 || xhr.status !== 200) {
                return;
            }
            regions = JSON.parse(xhr.responseText);
        }
    }

    // load settlements, streets, houses, flats

    window.onkeydown = function (event) {
        switch (event.keyCode) {
            case 27:
                event.preventDefault();
                hidePrompt();
                break;
        }
    };

    window.onmousedown = function (event) {

    };

    $("#Region").keyup(function (event) {
        if (event.keyCode !== 27 && event.keyCode !== 13) {
            var selected = limit(select(regions, this.value));
            var prompt = document.getElementsByClassName("region-prompt")[0];
            putItemsInPrompt(selected, prompt);
            prompt.style.visibility = 'visible';
        }
    });

    $("#Region").blur(function() {
        hidePrompt();
    });

    $(".address-control").focus(function () {
        document.getElementById(this.id.toLowerCase() + '-prompt').style.visibility = "visible";
    });
});

function select(arr, substring) {
    var entry = substring.toLowerCase();
    return arr.reduce(function (current, item) {
        if (item.toLowerCase().split(' ').some(function (word) {
            return word.startsWith(entry);
        })) {
            current.push(item);
        }
        return current;
    }, []);
}

function limit(arr, count) {
    count = count || 5;
    return arr.slice(0, count);
}

function putItemsInPrompt(arr, prompt) {
    while (prompt.hasChildNodes()) {
        prompt.removeChild(prompt.lastChild);
    }
    if (arr.length === 0) {
        var notFound = document.createElement('p');
        notFound.appendChild(document.createTextNode('Не найдено'));
        prompt.appendChild(notFound);
    } else {
        var fragment = document.createDocumentFragment();
        arr.forEach(function (item) {
            var cell = document.createElement('p');
            cell.appendChild(document.createTextNode(item));
            fragment.appendChild(cell);
        });
        prompt.appendChild(fragment);
    }
}

function hidePrompt() {
    [].slice.call(document.getElementsByClassName("prompt")).forEach(function (prompt) {
        prompt.style.visibility = "hidden";
    });
}
