const encodeReverseButton = document.querySelector(".encoder__button_reverse");
const encodeBrailleButton = document.querySelector(".encoder__button_braille");
const encodeJumbleButton = document.querySelector(".encoder__button_jumble");
const popupText = document.querySelector(".popup-content__paragraph");
const popup = document.querySelector(".popup-overlay");

function encodeMessage(type) {
  const inputText = document.querySelector(".encoder__input").value;

  fetch(`/api/message/encode/${type}`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ input: inputText }),
  })
    .then((res) => {
      if (!res.ok) throw new Error("Encoding failed");
      return res.json();
    })
    .then((data) => {
      popupText.textContent = data.output;
    })
    .catch((err) => {
      popupText.textContent = `Error: ${err.message}`;
    });

    popup.style.display = 'flex';
}

encodeReverseButton.addEventListener("click", () => {
    encodeMessage("reverse");
});

encodeBrailleButton.addEventListener("click", () => {
    encodeMessage("braille");
});

encodeJumbleButton.addEventListener("click", () => {
    encodeMessage("jumble");
});
