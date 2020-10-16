allCheck = document.getElementById('global_checkbox');

allCheck.addEventListener('click', () => {
    var checkBoxes = [...document.getElementsByClassName("check-box")];
    checkBoxes.forEach(x => x.checked = allCheck.checked);
});

const checkbox = document.querySelector(".check-box");
checkbox.addEventListener('click', (e) => {
    console.log(e.target.checked);
});