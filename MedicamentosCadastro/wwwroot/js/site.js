

$(document).ready(function () {

    $('#Medicamentos').DataTable();

    setTimeout(function () {

        $('.alert').fadeOut("low", function () {
            $(this).alert('close');
        })
    }, 5000)

});