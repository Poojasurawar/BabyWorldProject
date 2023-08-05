$(document).ready(function () {
    GetCategoriesList();
});
var SaveCategory = function () {
    debugger;

    var categoryid = $("#hdCategoryID").val();
    var name = $("#txtName").val();
    var details = $("#txtDetails").val();

    var model = {
        CategoryID: categoryid,
        Name: name,
        Details: details,
    };

    $.ajax({
        url: "/Category/SaveCategory",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message)
            GetCategoriesList();
        },
        error: function (response) {
            alert(response.model)
        }
    })
}

var GetCategoriesList = function () {
    debugger;
    $.ajax({
        url: "/Category/GetList",
        method: "post",
        /*data: JSON.stringify(model),*/
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblCategory tbody").empty();
            $.each(response.Message, function (index, elementValue) {
                html += "<tr><td>" + elementValue.CategoryID +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.Details + "</td><td><input type='button' class='btn btn-danger' value='delete'onclick='DeleteCategory(" + elementValue.CategoryID + ")'</td><td><input type='button' class='btn btn-success'value='edit' onclick='EditCategory(" + elementValue.CategoryID+")'</td></tr>"
            })
            $("#tblCategory tbody").append(html);
        },
        error: function (response) {
            alert(response.model)
        }
    });
}

var DeleteCategory = function (CategoryID) {
    debugger;
    var model = { CategoryID: CategoryID }

    $.ajax({
        url: "/Category/DeleteCategory",
        method: "post",
        data: JSON.stringify(model),
        contentType:"application/json;charset=utf-8",
        dataType: "json",
        async:false,
        success: function (response) {
            alert("Category deleted");
        }
    })
}

var EditCategory = function (CategoryID) {
    debugger;
    var model = { CategoryID: CategoryID }

    $.ajax({
        url: "/Category/EditCategory",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdCategoryID").val(response.model.CategoryID);
            $("#txtName").val(response.model.Name);
            $("#txtDetails").val(response.model.Details);

        }
    });
}