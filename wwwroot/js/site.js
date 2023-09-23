// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*Define ID's*/
let selectNavbarText = document.getElementById('changeFonts');
let selectAcerText = document.getElementById('changeAcerFontSize');
let selectMacText = document.getElementById('changeMacFontSize');
let selectSurfaceText = document.getElementById('changeSurfaceFontSize');
let darkModeButton = document.getElementById('darkModeButton')
let backgroundColor = document.body;
let navColor = document.getElementById('navActive');
let headText = document.getElementById('headText');
let darkModeCheck = localStorage.getItem('darkModeCheck');
let selectMainImage = document.getElementById('animateImage');
let selectMainImage2 = document.getElementById('animateImage2');
let selectMainImage3 = document.getElementById('animateImage3');
let getForm = document.getElementById('toggleForm');
let optional = document.getElementById('optional');

/*If image to animate does not exist, do not perform Java*/
if (selectMainImage != null && selectMainImage2 != null && selectMainImage3 != null) {
    let originalWidth = 170;
    let increaseWidth = originalWidth;
    let windowSize = window.matchMedia("(min-width: 990px)")
    if (windowSize.matches) {
        maxWidth = window.screen.width * 0.50;
    }
    else {
        maxWidth = window.screen.width * 0.25;
    }
    function enlargeImage() {
        increaseWidth++;
        selectMainImage.style.width = increaseWidth + 'px';
        if (increaseWidth == maxWidth) {
            clearInterval(timer);
            increaseWidth = originalWidth;
        }
    }
    selectMainImage.addEventListener('click', () => {
        timer = setInterval(enlargeImage, 1);
    })

    function enlargeImage2() {
        increaseWidth++;
        selectMainImage2.style.width = increaseWidth + 'px';
        if (increaseWidth == maxWidth) {
            clearInterval(timer);
            increaseWidth = originalWidth;
        }
    }
    selectMainImage2.addEventListener('click', () => {
        timer = setInterval(enlargeImage2, 1);
    })

    function enlargeImage3() {
        increaseWidth++;
        selectMainImage3.style.width = increaseWidth + 'px';
        if (increaseWidth == maxWidth) {
            clearInterval(timer);
            increaseWidth = originalWidth;
        }
    }
    selectMainImage3.addEventListener('click', () => {
        timer = setInterval(enlargeImage3, 1);
    })
}
else if (selectMainImage != null) {
    let originalWidth = 170;
    let increaseWidth = originalWidth;
    let windowSize = window.matchMedia("(min-width: 990px)")
    if (windowSize.matches) {
        maxWidth = window.screen.width * 0.50;
    }
    else {
        maxWidth = window.screen.width * 0.25;
    }
    /*Animate main image*/
    function enlargeImage() {
        increaseWidth++;
        selectMainImage.style.width = increaseWidth + 'px';
        if (increaseWidth == maxWidth) {
            clearInterval(timer);
            increaseWidth = originalWidth;
        }
    }
    selectMainImage.addEventListener('click', () => {
        timer = setInterval(enlargeImage, 1);
    })
}
else if (selectMainImage == null) {
    ;
}

