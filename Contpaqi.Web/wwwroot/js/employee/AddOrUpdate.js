$(document).ready(function () {
    const form = document.getElementById("employeeForm");

    var url = window.location.pathname; 
    var segments = url.split('/'); 
    var employeeId = segments[segments.length - 1]; 

    if (!isNaN(employeeId)) {
        console.log(employeeId);
        axios.get(apiUrl + "/employee/Get/" + employeeId) // Ajusta la URL según tu enrutamiento
            .then(function (response) {
                if (response.status === 200) {
                    var employee = response.data;
                    populateEmployeeForm(employee);
                } else {
                    console.error("Error al obtener los datos del empleado.");
                }
            })
            .catch(function (error) {
                console.error("Error en la solicitud Axios: " + error);
                alert(error);
            });
    } else {
        console.error("ID de empleado no válido en la URL.");
    }

    function populateEmployeeForm(employee) {
        $("#Id").val(employee.id);
        $("#Name").val(employee.name);
        $("#LastName").val(employee.lastName);
        $("#MiddleName").val(employee.middleName);
        $("#Address").val(employee.address);
        $("#PhoneNumber").val(employee.phoneNumber);
        $("#Age").val(employee.age);
        $("#CivilStatus").val(employee.civilStatus);
        $("#DateOfBirth").val(employee.dateOfBirth.substring(0, 10));
        $("#Position").val(employee.position);
        $("#Email").val(employee.email);
        $("#Gender").val(employee.gender);
        $("#Rfc").val(employee.rfc);
        $("#EndDate").val(employee.endDate);
    }
   
    $("#submitButton").click(function () {
        const formData = new FormData(form);
        const data = {};
        formData.forEach((value, key) => {
            data[key] = value;
        });

        if (data["EndDate"] === "") {
            data["EndDate"] = null; 
        }

        axios.put(apiUrl + "/employee/AddOrUpdate", data)
            .then(response => {
                window.location.href = '/Employee/Index';
            })
            .catch(error => {
                alert("Error al guardar el empleado.");
            });
    });
});