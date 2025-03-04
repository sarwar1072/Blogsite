document.addEventListener("DOMContentLoaded", function () {
    const buttons = document.querySelectorAll(".tab-btn");
    const activeTab = localStorage.getItem("activeTab");

    // Set the active class based on stored value
    if (activeTab) {
        buttons.forEach(btn => {
            if (btn.getAttribute("data-tab") === activeTab) {
                btn.classList.remove("btn-outline-danger");
                btn.classList.add("btn-danger", "text-white");
            }
        });
    }

    buttons.forEach(button => {
        button.addEventListener("click", function () {
            localStorage.setItem("activeTab", this.getAttribute("data-tab"));
        });
    });
});

