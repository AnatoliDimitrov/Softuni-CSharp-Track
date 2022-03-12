import auth from "./authService.js";

let container = document.querySelector('#calculator-container');
container.addEventListener('click', hidePanel);

let productType = '';
let productModel = '';
let productColor = '';
let productWidth = '';
let productHeight = '';

panels();

function hidePanel(e) {
    if (e.target.tagName === 'INPUT') {
        chooseOption(e.target);
    }
}

async function chooseOption(option) {
    var answer = option.closest('.answer');
    if (answer.id == 'productChoice') {
        let result = await auth.getModelsWithId(option.value);
        productType = option.value;
        renderRadios(result, 'model');
    }
    else if (answer.id == 'modelChoice') {
        let result = await auth.getColorsWithId(option.value);
        productModel = option.value;
        renderRadios(result, 'color');
    }
    var element = answer.closest('.element');
    element.querySelector('i').className = 'fas fa-plus-circle';
    openNextPanel(option.closest('.answer'));
}

function renderRadios(options, id) {
    let container = document.getElementById(id);
    container.innerHTML = '';

    for (var option of options) {
        let div = document.createElement('div');
        div.className = 'raduo-button-container';
        let radio = document.createElement('input');
        radio.id = 'model' + option.id;
        radio.setAttribute('type', 'radio');
        radio.setAttribute('name', 'model');
        radio.value = option.id;
        let label = document.createElement('label');
        label.className = 'radio-button-label';
        label.setAttribute('for', 'model' + option.id);
        label.textContent = option.name;
        if (id == 'color') {
            label.textContent = option.number;
        }

        div.appendChild(radio);
        div.appendChild(label);

        if (id == 'color') {

            let span = document.createElement('span');
            span.className = 'float-right';
            span.textContent = option.group;
            let image = document.createElement('img');
            image.setAttribute('src', option.url);
            let imgSpan = document.createElement('span');
            let a = document.createElement('a');
            a.href = option.url;
            a.setAttribute('data-fancybox', 'gallery');
            a.appendChild(image);
            a.classList.toggle('lightbox-image');
            imgSpan.classList.toggle('sample-image');
            imgSpan.appendChild(a)

            div.appendChild(span);
            div.appendChild(imgSpan);
        }

        container.appendChild(div);
    }
}

function openNextPanel(answer) {
    answer.classList.add('hideText');
    let element = answer.closest('.element');
    var nextElement = element.nextElementSibling;
    nextElement.querySelector('.answer').classList.remove('hideText');

    nextElement.querySelector('i').className = 'fas fa-minus-circle';
}

function clearContent() {

}

function panels() {

    const elements = document.querySelectorAll('.element');

    elements.forEach(element => {
        let btn = element.querySelector('.question button');
        let question = element.querySelector('.question');
        let icon = element.querySelector('.question button i');
        var answer = element.lastElementChild;
        var answers = document.querySelectorAll('.element .answer');

        question.addEventListener('click', (e) => {
            answers.forEach(ans => {
                let ansIcon = ans.parentElement.querySelector('button i');
                if (answer !== ans) {
                    ans.classList.add('hideText');
                    ansIcon.className = 'fas fa-plus-circle';
                }
            });

            answer.classList.toggle('hideText');
            icon.className === 'fas fa-plus-circle' ? icon.className = 'fas fa-minus-circle'
                : icon.className = 'fas fa-plus-circle';
        });
    });

}