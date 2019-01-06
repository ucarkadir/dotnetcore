// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


$(document).ready(function() {
    
    $('.dell-button').on('click', function(e) {
        custDisabled(e.target);
    });
});

function custDisabled(button) {
    button.disabled = true;

    var row = button.closest('tr');
    $(row).addClass('dell');

    var form = button.closest('form');
    form.submit();
}