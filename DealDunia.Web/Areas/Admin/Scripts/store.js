function loadStoreSource(url, containerclass) {
    return callAjaxURLWithSingleParam(url, { controlName: "StoreSourceId" });
}

function getStores(url, params) {
    $body = $("body");
    $body.addClass("loading");
    callAjaxURLWithSingleParam(url, params)
    .done(function (data) {
        $body.removeClass("loading");
        $("#container-store-grid").html(data);
    }).fail(function (data, status, headers, config) {
        //TODO:Debugging
    });
}

//$("#container-store-grid").on("click", "thead a,tfoot a", function (e) {
//    alert('test');
//    e.preventDefault();
//    var param = $(this).attr("href").split("?")[1];
//    var url = '@Url.Action("StoreGrid", "Stores")' + '?' + param;

//    callAjaxURLWithSingleParam(url, null)
//        .done(function (data) {
//            $("#container-store-grid").html(data);
//        }).fail(function (error) {
//            //TODO:Debugging
//        });
//});

function loadStoreView(url, params) {
    callAjaxURLWithSingleParam(url, params)
    .done(function (data) {
        $(".modal-dialog").html(data);
        $("#myModal").modal();

        //Need to register unobtrusive validation for dynamically added elements
        var form = $("#myForm");
        form.removeData('validator');
        form.removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse(form);
    }).fail(function (data, status, headers, config) {
        //TODO:Debugging
    });
}

function appendCategoryMapLineRow(url, param, containerclass) {
    callAjaxURLWithSingleParam(url, param)
    .done(function (data) {
        $("." + containerclass).append(data);
    }).fail(function (data, status, headers, config) {
        //TODO:Debugging
    });
}

function save(url, param) {
    callAjaxPostURLWithSingleParam(url, param)
    .done(function (data) {
        $("#myModal").modal("hide");
        alert("Record Saved.");
    }).fail(function (data, status, headers, config) {
        //TODO:Debugging
    });
}