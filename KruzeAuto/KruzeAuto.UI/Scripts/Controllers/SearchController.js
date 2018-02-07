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
            function displayData(data) {
                var results = [];
                results = data;
                if (results.length == 0) {
                    $("#card-result").children().remove();
                    $('#no-result').removeAttr("hidden");
                    $(".to-pagination").children().remove();
                } else {
                    $('#no-result').attr("hidden", "true");
                    $("#card-result").children().remove();
                    $(".to-pagination").children().remove();

                    var noPages = Math.ceil(results.length / 9);
                    if (noPages >= 2) {
                        $(".to-pagination").append("<li class='page-item disabled'><a class='page-link prev'> Previous </a > </li>");
                        for (var p = 1; p <= noPages; p++) {
                            $(".to-pagination").append("<li class='page-item'><a class='page-link page-no' >" + p + "</a></li>");
                        }
                        $(".to-pagination").append("<li class='page-item'><a class='page-link next'> Next </a ></li>");
                        $("ul .to-pagination:nth-child(2)").addClass('active');
                        $(".to-pagination .page-item:nth-child(2)").addClass('active');
                        for (var i = 0; i < 9; i++) {
                            var searchCardController = new SearchCardController("card-result", results[i]);
                            searchCardController.RenderCard();
                        }
                    }
                    else {
                        for (var i = 0; i < results.length; i++) {
                            var searchCardController = new SearchCardController("card-result", results[i]);
                            searchCardController.RenderCard();
                        }
                    }

                    $('.prev').on('click', function () {
                        var index = parseInt($(".page-item.active").text());
                        $(".page-item").eq(index).removeClass('active');
                        $(".page-item").eq(index - 1).addClass('active');
                        if (index == 1)
                            $(".page-item").eq(0).addClass('disabled');
                        if (index == noPages)
                            $(".page-item").eq(noPages + 1).removeClass('disabled');
                        if (index == 2)
                            $(".page-item").eq(0).addClass('disabled');
                        $("#card-result").children().remove();
                        scroll(0, 0);
                        for (var i = (index - 1) * 9 - 9; i < (index - 1) * 9; i++) {
                            var searchCardController = new SearchCardController("card-result", results[i]);
                            searchCardController.RenderCard();
                        }
                    });

                    $('.next').on('click', function () {
                        var index = parseInt($(".page-item.active").text());
                        $(".page-item").eq(index).removeClass('active');
                        $(".page-item").eq(index + 1).addClass('active');
                        if (index + 1 > 1)
                            $(".page-item").eq(0).removeClass('disabled');
                        if (index + 1 == noPages)
                            $(".page-item").eq(noPages + 1).addClass('disabled');
                        $("#card-result").children().remove();
                        scroll(0, 0);
                        for (var i = (index + 1) * 9 - 9; i < (index + 1) * 9; i++) {
                            var searchCardController = new SearchCardController("card-result", results[i]);
                            searchCardController.RenderCard();
                        }
                    });

                    $(".page-no").on("click", function () {
                        var index = parseInt($(this).text());
                        $(".page-item.active").removeClass('active');
                        $(this).parent().addClass('active');
                        if (index == 1)
                            $(".page-item").eq(0).addClass('disabled');
                        else
                            $(".page-item").eq(0).removeClass('disabled');
                        if (index == noPages)
                            $(".page-item").eq(noPages + 1).addClass('disabled');
                        else
                            $(".page-item").eq(noPages + 1).removeClass('disabled');
                        $("#card-result").children().remove();
                        scroll(0, 0);
                        for (var i = (index) * 9 - 9; i < (index) * 9; i++) {
                            var searchCardController = new SearchCardController("card-result", results[i]);
                            searchCardController.RenderCard();
                        }
                    });
                }
            }
            serviceContext.SearchService().MainSearch(result, displayData);
        });
    };
};