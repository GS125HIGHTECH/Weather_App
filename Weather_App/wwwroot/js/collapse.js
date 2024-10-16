document.addEventListener("DOMContentLoaded", () => {
    $('.card-header').on('click', function () {
        const icon = $(this).find('i');
        icon.toggleClass('bi-chevron-down bi-chevron-up');
    });
});