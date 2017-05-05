//var test = "it works";
//console.log(test);

$(document).ready(function () {
    $('.activate').click(function () {
        $.ajax({
            type: 'GET',
            url: 'Jobs/Activate',
            success: function (result) {
                $('#activate-result').html(result);
            }
        });
    });
});