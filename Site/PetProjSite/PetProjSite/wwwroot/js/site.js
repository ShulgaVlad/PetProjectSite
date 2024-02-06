// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    const toggleButton = document.getElementById('toggleButton');
    const menu = document.getElementById('menu');

    toggleButton.addEventListener('click', function () {
        // Toggle the menu's position on button click
        if (menu.classList.contains('menu-open')) {
            menu.style.right = '-300px';
            menu.classList.remove('menu-open');
        } else {
            menu.style.right = '0px';
            menu.classList.add('menu-open');
        }
    });
});

