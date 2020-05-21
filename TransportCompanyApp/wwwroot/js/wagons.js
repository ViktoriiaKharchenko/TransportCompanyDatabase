const uri = 'api/Wagons';
let wagons = [];
const url = 'api/Trailers/free';
let trailers = [];


function getWagons() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayWagons(data))
        .catch(error => console.error('Unable to get wagons.', error));
    _removeDropDown();
    getFreeTrailers();
}

function getFreeTrailers() {
    fetch(url)
        .then(response => response.json())
        .then(data => _fillDropDown(data))
        .catch(error => console.error('Unable to get trailers.', error));
}

function _removeDropDown() {
    let x = document.getElementById("add-trailer");
    while (x.length > 0) {
        x.remove(x.length - 1);
    }
    let y = document.getElementById("edit-trailer");
    while (y.length > 0) {
        y.remove(y.length - 1);
    }
        
}
async function addWagon() {
    const addNumTextbox = document.getElementById('add-num');
    const addTrailerTextbox = document.getElementById('add-trailer');
    

    const wagon = {
        wagonNum: addNumTextbox.value,
        trailerId: parseInt(addTrailerTextbox.value)
        
    };
    document.getElementById("add-num").setAttribute('class', 'form-control');
    document.getElementById("num-invalid").textContent = "";

    
    const response = await fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(wagon)
    });
    if (response.ok === true) {
        const wagon1 = await response.json();
        getWagons();
        addNumTextbox.value = '';
        document.querySelector("tbody").append(row(wagon1));
    }

    else {
    const errorData = await response.json();
        console.log("errors", errorData);
        if (errorData) {
            // ошибки вследствие валидации по атрибутам
            if (errorData.errors) {
                if (errorData.errors["WagonNum"]) {

                    document.getElementById("add-num").setAttribute('class', 'form-control is-invalid');
                    document.getElementById("num-invalid").textContent = errorData.errors["WagonNum"];
                    document.getElementById("num-invalid").setAttribute('class', 'invalid-feedback');

                }
                
            }
            // кастомные ошибки, определенные в контроллере
            if (errorData["WagonNum"]) {

                document.getElementById("add-num").setAttribute('class', 'form-control is-invalid');
                document.getElementById("num-invalid").textContent = errorData["WagonNum"];
                document.getElementById("num-invalid").setAttribute('class', 'invalid-feedback');
            }
        }
    }
}
function deleteWagon(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getWagons())
        .catch(error => console.error('Unable to delete wagons.', error));
}

function displayEditForm(id) {
    const wagon = wagons.find(wagon => wagon.id === id);
    document.getElementById('edit-id').value = wagon.id;
    document.getElementById('edit-num').value = wagon.wagonNum;
    getWagons();
    let dropDown2 = document.getElementById("edit-trailer");
    var str = "" + wagon.trailer.trailerType.type + " " + wagon.trailer.volume + " м^3 " + wagon.trailer.carryingCapacity + " т ";
    var tmpOption = document.createElement("option");
    tmpOption.setAttribute("value", wagon.trailerId);
    tmpOption.setAttribute("selected","selected");
    tmpOption.appendChild(document.createTextNode(str));
    dropDown2.appendChild(tmpOption);
    
}

async function updateWagon() {
    const wagonId = document.getElementById('edit-id').value;
    const addTrailerTextbox = document.getElementById('edit-trailer');
    const wagon1 = wagons.find(wagon => wagon.id == wagonId);
    
    const wagon = {
        id: parseInt(wagonId, 10),
        wagonNum: document.getElementById('edit-num').value.trim(),
        trailerId: parseInt(addTrailerTextbox.value)
    };
    document.getElementById("edit-num").setAttribute('class', 'form-control');
    document.getElementById("edit-num-invalid").textContent = "";
    

    
    const response = await fetch(`${uri}/${wagonId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(wagon)
    })
    if (response.ok === true) {
        getWagons();
        let dropDown2 = document.getElementById("edit-trailer");
        var str = "" + wagon1.trailer.trailerType.type + " " + wagon1.trailer.volume + " м^3 " + wagon1.trailer.carryingCapacity + " т ";
        var tmpOption = document.createElement("option");
        tmpOption.setAttribute("value", wagon.trailerId);
        tmpOption.setAttribute("selected", "selected");
        tmpOption.appendChild(document.createTextNode(str));
        dropDown2.appendChild(tmpOption);
    }

    else {
        const errorData = await response.json();
        console.log("errors", errorData);
        if (errorData) {
            // ошибки вследствие валидации по атрибутам
            if (errorData.errors) {
                if (errorData.errors["WagonNum"]) {
                    document.getElementById("edit-num").setAttribute('class', 'form-control is-invalid');
                    document.getElementById("edit-num-invalid").textContent = errorData.errors["WagonNum"];
                    document.getElementById("edit-num-invalid").setAttribute('class', 'invalid-feedback');
                }
            }
            // кастомные ошибки, определенные в контроллере
            if (errorData["WagonNum"]) {

                document.getElementById("edit-num").setAttribute('class', 'form-control is-invalid');
                document.getElementById("edit-num-invalid").textContent = errorData["WagonNum"];
                document.getElementById("edit-num-invalid").setAttribute('class', 'invalid-feedback');
            }
        }
    }
    closeInput();

    return false;
}
function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}
function _fillDropDown(data) {
    let dropDown = document.getElementById("add-trailer");
    let dropDown2 = document.getElementById("edit-trailer");
    data.forEach(trailer => {
        var str = "" + trailer.trailerType.type + " " + trailer.volume + " м^3 " + trailer.carryingCapacity + " т ";
        var tmpOption = document.createElement("option");
        tmpOption.setAttribute("value", trailer.id )
        tmpOption.appendChild(document.createTextNode(str));
        dropDown.appendChild(tmpOption);
        
    })
    data.forEach(trailer => {
        var str = "" + trailer.trailerType.type + " " + trailer.volume + " м^3 " + trailer.carryingCapacity + " т ";
        var tmpOption = document.createElement("option");
        tmpOption.setAttribute("value", trailer.id)
        tmpOption.appendChild(document.createTextNode(str));
        dropDown2.appendChild(tmpOption);

    })
}

function _displayWagons(data) {
    const tBody = document.getElementById('wagons');
    tBody.innerHTML = '';
   

    const button = document.createElement('button');

    data.forEach(wagon => {
       
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.setAttribute('class', 'btn btn-primary')
        editButton.setAttribute('data-toggle', 'collapse')
        editButton.setAttribute('data-target', '#editWagon')
        editButton.setAttribute('aria-expanded', 'false')
        editButton.setAttribute('aria-controls', 'editWagon')
        editButton.setAttribute('onclick', `displayEditForm(${wagon.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('class', `btn btn-warning`);
        deleteButton.setAttribute('onclick', `deleteWagon(${wagon.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNodeName = document.createTextNode(wagon.wagonNum);
        td1.appendChild(textNodeName);

        let td2 = tr.insertCell(1);
        let textNodeTrailer = document.createTextNode(wagon.trailer.trailerType.type);
        td2.appendChild(textNodeTrailer);

        let td3 = tr.insertCell(2);
        let textNodeVolume = document.createTextNode(wagon.trailer.volume);
       td3.appendChild(textNodeVolume);

        let td4 = tr.insertCell(3);
        let textNodeCapacity = document.createTextNode(wagon.trailer.carryingCapacity);
        td4.appendChild(textNodeCapacity);

        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);

        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);
    });

    wagons = data;
}










