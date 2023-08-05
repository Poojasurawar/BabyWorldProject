$(document).ready(function () {
    GetCartList();
});


var SaveCart = function () {
    debugger;

    var cartid = $("#hdnCartID").val();
    var orderid = $("#txtOrderID").val();
    var productid = $("#txtProductID").val();
    var price = $("#txtPrice").val();
    var quantity = $("#txtQuantity").val();
    var amount = $("#txtAmount").val();
    var discount = $("#txtDiscount").val();

    var model = {
        CartID:cartid,
        OrderID: orderid,
        ProductID: productid,
        Price: price,
        Quantity: quantity,
        Amount: amount,
        Discount: discount,
    }

    $.ajax({
        url: "/Cart/SaveCart",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message)
            GetCartList();
        },
        error: function (response) {
            alert(response.model)
        }
    });
}

var GetCartList = function ()
{
    debugger;
    $.ajax({
        url: "/Cart/GetList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblCart tbody").empty();
            $.each(response.Message, function (index, elementValue) {
                html += "<tr><td>" + elementValue.CartID +
                    "</td><td>" + elementValue.OrderID +
                    "</td><td>" + elementValue.ProductID +
                    "</td><td>" + elementValue.Price +
                    "</td><td>" + elementValue.Quantity +
                    "</td><td>" + elementValue.Amount +
                    "</td><td>" + elementValue.Discount + "</td><td><input type ='button' class ='btn btn-danger' value='delete'onclick='RemoveItem(" + elementValue.CartID + ")'/><td><td><input type ='button' class = 'btn btn-info' value='Edit'onclick='EditCart(" + elementValue.CartID + ")'/></td></tr>";
            })
            $("#tblCart tbody").append(html);
        },
        error: function (response) {
            alert(response.model)
        }
    });

}

var RemoveItem = function (CartID) {
    debugger;
    var model = { cartid: CartID }
    $.ajax({
        url: "/Cart/RemoveItem",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Item Removed Successfully");
        }
    });
}

var EditCart = function (CartID) {
    var model = { CartID: CartID };
    $.ajax({
        url: "/Cart/EditCart",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdnCartID").val(response.model.CartID);
            $("#txtOrderID").val(response.model.OrderID);
            $("#txtProductID").val(response.model.ProductID);
            $("#txtPrice").val(response.model.Price);
            $("#txtQuantity").val(response.model.Quantity);
            $("#txtAmount").val(response.model.Amount);
            $("#txtDiscount").val(response.model.Discount);
        }

    });
}