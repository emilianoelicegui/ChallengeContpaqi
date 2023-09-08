$(document).ready(function () {
    const form = document.getElementById("employeeForm");

    $("#employeeForm").validate({
        rules: {
            Name: {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            LastName: {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            Age: {
                required: true,
                digits: true, 
                min: 0
            },
            DateOfBirth: {
                required: true,
                date: true 
            },
            Gender: {
                required: true
            },
            CivilStatus: {
                required: true
            },
            Rfc: {
                required: true,
                minlength: 13, 
                maxlength: 13
            },
            Address: {
                required: true
            },
            Email: {
                required: true,
                email: true 
            },
            PhoneNumber: {
                required: true
            },
            Position: {
                required: true
            },
            EndDate: {
                date: true 
            }
        },
        messages: {
            Name: {
                required: "El nombre es requerido."
            },
            LastName: {
                required: "El apellido es requerido."
            },
            Age: {
                required: "La edad es requerida.",
                digits: "Ingrese solo dígitos.",
                min: "La edad mínima permitida es 18 años."
            },
            DateOfBirth: {
                required: "La fecha de nacimiento es requerida.",
                date: "Ingrese una fecha válida."
            },
            Gender: {
                required: "El género es requerido."
            },
            CivilStatus: {
                required: "El estado civil es requerido."
            },
            Rfc: {
                required: "El RFC es requerido."
            },
            Address: {
                required: "La dirección es requerida."
            },
            Email: {
                required: "El correo electrónico es requerido.",
                email: "Ingrese una dirección de correo electrónico válida."
            },
            PhoneNumber: {
                required: "El número de teléfono es requerido."
            },
            Position: {
                required: "La posición es requerida."
            },
            EndDate: {
                date: "Ingrese una fecha válida para la fecha de término."
            }
        },
        errorElement: "span",
        errorPlacement: function (error, element) {
            error.addClass("text-danger");
            error.appendTo(element.parent());
        }
    });

    var url = window.location.pathname; 
    var segments = url.split('/'); 
    var employeeId = segments[segments.length - 1]; 

    if (!isNaN(employeeId)) {
        console.log(employeeId);
        axios.get(apiUrl + "/employee/Get/" + employeeId) 
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
        $("#EndDate").val(employee.endDate.substring(0, 10));
    }
   
    $("#submitButton").click(function () {

        if ($("#employeeForm").valid()) {

            const formData = new FormData(form);
            const data = {};
            formData.forEach((value, key) => {
                data[key] = value;
            });

            if (data["Id"] === "") {
                data["Id"] = null;
            }

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
        }
    });
});