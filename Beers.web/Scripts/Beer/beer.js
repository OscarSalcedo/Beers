
var onChangeHandler = function () {
    getCities().done(successLoadCities);
}

var successLoadCities = function(data) {
    var options = $('#cmbCities');
    options.empty();
    $.each(data, function () {
        options.append(new Option(this.Description, this.Code));
    })
}

var getCities = function () {
    var id = $('#cmbCountry').val()
    return $.getJSON('/api/city/', { id: id });
}

$('#cmbCountry').change(onChangeHandler);


var onKeyPressHandler = function (e) {
    var regex = /^([0-9])*$/;
    if (!regex.test(e.key)) {
        return false;
    }
    else return true;
}


$('#txtGraduation').keypress(onKeyPressHandler);




