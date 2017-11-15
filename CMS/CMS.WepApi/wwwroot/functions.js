function GetUsers() {
    $.ajax({
        url: '/api/customers/',
        type: 'GET',
        contentType: "application/json",
        success: function (users) {
            var rows = "";
            $.each(users,
                function (index, user) {
                    rows += "<tr><td>" + user.firstName + "</td><td>" + user.lastName + "</td><td>" + user.birthDate + "</td><td>" + user.email + "</td><td>" + user.phoneNumber + "</td><td>" + user.country + "</td><td>" + user.city + "</td></tr>";
                });
            $("table tbody").append(rows);
        }
    });
}
var row = function (user) {
    return "<tr data-rowid='" + user.firstName + "'>" +
        "" + "<td>" + user.firstName + "</td>"
        + "<td>" + user.lastName + "</td>"
        + " <td>" + user.birthDate + "</td>"
        + "<td>" + user.email + "</td> <td>"
        + "<td>" + user.phoneNumber + "</td> <td>"
        + "<td>" + user.country + "</td> <td>" +

        "<td><a class='editLink' data-id='" + user.id + "'>Save</a> | " +
        "<a class='removeLink' data-id='" + user.id + "'>Reset</a></td></tr>";
}

function CreateUser(firstName, lastName, birthDate, email, phoneNumber, country, city) {
    $.ajax({
        url: "api/customers",
        contentType: "application/json",
        method: "POST",
        data: JSON.stringify({
            firstName: firstName,
            lastName: lastName,
            birthDate: birthDate,
            email: email,
            phoneNumber: phoneNumber,
            country: country,
            city: city
        }),
        success: function (user) {
            reset();
            $("table tbody").append(row(user));
        }
    });
}

$("#reset").click(function (e) {

    e.preventDefault();
    reset();
});

$("form").submit(function (e) {
    e.preventDefault();
    var firtsName = this.elements["firstName"].value;
    var lastName = this.elements["lastName"].value;
    var birthDate = this.elements["birthDate"].value;
    var email = this.elements["email"].value;
    var phoneNumber = this.elements["phoneNumber"].value;
    var country = this.elements["country"].value;
    var city = this.elements["city"].value;
    CreateUser(firtsName, lastName, birthDate, email, phoneNumber, country, city);

});

GetUsers();
