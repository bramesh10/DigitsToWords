$(document).ready(function () {
    $('form').submit(function () {
        $("#words").text("Processing Cheque Details...");
        $.ajax({
            url: 'api/Cheque/ProcessDetails',
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                Name: $('#name').val(),
                AmountInNumbers: $('#numbers').val()
            }),
            success: function (result) {
                $("#output").text("Output");
                $("#rname").text(result.Name);
                $("#words").text(result.AmountInWords);
            },
            error: function (result) {
                $("#output").text();
                $("#rname").text();
                $("#words").text();

                var errMesasgeObject = $.parseJSON(result.responseText);
                $("#words").text("Cheque Processing Failed. Error Result: " + errMesasgeObject.Message);
            }
        });
        return false;
    });
});