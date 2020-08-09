$(document).ready(function () {
    $('.sepeteAt').on("click", function () {
        var getItemId = $(this).attr('data-id');
        $.ajax({
            type: 'POST',
            url: '/Cart/AddToCart',
            data: { ProductId: getItemId },
            success: function (data) {
                $('#sepeteEklendi').modal('show');
            },
        });
    });
});