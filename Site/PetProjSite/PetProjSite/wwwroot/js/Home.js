// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


document.addEventListener('DOMContentLoaded', function () {
    // весь ваш код тут
    var buttonPortfolio = document.getElementById('Main__button_portfolio');
    var buttonContacts = document.getElementById('Main__button_contacts');
    var portfolioElement = document.getElementById('portfolio');
    var contactsElement = document.getElementById('contacts');
    var footerElement = document.querySelector('footer');

    buttonPortfolio.addEventListener('click', function () {
        portfolioElement.scrollIntoView({ behavior: 'smooth' });
    });

    buttonContacts.addEventListener('click', function () {
        footerElement.scrollIntoView({ behavior: 'smooth' });
    });
});