$(document).ready(function () {


    var theForm = $("#theForm");
    theForm.hide();

    var buyButton = $("#buyButton");
    buyButton.on("click", function () {
        alert("Buy the pic");
    });

    var productProp = $(".product-props li");
    productProp.on("click", function () {

        console.log("you clicked on " + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function () {
        $popupForm.slideToggle(500);
    });
});

