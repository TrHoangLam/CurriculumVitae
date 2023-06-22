// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $(function () {
        $('#button-export').click(function () {
            console.log('test')
            $('#examScoresTable').table2excel({
                filename: 'ExamScores.xls'
            });
        });
    });

$(function () {
    $('#button-export').click(function () {
        console.log('test')
        $('#StudentTable').table2excel({
            filename: 'Students.xls'
        });
    });
});