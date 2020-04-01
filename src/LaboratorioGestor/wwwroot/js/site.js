function ObterDentistaPorDescricao() {
    $("#NomeDentista").autocomplete({
        source: function (request, response) {
            $.ajax(
                {
                    url: "/Servicos/ObterDentistaPorDescricao",
                    dataType: "json",
                    data: { 'nomeDetista': request.term },
                    success: response
                });
        },

        focus: function (event, ui) {
            $("#IDPesquisa").val(ui.item.value);
        },

        select: function (event, ui) {
            $("#NomeDentista").val(ui.item.value);
            $("#IDPesquisa").val(ui.item.id);
            return false;
        }
    });
}

function AdicionarCobranca() {
    $('#btnSalvarServicos').click(function () {

        var arrayServicos = $('#itemTecnico');
        var NomePaciente = new Array();
        var Id = new Array();
        var ReferenciaOS = new Array();
        var Valor = new Array();
        var servicos = new Array();

        alert(arrayServicos.length);

        function pegarosTecnicos() {

            for (var i = 0; i < arrayServicos.length; i++) {

                servicos = {
                    id: $('.Id').val(),
                    NomePaciente: $('.NomePaciente').val(),
                    ReferenciaOS: $('.ReferenciaOS').val()
                };
            }
        }

        pegarosTecnicos();

        $.ajax({
            type: "POST",
            url: "/Cobranca/AdicionarCobranca", // to get the right path to controller from TableRoutes of Asp.Net MVC
            dataType: "json", //to work with json format
            data: servicos, // passar os parametros
            success: function (data) {


            },
            error: function (xhr) {
                alert("Erro! ao Salvar os com os tecnicos, Favor Entrar em Contato com O Suporte.");
            }

        });

        alert(servicos.length);
    });
}