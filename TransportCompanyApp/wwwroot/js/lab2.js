const uri = 'api/Drivers';
let drivers = [];

function getDrivers() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayDrivers(data))
        .catch(error => console.error('Unable to get drivers.', error));
}
function closeInputMazafaka() {
    document.getElementById('add_row_mazafaka').style.display = 'initial';
}
async function addDriver() {
    const addNameTextbox = document.getElementById('add-name');
    const addPassportTextbox = document.getElementById('add-passport');
    const addLicenseTextbox = document.getElementById('add-license');
    const addADR = document.getElementById('ADR')

    const driver = {
        fullName: addNameTextbox.value,
        passportNum: addPassportTextbox.value.trim(),
        driverLicenseNum: addLicenseTextbox.value.trim(),
        adrCertificate: addADR.checked,
    };
    document.getElementById("add-name").setAttribute('class', 'form-control');
    document.getElementById("add-passport").setAttribute('class', 'form-control');
    document.getElementById("add-license").setAttribute('class', 'form-control');
    document.getElementById("name-invalid").textContent = "";
    document.getElementById("passport-invalid").textContent = "";
    document.getElementById("license-invalid").textContent = "";

    const response = await fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(driver)
    });
    if (response.ok === true) {
        const driver1 = await response.json();
        getDrivers();
        addNameTextbox.value = '';
        addPassportTextbox.value = '';
        addLicenseTextbox.value = '';

        document.querySelector("tbody").append(row(driver1));
    }

    else {
        const errorData = await response.json();
        console.log("errors", errorData);
        if (errorData) {
            // ошибки вследствие валидации по атрибутам
            if (errorData.errors) {
                if (errorData.errors["FullName"]) {

                    document.getElementById("add-name").setAttribute('class', 'form-control is-invalid');
                    document.getElementById("name-invalid").textContent = errorData.errors["FullName"];
                    document.getElementById("name-invalid").setAttribute('class', 'invalid-feedback');

                }
                if (errorData.errors["PassportNum"]) {

                    document.getElementById("add-passport").setAttribute('class', 'form-control is-invalid');
                    document.getElementById("passport-invalid").textContent = errorData.errors["PassportNum"];
                    document.getElementById("passport-invalid").setAttribute('class', 'invalid-feedback');
                }
                if (errorData.errors["DriverLicenseNum"]) {

                    document.getElementById("add-license").setAttribute('class', 'form-control is-invalid');
                    document.getElementById("license-invalid").textContent = errorData.errors["DriverLicenseNum"];
                    document.getElementById("license-invalid").setAttribute('class', 'invalid-feedback');
                }
            }
            // кастомные ошибки, определенные в контроллере
            // добавляем ошибки свойства Name
            if (errorData["FullName"]) {

                document.getElementById("add-name").setAttribute('class', 'form-control is-invalid');
                document.getElementById("name-invalid").textContent = errorData["FullName"];
                document.getElementById("name-invalid").setAttribute('class', 'invalid-feedback');
            }

            // добавляем ошибки свойства Age
            if (errorData["PassportNum"]) {

                document.getElementById("add-passport").setAttribute('class', 'form-control is-invalid');
                document.getElementById("passport-invalid").textContent = errorData["PassportNum"];
                document.getElementById("passport-invalid").setAttribute('class', 'invalid-feedback');
            }
            if (errorData["DriverLicenseNum"]) {

                document.getElementById("add-license").setAttribute('class', 'form-control is-invalid');
                document.getElementById("license-invalid").textContent = errorData["DriverLicenseNum"];
                document.getElementById("license-invalid").setAttribute('class', 'invalid-feedback');
            }
        }

    }
}
function deleteDriver(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getDrivers())
        .catch(error => console.error('Unable to delete driver.', error));
}

function displayEditForm(id) {
    const driver = drivers.find(driver => driver.id === id);

    document.getElementById('edit-id').value = driver.id;
    document.getElementById('edit-name').value = driver.fullName;
    document.getElementById('edit-passport').value = driver.passportNum;
    document.getElementById('edit-license').value = driver.driverLicenseNum;
    document.getElementById('edit-ADR').checked = driver.adrCertificate;
    //document.getElementById('editForm').style.display = 'block';
}

