    $(document).ready(function () {
        $("#btnTour").click(function (e) {
            e.preventDefault();

            $.ajax({
                type: "GET",
                url: "/Home/GetListOfTour", // Replace with the actual endpoint for fetching tours
                contentType: "application/json",
                success: function (data) {
                    console.log("Data received:", data);
                    renderTours(data);
                },
                error: function (error) {
                    console.log("Error fetching tour data:", error);
                }
            });
        });
        });

    function renderTours(response) {
        const tours = Array.isArray(response) ? response : response.tours; // Adjust based on actual structure
        $("#tourList").empty();

    if (Array.isArray(tours)) {
        tours.forEach(function (tour) {
            const tourCard = `
                        <div class="card tour-card">
                                    <img src="${tour.tourUrl}" alt="${tour.tourName}" class="card-img-top">
                            <div class="card-body">
                                <h5 class="card-title">${tour.tourName}</h5>
                                <p class="card-text">${tour.destination}</p>
                                <p class="card-price">Price: $${tour.price}</p>
                                <button class="btn btn-primary">Book Now</button>
                            </div>
                        </div>
                    `;
            $("#tourList").append(tourCard);
        });
            } else {
        console.error("Expected an array but received:", tours);
            }
        }
        

