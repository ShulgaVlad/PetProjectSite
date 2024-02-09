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


document.addEventListener('DOMContentLoaded', function () {
    var showButton = document.getElementById('show');
    var overlay = document.getElementById('overlay');

    showButton.addEventListener('click', function () {
        // Додаємо клас для з'явлення блоку
        overlay.classList.add('showOverlay');
    });

    // Додаємо обробник події для натискання клавіші "Escape"
    document.addEventListener('keydown', function (event) {
        if (event.key === 'Escape') {
            // Видаляємо клас для закриття вікна, якщо клас присутній
            overlay.classList.remove('showOverlay');
        }
    });
});



function copyToClipboard(elementId) {
    var element = document.getElementById(elementId);

    // Створюємо текстовий об'єкт
    var textArea = document.createElement('textarea');
    textArea.value = element.textContent;

    // Додаємо текстовий об'єкт до DOM
    document.body.appendChild(textArea);

    // Виділяємо текст у текстовому об'єкті
    textArea.select();

    try {
        // Копіюємо виділений текст в буфер обміну з використанням Clipboard API
        navigator.clipboard.writeText(textArea.value)
            .then(() => {
                alert('Текст скопійовано в буфер обміну: ' + element.textContent);
            })
            .catch(err => {
                console.error('Помилка копіювання в буфер обміну: ', err);
            });
    } catch (err) {
        console.error('Помилка копіювання в буфер обміну: ', err);
    } finally {
        // Видаляємо текстовий об'єкт
        document.body.removeChild(textArea);
    }
}