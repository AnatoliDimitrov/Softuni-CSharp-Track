import auth from "./authService.js";

async function renderProducts() {

    let products = await auth.getMyProducts();

    if (products.length === 0) {
        return;
    }

    let container = document.getElementById('table-container');
    container.innerHTML = '';
    container.textContent = 'works';
};

await renderProducts();
