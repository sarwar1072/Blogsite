document.addEventListener('DOMContentLoaded', function () {
    // Set default location
    document.getElementById('hotelLocation').value = "Dhaka";

    // Set default dates
    const today = new Date();
    const checkInDate = new Date(today);
    const checkOutDate = new Date(today);
    checkInDate.setDate(today.getDate() + 2); // Check-in 2 days from today
    checkOutDate.setDate(today.getDate() + 7); // Check-out 7 days from today

    document.getElementById('checkInDate').value = checkInDate.toISOString().split('T')[0];
    document.getElementById('checkOutDate').value = checkOutDate.toISOString().split('T')[0];

    // Set default number of guests
    document.getElementById('numberOfGuests').value = 2;
});
