var SearchController = function (serviceContext) {

    this.SetMainSearchEngineData = function () {
        setOption(CAR_DATA.brands, "#brands");
        setModel(CAR_DATA, 'select[name=brands]', "#models");
        setCarTime(CAR_DATA.year);
        setCarPrice(CAR_DATA.price);
        setCarKm(CAR_DATA.km);
    };

    this.ActivateData = function () {
        $('#main-page-card-category a').on("click", function () {
            setActiveCategory($(this), "a");
        });

        $(".main-search").on("click", function () {

            var fuel = CAR_DATA.fuel;
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