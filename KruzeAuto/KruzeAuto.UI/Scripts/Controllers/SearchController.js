var SearchController = function () {
    var carData = {
        "brands": ["BMW", "Mercedes", "Audi"],
        "BMW": ["1 Series", "2 Series", "3 Series", "4 Series", "5 Series", "6 Series", "7 Series", "X1", "X3", "X4", "X5", "X6", "M3", "M4", "M5", "M6"],
        "Mercedes": ["A Class", "B Class", "C Class", "E Class", "S Class", "CLS", "GT AMG"],
        "Audi": ["A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "Q7"],
        "year": 2018,
        "price": 100,
        "km": 5000,
        "fuel": ["Petrol", "Diesel", "Ethanol", "Hibrid", "LPG", "Natural Gas", "Hydrogen", "Other"]
    };

    this.SetMainSearchEngineData = function () {
        setOption(carData.brands, "#brands");
        setModel(carData);
        setCarTime(carData.year);
        setCarPrice(carData.price);
        setCarKm(carData.km);
        //set car fuel
        setOption(carData.fuel, "#fuel");
    }

    this.ActivateData = function () {
        $('#main-page-card-category a').on("click", function () {
            setActiveCategory($(this), "a");
        });

        $(".main-search").on("click", function () {
            var result = {
                type: $('#main-page-card-category a.active').attr('id'),
                brand: $('select[name=brands]').val(),
                model: $('select[name=models]').val(),
                registration: $('input[name=registration]').val(),
                price: $('input[name=price]').val(),
                km: $('input[name=km]').val(),
                fuel: $('select[name=fuel]').val(),
                condition: $('input[name=main-radio]:checked').val()
            };

            console.log(result);
            var _searchResult = new searchResult(result);
            _searchResult.getResult();
        });
    }
}