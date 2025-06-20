// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// liveClock
export function startLiveClock(serverTimeIso, elementId) {
    let serverTime = new Date(serverTimeIso);

    function updateClock() {
        document.getElementById(elementId).textContent = serverTime.toLocaleString();
        serverTime.setSeconds(serverTime.getSeconds() + 1);
    }

    updateClock();
    setInterval(updateClock, 1000);
}

