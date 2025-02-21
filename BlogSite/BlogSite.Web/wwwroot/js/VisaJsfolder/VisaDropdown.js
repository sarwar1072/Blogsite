$(document).ready(function () {
    $("#VisaDestination").on("focus", function () {
        $.ajax({
            type: "POST",
            url: "/Visa/GetDropDownList",
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                // Clear previous suggestions
                $("#VisadestinationList").empty();
                // Append each destination as a dropdown item
                $.each(data, function (index, v) {

                    $("#VisadestinationList").append(
                        `<a href="#" class="dropdown-item" onclick="selectLocation('${v}')">${v}</a>`
                    );
                });

                // Show the dropdown
                $("#VisadestinationList").show();
            }
        });
    });
    // Hide the dropdown if clicked outside
    $(document).on("click", function (e) {
        if (!$(e.target).closest("#VisaDestination, #VisadestinationList").length) {
            $("#VisadestinationList").hide(); // Hide the dropdown
        }
    });

});
function selectLocation(location) {
    $("#VisaDestination").val(location); // Set the selected value in the input field
    $("#VisadestinationList").hide(); // Hide the dropdown
}