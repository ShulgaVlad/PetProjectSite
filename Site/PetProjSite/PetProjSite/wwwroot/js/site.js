// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    const toggleButton = document.getElementById('toggleButton');
    const menu = document.getElementById('menu');

    toggleButton.addEventListener('click', function () {
        // Toggle the menu's position on button click
        if (menu.classList.contains('menu-open')) {
            menu.classList.remove('menu-open');
        } else {
            menu.classList.add('menu-open');
        }
    });
});

window.addEventListener('keydown', (e) => {
    if (e.key === "Escape") {
        menu.classList.remove('menu-open');
    }
})
document.addEventListener('keydown', function (e) {
    if (e.key === 'Escape') {
        document.body.classList.add('no-focus-outline');
    }
});

document.addEventListener('focusout', function () {
    document.body.classList.remove('no-focus-outline');
});