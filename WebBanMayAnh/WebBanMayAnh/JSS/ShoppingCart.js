$(document).ready(function () {
    $(function () {
        $(".wart").click(function () {
            var productid = parseFloat($(this).attr("data-productid"));
            $.ajax({
                url: 'api/cart/add',
                type: "POST",
                dataType: "JSON",
                data: { productid: productid },
                success: function (response) {
                    if (response.result == 'Redirect') {
                        window.location = response.url;
                    }
                    else {
                        loadHeaderCart();//add product sucsess
                        location.reload();
                    }
                    console.log(response);
                },
                error: function (error) {
                    alert("There was an error posting the data to the server: " + error.responseText);
                }
            });
        });
    })
})