async function updateDriver()
{
    const driverId = document.getElementById('edit-id').value;
    const driver = {
        id: parseInt(driverId, 10),
        fullName: document.getElementById('edit-name').value.trim(),
        passportNum: document.getElementById('edit-passport').value.trim(),
        driverLicenseNum: document.getElementById('edit-license').value.trim(),
        adrCertificate: document.getElementById('edit-ADR').checked
    };
    document.getElementById("edit-name").setAttribute('class', 'form-control');
    document.getElementById("edit-passport").setAttribute('class', 'form-control');
    document.getElementById("edit-license").setAttribute('class', 'form-control');
    document.getElementById("edit-name-invalid").textContent = "";
    document.getElementById("edit-passport-invalid").textContent = "";
    document.getElementById("edit-license-invalid").textContent = "";
    const response = await fetch(`${uri}/${driverId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(driver)
    })
    //.then(() => getDrivers())
    //.catch(error => console.error('Unable to update driver.', error));
    if (response.ok === true) {
        getDrivers();
    }

    else {
        const errorData = await response.json();
        console.log("errors", errorData);
        if (errorData) {
            // ошибки вследствие валидации по атрибутам
            if (errorData.errors) {
                if (errorData.errors["FullName"]) {

                    document.getElementById("edit-name").setAttribute('class', 'form-control is-invalid');
                    document.getElementById("edit-name-invalid").textContent = errorData.errors["FullName"];
                    document.getElementById("edit-name-invalid").setAttribute('class', 'invalid-feedback');

                }
                if (errorData.errors["PassportNum"]) {

                    document.getElementById("edit-passport").setAttribute('class', 'form-control is-invalid');
                    document.getElementById("edit-passport-invalid").textContent = errorData.errors["PassportNum"];
                    document.getElementById("edit-passport-invalid").setAttribute('class', 'invalid-feedback');
                }
                if (errorData.errors["DriverLicenseNum"]) {

                    document.getElementById("edit-license").setAttribute('class', 'form-control is-invalid');
                    document.getElementById("edit-license-invalid").textContent = errorData.errors["DriverLicenseNum"];
                    document.getElementById("edit-license-invalid").setAttribute('class', 'invalid-feedback');
                }
            }
            // кастомные ошибки, определенные в контроллере
            // добавляем ошибки свойства Name
            if (errorData["FullName"]) {

                document.getElementById("edit-name").setAttribute('class', 'form-control is-invalid');
                document.getElementById("edit-name-invalid").textContent = errorData["FullName"];
                document.getElementById("edit-name-invalid").setAttribute('class', 'invalid-feedback');
            }

            // добавляем ошибки свойства Age
            if (errorData["PassportNum"]) {

                document.getElementById("edit-passport").setAttribute('class', 'form-control is-invalid');
                document.getElementById("edit-passport-invalid").textContent = errorData["PassportNum"];
                document.getElementById("edit-passport-invalid").setAttribute('class', 'invalid-feedback');
            }
            if (errorData["DriverLicenseNum"]) {

                document.getElementById("edit-license").setAttribute('class', 'form-control is-invalid');
                document.getElementById("edit-license-invalid").textContent = errorData["DriverLicenseNum"];
                document.getElementById("edit-license-invalid").setAttribute('class', 'invalid-feedback');
            }
        }
    }
        closeInput();

        return false;
}
    function closeInput() {
        document.getElementById('editForm').style.display = 'none';
    }


    function _displayDrivers(data) {
        const tBody = document.getElementById('drivers');
        tBody.innerHTML = '';


        const button = document.createElement('button');

        data.forEach(driver => {
            let editButton = button.cloneNode(false);
            editButton.innerText = 'Редагувати';
            editButton.setAttribute('class', 'btn btn-primary')
            editButton.setAttribute('data-toggle', 'collapse')
            editButton.setAttribute('data-target', '#editDriver')
            editButton.setAttribute('aria-expanded', 'false')
            editButton.setAttribute('aria-controls', 'editDriver')
            editButton.setAttribute('onclick', `displayEditForm(${driver.id})`);

            let deleteButton = button.cloneNode(false);
            deleteButton.innerText = 'Видалити';
            deleteButton.setAttribute('class', `btn btn-warning`);
            deleteButton.setAttribute('onclick', `deleteDriver(${driver.id})`);

            let tr = tBody.insertRow();


            let td1 = tr.insertCell(0);
            let textNodeName = document.createTextNode(driver.fullName);
            td1.appendChild(textNodeName);

            let td2 = tr.insertCell(1);
            let textNodePassport = document.createTextNode(driver.passportNum);
            td2.appendChild(textNodePassport);

            let td3 = tr.insertCell(2);
            let textNodeLicense = document.createTextNode(driver.driverLicenseNum);
            td3.appendChild(textNodeLicense);

            let td4 = tr.insertCell(3);
            if (driver.adrCertificate) { td4.innerHTML = "<b>+</b>" } else { td4.innerHTML = "<b>-</b>" }

            let td5 = tr.insertCell(4);
            td5.appendChild(editButton);

            let td6 = tr.insertCell(5);
            td6.appendChild(deleteButton);
        });

        drivers = data;
    }










