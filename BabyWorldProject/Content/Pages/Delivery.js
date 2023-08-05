$(document).ready(function () {
    DeliveryList();
})
var SaveDelivery = function () {
    

    var deliverid = $("#txthd").val();
    var customerid = $("#txtCustomerID").val();
    var personname = $("#txtPersonName").val();
    var address = $("#txtAddress").val();
    var city = $("#txtCity").val();
    var landmark = $("#txtLandmark").val();
    var pincode = $("#txtPincode").val();
    var type = $("#txtType").val();

    var model = {
        DeliveryID: deliverid,
        CustomerID: customerid,
        PersonName: personname,
        Address: address,
        City: city,
        landmark: landmark,
        Pincode: pincode,
        Type: type,
    };
    $.ajax({
        url: "/Delivery/SaveDelivery",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (response) {
            alert(response.Message)
            DeliveryList();
        },
        error: function (response) {
            alert(response.model)
        }
    });
}

var DeliveryList = function () {
    
    $.ajax({
        url: "/Delivery/DeliveryList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblDelivery1 tbody").empty();
            $.each(response.Message, function (index, elementValue) {
                html += "<tr><td>" + elementValue.DeliveryID +
                    "</td><td>" + elementValue.CustomerID +
                    "</td><td>" + elementValue.PersonName +
                    "</td><td>" + elementValue.Address +
                    "</td><td>" + elementValue.City +
                    "</td><td>" + elementValue.Landmark +
                    "</td><td>" + elementValue.Pincode +
                    "</td><td>" + elementValue.Type +
                    "</td><td><input type='button'class='btn btn-danger'value='delete'onclick='DeleteDelivery(" + elementValue.DeliveryID + ")'</td><td><input type='button'class='btn btn-success'value='edit'onclick='EditDelivery(" + elementValue.DeliveryID + ")'</td></tr>";
            })
            $("#tblDelivery1 tbody").append(html);
        },
        error: function (response) {
            alert(response.model)
        }
    });
}

var DeleteDelivery = function (DeliveryID) {
    
    var model = { DeliveryID: DeliveryID }

    $.ajax({
        url: "/Delivery/DeleteDelivery",
        method: "post",
        data: JSON.stringify,
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            alert("Data Deleted");
        }
    });
}

var EditDelivery = function (DeliveryID) {
    
    var model = { DeliveryID: DeliveryID }

    $.ajax({
        url: "/Delivery/EditDelivery",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            $("#txthd").val(response.Message.DeliveryID);
            $("#txtCustomerID").val(response.Message.CustomerID);
            $("#txtPersonName").val(response.Message.PersonName);
            $("#txtAddress").val(response.Message.Address);
            $("#txtCity").val(response.Message.City);
            $("#txtLandmark").val(response.Message.Landmark);
            $("#txtPincode").val(response.Message.Pincode);
            $("#txtType").val(response.Message.Type);


        }
    });
}