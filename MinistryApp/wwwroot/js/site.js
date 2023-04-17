// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
$(document).ready(function () {
    $("#FaqTitle").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Course/Create1",
                tye: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.Title, value: item.Title };
                    }))
                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });
})



function FileDelete(sender) {
    Ask("Are you sure to delete this file!", function () {
        var url = "/Common/FileDelete?filepath=" + $(sender).attr('data-url') + "&table=" + $(sender).attr('data-table') + "&field=" + $(sender).attr('data-field') + "&id=" + $(sender).attr('data-id');
        $.ajax({
            type: "GET",
            url: url,
            error: function (xhr, status, error) {
                //"test"
            },
            success: function (response) {
                if (response) {
                    $(sender).closest("div").parent().remove();
                    ShowResult("Success", "File deleted!");
                }
                else {
                    ShowResult("Fail", "File deleted failed!");
                }
            }
        })
    }, function () { })

}

