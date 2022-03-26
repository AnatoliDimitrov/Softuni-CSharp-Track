import auth from "./authService.js";
import horizontalCalculator from "./horizontalCalculation.js";
import verticalCalculator from "./verticalCalculation.js";
import woodenCalculator from "./woodenCalculation.js";
import rollerCalculator from "./rollerCalculation.js";
import romanCalculator from "./romanCalculation.js";
import bambooCalculator from "./bambooCalculation.js";
import pleatsCalculator from "./pleatsCalculation.js";
import externalRollerCalculator from "./externalRollerCalculation.js";
import externalVenetianCalculator from "./externalVenetianCalculation.js";
import awningCalculator from "./awningCalculation.js";
import netsCalculator from "./netsCalculation.js";

async function renderProducts() {

    let products = await auth.getMyProducts();

    if (products.length === 0) {
        return;
    }

    let typeGroup = "";

    let container = document.getElementById('table-container');
    container.innerHTML = '';

    let tbody;
    let counter = 0;

    for (let product of products) {
        counter++;

        if (product.type !== typeGroup) {
            counter = 1;

            typeGroup = product.type;
            let heading = document.createElement('h3');
            heading.textContent = typeGroup;

            let table = document.createElement('table');
            //table.classList.toggle('table-sm');
            table.classList.toggle('table');
            table.classList.toggle('table-striped');
            let thead = document.createElement('thead');
            tbody = document.createElement('tbody');

            createTableHeads(thead);

            table.appendChild(thead);
            table.appendChild(tbody);

            container.appendChild(heading);
            container.appendChild(table);
        }

        createTableRows(product, tbody, counter);
    }
};

function createTableHeads(thead) {
    let headsContents = ['#', 'Модел', 'цвят', 'Ширина', 'Височина', 'Кв.М.', 'Количество', 'Екстри', 'Цена', 'Опции'];

    for (const content of headsContents) {
        let th = document.createElement('th');
        th.setAttribute('scope', 'col');
        th.textContent = content;

        thead.appendChild(th);
    }
}

function createTableRows(product, tbody, counter) {
    let tr = document.createElement('tr');
    let th = document.createElement('th');
    th.textContent = counter;

    tr.appendChild(th);

    for (let property in product) {
        let currentPrice = calculateCurrentPrice(product);

        product.price = currentPrice;

        if (property == 'id' || property == 'colorGroup' || property == 'type') {
            continue;
        }

        let td = document.createElement('td');
        
        if (property == 'extras') {
            if (product[property].length > 0) {
                let ul = document.createElement('ul');

                for (let extra of product[property]) {
                    let li = document.createElement('li');
                    li.textContent = extra;

                    ul.appendChild(li);
                }

                td.appendChild(ul);
            } else {
                td.textContent = 'Няма';
            }
        } else {
            td.textContent = product[property];
        }

        tr.appendChild(td);
    }

    let deleteTd = document.createElement('td');
    let form = document.createElement('form');
    form.setAttribute('method', 'post');

    let button = document.createElement('button');
    button.setAttribute('type', 'submit');
    button.setAttribute('title', 'Изтрии');
    button.id = product.id;
    button.name = 'id';
    button.value = product.id;
    button.classList.toggle('btn');
    button.classList.toggle('text-danger');
    button.classList.toggle('delete');
    button.innerHTML = '&times;';

    form.appendChild(button);

    deleteTd.appendChild(form);

    tr.appendChild(deleteTd);

    tbody.appendChild(tr);
}

function calculateCurrentPrice(product) {

    let price = 'Няма цена';

    if (product.type === 'Хоризонтални Щори') {
        let driving = product.extras.includes('Странично Водене');
        let planks = product.extras.includes('Планки Лукс');

        price = horizontalCalculator.calculate(product.model,
            product.color,
            product.width,
            product.height,
            driving,
            planks);

        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    } else if (product.type === 'Вертикални Щори') {

        price = verticalCalculator.calculate(product.model, product.colorGroup, product.width, product.height);
        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    } else if (product.type === 'Дървени Щори') {
        let driving = product.extras.includes('Странично Водене');

        price = woodenCalculator.calculate(product.model, product.color, product.width, product.height, driving);
        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    } else if (product.type === 'Руло Щори') {
        let driving = product.extras.includes('Странично Водене');

        price = rollerCalculator.calculate(product.model, product.colorGroup, product.width, product.height, driving);
        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    } else if (product.type === 'Римски Щори') {
        let driving = product.extras.includes('Странично Водене');

        price = price = romanCalculator.calculate(product.model, product.colorGroup, product.width, product.height, driving);
        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    } else if (product.type === 'Бамбукови Щори') {

        price = bambooCalculator.calculate(product.model, product.color, product.width, product.height);
        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    } else if (product.type === 'Плисе Щори') {

        price = pleatsCalculator.calculate(product.model, product.colorGroup, product.width, product.height);
        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    } else if (product.type === 'Външни Ролетни Щори') {

        price = externalRollerCalculator.calculate(product.model, product.color, product.width, product.height);
        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    } else if (product.type === 'Външни Ламелни Щори') {
        let decorativeCover = product.extras.includes('Декортативен Капак');

        price = price = externalVenetianCalculator.calculate(product.model,
            product.colorGroup,
            product.width,
            product.height,
            decorativeCover);

        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    } else if (product.type === 'Сенници') {

        price = awningCalculator.calculate(product.model, product.colorGroup, product.width, product.height);
        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    } else if (product.type === 'Мрежи Против Насекоми') {

        price = netsCalculator.calculate(product.model, product.color, product.width, product.height);
        if (isNaN(price)) {
            return 'Няма цена';
        }
        price = product.quantity * price;
        price = price.toFixed(2) + " лв.";

        return price;
    }

    return 'Няма цена';
}

await renderProducts();
