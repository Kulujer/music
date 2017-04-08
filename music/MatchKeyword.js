$(function () {
    $("#txtSearch").keyup(function () {
        var availableTags = [];
        var key = $("#txtSearch").val();
        $.ajax({
            url: 'MatchKeyword.ashx',
            type: 'post',
            data: { "key": key },
            success: function (res) {
                var jsonObj = jQuery.parseJSON(res);
                var availableTags = jsonObj["res"];
                $("#txtSearch").autocomplete({
                    source: availableTags
                });
            }
        });
    });
});