$(document).ready(function () {
    $("#btnTour").click(function () {
        $(".search-form").hide(); // Hide all search forms
        $("#tourSearch").show();  // Show the Tour search form
    });

    $("#btnHotel").click(function () {
        $(".search-form").hide();
        $("#hotelSearch").show(); // Show the Hotel search form
    });

    $("#btnFlight").click(function () {
        $(".search-form").hide();
        $("#flightSearch").show(); // Show the Flight search form
    });
});