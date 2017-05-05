//var test = "it works";
//console.log(test);

$(document).ready(function () {
    //Displays result of marking a job as active
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

    //Displays result of marking a job as complete
    $('.complete').click(function () {
        var route = '#complete-result-' + this.id;
        console.log(this.id);
        $.ajax({
            type: 'GET',
            url: 'Jobs/Complete/' + this.id,
            success: function (result) {
                $(route).html(result);
            }
        });
    });

    //Displays claim button
    $('.claim').click(function () {
        var route = '#claim-show-' + this.id;
        console.log(this.id);
        $.ajax({
            type: 'GET',
            url: 'Jobs/Claim/' + this.id,
            success: function (result) {
                $(route).html(result);
            }
        });
    });

    //Posts change to database - user claims a job
    $('.claim-job').submit(function (event) {
        event.preventDefault();
        var route = '#claim-result-' + this.id;
        $.ajax({
            url: 'Jobs/Claim/' + this.id,
            type: 'POST',
            dataTyle: 'json',
            data: $(this).serialize(),
            success: function (result) {
                var resultMessage = "Job has been claimed";
                $(route).html(resultMessage);
            }
        })
    })
});