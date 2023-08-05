$(document).ready(function () {
    GetProductList();
})
var SaveProduct = function () {
    debugger;

    var productid = $("#txthd").val();
    var productname = $("#txtProductName").val();
    var productimage = $("#txtProductImage").val();
    var description = $("#txtDescription").val();
    var mfgdate = $("#txtMFGDate").val();
    var expirydate = $("#txtExpiryDate").val();
    var price = $("#txtPrice").val();
    var discount = $("#txtDiscount").val();
    var sgst = $("#txtSGST").val();
    var cgst = $("#txtCGST").val();
    var igst = $("#txtIGST").val();
    var categoryid = $("#txtCategoryID").val();

    var model = {
        ProductID: productid,
        ProductName: productname,
        ProductImage: productimage,
        Description: description,
        MFGDate: mfgdate,
        ExpiryDate: expirydate,
        Price: price,
        Discount: discount,
        SGST: sgst,
        CGST: cgst,
        IGST: igst,
        CategoryID:categoryid
    };

    $.ajax({
        url: "/Product/SaveProduct",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (response) {
            alert(response.Message)
            GetProductList();
            
        },
        error: function (response) {
            alert(response.model)
        }
    });
}

var GetProductList = function () {
    debugger;
    $.ajax({
        url: "/Product/GetProductList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblProduct tbody").empty();
            $.each(response.Message, function (index, elementValue) {
               html+= "<tr><td>" + elementValue.ProductID +
                    "</td><td>" + elementValue.ProductName +
                    "</td><td>" + elementValue.ProductImage +
                    "</td><td>" + elementValue.Description +
                    "</td><td>" + elementValue.MFGDate +
                    "</td><td>" + elementValue.ExpiryDate +
                    "</td><td>" + elementValue.Price +
                    "</td><td>" + elementValue.Discount +
                    "</td><td>" + elementValue.SGST +
                    "</td><td>" + elementValue.CGST +
                    "</td><td>" + elementValue.IGST +
                   "</td><td>" + elementValue.CategoryID +
                   "</td><td><input type='button'class='btn btn-danger' value='delete'onclick='DeleteProduct(" + elementValue.ProductID + ")'</td></tr>";
            })
            $("#tblProduct tbody").append(html);
        },
        error: function (response) {
            alert(response.model)
        }
    });
}

var DeleteProduct = function (ProductID) {
    debugger;
    var model = { ProductID: ProductID }

    $.ajax({
        url: "/Product/DeleteProduct",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            alert("Item Removed Successfully");
        }
    });
}