



function setMainSearchEngineData() {
    setOption(cars.brands,"#brands");
    setModel(cars);
    setCarTime(cars.year);
    setCarPrice(cars.price);
    setCarKm(cars.km);
    //set car fuel
    setOption(cars.fuel, "#fuel");
}

function setActiveCategory(target, selector) {    
    target.parent().parent().find(selector).removeClass("active");
    target.addClass("active");
}