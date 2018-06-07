/*
 * 成功提示
 */
$.fn.SKSuccess = function (msg) {
    layer.alert(msg, { title: "提示", icon: 1 });
}

/*
 * 错误提示
 */
$.fn.SKError = function (msg) {
    layer.alert(msg, { title: "提示", icon: 2 });
}

/*
* 初始化DataTable
* type get or post
* url 例如 api/SysUser/
* initParam 初始化请求参数
* initResult 初始化返回结果
* columns 数组
*/
$.fn.SKDataTable = function (type, url, initParam, initResult, columns) {

    var options = {
        "ajax": function (data, callback, settings) {

            var requestData = {};
            requestData.start = data.start;
            requestData.length = data.length;

            if (initParam) {
                $.extend(requestData, initParam(requestData));
            }

            $.ajax({
                "url": app.ApiHost + url,
                "type": type,
                "contentType": "application/json",
                "dataType": "json",
                "beforeSend": function (request) {
                    request.setRequestHeader("Authorization", "Bearer " + window.localStorage["token"]);
                },
                "data": requestData,
                "success": function (json) {
                    json.draw = settings.draw;

                    if (initResult) {
                        $.extend(json, initResult(json));
                    }

                    callback(json);
                },
                "error": function (xhr, textStatus, errorThrown) {
                    if (xhr.status === 401) {
                        layer.alert('请重新登录...', {
                            title: "提示", icon: 2,
                            success: function (layero, index) {
                                mgr.signinRedirect();
                            }
                        });
                    }
                }
            })
        }, "columns": columns
    }
    var defaults = {
        "searching": false,
        "processing": true,
        "serverSide": true,
        "ordering": false,
        "destroy": true,
        "language": {
            url: '//cdn.datatables.net/plug-ins/1.10.16/i18n/Chinese.json'
        }
    }

    var settings = $.extend({}, defaults, options);

    return $(this).DataTable(settings);
}

$.fn.SKAjax = function (type, url, data, successFunc) {
    $.ajax({
        type: type,
        url: app.ApiHost + url,
        data: data,
        beforeSend: function (request) {
            request.setRequestHeader("Authorization", "Bearer " + storage["token"]);
        },
        success: function (result) {
            if (successFunc) {
                successFunc(result);
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            if (xhr.status === 401) {
                layer.alert('请重新登录...', {
                    title: "提示", icon: 2,
                    success: function (layero, index) {
                        mgr.signinRedirect();
                    }
                });
            }
        }
    });
}