$(".button-position-delete").click(function () {
    var index = $(this).data("index")
    $.ajax({
        url: '/ShopCard/DeleteProductOnCard?indx=' + index,
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            location.reload();
        },
        error: function (e) { }
    })
});

$(".price-button-buy").click(function () {
    var deposit = $('#deposit').data("deposit");
    var price = $('.list-price').data("price");
    window.location.href = '/Pay/Finish?deposit=' + deposit + "&price=" + encodeURIComponent(price);
});

