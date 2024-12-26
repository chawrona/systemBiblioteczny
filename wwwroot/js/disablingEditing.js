const editButton = document.querySelector('#editButton');
const inputs = document.querySelectorAll('input');
editButton.disabled = true;
inputs.forEach(input => input.addEventListener('input', () => editButton.disabled = false))

