function checkSelected() {
    var checkboxes = document.getElementsByName("item");
    var TotalChecked = 0;

    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            TotalChecked++;
        }
    }
    if (TotalChecked >= 2) 
        document.getElementById("button").disabled = false;
    else 
        document.getElementById("button").disabled = true;
}