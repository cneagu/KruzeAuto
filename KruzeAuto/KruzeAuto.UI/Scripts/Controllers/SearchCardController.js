﻿var SearchCardController = function (containerId, announcement) {

    this.RenderCard = function () {
        var jqCard = "<div class='card text-white col-sm-6 col-md-4 col-lg-4'>"
            + "<img class='card-img' src='" + announcement.AnnouncementsPicturesPrimary + "' alt='Card image'>"
            + "<div id='" + announcement.AnnoucementID + "'class='card-img-overlay text-border'>"
            + "<h4 class='card-title'>" + announcement.Title + "</h4></div>"
            + "<div class='card-body text-dark'>"
            + "<div class='row justify-content-between'>"
            + "<h3 class='card-title' >" + announcement.Price + "  EUR</h2>"
            + "<button type='button' class='btn btn-outline-danger' value=+'"+ announcement.AnnoucementID +"'><i class='fa fa-envelope-o'></i></button></div>"
            + "<div class='row justify-content-between'>"
            + "<p class='card-text'>" + announcement.FabricationYear + '  •  ' + + announcement.Kilometer + "  Km</p>"
            + "<p class='card-text'>" + announcement.Power + "  HP</p></div >"
            + "<div class='row justify-content-between'>"
            + "<p class='card-text'><i class='fa fa-map-marker'></i>  " + announcement.County + "</p>"
            + "<p class='card-text'><i class='fa fa-user-o'></i>  " + announcement.UserName + "</p>"
            + "</div ></div> </div>";
         
        $("#" + containerId).append(jqCard);      
    }
}