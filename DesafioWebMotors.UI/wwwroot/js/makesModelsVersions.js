function obterModelos() {
    var name = $('#marca').val();
    $.ajax({
        url: '/AnuncioWebmotor/ObterModelos',
        type: 'GET',
        dataType: 'json',
        data: { name: name },
        success: function (data) {
            console.log(data);
            $("#modelo").html("");
            $.each(data, function (i, data) {
                $("#modelo").append($('<option>', {
                    value: data.name,
                    text: data.name
                }));
            });

            obterVersions();
        }
    });
}

function obterVersions() {
    var modelo = $('#modelo').val();
    var marca = $('#marca').val();
    $.ajax({
        url: '/AnuncioWebmotor/ObterVersoes',
        type: 'GET',
        dataType: 'json',
        data: { marca: marca, modelo: modelo },
        success: function (data) {
            console.log(data);
            $("#version").html("");
            $.each(data, function (i, data) {
                $("#version").append($('<option>', {
                    value: data.name,
                    text: data.name
                }));
            });
        }
    });
}