$(document).ready(function () {
    GetCustomerList();
})
var SaveCustomer = function () {
    debugger;

    var customerid = $("#hdnid").val();
    var name = $("#txtName").val();
    var mobileno = $("#txtMobileNo").val();
    var emailid = $("#txtEmail").val();
    var password = $("#pass").val();

    var model = {
        CustomerID: customerid,
        Name: name,
        MobileNo: mobileno,
        EmailId: emailid,
        Password: password,
    };

    $.ajax({

        url: "/Customer/SaveCustomer",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message)
            GetCustomerList();
        },
        error: function (response) {
            alert(response.model)
        }
    });
}

var GetCustomerList = function () {
    debugger;
    $.ajax({
        url: "/Customer/GetCustomerList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblCustomer tbody").empty();
            $.each(response.Message, function (index, elementValue) {
                html += "<tr><td>" + elementValue.CustomerID +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.MobileNo +
                    "</td><td>" + elementValue.EmailId +
                    "</td><td>" + elementValue.Password + "</td><td><input type='button' class='btn btn-danger'value='delete'onclick='DeleteCustomer(" + elementValue.CustomerID + ")'</td><td><input type='button' class='btn btn-info'value='edit'onclick='EditCustomer(" + elementValue.CustomerID + ")'</td></tr>";
            })
            $("#tblCustomer tbody").append(html);
        },
        error: function (response) {
            alert(response.model)
        }
    });
}

var DeleteCustomer = function (CustomerID) {
    debugger;
    var model = { CustomerID: CustomerID }
    $.ajax({
        url: "/Customer/DeleteCustomer",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async:false,
        success: function (response) {
            alert("Data deleted successfully");
        }
    });
}

var EditCustomer = function (CustomerID) {
    debugger;
    var model = { CustomerID: CustomerID }

    $.ajax({
        url: "/Customer/EditCustomer",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            $("#hdnid").val(response.model.CustomerID);
            $("#txtName").val(response.model.Name);
            $("#txtMobileNo").val(response.model.MobileNo);
            $("#txtEmail").val(response.model.EmailId);
            $("#pass").val(response.model.Password);

        }
    });
}