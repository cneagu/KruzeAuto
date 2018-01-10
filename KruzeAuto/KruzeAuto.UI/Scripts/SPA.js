﻿(function () {
    function setActiveLink(fragmentId) {
        $(".page-content").each(function (i, divElement) {
            var divElement = $(this).attr('id');
            if (divElement == fragmentId) {
                $(this).removeAttr("hidden");
            }
            else {
                $(this).attr("hidden", "true");
            }
        });
    }

    function navigate() {
        var fragmentIdcomplete = location.hash.substr(1);
        var fragmentId = fragmentIdcomplete.split("?");
        setActiveLink(fragmentId[0]);

    }

    if (!location.hash) {
        location.hash = "#home";
    }

    navigate();
    $(window).on('hashchange', function (e) {
        navigate();
    });

    $("#primary-login").on("click", function () {
        window.location.hash = '#login';

    });

    $(".main-search").on("click", function () {
        window.location.hash = '#search';
    });
}());