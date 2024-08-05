// select popup-overlay, popup-box, add-popup-button
var popupoverlay = document.querySelector(".popup-overlay")
var popupbox = document.querySelector(".popup-box")
var addpopupbutton = document.getElementById("add-popup-button")

addpopupbutton.addEventListener("click", function () {
    popupoverlay.style.display = "block"
    popupbox.style.display = "block"
})

//select cance-popup button
var cancelbutton = document.getElementById("cancel-popup")
cancelbutton.addEventListener("click", function (event) {
    event.preventDefault()
    popupoverlay.style.display = "none"
    popupbox.style.display = "none"
})

//select container, add-book, book-title-input, book-author-input, book-description-input
var container1 = document.querySelector(".container1")

var addbook = document.getElementById("add-book")
var booktitleinput = document.getElementById("book-title-input")
var bookauthorinput = document.getElementById("book-author-input")
var bookdescriptioninput = document.getElementById("book-description-input")

addbook.addEventListener("click", function (event) {
    event.preventDefault();
    var div = document.createElement("div")
    div.setAttribute("class", "book-container")
    div.innerHTML = `<h2>${booktitleinput.value}</h2>
    <h5>${bookauthorinput.value}</h5>
    <p>${bookdescriptioninput.value}</p>
    <button onclick="deleteitem(event)">Delete</button>`
    container1.append(div)
    popupoverlay.style.display = "none"
    popupbox.style.display = "none"
})
function deleteitem(event) {
    event.target.parentElement.remove()
}


