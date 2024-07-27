let originalValues = {};

function GetElementsById(id, isInput = false) {
    let name = document.getElementById(
        `name_${isInput?"input":"text"}_id_${id}`);
    
    let description = document.getElementById(
        `description_${isInput?"input":"text"}_id_${id}`);
    
    let cost = document.getElementById(
        `cost_${isInput?"input":"text"}_id_${id}`);
    
    let amount = document.getElementById(
        `amount_${isInput?"input":"text"}_id_${id}`);

    return {
        name,
        description,
        cost,
        amount
    }
}

function ClearInnerHtmlOfElement(element){
    element.name.innerHTML = "";
    element.description.innerHTML = "";
    element.cost.innerHTML = "";
    element.amount.innerHTML = "";
}

function SaveOriginalElementValues(id, element) {
    originalValues[id] = {
        name: element.name.innerText,
        description: element.description.innerText,
        cost: element.cost.innerText,
        amount: element.amount.innerText
    }
} 

function CreateInputs(id){
    let name = document.createElement(
        "input");
    let description = document.createElement(
        "input");
    let cost = document.createElement(
        "input");
    let amount = document.createElement(
        "input");

    name.id = `name_input_id_${id}`;
    description.id = `description_input_id_${id}`;
    cost.id = `cost_input_id_${id}`;
    amount.id = `amount_input_id_${id}`;
    
    return {
        name,
        description,
        cost,
        amount
    }
}

function SwapValues(originalElement, inputElement, 
                    isChangeInputElementText = false) {
    if (isChangeInputElementText) {
        inputElement.name.value = originalElement.name.innerText;
        inputElement.description.value = originalElement.description.innerText;
        inputElement.cost.value = originalElement.cost.innerText;
        inputElement.amount.value = originalElement.amount.innerText;
    } else {
        originalElement.name.innerText = inputElement.name.value;
        originalElement.description.innerText = inputElement.description.value;
        originalElement.cost.innerText = inputElement.cost.value;
        originalElement.amount.innerText = inputElement.amount.value;
    } 
}

function OnEditClick(id) {
    let originalElement = GetElementsById(id);

    SaveOriginalElementValues(id, originalElement);

    let inputElement = CreateInputs(id);

    SwapValues(originalElement, inputElement, true);

    ClearInnerHtmlOfElement(originalElement);

    originalElement.name.appendChild(inputElement.name);
    originalElement.description.appendChild(inputElement.description);
    originalElement.cost.appendChild(inputElement.cost);
    originalElement.amount.appendChild(inputElement.amount);

    showYesNoButtons(id);
}

function onEditSaveClick(id) {
    let originalElement = GetElementsById(id);

    let inputElement = GetElementsById(id, true);

    SwapValues(originalElement, inputElement)

    ClearInnerHtmlOfElement(inputElement);
    
    showYesNoButtons(id, false);
}

function onEditCancelClick(id) {
    let originalElement = GetElementsById(id);

    originalElement.name.innerText = originalValues[id].name;
    originalElement.description.innerText = originalValues[id].description;
    originalElement.cost.innerText = originalValues[id].cost;
    originalElement.amount.innerText = originalValues[id].amount;
    
    
    showYesNoButtons(id, false);
}


function showYesNoButtons(id, isShowButtons = true) {
    let yesButton = document.getElementById(`yesButton_id_${id}`);
    let noButton = document.getElementById(`noButton_id_${id}`);

    let editButton = document.getElementById(`editButton_id_${id}`);


    yesButton.style.display = isShowButtons ? "block" : "none";
    noButton.style.display = isShowButtons ? "block" : "none";

    editButton.style.display = isShowButtons ? "none" : "block";
    
    
}

async function onRefreshClick(id) {
    let response = await fetch(`product/${id}`)
    let product = await response.json(); 

    let nameText = document.getElementById(`name_id_${id}`);
    nameText.innerText = product.name;

    let descriptionText = document.getElementById(`name_id_${id}`);
    descriptionText.innerText = product.description;
    
}


