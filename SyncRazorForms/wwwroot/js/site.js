function showYesNoButtons(id, isShowButtons = true) {
    let yesButton = document.getElementById(`yesButton_id_${id}`);
    let noButton = document.getElementById(`noButton_id_${id}`);

    let editButton = document.getElementById(`editButton_id_${id}`);


    yesButton.style.display = isShowButtons ? "block" : "none";
    noButton.style.display = isShowButtons ? "block" : "none";

    editButton.style.display = isShowButtons ? "none" : "block";


}
function GetProductById(id, isInput = false) {
    let id_element = document.getElementById(
        `id_${isInput?"input":"text"}_id_${id}`);

    let name_element = document.getElementById(
        `name_${isInput?"input":"text"}_id_${id}`);
    
    let description_element = document.getElementById(
        `description_${isInput?"input":"text"}_id_${id}`);
    
    let price_element = document.getElementById(
        `price_${isInput?"input":"text"}_id_${id}`);
    
    let amount_element = document.getElementById(
        `amount_${isInput?"input":"text"}_id_${id}`);

    return {
        id : id_element,
        name: name_element,
        description: description_element,
        price: price_element,
        amount: amount_element
    }
}

function ClearInnerHtmlOfElement(element){
    element.id.innerHTML = "";
    element.name.innerHTML = "";
    element.description.innerHTML = "";
    element.price.innerHTML = "";
    element.amount.innerHTML = "";
}

function CreateInputs(id){
    let id_input = document.createElement(
        "id");
    let name_input = document.createElement(
        "input");
    let description_input = document.createElement(
        "input");
    let price_input = document.createElement(
        "input");
    let amount_input = document.createElement(
        "input");

    id_input.id = `id_input_id_${id}`;
    name_input.id = `name_input_id_${id}`;
    description_input.id = `description_input_id_${id}`;
    price_input.id = `price_input_id_${id}`;
    amount_input.id = `amount_input_id_${id}`;

    id_input.innerText = id;
    
    return {
        id: id_input,
        name: name_input,
        description: description_input,
        price: price_input,
        amount: amount_input
    }
}

// secondElement - элемент в который войдут значения первого
function PutValuesOfFirstElementToSecond(firstElement, secondElement) {
    let isSecondElementIsInput = secondElement.name.tagName === "INPUT";
    
   
    if (isSecondElementIsInput) {
        secondElement.id.value = firstElement.id.innerText;
        secondElement.name.value = firstElement.name.innerText;
        secondElement.description.value = firstElement.description.innerText;
        secondElement.price.value = firstElement.price.innerText;
        secondElement.amount.value = firstElement.amount.innerText;
    } else {
        secondElement.id.innerText = firstElement.id.value;
        secondElement.name.innerText = firstElement.name.value;
        secondElement.description.innerText = firstElement.description.value;
        secondElement.price.innerText = firstElement.price.value;
        secondElement.amount.innerText = firstElement.amount.value;
    } 
}

function AppendChild(appendingElement, parentElement){
    // добавляет второму элементу дочерний первый
    
    parentElement.id.appendChild(appendingElement.id);
    parentElement.name.appendChild(appendingElement.name);
    parentElement.description.appendChild(appendingElement.description);
    parentElement.price.appendChild(appendingElement.price);
    parentElement.amount.appendChild(appendingElement.amount);
}

function OnEditClick(id) {
    let originalElement = GetProductById(id);
    let inputElement = CreateInputs(id);

    PutValuesOfFirstElementToSecond(originalElement, inputElement);

    ClearInnerHtmlOfElement(originalElement);

    AppendChild(inputElement, originalElement);
    
    inputElement.name.focus();
    
    showYesNoButtons(id);
}

async function onEditCancelClick(id) {
    let finalElement = GetProductById(id);
    let originalElement = await fetch(`api/EfProductApi/${id}`, {
        method : "GET"
    }).then(response => response.json());
    
    finalElement.id.innerText = originalElement.id;
    finalElement.name.innerText = originalElement.name;
    finalElement.description.innerText = originalElement.description;
    finalElement.price.innerText = originalElement.price;
    finalElement.amount.innerText = originalElement.amount;

    console.log("Отмена редактирования");
    
    showYesNoButtons(id, false);
}

