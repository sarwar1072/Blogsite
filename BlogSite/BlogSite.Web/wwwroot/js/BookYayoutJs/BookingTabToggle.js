document.addEventListener("DOMContentLoaded", function () {
    const tabButtons = document.querySelectorAll(".tab-btn");

    // Retrieve stored active states from localStorage
    const activeBookingTab = localStorage.getItem("activeBookingTab");


    // Set the active class for the booking tabs
    if (activeBookingTab) {
        tabButtons.forEach(btn => {
            btn.classList.remove("btn-danger", "text-white");
            if (btn.getAttribute("data-tab") === activeBookingTab) {
                btn.classList.add("btn-danger", "text-white");
                btn.classList.remove("btn-outline-danger");
            }
        });
    }



    tabButtons.forEach(button => {
        button.addEventListener("click", function () {
            tabButtons.forEach(btn => btn.classList.remove("btn-danger", "text-white"));
            this.classList.add("btn-danger", "text-white");
            this.classList.remove("btn-outline-danger");

            // Store the active booking tab
            localStorage.setItem("activeBookingTab", this.getAttribute("data-tab"));
        });
    });
});



//document.addEventListener("DOMContentLoaded", function () {
//    const sidebarLinks = document.querySelectorAll(".nv");
//    const tabButtons = document.querySelectorAll(".tab-btn");

//    // Retrieve stored active states from localStorage
//    const activeSidebarTab = localStorage.getItem("activeSidebarTab");
//    const activeBookingTab = localStorage.getItem("activeBookingTab");

//    // Set the active class for the sidebar
//    if (activeSidebarTab) {
//        sidebarLinks.forEach(link => {
//            link.classList.remove("active", "bg-danger", "text-white", "rounded", "px-3", "py-2");
//            if (link.getAttribute("data-tab") === activeSidebarTab) {
//                link.classList.add("active", "bg-danger", "text-white", "rounded", "px-3", "py-2");
//            }
//        });
//    }

//    // Set the active class for the booking tabs
//    if (activeBookingTab) {
//        tabButtons.forEach(btn => {
//            btn.classList.remove("btn-danger", "text-white");
//            if (btn.getAttribute("data-tab") === activeBookingTab) {
//                btn.classList.add("btn-danger", "text-white");
//                btn.classList.remove("btn-outline-danger");
//            }
//        });
//    }

//    // Click event for sidebar navigation
//    sidebarLinks.forEach(link => {
//        link.addEventListener("click", function () {
//            sidebarLinks.forEach(l => l.classList.remove("active", "bg-danger", "text-white", "rounded", "px-3", "py-2"));
//            this.classList.add("active", "bg-danger", "text-white", "rounded", "px-3", "py-2");

//            // Store the active sidebar tab
//            localStorage.setItem("activeSidebarTab", this.getAttribute("data-tab"));
//        });
//    });

//    // Click event for booking tabs
//    tabButtons.forEach(button => {
//        button.addEventListener("click", function () {
//            tabButtons.forEach(btn => btn.classList.remove("btn-danger", "text-white"));
//            this.classList.add("btn-danger", "text-white");
//            this.classList.remove("btn-outline-danger");

//            // Store the active booking tab
//            localStorage.setItem("activeBookingTab", this.getAttribute("data-tab"));
//        });
//    });
//});
