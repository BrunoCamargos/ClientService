$(document).ready(function () {
    $("#txtNome").focus();
});

function getClientObj() {
    var clientObj = { client: {} };
    clientObj.client.Nome = $("#txtNome").val();
    clientObj.client.Email = $("#txtEmail").val();
    clientObj.client.DataNascimento = $("#txtDtNascimento").val();
    clientObj.client.TelefoneCelular = $("#txtTelCelular").val();
    clientObj.client.TelefoneResidencial = $("#txtTelRes").val();

    return clientObj;
}

function callService() {
    //var url = 'http://localhost:6507/ClientService.svc/REST/getdata';
    var url = 'http://localhost:6507/ClientService.svc/REST/RegisterClient';

    // Com erro no Email
    //var data = '{"client": {"DataNascimento":"07\/08\/1984","Email":"bruno.camargos#gmail.com","Nome":"JoséSilveira","TelefoneCelular":"97000706","TelefoneResidencial":null}';
    // Com erro na DataNascimento
    //var data = '{"client": {"DataNascimento":"45\/08\/1984","Email":"bruno.camargos@gmail.com","Nome":"JoséSilveira","TelefoneCelular":"97000706","TelefoneResidencial":null}';
    //Com erro na DataNascimento e Email
    //var data = '{"client": {"DataNascimento":"45\/08\/1984","Email":"bruno.camargos#gmail.com","Nome":"JoséSilveira","TelefoneCelular":"97000706","TelefoneResidencial":null}';
    // Sem erro
    //var data = '{"client": {"DataNascimento":"07\/08\/1984","Email":"bruno.camargos@gmail.com","Nome":"JoséSilveira","TelefoneCelular":"97000706","TelefoneResidencial":null}';
    //var data = '{ "value": "lkjhçsdlfjsçdlfsdoiweuoriwe" }';
    var data = getClientObj();
    $("#btnSalvar").val("Salvando...")
        .attr('disabled', 'disabled')
        .css('cursor', 'default');

    $.ajax({
        url: url,
        data: $.toJSON(data),
        type: "POST",
        //processData: false,
        contentType: "application/json; charset=utf-8",
        timeout: 10000,
        dataType: "json",  // not "json" we'll parse
        success:
        function (data, textStatus, xhr) {
            if (data.RegisterClientResult.HasError)
                alert(data.RegisterClientResult.ErrorMessage);
            else
                alert("Registro salvo com sucesso");
        },
        error: function (xhr, textStatus, errorThrown) {
            alert(errorThrown);

            return;
        },
        complete: function (xhr, textStatus) {
            $("#btnSalvar").val("Salvar")
                .removeAttr('disabled')
                .css('cursor', 'pointer');
        }
    });
}