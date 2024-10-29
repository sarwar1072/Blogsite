$(document).ready(function (){
    $(".search-tab").click(function () {
        // Remove active class from all tabs
        $(".search-tab").removeClass("active");
        $(".search-tab img").addClass("inactive");
        $(".active-indicator").css("visibility", "hidden");

        // Add active class to clicked tab
        $(this).addClass("active");
        $(this).find("img").removeClass("inactive");
        $(this).find(".active-indicator").css("visibility", "visible");

        // Hide all tab content
        $(".tab-content").removeClass("active");

        // Show the relevant tab content
        var tabId = $(this).attr("id");
        $("#" + tabId + "Content").addClass("active");
    });
});

