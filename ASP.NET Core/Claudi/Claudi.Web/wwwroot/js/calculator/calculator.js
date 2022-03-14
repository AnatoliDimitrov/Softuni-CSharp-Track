import auth from "./authService.js";
import horizontalCalculator from "./horizontalCalculation.js";
import verticalCalculator from "./verticalCalculation.js";
import woodenCalculator from "./woodenCalculation.js";
import rollerCalculator from "./rollerCalculation.js";
import romanCalculator from "./romanCalculation.js";
import bambooCalculator from "./bambooCalculation.js";

let container = document.querySelector('#calculator-container');
container.addEventListener('click', hidePanel);

let productType = '';
let productName = '';
let productModel = '';
let productModelId = '';
let productColor = '';
let productColorGroup = '';
let productWidth = '';
let productHeight = '';
let productQuantity = '';
let price = '';
let productExtras = [];

panels();

function hidePanel(e) {
    if (e.target.tagName === 'INPUT') {
        chooseOption(e.target);
    }
}

async function chooseOption(option) {
    var answer = option.closest('.answer');
    if (answer.id == 'productChoice') {
        document.getElementById('typeHeading').textContent = option.name;
        let result = await auth.getModelsWithId(option.value);
        productType = option.value;
        productName = option.name;
        showContent(productType);
        renderRadios(result, 'model');

        var element = answer.closest('.element');
        element.querySelector('i').className = 'fas fa-plus-circle';
        openNextPanel(option.closest('.answer'));
    }
    else if (answer.id == 'modelChoice') {
        let result = await auth.getColorsWithId(option.value);
        document.getElementById('modelHeading').textContent = option.nextElementSibling.textContent;
        productModel = option.name;
        productModelId = option.value;
        renderRadios(result, 'color');

        var element = answer.closest('.element');
        element.querySelector('i').className = 'fas fa-plus-circle';
        openNextPanel(option.closest('.answer'));
    }
    else if (answer.id == 'colorChoice') {
        productColor = option.getAttribute('number');
        document.getElementById('colorHeading').textContent = productColor;
        productColorGroup = option.getAttribute('group');
        renderSizes();

        var element = answer.closest('.element');
        element.querySelector('i').className = 'fas fa-plus-circle';
        openNextPanel(option.closest('.answer'));
    }
}

