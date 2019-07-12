$(document).on("click", "#enviarCadastro", function (e) {
    $('form#cadastroForm').submit();
});


//$(function () {

//  $("#cadastroForm input,#cadastroForm select").jqBootstrapValidation({
//    preventSubmit: true,
//    submitError: function($form, event, errors) {
//      // additional error messages or events
//    },
//    submitSuccess: function($form, event) {
//      event.preventDefault(); // prevent default submit behaviour
//      // get values from FORM
//      var nome = $("input#nome").val();
//      var cpf = $("input#cpf").val();
//      var tiposangue = $("select#tiposangue").val();
//      var idade = $("input#idade").val();
//      var logradouro = $("input#logradouro").val();
//      var cidade = $("input#cidade").val();
//      var numero = $("input#numero").val();
//      var bairro = $("input#bairro").val();
//      var cep = $("input#cep").val();
//      var sexo = $("select#sexo").val();

//      $this = $("#enviaCadastro");
//      $this.prop("disabled", true); // Disable submit button until AJAX call is complete to prevent duplicate messages
//      $.ajax({
//        url: "/admin/doador/create/",
//        type: "POST",
//        data: {
//          Nome: nome,
//          CPF: cpf,
//          TipoSangue: tiposangue,
//          Idade: idade,
//          Logradouro: logradouro,
//          Cidade: cidade,
//          Numero: numero,
//          Bairro: bairro,
//          CEP: cep,
//          Sexo: sexo
//        },
//        cache: false,
//        success: function() {
//          // Success message
//          $('#success').html("<div class='alert alert-success'>");
//          $('#success > .alert-success').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;")
//            .append("</button>");
//          $('#success > .alert-success')
//            .append("<strong>Cadastro Efetuado com Sucesso. </strong>");
//          $('#success > .alert-success')
//            .append('</div>');
//          //clear all fields
//          $('#cadastroForm').trigger("reset");
//        },
//        error: function() {
//          // Fail message
//          $('#success').html("<div class='alert alert-danger'>");
//          $('#success > .alert-danger').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;")
//            .append("</button>");
//          $('#success > .alert-danger').append($("<strong>").text("Desculpe " + nome + ", não foi possível realizar o cadastro no momento!"));
//          $('#success > .alert-danger').append('</div>');
//          //clear all fields
//          $('#cadastroForm').trigger("reset");
//        },
//        complete: function() {
//          setTimeout(function() {
//            $this.prop("disabled", false); // Re-enable submit button when AJAX call is complete
//          }, 1000);
//        }
//      });
//    },
//    filter: function() {
//      return $(this).is(":visible");
//    },
//  });

//  $("a[data-toggle=\"tab\"]").click(function(e) {
//    e.preventDefault();
//    $(this).tab("show");
//  });
//});

///*When clicking on Full hide fail/success boxes */
//$('#nome').focus(function() {
//  $('#success').html('');
//});
