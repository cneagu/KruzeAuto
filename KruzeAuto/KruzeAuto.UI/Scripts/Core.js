








$(document).ready(function () {
    
    setMainSearchEngineData();

    $('#main-page-card-category a').on("click", function () {
        console.log($(this).text());
        setActiveCategory($(this), "a");
    });

    $(".main-search").on("click", function () {

        window.location.hash = '#search';
        var result = {
            brand : $('select[name=brands]').val(),
            model : $('select[name=models]').val(),
            registration : $('select[name=registration]').val(),
            price : $('select[name=price]').val(),
            km : $('select[name=km]').val(),
            fuel : $('select[name=fuel]').val(),
            new : $('select[name=new]').val(),
            used : $('select[name=used]').val()
        };
        
        console.log(result);
    });

    $("#primary-login").on("click", function () {
        window.location.hash = '#login';

    });
});