function renderSizes() {
    let formElement = document.querySelector('#input-form');
    formElement.addEventListener('submit', calculate);
    formElement.innerHTML = '';

    let widthDiv = document.createElement('div');
    widthDiv.className = 'form-floating';

    let widthInput = document.createElement('input');
    widthInput.id = 'width';
    widthInput.type = 'number';
    widthInput.name = 'width';
    widthInput.classList.toggle('form-control');
    widthInput.classList.toggle('col-md-6');

    let widthLabel = document.createElement('label');
    widthLabel.setAttribute('for', 'width');
    widthLabel.classList.toggle('form-label');
    widthLabel.textContent = 'Ширина - СМ';

    widthDiv.appendChild(widthInput);
    widthDiv.appendChild(widthLabel);

    let widthSpan = document.createElement('span');
    widthSpan.id = 'widthError';
    widthSpan.classList.toggle('badge');
    widthSpan.classList.toggle('badge-danger');

    let heightDiv = document.createElement('div');
    heightDiv.className = 'form-floating';

    let heightInput = document.createElement('input');
    heightInput.id = 'height';
    heightInput.type = 'number';
    heightInput.name = 'height';
    heightInput.classList.toggle('form-control');
    heightInput.classList.toggle('col-md-6');

    let heightLabel = document.createElement('label');
    heightLabel.setAttribute('for', 'width');
    heightLabel.classList.toggle('form-label');
    heightLabel.textContent = 'Височина - СМ';

    heightDiv.appendChild(heightInput);
    heightDiv.appendChild(heightLabel);

    let heightSpan = document.createElement('span');
    heightSpan.id = 'heightError';
    heightSpan.classList.toggle('badge');
    heightSpan.classList.toggle('badge-danger');

    let quantityDiv = document.createElement('div');
    quantityDiv.className = 'form-floating';

    let quantityInput = document.createElement('input');
    quantityInput.id = 'quantity';
    quantityInput.type = 'number';
    quantityInput.name = 'quantity';
    quantityInput.classList.toggle('form-control');
    quantityInput.classList.toggle('col-md-6');
    quantityInput.value = 1;

    let quantityLabel = document.createElement('label');
    quantityLabel.setAttribute('for', 'width');
    quantityLabel.classList.toggle('form-label');
    quantityLabel.textContent = 'Брой';

    quantityDiv.appendChild(quantityInput);
    quantityDiv.appendChild(quantityLabel);

    let quantitySpan = document.createElement('span');
    quantitySpan.id = 'quantityError';
    quantitySpan.classList.toggle('badge');
    quantitySpan.classList.toggle('badge-danger');

    let divButton = document.createElement('div');
    let button = document.createElement('button');
    button.type = 'submit';
    button.classList.toggle('w-100');
    button.classList.toggle('btn');
    button.classList.toggle('btn-lg');
    button.classList.toggle('btn-outline-warning');
    button.textContent = 'Изчисли';

    divButton.appendChild(button);

    let extrasDiv = document.createElement('div');
    extrasDiv.id = 'extras-container';
    extrasDiv.classList.toggle('form-floating');

    formElement.appendChild(widthDiv);
    formElement.appendChild(widthSpan);
    formElement.appendChild(heightDiv);
    formElement.appendChild(heightSpan);
    formElement.appendChild(quantityDiv);
    formElement.appendChild(quantitySpan);
    formElement.appendChild(extrasDiv);
    formElement.appendChild(divButton);

    renderExtras(extrasDiv);
}

async function renderExtras(container) {
    let extras = await auth.getExtrasWithId(productModelId);

    if (extras == []) {
        return;
    }

    for (var i = 0; i < extras.length; i++) {
        let div = document.createElement('div');
        div.classList.toggle('form-check');
        div.classList.toggle('form-switch');

        let input = document.createElement('input');
        input.classList.toggle('form-check-input');
        input.style.marginLeft = '-20px';
        input.style.marginRight = '5px';
        input.type = 'checkbox';
        input.name = extras[i].name;
        input.setAttribute('extraId', extras[i].id);
        input.id = 'extra' + (i + 1);

        let label = document.createElement('label');
        label.classList.toggle('form-check-label');
        label.setAttribute('for', 'extra' + (i + 1));
        label.textContent = extras[i].name;

        div.appendChild(input);
        div.appendChild(label);

        container.appendChild(div);
    }
}

function calculate(e) {
    e.preventDefault();
    let form = e.currentTarget;
    let formData = new FormData(form);
    productWidth = formData.get('width');
    productHeight = formData.get('height');
    productQuantity = formData.get('quantity');

    let isValidInput = true;

    if (isNaN(productWidth) || productWidth == null || productWidth == '') {
        document.getElementById('widthError').textContent = 'Въведете валидно число';
        isValidInput = false;
    }
    if (isNaN(productHeight) || productHeight == null || productHeight == '') {
        document.getElementById('heightError').textContent = 'Въведете валидно число';
        isValidInput = false;
    }
    if (isNaN(productQuantity) || productQuantity == null || productQuantity == '' || productQuantity <= 0) {
        document.getElementById('quantityError').textContent = 'Въведете валидно число';
        isValidInput = false;
    }

    if (!isValidInput) {
        return;
    }

    document.getElementById('widthError').textContent = '';
    document.getElementById('heightError').textContent = '';
    document.getElementById('quantityError').textContent = '';

    if (productType == 1) {
        calculateHorizontalBlinds();
    }
    else if (productType == 2) {
        calculateVerticalBlinds();
    }
    else if (productType == 3) {
        calculateWoodenBlinds();
    }
    else if (productType == 4) {
        calculateRollerBlinds();
    }
    else if (productType == 5) {
        calculateRomanBlinds();
    }
    else if (productType == 6) {
        calculateBambooBlinds();
    }
}

