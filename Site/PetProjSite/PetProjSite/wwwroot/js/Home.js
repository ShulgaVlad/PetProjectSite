// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Отримайте посилання на кнопки та цільові елементи
var buttonPortfolio = document.getElementById('Main__button_portfolio');
var buttonContacts = document.getElementById('Main__button_contacts');
var portfolioElement = document.getElementById('portfolio');
var contactsElement = document.getElementById('contacts');
var footerElement = document.querySelector('footer');

// Додайте обробник подій для натискання на кнопки
buttonPortfolio.addEventListener('click', function () {
    // Викликайте метод scrollIntoView() для прокрутки до цільового елемента
    portfolioElement.scrollIntoView({ behavior: 'smooth' });
});

buttonContacts.addEventListener('click', function () {
    // Викликайте метод scrollIntoView() для прокрутки до цільового елемента
    footerElement.scrollIntoView({ behavior: 'smooth' });
});