async function onEditSaveClick(id) {
    let finalElement = GetProductById(id);

    let inputElement = GetProductById(id, true);

    PutValuesOfFirstElementToSecond(inputElement, finalElement);

    let product = getProductObjectFromElement(id);

    let response = await fetch(`api/EfProductApi`, {
        method: "PUT",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(product)
    });

    if (response.ok) {
        // Обновите только данные в таблице без перемещения
        updateRowInUI(id, product);
    } else {
        console.error('Ошибка обновления продукта:', response.statusText);
    }

    showYesNoButtons(id, false);
}

function updateRowInUI(id, product) {
    const productItem = document.getElementById(`product_id_${id}`);

    // Обновите только данные ячеек
    productItem.querySelector(`#name_text_id_${id}`).innerText = product.name;
    productItem.querySelector(`#description_text_id_${id}`).innerText = product.description;
    productItem.querySelector(`#price_text_id_${id}`).innerText = product.price;
    productItem.querySelector(`#amount_text_id_${id}`).innerText = product.amount;
}



async function onCreateClick(){
    let response = await fetch(`api/EfProductApi`, {
        method : "POST"
    });
    
    let idOf = await response.json();
    
    addProductToUI(idOf);

    OnEditClick(idOf)
    
    window.scrollTo({
        top: document.body.scrollHeight, // Высота всей страницы
        behavior: 'smooth' // Плавная прокрутка
    });
}


async function onGetProductClick(id){
    await fetch(`api/EfProductApi/${id}`, {
        method : "GET"
    })
        .then(response => response.json())
        .then(response => alert(`
        id = ${response.id}
        товар = ${response.name}
        описание = ${response.description}
        стоимость = ${response.price}
        количество = ${response.amount}
        `))
}

function addProductToUI(id) {
    let productList = document.getElementById("productList");
    
    // Создание элемента для нового продукта
    let productItem = document.createElement("tr");
    productItem.id = `product_id_${id}`;
    productItem.innerHTML = `
         <td> <div id="id_text_id_${id}" </div>${id}</td>
         <td> <div id="name_text_id_${id}"> </div> </td>
         <td> <div id="description_text_id_${id}"> </div> </td>
         <td> <div id="price_text_id_${id}"> </div> </td>
         <td> <div id="amount_text_id_${id}"> </div> </td>
         <td>
             <div class="buttons-container"> 
                 <button onclick="OnEditClick(${id})" id="editButton_id_${id}" >📝</button>
                 <button onclick="onEditSaveClick(${id})" id="yesButton_id_${id}" style="display: none;">✅</button>
                 <button onclick="onEditCancelClick(${id})" id="noButton_id_${id}" style="display: none;">❌</button>
             </div>
             
             <div class="buttons-container">
             <button onclick="onDeleteClick(${id})" id="deleteButton_id_${id}">⌫</button>
             <button onclick="onGetProductClick(${id})" id="getButton_id_${id}">👁</button>
             </div>
         </td>
    `;
    
    productList.appendChild(productItem);
}

async function onDeleteClick(id){
    let response = await fetch(`api/EfProductApi/${id}`, {
        method : "DELETE"
    })

    deleteProductFromUI(id)

    if (response.ok) {
        console.log(`Удаление объекта с ID ${id}`)
    }
    else{
        console.error("Error deleting product:", response.statusText);
    }
}

// chat gpt придумали гении для неумных личностей
function deleteProductFromUI(id) {
    const productItem = document.getElementById(`product_id_${id}`);
    
    if (productItem) {
        productItem.remove();
        console.log(`Продукт с ID ${id} был успешно удалён *_-`);
    }
}

function getProductObjectFromElement(id) {
    let product = GetProductById(id);
    return {
        id: product.id.innerText,
        name: product.name.innerText || '', // Убедитесь, что вы работаете с правильными значениями
        description: product.description.innerText || '',
        price: parseInt(product.price.innerText) || 0, // Преобразование в число
        amount: parseInt(product.amount.innerText) || 0 // Преобразование в число
    };
}