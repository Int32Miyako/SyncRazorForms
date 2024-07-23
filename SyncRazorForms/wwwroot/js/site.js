let originalValues = {};

function OnEditClick(id) {
    let name = document.getElementById(`name_id_${id}`);
    let description = document.getElementById(`description_id_${id}`);
    let cost = document.getElementById(`cost_id_${id}`);
    let amount = document.getElementById(`amount_id_${id}`);

    originalValues[id] = {
        name : name.innerText,
        description : description.innerText,
        cost : cost.innerText,
        amount : amount.innerText
    }
    
    let inputName           = document.createElement("input");
    let inputDescription = document.createElement("input");
    let inputCost       = document.createElement("input");
    let inputAmount      = document.createElement("input");
    
    inputName.id        = `input_name_id_${id}`;
    inputDescription.id = `input_description_id_${id}`;
    inputCost.id        = `input_cost_id_${id}`;
    inputAmount.id      = `input_amount_id_${id}`;
    
    inputName.value        = name.innerText;
    inputDescription.value = description.innerText;
    inputCost.value        = cost.innerText;
    inputAmount.value      = amount.innerText;

    name.innerHTML = "";
    description.innerHTML = "";
    cost.innerHTML = "";
    amount.innerHTML = "";
    
    name.appendChild(inputName);
    description.appendChild(inputDescription);
    cost.appendChild(inputCost);
    amount.appendChild(inputAmount);

    showYesNoButtons(id);
}

function onEditSaveClick(id){
    let name        = document.getElementById(`name_id_${id}`);
    let description = document.getElementById(`description_id_${id}`);
    let cost        = document.getElementById(`cost_id_${id}`);
    let amount      = document.getElementById(`amount_id_${id}`);

    let inputName       = document.getElementById(`input_name_id_${id}`);
    let inputDescription= document.getElementById(`input_description_id_${id}`);
    let inputCost       = document.getElementById(`input_cost_id_${id}`);
    let inputAmount     = document.getElementById(`input_amount_id_${id}`);

    name.innerText        = inputName.value;
    description.innerText = inputDescription.value;
    cost.innerText        = inputCost.value;
    amount.innerText      = inputAmount.value;
    
    inputName.innerHTML = "";
    inputDescription.innerHTML = "";
    inputCost.innerHTML = "";
    inputAmount.innerHTML = "";


    hideYesNoButtons(id);
}

function onEditCancelClick(id){
    let name        = document.getElementById(`name_id_${id}`);
    let description = document.getElementById(`description_id_${id}`);
    let cost        = document.getElementById(`cost_id_${id}`);
    let amount      = document.getElementById(`amount_id_${id}`);

    name.innerText = originalValues[id].name
    description.innerText = originalValues[id].description
    cost.innerText = originalValues[id].cost
    amount.innerText = originalValues[id].amount

    
    
    hideYesNoButtons(id);
}



function showYesNoButtons(id) {
    let yesButton = document.getElementById(`yesButton_id_${id}`);
    let noButton  = document.getElementById(`noButton_id_${id}`);
    
    let editButton= document.getElementById(`editButton_id_${id}`);

   
    yesButton.style.display = "block";
    noButton.style.display  = "block";
    
    editButton.style.display = "none";
}

function hideYesNoButtons(id){
    let yesButton = document.getElementById(`yesButton_id_${id}`);
    let noButton  = document.getElementById(`noButton_id_${id}`);

    let editButton= document.getElementById(`editButton_id_${id}`);


    yesButton.style.display  = "none";
    noButton.style.display   = "none";

    editButton.style.display = "block";
}
