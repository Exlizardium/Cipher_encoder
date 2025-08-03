const decodeReverseButton = document.querySelector(".decoder__button_reverse");
const decodeBrailleButton = document.querySelector(".decoder__button_braille");
const decodeJumbleButton = document.querySelector(".decoder__button_jumble");
const popupText = document.querySelector(".popup-content__paragraph");
const popup = document.querySelector(".popup-overlay");

function decodeMessage(type) {
  const inputText = document.querySelector(".decoder__input").value;

  fetch(`/api/message/decode/${type}`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ input: inputText }),
  })
    .then((res) => {
      if (!res.ok) throw new Error("Decoding failed");
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

decodeReverseButton.addEventListener("click", () => {
    decodeMessage("reverse");
});

decodeBrailleButton.addEventListener("click", () => {
    decodeMessage("debraille");
});

decodeJumbleButton.addEventListener("click", () => {
    decodeMessage("dejumble");
});
