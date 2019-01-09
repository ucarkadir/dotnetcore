// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


$(document).ready(function () {

    $('.dell-button').on('click', function (e) {
        custDisabled(e.target);
    });

    var statu = true;
    $('.select-button').on('click', function () {

        this.disabled = true;

        panel(statu);
    });

    // custUpdated işlemi yap
    $('#btnUpd').on('click', function () {
        custUpdated();
    });


});

function panel(status) {

    var addPanel = $('.add-item-form');
    var updPanel = $('.upd-item-form');

    if (status == true) {
        addPanel.hide();
        updPanel.show();
        status = false;
    } else {
        addPanel.show();
        updPanel.hide();
        status = true;
    }
    statu=status;
}

function custUpdated() {
    // ajax post ile seçili olan müsterinin bilgilerini getir.   

};


function custDisabled(button) {
    button.disabled = true;

    var row = button.closest('tr');
    row.addClass('dell');

    var form = button.closest('form');
    form.submit();
};