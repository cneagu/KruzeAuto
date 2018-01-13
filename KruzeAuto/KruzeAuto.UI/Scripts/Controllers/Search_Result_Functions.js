var searchResult = function (serviceContext, result) {

    var _announcements = serviceContext.AnnouncementService().ReadAll();
    var results = [];
    console.log(result);

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
            } else {
                $('#no-result').attr("hidden", "true");
                $("#card-result").children().remove();
                for (var i = 0; i < results.length; i++) {
                    var searchCardController = new SearchCardController("card-result", results[i]);
                    searchCardController.RenderCard();
                }
            }
    }
};