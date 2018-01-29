var AnnouncementController = function (serviceContext) {
    var _announcement = [];
    var _valide = false;

    this.SetAnnouncementData = function () {
        $('#newAnnouncement').on('click', function () {
            //console.log(CURENT_USER);
            setOption(CAR_DATA.brands, "#new-brand");
            setModel(CAR_DATA, 'select[name=new-brand]', "#new-model");
            setOption(CAR_DATA.type, "#new-type");
            setOption(CAR_DATA.fuel, "#new-fuelType");
            setOption(CAR_DATA.currency, "#new-currency");
            setOption(CAR_DATA.transmission, "#new-transmission");
            setOption(CAR_DATA.emissionClass, "#new-emissionClass");
        });
    };

    this.CreateAnnouncement = function () {
        
        $("#create").on('click', function () {
            var guid = newGuid();
            var date = newDate();

            var vehicleType = parseInt($('select[name=new-vehicle-type]').val());
            var condition = $('select[name=new-condition]').val();
            var title = $('input[name=new-title]').val();
            var brand = $('select[name=new-brand]').val();
            var model = $('select[name=new-model]').val();
            var type = $('select[name=new-type]').val();
            var km = parseInt(validateDigits($('input[name=new-km]').val(), '#new-km'));
            var fabricationYear = parseInt($('input[name=new-fabricationYear]').val());
            var vin = $('input[name=new-vin]').val();
            var fuelType = $('select[name=new-fuelType]').val();
            var price = parseInt(validateDigits($('input[name=new-price]').val(), '#new-price'));
            var currency = $('select[name=new-currency]').val();
            var negociablePrice = $('#main-negociablePrice').is(':checked') ? true : false;
            var color = $('select[name=new-color]').val();
            var colorType = $('select[name=new-colorType]').val();
            var power = parseInt(validateDigits($('input[name=new-power]').val(), '#new-power'));
            var transmission = $('select[name=new-transmission]').val();
            var cubicCapacity = parseInt(validateDigits($('input[name=new-cubicCapacity]').val(), '#new-cubicCapacity'));
            var emissionClass = $('select[name=new-emissionClass]').val();
            var numberOfSeats = parseInt(validateDigits($('input[name=new-numberOfSeats]').val(), '#new-numberOfSeats'));
            var GVW = parseInt(validateDigits($('input[name=new-GVW]').val(), '#new-GVW'));
            var loadCapacity = parseInt(validateDigits($('input[name=new-loadCapacity]').val(), '#new-loadCapacity'));
            var operatingHours = parseInt(validateDigits($('input[name=new-operatingHours]').val(), '#new-operatingHours'));
            var description = $('textarea#new-description').val();



            var _announcementToValidate = {
                vehicleType: vehicleType,
                condition: condition,
                title: title,
                brand: brand,
                model: model,
                type: type,
                km: km,
                fabricationYear: fabricationYear,
                fuelType: fuelType,
                price: price,
                currency: currency,
                power: power
            };

            if (validate(_announcementToValidate) !== 0) {
                _announcement = {
                    AnnoucementID: guid,
                    UserID: CURENT_USER.UserID,
                    VehicleType: validateDigit(vehicleType),
                    Views: 0,
                    Promoted: false,
                    Active: true,
                    CreationDate: date,
                    Update: date,
                    Condition: condition,
                    Title: title,
                    Brand: brand,
                    Model: model,
                    Type: type,
                    Kilometer: validateDigit(km),
                    FabricationYear: validateDigit(fabricationYear),
                    VIN: validationText(vin),
                    FuelType: fuelType,
                    Price: validateDigit(price),
                    NegociablePrice: negociablePrice,
                    Currency: currency,
                    Color: validationText(color),
                    ColorType: validationText(colorType),
                    Power: validateDigit(power),
                    Transmission: transmission,
                    CubicCapacity: validateDigit(cubicCapacity),
                    EmissionClass: emissionClass,
                    NumberOfSeats: validateDigit(numberOfSeats),
                    GVW: validateDigit(GVW),
                    LoadCapacity: validateDigit(loadCapacity),
                    OperatingHours: validateDigit(operatingHours),
                    Description: validationText(description)
                };
                

                console.log(_announcement);
                var _newAnnouncement = new NewAnnouncement(serviceContext, _announcement);
                _newAnnouncement.Insert();
            }
            else
                alert('not valid!');

        });
    };
};