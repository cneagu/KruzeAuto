var SearchController = function (serviceContext) {

    this.SetMainSearchEngineData = function () {
        setOption(cars.brands, "#brands");
        setModel(cars);
        setCarTime(cars.year);
        setCarPrice(cars.price);
        setCarKm(cars.km);
        //set car fuel
        setOption(cars.fuel, "#fuel");
    }

    this.ActivateData = function () {
        $('#main-page-card-category a').on("click", function () {
            console.log($(this).text());
            setActiveCategory($(this), "a");
        });

        $(".main-search").on("click", function () {

           

            var result = {
                brand: $('select[name=brands]').val(),
                model: $('select[name=models]').val(),
                registration: $('input[name=registration]').val(),
                price: $('input[name=price]').val(),
                km: $('input[name=km]').val(),
                fuel: $('select[name=fuel]').val(),
                type: $('input[name=main-radio]:checked').val()
            };

           

            var _searchResult = new searchResult(serviceContext, result);
            _searchResult.getResult();

        });
    }
}