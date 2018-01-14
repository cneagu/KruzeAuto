var searchResult = function (serviceContext, result) {

    var _announcements = serviceContext.AnnouncementService().ReadAll();
    var results = [];

    this.getResult = function () {

            for (var i = 0; i < _announcements.length; i++) {
                if ((result.brand == _announcements[i].Brand || result.brand == null || result.brand == 'Any')
                    && (result.model == _announcements[i].Model || result.model == null || result.model == 'Any')
                    && (parseInt(result.registration) <= _announcements[i].FabricationYear || result.registration == null || result.registration == 'Any' || result.registration === "")
                    && (parseInt(result.price) >= _announcements[i].Price || result.price == null || result.price == 'Any' || result.price === "")
                    && (parseInt(result.km) >= _announcements[i].Kilometer || result.km == null || result.km == 'Any' || result.km === "")
                    && (result.fuel == _announcements[i].FuelType || result.fuel == null || result.fuel == 'Any')
                    && (result.type == "All" || result.type == _announcements[i].Condition)) {
                    results.push(_announcements[i]);
                }                  
            } 
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
                        $(".to-pagination").append("<li class='page-item'><a class='page-link page-no' >" + p +"</a></li>");
                    }
                    $(".to-pagination").append("<li class='page-item'><a class='page-link next'> Next </a ></li>");
                    $("ul .to-pagination:nth-child(2)").addClass('active');
                    $(".to-pagination .page-item:nth-child(2)").addClass('active');
                    for (var i = 0; i < 9 ; i++) {
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
                    for (var i = (index - 1) * 9 - 9; i < (index - 1) * 9 ; i++) {
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
};