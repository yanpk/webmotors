$(document).on("click", ".edit-item", function (e) {
    e.preventDefault();
    var id = $(this).data("id");
    var url = $("#create-item").data("url") + '/edit/' + id;
    getItem(url, id);
});

$(document).on("click", "#btn-close-modal", function (e) {
    e.preventDefault();
    closeModal();
});

$(document).on("click", ".delete-item", function (e) {
    e.preventDefault();
    var id = $(this).data("id");
    var url = $("#create-item").data("url") + '/delete/' + id;
    deleteItem(url);
});

$(document).on("click", "#create-item", function (e) {
    e.preventDefault();
    var url = $("#create-item").data("url") + '/create';
    var params = $("#create-item").data("params");
    if (params !== undefined && params !== null && params.length > 0)
        url += "?"+params;

    getItem(url);
});

$(document).on("click", "#config-item", function (e) {
    e.preventDefault();
    var url = $("#config-item").data("url") + '/create';
    getItem(url);
});

$(document).on("click", "#btn-save", function (e) {
    e.preventDefault();
    if ($("#item-form").length !== 0) {
        $("#item-form").submit();
        return;
    }

    if ($("#item-form-upload").length !== 0) {
        $("#item-form-upload").submit();
        return;
    }
    console.log("Nenhum form encontrado!");
});

$(document).on("click", "#btn-close", function (e) {
    e.preventDefault();
    closeModal();
});

$(document).on("submit", "#item-form", function (e) {
    e.preventDefault();
    var form = $("#item-form");
    var data = form.serialize();
    var url = form.attr("action");

    postItem(url, data);
});


$(document).on("click", ".pagination-link", function (e) {
    e.preventDefault();
    if ($(this).parent("li").hasClass("disabled") || $(this).parent("li").hasClass("active"))
        return;

    var pageNumber = parseInt($(this).data("pagenumber"));
    var url = $("#table-content").data("url") + "?page=" + pageNumber.toString();
    $("#table-content").data("url", url);
    ReloadTable();
});

var modal = null;
$(document).ready(function () {
    modal = $('#item-modal').modal();
});

function postItemWithFiles(url, data) {
    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: function (result) {
            showMessage("OK", "", "success");
            closeModal();
            clearModal();
            ReloadTable();
        },
        error: ajaxFail,
        cache: false,
        contentType: false,
        processData: false,
        xhr: function () {  // Custom XMLHttpRequest
            var myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload) { // Avalia se tem suporte a propriedade upload
                myXhr.upload.addEventListener('progress', function () {
                    /* faz alguma coisa durante o progresso do upload */
                    console.log("Upload em andamento");
                }, false);
            }
            return myXhr;
        }
    });
}

$(document).on("click", ".datepicker", function (e) {
    e.preventDefault();
    setDatePicker();
});

var defaultSchema = [
    { "data": "Id" },
    { "data": "Titulo" },
];
function LoadDataTable(schema) {
    if (schema === undefined) {
        schema = defaultSchema;
    }
    $('#table-content').DataTable();
    //$('#table-content').DataTable({
    //    "ajax": $('#table-content').data("url"),
    //    "columns": schema,
    //    "columnDefs": [{
    //        "targets": -1,
    //        "data": null,
    //        "defaultContent": '<i class="material-icon edit-item" data-id="@item.Id">eye</i> <i class="material-icon delete-item" data-id="@item.Id">remove</i>'
    //    }]
    //});
}

function postItemDoacoes(url, data) {
    $.post(url, data, function (result) {
        showMessage("OK", "", "success");
        closeModal();
        clearModal();
        location.reload();
    }).fail(ajaxFail);
}

function postItem(url, data) {
    $.post(url, data, function (result) {
        showMessage("OK", "", "success");
        closeModal();
        clearModal();
        ReloadTable();
    }).fail(ajaxFail);
}

function getItem(url, id) {
    $.get(url, function (result) {
        $("#item-modal-content").html(result);
        openModal();
        //Materialize.updateTextFields();
        //$('select').material_select();
        $('.js-example-basic-single').select2();
    }).fail(ajaxFail);
}

function ajaxFail(response, status, code) {
    console.group("Response Error:");
    console.log(response);
    console.log(status);
    console.log(code);
    console.groupEnd();
    if (response.responseJSON === undefined)
        return;

    let htmlMsg = "";
    for (i = 0; i < response.responseJSON.length; i++) {
        htmlMsg += response.responseJSON[i] + "<br/>";
    }
    showMessage("Ops", htmlMsg, "error");
}

function showMessage(title, message, type) {
    swal(title, message, type);
}

function openModal() {
    //
    try {
        $('#item-modal').modal('open');
    } catch (e) {
        $('#item-modal').modal();
        $('#item-modal').modal('open');
    }
}

function closeModal() {
    $('#item-modal').modal('close');
}

function clearModal() {
    $('#item-modal-content').html('');
    $('#item-modal').modal();
}

function deleteItem(url) {
    swal({
        title: 'Tem certeza que deseja excluir este item?',
        text: "Essa opção é irreversível",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sim!',
        cancelButtonText: 'Não'
    }).then((result) => {
        if (result.value) {
            deleteItemConfirmed(url);
        }
    });
}

function deleteItemConfirmed(url) {
    var data = { __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val() };
    $.post(url,data, function (result) {
        swal(
            'Pronto!',
            'Item excluído com sucesso.',
            'success'
        );
        ReloadTable();
    }).fail(ajaxFail);
}

function ReloadTable() {
    var url = $("#table-content").data("url");
    $.get(url, function (result) {
        $("#table-container").html(result);
    }).fail(ajaxFail);
}

function setDatePicker() {

    $('.datepicker').pickadate({
        selectMonths: true, // Creates a dropdown to control month
        selectYears: 15, // Creates a dropdown of 15 years to control year,
        today: 'Today',
        clear: 'Clear',
        close: 'Ok',
        closeOnSelect: false // Close upon selecting a date,
    });
}

//TODO: Finalizar blockUI
function blockUI(block) {
    if (block)
        console.log("blok");
    else
        console.log("unblock");
}
