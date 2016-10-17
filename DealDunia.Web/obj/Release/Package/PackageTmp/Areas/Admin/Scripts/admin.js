function callAjaxURLWithSingleParam(url, param) {
    return $.ajax({
        url: url,
        data: param
    });
}

function callAjaxPostURLWithSingleParam(url, param) {
    return $.ajax({
        url: url,
        data: param,
        type: 'POST'
    });
}

function callAjaxPostURLWithSingleParamJSON(url, param) {
    return $.ajax({
        url: url,
        data: param,
        datatype:'Json',
        type: 'POST'
    });
}

