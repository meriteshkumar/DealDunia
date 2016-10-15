function loadStoreSource(url) {
    callAjaxURLWithSingleParam(url, { controlName: "StoreSourceId" })
    .done(function (data) {
        $(".container-store-source").html(data);
    }).fail(function (data, status, headers, config) {
        //TODO:Debugging
    });
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