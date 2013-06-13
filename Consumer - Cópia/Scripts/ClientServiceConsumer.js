$(document).ready(function () {
    $("#txtNome").focus();
});
function callService() {
    //var url = 'http://localhost:6507/ClientService.svc/REST/getdata';
    var url = 'http://localhost:6507/ClientService.svc/REST/RegisterClient';

    // Com erro no Email
    //var data = '{"client": {"DataNascimento":"07\/08\/1984","Email":"bruno.camargos#gmail.com","Nome":"JoséSilveira","TelefoneCelular":"97000706","TelefoneResidencial":null}';
    // Com erro na DataNascimento
    //var data = '{"client": {"DataNascimento":"45\/08\/1984","Email":"bruno.camargos@gmail.com","Nome":"JoséSilveira","TelefoneCelular":"97000706","TelefoneResidencial":null}';
    //Com erro na DataNascimento e Email
    var data = '{"client": {"DataNascimento":"45\/08\/1984","Email":"bruno.camargos#gmail.com","Nome":"JoséSilveira","TelefoneCelular":"97000706","TelefoneResidencial":null}';
    // Sem erro
    //var data = '{"client": {"DataNascimento":"07\/08\/1984","Email":"bruno.camargos@gmail.com","Nome":"JoséSilveira","TelefoneCelular":"97000706","TelefoneResidencial":null}';
    //var data = '{ "value": "lkjhçsdlfjsçdlfsdoiweuoriwe" }';
    $.ajax({
        url: url,
        data: data,
        type: "POST",
        //processData: false,
        contentType: "application/json; charset=utf-8",
        timeout: 10000,
        dataType: "json",  // not "json" we'll parse
        success:
        function (data, textStatus, xhr) {
            var bo = true;
            if (data.RegisterClientResult.HasError)
                alert(data.RegisterClientResult.ErrorMessage);

            alert(data.RegisterClientResult.HasError);
            //if (!callback) return;

            // *** Use json library so we can fix up MS AJAX dates
            //var result = JSON2.parse(res);

            // *** Bare message IS result
            //if (bare)
            //{ callback(result); return; }

            // *** Wrapped message contains top level object node
            // *** strip it off
            //for (var property in result) {
            //    callback(result[property]);
            //    break;
            //}
        },
        error: function (xhr, textStatus, errorThrown) {
            //if (!error) return;
            if (xhr.responseText) {
                //var err = JSON2.parse(xhr.responseText);
                //if (err)
                //    error(err);
                //else
                //    error({ Message: "Unknown server error." })
            }
            return;
        }
    });
}