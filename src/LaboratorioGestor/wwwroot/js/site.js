function ObterDentistaPorDescricao() {
    $("#NomeDentista").autocomplete({
        source: function (request, response) {
            $.ajax(
                {
                    url: "/Servicos/ObterDentistaPorDescricao",
                    dataType: "json",
                    data: { 'nomeDetista': request.term },
                    success: response,
                    error: function (xhr) {
                        alert("Erro! Dentista não encontrado.");
                    }
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

function AjaxModal() {

    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({
                                keyboard: true
                            },
                                'show');
                            bindForm(this);
                        });
                    return false;
                });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#EnderecoTarget').load(result.url); // Carrega o resultado HTML para a div demarcada
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }
    });
}

