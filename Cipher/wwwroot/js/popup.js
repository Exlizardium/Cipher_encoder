const popupCloseButton = document.querySelector(".popup-content__button_close");
const popup = document.querySelector(".popup-overlay");

popupCloseButton.addEventListener('click', () => {
    popup.style.display = 'none';
});

popup.addEventListener('click', (event) => {
    if (event.target === popup) {
        popup.style.display = 'none';
    }
});

