//document.addEventListener("DOMContentLoaded", function () {
//    // Get current page URL
//    let currentPath = window.location.pathname.toLowerCase();

//    // Select all nav links
//    let navLinks = document.querySelectorAll(".nav-tabs .nav-link");

//    // Loop through links and add 'active' class if it matches current URL
//    navLinks.forEach(link => {
//        if (link.getAttribute("href").toLowerCase() === currentPath) {
//            link.classList.add("active");
//        }
//    });
//});

document.addEventListener("DOMContentLoaded", function () {
    let currentPath = window.location.pathname.toLowerCase();
    let navLinks = document.querySelectorAll(".nav-tabs .nav-link");

    navLinks.forEach(link => {
        if (link.getAttribute("href").toLowerCase() === currentPath) {
            link.classList.add("active");
        }
    });
});