const lightSection = document.querySelector(".encoder");
const darkSection = document.querySelector(".decoder");
const header = document.querySelector(".header-navigation");
const footer = document.querySelector(".footer");
const darkModeButton = document.querySelector(".header-navigation__button");

darkModeButton.addEventListener("click", () => {
    console.log("JS is connected!");
  header.classList.toggle("dark-mode");
  footer.classList.toggle("dark-mode");

  if (window.getComputedStyle(darkSection).display === "none") {
    darkSection.style.display = "flex";
    lightSection.style.display = "none";
  } else {
    darkSection.style.display = "none";
    lightSection.style.display = "flex";
  }
});
