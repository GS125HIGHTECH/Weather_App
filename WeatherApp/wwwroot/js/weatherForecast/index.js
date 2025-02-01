document.addEventListener("DOMContentLoaded", function () {
    const forecastContainers = document.querySelectorAll(".forecast-container");
    const currentDateDisplays = document.querySelectorAll(".current-date");

    forecastContainers.forEach((forecastContainer, index) => {
        const forecastHours = forecastContainer.querySelectorAll(".forecast-hour");
        const currentDateDisplay = currentDateDisplays[index];

        forecastContainer.addEventListener("scroll", function () {
            let closestHour = null;
            let closestDistance = Infinity;

            const containerRect = forecastContainer.getBoundingClientRect();
            const containerCenter = containerRect.left + containerRect.width / 2;

            forecastHours.forEach(hour => {
                const rect = hour.getBoundingClientRect();
                const hourCenter = rect.left + rect.width / 2;

                const distance = Math.abs(hourCenter - containerCenter);

                if (distance < closestDistance) {
                    closestDistance = distance;
                    closestHour = hour;
                }
            });

            if (closestHour) {
                currentDateDisplay.textContent = closestHour.getAttribute("data-date");
            }
        });
    });
});