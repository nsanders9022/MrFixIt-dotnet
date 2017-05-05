//var test = "it works";
//console.log(test);

$(document).ready(function () {
    $('.activate').click(function () {
        var route = '#activate-result-' + this.id;
        console.log(this.id);
        $.ajax({
            type: 'GET',
            url: 'Jobs/Activate/' + this.id,
            success: function (result) {
                $(route).html(result);
            }
        });
    });
});