/*If form does not exist, do not perform Java*/
if (getForm != null) {
    optional.classList.add('hide');
    /*Display optional form*/
    function hideForm() {
        optional.classList.add('hide');
        localStorage.setItem('formCheck', 'hide');
    }
    function showForm() {
        optional.classList.remove('hide');
        localStorage.setItem('formCheck', 'show');
    }
    getForm.addEventListener('click', () => {
        let formCheck = localStorage.getItem('formCheck')
        if (formCheck !== 'hide') {
            hideForm();
        }
        else {
            showForm();
        }
    })
}
else if (selectMainImage == null) {
    ;
}
/*Change font size and store in API*/
function increaseFont(value) {
    if (value == "largeFontSize") {
        if (selectAcerText !== null && selectMacText !== null && selectSurfaceText !== null) {
            selectNavbarText.setAttribute('id', 'navbarFontIncrease');
            selectAcerText.setAttribute('id', 'fontIncrease');
            selectMacText.setAttribute('id', 'fontIncrease');
            selectSurfaceText.setAttribute('id', 'fontIncrease');
            localStorage.fontSize = 'larger';
        }
        else {
            selectNavbarText.setAttribute('id', 'navbarFontIncrease');
            localStorage.fontSize = 'larger';
        }
    }
    else if (value == "smallFontSize") {
        if (selectAcerText !== null && selectMacText !== null && selectSurfaceText !== null) {
            selectNavbarText.setAttribute('id', 'navbarFontDecrease');
            selectAcerText.setAttribute('id', 'fontDecrease');
            selectMacText.setAttribute('id', 'fontDecrease');
            selectSurfaceText.setAttribute('id', 'fontDecrease');
            localStorage.fontSize = 'smaller';
        }
        else {
            selectNavbarText.setAttribute('id', 'navbarFontDecrease');
            localStorage.fontSize = 'smaller';
        }
    }
    else if (value == "normalFontSize") {
        if (selectAcerText !== null && selectMacText !== null && selectSurfaceText !== null) {
            selectNavbarText.setAttribute('id', 'navbarFontReset');
            selectAcerText.setAttribute('id', 'fontReset');
            selectMacText.setAttribute('id', 'fontReset');
            selectSurfaceText.setAttribute('id', 'fontReset');
            localStorage.fontSize = 'normal';
        }
        else {
            selectNavbarText.setAttribute('id', 'navbarFontReset');
            localStorage.fontSize = 'normal';
        }
    }
}

/*Load font sized stored in API*/
if (localStorage.fontSize == 'larger') {
    if (selectAcerText !== null && selectMacText !== null && selectSurfaceText !== null) {
        selectNavbarText.setAttribute('id', 'navbarFontIncrease');
        selectAcerText.setAttribute('id', 'fontIncrease');
        selectMacText.setAttribute('id', 'fontIncrease');
        selectSurfaceText.setAttribute('id', 'fontIncrease');
        localStorage.fontSize = 'larger';
    }
    else {
        selectNavbarText.setAttribute('id', 'navbarFontIncrease');
        localStorage.fontSize = 'larger';
    }
}
else if (localStorage.fontSize == 'smaller') {
    if (selectAcerText !== null && selectMacText !== null && selectSurfaceText !== null) {
        selectNavbarText.setAttribute('id', 'navbarFontDecrease');
        selectAcerText.setAttribute('id', 'fontDecrease');
        selectMacText.setAttribute('id', 'fontDecrease');
        selectSurfaceText.setAttribute('id', 'fontDecrease');
        localStorage.fontSize = 'smaller';
    }
    else {
        selectNavbarText.setAttribute('id', 'navbarFontDecrease');
        localStorage.fontSize = 'smaller';
    }
}
else if (localStorage.fontSize == 'normal') {
    if (selectAcerText !== null && selectMacText !== null && selectSurfaceText !== null) {
        selectNavbarText.setAttribute('id', 'navbarFontReset');
        selectAcerText.setAttribute('id', 'fontReset');
        selectMacText.setAttribute('id', 'fontReset');
        selectSurfaceText.setAttribute('id', 'fontReset');
        localStorage.fontSize = 'normal';
    }
    else {
        selectNavbarText.setAttribute('id', 'navbarFontReset');
        localStorage.fontSize = 'normal';
    }
}

/*Toggle dark mode*/
function addDarkMode() {
    backgroundColor.classList.add('dark-mode');
    navColor.classList.add('activeDark');
    localStorage.darkModeCheck = 'darker';
}
function removeDarkMode() {
    backgroundColor.classList.remove('dark-mode');
    navColor.classList.remove('activeDark');
    localStorage.darkModeCheck = 'brighter';
}
darkModeButton.addEventListener('click', () => {
    let darkModeCheck = localStorage.getItem('darkModeCheck')
    if (darkModeCheck == 'darker') {
        removeDarkMode();
    }
    else {
        addDarkMode();
    }
})

/*Store changes for dark mode*/
if (darkModeCheck == 'darker') {
    addDarkMode();
}
else {
    removeDarkMode();
}

/*Slide show*/
var slide = 1;
showContent(slide);

function swapContent(n) {
    showContent(slide += n);
}

function showContent(n) {
    var i;
    var x = document.getElementsByClassName("tablecontent");
    if (n > x.length) {
        slide = 1
    }
    if (n < 1) {
        slide = x.length
    }
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    x[slide - 1].style.display = "block";
}