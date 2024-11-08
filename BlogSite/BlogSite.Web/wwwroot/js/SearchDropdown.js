$(document).ready(function () {
    $("#tourDestination").on("focus", function () {
        $.ajax({
            type: "POST",
            url: "/Home/GetListOfDetination",
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                // Clear previous suggestions
                $("#destinationList").empty();
                // Append each destination as a dropdown item
                $.each(data, function (index, v) {

                    $("#destinationList").append(
                        `<a href="#" class="dropdown-item" onclick="selectDestination('${v.destination}')">${v.destination}</a>`
                    );
                });

                // Show the dropdown
                $("#destinationList").show();
            }
        });
    });
    // Hide the dropdown if clicked outside
    $(document).on("click", function (e) {
        if (!$(e.target).closest("#tourDestination").length) {
            $("#destinationList").hide();
        }
    });

    
});


// $(document).ready(function () {
  
// });
// Function to handle the click on a dropdown item
function selectDestination(destination) {
    $("#tourDestination").val(destination); // Set the selected value in the input field
    $("#destinationList").hide(); // Hide the dropdown
}