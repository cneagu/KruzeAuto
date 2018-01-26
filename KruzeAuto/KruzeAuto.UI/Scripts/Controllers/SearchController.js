var SearchController = function (serviceContext) {
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
    };

    this.ActivateData = function () {
        $('#main-page-card-category a').on("click", function () {
            setActiveCategory($(this), "a");
        });

        $(".main-search").on("click", function () {

            var fuel = carData.fuel;
            var selectedFuel = ['', '', '', '', '', '', '', ''];
            $("#main-fuel:checked").each(function (index) {              
                selectedFuel[index] = $(this).val();                
            });
            if (selectedFuel[0] !== '')
                fuel = selectedFuel;

            var registration = $('input[name=registration]').val();
            if (registration === '' || registration === 'Any')
                registration = 1700;

            var price = $('input[name=price]').val();
            if (price === '' || price === 'Any')
                price = 10000000;

            var km = $('input[name=km]').val();
            if (km === '' || km === 'Any')
                km = 100000000;

            var type = $('#main-page-card-category a.active').attr('id');

            var brand = $('select[name=brands]').val();
            if (brand === null)
                brand = 'Any';

            var model = $('select[name=models]').val();
            if (model === null)
                model = 'Any';

            var condition = $('input[name=main-radio]:checked').val();

            var result = {
                type: type,
                brand: brand,
                model: model,
                registration: registration,
                price: price,
                km: km,
                fuel: fuel,
                condition: condition
            };
            var _searchResult = new SearchResult(result, serviceContext);
            _searchResult.getResult();
        });
    };
};