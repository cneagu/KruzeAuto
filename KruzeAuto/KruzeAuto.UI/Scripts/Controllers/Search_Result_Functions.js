var searchResult = function (serviceContext, result) {

    var _announcements = serviceContext.AnnouncementService().ReadAll();
    var results = [];
    console.log(result);

    this.getResult = function () {

            for (var i = 0; i < _announcements.length; i++) {
                if ((result.brand == _announcements[i].Brand || result.brand == null || result.brand == 'Any')
                    && (result.model == _announcements[i].Model || result.model == null || result.model == 'Any')
                    && (parseInt(result.registration) <= _announcements[i].FabricationYear || result.registration == null || result.registration == 'Any')
                    && (parseInt(result.price) >= _announcements[i].Price || result.price == null || result.price == 'Any')
                    && (parseInt(result.km) >= _announcements[i].Kilometer || result.km == null || result.km == 'Any')
                    && (result.fuel == _announcements[i].FuelType || result.fuel == null || result.fuel == 'Any')
                    && (result.type == "All" || result.type == _announcements[i].Condition)) {
                    results.push(_announcements[i]);
                    console.log(typeof (parseInt(result.registration)));
                    console.log(typeof (_announcements[i].FabricationYear));
                }
                   
            } 
        console.log(results);
    }
};