function renderResult(info) {
    let container = document.getElementById('result');
    container.innerHTML = '';

    var keys = ['Продукт', 'Модел', 'Цвят', 'Ширина - СМ', 'Височина - СМ', 'Брой', 'Кв.М', 'Екстри', 'Цена'];

    for (var i = 0; i < keys.length; i++) {

        if (keys[i] == 'Екстри') {
            for (var j = 0; j < info[i].length; j++) {
                let div = document.createElement('div');
                div.className = 'form-floating';

                let input = document.createElement('input');
                input.id = 'extra' + i + j;
                input.type = 'text';
                input.name = info[i][j].name;
                input.classList.toggle('form-control');
                input.classList.toggle('col-md-6');
                input.value = info[i][j].isChecked ? 'Да' : 'Не';
                input.disabled = true;

                let label = document.createElement('label');
                label.setAttribute('for', 'extra' + i + j);
                label.classList.toggle('form-label');
                label.textContent = info[i][j].name;

                div.appendChild(input);
                div.appendChild(label);

                container.appendChild(div);
            }

            continue;
        }
        let div = document.createElement('div');
        div.className = 'form-floating';

        let input = document.createElement('input');
        input.id = 'resilt' + i;
        input.type = 'text';
        input.name = keys[i];
        input.classList.toggle('form-control');
        input.classList.toggle('col-md-6');
        input.value = info[i];
        input.disabled = true;

        let label = document.createElement('label');
        label.setAttribute('for', 'resilt' + i);
        label.classList.toggle('form-label');
        label.textContent = keys[i];

        div.appendChild(input);
        div.appendChild(label);

        container.appendChild(div);
    }

    if (true) {
        let divButton = document.createElement('div');
        let button = document.createElement('button');
        button.type = 'submit';
        button.classList.toggle('col-md-6');
        button.classList.toggle('btn');
        button.classList.toggle('btn-lg');
        button.classList.toggle('btn-success');
        button.textContent = 'Запази';

        divButton.appendChild(button);

        container.appendChild(divButton);
    }
}

