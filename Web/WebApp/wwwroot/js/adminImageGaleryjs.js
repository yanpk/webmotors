$(document).on("DOMNodeInserted ", "#table-container", function (e) {
    if ($(e.target.parentNode).hasClass("gallery"))
        return;
    onLoadTable();
});

function onLoadTable() {
    $("#sortable").sortable({
        placeholder: "ui-state-highlight"
    });
    $("#sortable li").attr("style", "display:inline-block");
    $("#sortable").disableSelection();
}

$(document).ready(function () {
    onLoadTable();
});