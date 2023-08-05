$(document).ready(function () {
    OrderList();
})
var SaveOrder = function () {
    debugger;

    var orderid = $("#txthd").val();
    var customerid = $("#txtCustomerID").val();
    var amount = $("#txtAmount").val();
    var discount = $("#txtDiscount").val();
    var totalamount = $("#txtTotalAmount").val();
    var orderdate = $("#txtOrderDate").val();
    var paymentmode = $("#txtPaymentMode").val();
    var sgst = $("#txtSGST").val();
    var cgst = $("#txtCGST").val();
    var igst = $("#txtIGST").val();
    var deliverydate = $("#txtDeliveryDate").val();
    var deliveryperson = $("#txtDeliveryPerson").val();

    var model = {
        OrderID: orderid,
        CustomerID: customerid,
        Amount: amount,
        Discount: discount,
        TotalAmount: totalamount,
        OrderDate: orderdate,
        PaymentMode: paymentmode,
        SGST: sgst,
        CGST:cgst,
        IGST: igst,
        DeliveryDate: deliverydate,
        DeliveryPerson: deliveryperson,
  };
    $.ajax({
        url: "/Order/SaveOrder",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (response) {
            alert(response.Message)
            OrderList();
        },
        error: function (response) {
            alert(response.model)
        }
    });
}

var OrderList = function () {

    $.ajax({
        url: "/Order/OrderList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblOrder tbody").empty();
            $.each(response.Message, function (index, elementValue) {
                html += "<tr><td>" + elementValue.OrderID +
                    "</td><td>" + elementValue.CustomerID +
                    "</td><td>" + elementValue.Amount +
                    "</td><td>" + elementValue.Discount +
                    "</td><td>" + elementValue.TotalAmount +
                    "</td><td>" + elementValue.OrderDate +
                    "</td><td>" + elementValue.PaymentMode +
                    "</td><td>" + elementValue.SGST +
                    "</td><td>" + elementValue.CGST +
                    "</td><td>" + elementValue.IGST +
                    "</td><td>" + elementValue.DeliveryDate +
                    "</td><td>" + elementValue.DeliveryPerson +
                    "</td><td><input type='button'class='btn btn-success'value='edit'onclick='EditOrder(" + elementValue.OrderID + ")'</td></tr>";
            })
            $("#tblOrder tbody").append(html);
        },
        error: function (response) {
            alert(response.model)
        }
    });
}

var EditOrder = function () {
    debugger;
    var model = { OrderID: OrderID }

    $.ajax({
        url: "/Order/EditOrder",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            $("#txthd").val(response.Message.OrderID);
            $("#txtCustomerID").val(response.Message.CustomerID);
            $("#txtAmount").val(response.Message.Amount);
            $("#txtDiscount").val(response.Message.Discount);
            $("#txtTotalAmount").val(response.Message.TotalAmount);
            $("#txtOrderDate").val(response.Message.OrderDate);
            $("#txtPaymentMode").val(response.Message.PaymentMode);
            $("#txtSGST").val(response.Message.SGST);
            $("#txtCGST").val(response.Message.CGST);
            $("#txtIGST").val(response.Message.IGST);
            $("#txtDeliveryDate").val(response.Message.DeliveryDate);
            $("#txtDeliveryPerson").val(response.Message.DeliveryPerson);
        }
    });
}