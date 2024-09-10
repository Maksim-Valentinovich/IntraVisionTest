$(".finish-pay-button").click(function () {
    $.ajax({
        url: '/ShopCard/ClearShopCard',
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            window.location.href = "http://localhost:5255/Home/Index";
        },
        error: function (e) { }
    })
});

