$(document).ready(function () {
    $("#hotelLocation").on("focus", function () {
        $.ajax({
            type: "POST",
            url: "/Home/GetHotelList",
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                // Clear previous suggestions
                $("#HotelLocationList").empty();
                // Append each destination as a dropdown item
                $.each(data, function (index, v) {

                    $("#HotelLocationList").append(
                        `<a href="#" class="dropdown-item" onclick="selectLocation('${v}')">${v}</a>`
                    );
                });

                // Show the dropdown
                $("#HotelLocationList").show();
            }
        });
    });
    // Hide the dropdown if clicked outside
    $(document).on("click", function (e) {
        if (!$(e.target).closest("#hotelLocation, #HotelLocationList").length) {
            $("#HotelLocationList").hide(); // Hide the dropdown
        }      
    });
   
});
function selectLocation(location) {
    $("#hotelLocation").val(location); // Set the selected value in the input field
    $("#HotelLocationList").hide(); // Hide the dropdown
}