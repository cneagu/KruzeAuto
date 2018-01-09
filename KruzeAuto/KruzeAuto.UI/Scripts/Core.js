var brand = ["BMW",
    "Mercedes",
    "Audi"
];
var bmw = ["1 Series",
    "3 Series",
    "5 Series",
    "6 Series",
    "7 Series",
    "X1",
    "X3",
    "X6",
    "M3",
    "M5",
    "M6"
];
var mercedes = ["A Class",
    "B Class",
    "C Class",
    "E Class",
    "S Class",
    "CLS",
    "GT AMG"
];
var audi = ["A1",
    "A2",
    "A3",
    "A4",
    "A5",
    "A6",
    "A7",
    "A8",
    "Q7"
];

var fuel = ["Petrol",
    "Diesel",
    "Ethanol",
    "Hibrid",
    "LPG",
    "Natural Gas",
    "Hydrogen",
    "Other"
]


function setMainSearchEngineData() {
    $('#brands').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
    for (var i = 0; i < brand.length; i++) {
        $('#brands').append("<option value='" + brand[i] + "'>" + brand[i] +"</option>" );
    }

    
    $('select[name=brands]').change(function () {
        switch ($('select[name=brands]').val()) {
            case "BMW":
                $("#models").children().remove();
                $('#models').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
                for (var i = 0; i < bmw.length; i++) {
                    $('#models').append("<option value='" + bmw[i] + "'>" + bmw[i] + "</option>");
                }
                break;
            case "Mercedes":
                $("#models").children().remove();
                $('#models').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
                for (var i = 0; i < mercedes.length; i++) {
                    $('#models').append("<option value='" + mercedes[i] + "'>" + mercedes[i] + "</option>");
                }
                break;
            case "Audi":
                $("#models").children().remove();
                $('#models').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
                for (var i = 0; i < audi.length; i++) {
                    $('#models').append("<option value='" + audi[i] + "'>" + audi[i] + "</option>");
                }
                break;
        }
    });

    var year = 2018;
    $('#registration').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
    while(year >= 1900){
        $('#registration').append("<option value='" + year + "'>" + year + "</option>");
        if (year > 1990)
            year--;
        else if (year > 1900 && year <= 1990)
            year -= 5;
        else
            break;
    }

    var price = 100;
    $('#price').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
    while (price <= 100000) {
        $('#price').append("<option value='" + price + "'>" + price + " €</option>");
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

    var km = 5000;
    $('#km').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
    while (km <= 300000) {
        $('#km').append("<option value='" + km + "'>" + km + " km</option>");
        if (km < 10000)
            km += 5000;
        else if (km < 100000 && km >= 10000)
            km += 10000;
        else if (price < 200000 && km >= 100000)
            km += 25000;
        else if (km <= 300000 && km >= 200000)
            km += 50000;
    }
    $('#fuel').append("<option value='" + "Any" + "'>" + "Any" + "</option>");
    for (var i = 0; i < fuel.length; i++) {
        $('#fuel').append("<option value='" + fuel[i] + "'>" + fuel[i] + "</option>");
    }
}








$(document).ready(function () {
    
    setMainSearchEngineData();

    $(".main-search").on("click", function (e) {
        
        var result = {
            "brand": $('select[name=brands]').val(),
            "model": $('select[name=models]').val(),
            "registration": $('select[name=registration]').val(),
            "price": $('select[name=price]').val(),
            "km": $('select[name=km]').val(),
            "fuel": $('select[name=fuel]').val(),
            "new": $('select[name=new]').val(),
            "used": $('select[name=used]').val()
        };
        
        console.log(result);
    });

});

