$(document).ready(function () {
    $("#hotelForm").submit(function (e) {
        e.preventDefault(); // Prevent default form submission

        // Collect form data
        var location = $("#hotelLocation").val();
        var checkInDate = $("#checkInDate").val();
        var checkOutDate = $("#checkOutDate").val();
        var numberOfGuests = $("#Number").val();

        // Send AJAX POST request
        $.ajax({
            url: '/Home/SearchHotel',
            type: 'POST',
            data: {
                location: location,
                checkInDate: checkInDate,
                checkOutDate: checkOutDate,
                numberOfGuests: numberOfGuests
            },
            success: function (response) {
                // Process response (for example, display search results)
                $("#searchResults").html(response);
            },
            error: function (xhr, status, error) {
                console.error("Error:", error);
            }
        });
    });
});
