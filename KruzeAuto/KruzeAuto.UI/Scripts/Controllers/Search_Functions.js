function setActiveCategory(target, selector) {
    target.parent().parent().find(selector).removeClass("active");
    target.addClass("active");
}

function setOption(field, id) {

    $(id).append("<option value='" + "Any" + "'>" + "Any" + "</option>");
    for (var i = 0; i < field.length; i++) {
        $(id).append("<option value='" + field[i] + "'>" + field[i] + "</option>");
    }
}


function setModel(type) {
    $('select[name=brands]').change(function () {
        var model = $('select[name=brands]').val()
        $("#models").children().remove();
        setOption(type[model], "#models");

    });
}

function setCarTime(year) {
    $('#dregistration').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
    while (year >= 1900) {
        $('#dregistration').append("<option value='" + year + "'>" + year + "</option>");
        if (year > 1990)
            year--;
        else if (year > 1900 && year <= 1990)
            year -= 5;
        else
            break;
    }
}

function setCarPrice(price) {
    $('#dprice').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
    while (price <= 100000) {
        $('#dprice').append("<option value='" + price + "'>€</option>");
        if (price < 500)
            price += 200;
        else if (price < 5000 && price >= 500)
            price += 500;
        else if (price < 10000 && price >= 5000)
            price += 1000;
        else if (price < 20000 && price >= 10000)
            price += 2500;
        else if (price < 50000 && price >= 20000)
            price += 5000;
        else if (price <= 100000 && price >= 50000)
            price += 25000;
    }
}

function setCarKm(km) {
    $('#dkm').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
    while (km <= 300000) {
        $('#dkm').append("<option value='" + km + "'>km</option>");
        if (km < 10000)
            km += 5000;
        else if (km < 100000 && km >= 10000)
            km += 10000;
        else if (km < 200000 && km >= 100000)
            km += 25000;
        else if (km <= 300000 && km >= 200000)
            km += 50000;
    }
}