function renderRadios(options, id) {
    let container = document.getElementById(id);
    container.innerHTML = '';

    for (var option of options) {
        let div = document.createElement('div');
        div.className = 'raduo-button-container';
        let radio = document.createElement('input');
        radio.id = 'model' + option.id;
        radio.setAttribute('name', option.name);
        radio.setAttribute('type', 'radio');
        radio.value = option.id;
        let label = document.createElement('label');
        label.className = 'radio-button-label';
        label.setAttribute('for', 'model' + option.id);
        label.textContent = option.name;
        if (id == 'color') {
            radio.setAttribute('number', option.number);
            radio.setAttribute('group', option.group);
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

function panels() {

    const elements = document.querySelectorAll('.element');

    elements.forEach(element => {
        let btn = element.querySelector('.question button');
        let question = element.querySelector('.question');
        let icon = element.querySelector('.question button i');
        var answer = element.lastElementChild;
        var answers = document.querySelectorAll('.element .answer');

        question.addEventListener('click', () => {
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

function showContent(id) {
    for (var i = 1; i < 11; i++) {
        let content = document.getElementById(i);
        if (content.id == id) {
            content.classList.remove('hide');
        }
        else {
            content.classList.add('hide');
        }
    }
}

function calculateHorizontalBlinds() {
    let driving = document.getElementById('extra1');
    let drivingIsChecked = driving.checked;

    let planks = document.getElementById('extra2');
    let planksIsChecked = planks.checked;

    price = horizontalCalculator.calculate(productModel, productColor, productWidth, productHeight, drivingIsChecked, planksIsChecked)
    if (isNaN(price)) {
        var span = document.getElementById('quantityError');
        span.classList.toggle('col-md-12');
        span.textContent = price;
        return;
    }
    price = productQuantity * price;
    price = price.toFixed(2) + " лв.";

    let squareMeters = (((productHeight * productWidth) / 10000) * productQuantity).toFixed(2)

    renderResult([productName, productModel, productColor, productWidth, productHeight, productQuantity, squareMeters,
        [{ name: driving.name, isChecked: drivingIsChecked }, { name: planks.name, isChecked: planksIsChecked }], price]);
}

function calculateVerticalBlinds() {

    price = verticalCalculator.calculate(productModel, productColorGroup, productWidth, productHeight,)
    if (isNaN(price)) {
        var span = document.getElementById('quantityError');
        span.classList.toggle('col-md-12');
        span.textContent = price;
        return;
    }
    price = productQuantity * price;
    price = price.toFixed(2) + " лв.";

    let squareMeters = (((productHeight * productWidth) / 10000) * productQuantity).toFixed(2)

    renderResult([productName, productModel, productColor, productWidth, productHeight, productQuantity, squareMeters,
        [], price]);
}

function calculateWoodenBlinds() {
    let driving = document.getElementById('extra1');
    let drivingIsChecked = driving.checked;

    price = woodenCalculator.calculate(productModel, productColor, productWidth, productHeight, drivingIsChecked)
    if (isNaN(price)) {
        var span = document.getElementById('quantityError');
        span.classList.toggle('col-md-12');
        span.textContent = price;
        return;
    }
    price = productQuantity * price;
    price = price.toFixed(2) + " лв.";

    let squareMeters = (((productHeight * productWidth) / 10000) * productQuantity).toFixed(2)

    renderResult([productName, productModel, productColor, productWidth, productHeight, productQuantity, squareMeters,
        [{ name: driving.name, isChecked: drivingIsChecked }], price]);
}

function calculateRollerBlinds() {

    let drivingIsChecked = false;
    let driving = document.getElementById('extra1');
    let extras = []

    if (driving !== undefined && driving !== null) {
        drivingIsChecked = driving.checked;
        extras = [{ name: driving.name, isChecked: drivingIsChecked }];
    }

    price = rollerCalculator.calculate(productModel, productColorGroup, productWidth, productHeight, drivingIsChecked)
    if (isNaN(price)) {
        var span = document.getElementById('quantityError');
        span.classList.toggle('col-md-12');
        span.textContent = price;
        return;
    }
    price = productQuantity * price;
    price = price.toFixed(2) + " лв.";

    let squareMeters = (((productHeight * productWidth) / 10000) * productQuantity).toFixed(2)

    renderResult([productName, productModel, productColor, productWidth, productHeight, productQuantity, squareMeters,
       extras, price]);
}

function calculateRomanBlinds() {
    let driving = document.getElementById('extra1');
    let drivingIsChecked = driving.checked;

    price = romanCalculator.calculate(productModel, productColor, productWidth, productHeight, drivingIsChecked)
    if (isNaN(price)) {
        var span = document.getElementById('quantityError');
        span.classList.toggle('col-md-12');
        span.textContent = price;
        return;
    }
    price = productQuantity * price;
    price = price.toFixed(2) + " лв.";

    let squareMeters = (((productHeight * productWidth) / 10000) * productQuantity).toFixed(2)

    renderResult([productName, productModel, productColor, productWidth, productHeight, productQuantity, squareMeters,
        [{ name: driving.name, isChecked: drivingIsChecked }], price]);
}

function calculateBambooBlinds() {

    price = bambooCalculator.calculate(productModel, productColor, productWidth, productHeight)
    if (isNaN(price)) {
        var span = document.getElementById('quantityError');
        span.classList.toggle('col-md-12');
        span.textContent = price;
        return;
    }
    price = productQuantity * price;
    price = price.toFixed(2) + " лв.";

    let squareMeters = (((productHeight * productWidth) / 10000) * productQuantity).toFixed(2)

    renderResult([productName, productModel, productColor, productWidth, productHeight, productQuantity, squareMeters,
        [], price]);
}