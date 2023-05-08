var fontSize = 15;
var text = document.getElementById("conteudo-paragrafo");

function changeFontColorToBlack() {
    var paragrafo = document.getElementById("paragrafo");
    paragrafo.style.color = "black";
}

function changeFontColorToWhite() {
    var paragrafo = document.getElementById("paragrafo");
    paragrafo.style.color = "white";
}

function changebackgroundColorToBlack() {
    var paragrafo = document.getElementById("paragrafo");
    paragrafo.style.backgroundColor = "black";
}

function changebackgroundColorToWhite() {
    var paragrafo = document.getElementById("paragrafo");
    paragrafo.style.backgroundColor = "white";
}

function increaseFontSize() {
    fontSize += 2; 
    paragrafo.style.fontSize = fontSize + "px";
}

function decreaseFontSize() {
    fontSize -= 2; 
    paragrafo.style.fontSize = fontSize + "px";
}

function toUpperCase() {
    var text = paragrafo.textContent;
    paragrafo.textContent = text.toUpperCase();
}

function toLowerCase() {
    var text = paragrafo.textContent;
    paragrafo.textContent = text.toLowerCase();
}