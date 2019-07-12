$(document).on("change", "#selectMarca", function (e) {
    var value = $(this).val();
    if (value == '') {
        alert('Escolha uma Marca');
    } else {
        var idMarca = $("#selectMarca").val();
        var selectbox = $('#selectVeiculo');
        selectbox.find('option').html("Selecione o Veículo");
        ResetarTabelaConsulta();
        console.log(idMarca);
        GetModelos(idMarca);
        var selectbox2 = $('#selectModelo');
        selectbox2.find('option').html("Selecione o Modelo");
        return;
    }
});

$(document).on("change", "#selectModelo", function (e) {
    var value = $(this).val();
    if (value == '') {
        alert('Escolha um Modelo');
    } else {
        var idMarca = $("#selectMarca").val();
        var idModelo = $("#selectModelo").val();
        //var selectbox = $('#selectModelo');
        //selectbox.find('option').html("Selecione o Modelo");
        console.log(idMarca);
        console.log(idModelo);
        GetVeiculos(idMarca, idModelo);
        return;
    }
});

$(document).on("change", "#selectVeiculo", function (e) {
    var value = $(this).val();
    if (value == '' || value == null) {
        alert('Escolha um veículo');
    } else {
        var idMarca = $("#selectMarca").val();
        var idModelo = $("#selectModelo").val();
        var idVeiculo = $("#selectVeiculo").val();
        //var selectbox = $('#selectVeiculo');
        //selectbox.find('option').html("Selecione o Veículo");
        console.log(idMarca);
        console.log(idModelo);
        console.log(idVeiculo);
        //GetVeiculoEspecifico(idMarca, idModelo, idVeiculo);
        ResetarTabelaConsulta();
        return;
    }
});

function GetModelos(idMarca) {
    var selectbox = $('#selectModelo');
    selectbox.find('option').remove();
    //selectbox.find('option').html("Selecione o Veículo");
    var data = { idMarca: idMarca };
    $.post("admin/modelo/ConsultarVeiculosPorMarca/", data, function (result) {
        console.log(result);
        if (result != null && result != undefined) {
            $('<option>').val("").text("Selecione o Modelo").attr("disabled", "disabled").attr("selected", "selected").appendTo(selectbox);
            $.each(result, function (i, d) {
                $('<option>').val(d.id).text(d.nome).appendTo(selectbox);
            });
        }
        $('select').material_select('update');

    }).fail(function (response, status, error) {
        console.log("Não listou veículos");
        console.log(status);
    });
}

function GetVeiculos(idMarca, idModelo) {
    var selectbox = $('#selectVeiculo');
    selectbox.find('option').remove();
    //selectbox.find('option').html("Selecione o Veículo");
    var data = { idMarca: idMarca, idModelo: idModelo };
    $.post("admin/Veiculo/ConsultarVeiculosPorModelo/", data, function (result) {
        console.log(result);
        if (result != null && result != undefined) {
            $('<option>').val("").text("Selecione o Veículo").attr("disabled", "disabled").attr("selected", "selected").appendTo(selectbox);
            $.each(result, function (i, d) {
                var option = $('<option>').val(d.fipeCodigo).text(d.anoModelo + " - " + d.nome + " (" + d.combustivel + ")");
                option.data("anoModelo", d.anoModelo);
                option.data("combustivel", d.combustivel);
                option.data("preco", d.preco);
                option.data("fipe", d.fipeCodigo);
                option.data("modelo", d.nome);
                option.data("marca", d.idMarca);

                option.appendTo(selectbox);
            });
        }
        $('select').material_select('update');
    }).fail(function (response, status, error) {
        console.log("Não listou veículos");
        console.log(status);
    });
}

$(document).on("change", "#selectVeiculo", function (e) {
    var anoModelo = $("#selectVeiculo option:selected").data("anoModelo");
    var combustivel = $("#selectVeiculo option:selected").data("combustivel");
    var preco = $("#selectVeiculo option:selected").data("preco");
    var codigoFipe = $("#selectVeiculo option:selected").data("fipe");
    var modelo = $("#selectVeiculo option:selected").data("modelo");
    var marca = $("#selectVeiculo option:selected").data("marca");


    $("#CodigoFipe").val(codigoFipe);
    $("#Modelo").val(modelo);
    $("#Versao").val(modelo);
    $("#Marca").val(marca);


    if ($("#Preco").val() == "" || $("#Preco").val() == "0")
        $("#Preco").val(preco);

    if ($("#Combustivel").val() == "" || $("#Combustivel").val() == "0")
        $("#Combustivel").val(combustivel);


    if ($("#AnoModelo").val() == "" || $("#AnoModelo").val() == "0") {
        $("#AnoModelo").val(anoModelo);
        $("#AnoFabricacao").val(anoModelo);
    }

    Materialize.updateTextFields();
});

function GetVeiculoEspecifico(idMarca, idModelo, idVeiculo) {
    var data = { IdMarca: idMarca, IdModelo: idModelo, IdVeiculo: idVeiculo };
    $.post("admin/consulta/consultaveiculoespecifico/", data, function (result) {
        console.log(result);
        if (result != null && result != undefined) {
            var table = $('#tableConsulta').find("tbody").find("tr");
            $('<td>').val(result.Id).text(result.Id).appendTo(table);
            $('<td>').val(result.Nome).text(result.Nome).appendTo(table);
            $('<td>').val(result.AnoModelo).text(result.AnoModelo).appendTo(table);
            $('<td>').val(result.Combustivel).text(result.Combustivel).appendTo(table);
            $('<td>').val(result.FipeCodigo).text(result.FipeCodigo).appendTo(table);
            $('<td>').val(result.Referencia).text(result.Referencia).appendTo(table);
            var valorFormat = "R$ " + result.Preco.toFixed(2).replace(".", ",");
            $('<td>').val(valorFormat).text(valorFormat).appendTo(table);
        }
    }).fail(function (response, status, error) {
        console.log("Não listou veículos");
        console.log(status);
    });

}

function ResetarTabelaConsulta() {
    $("#tableConsulta").find("tbody").find("tr").html("");
}

