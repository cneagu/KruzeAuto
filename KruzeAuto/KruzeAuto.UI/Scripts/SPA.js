(function () {

    // Stores the cached partial HTML pages.
    // Keys correspond to fragment identifiers.
    // Values are the text content of each loaded partial HTML file.
    var partialsCache = {}

    // Gets the appropriate content for the given fragment identifier.
    // This function implements a simple cache.
    function getContent(fragmentId, callback) {

        // If the page has been fetched before,
        if (partialsCache[fragmentId]) {

            // pass the previously fetched content to the callback.
            callback(partialsCache[fragmentId]);

        } else {
            // If the page has not been fetched before, fetch it.
            $.get(fragmentId + ".html", function (content) {

                // Store the fetched content in the cache.
                partialsCache[fragmentId] = content;

                // Pass the newly fetched content to the callback.
                callback(content);
            });
        }
    }

    // Sets the "active" class on the active navigation link.
    function setActiveLink(fragmentId) {
        $(".page-content").each(function (i, divElement) {
            var divElement = $(this).attr('id');
            console.log(divElement);                
            if (divElement != fragmentId) 
                $(this).attr("hidden", "true");
        });
    }

    // Updates dynamic content based on the fragment identifier.
    function navigate() {

        // Isolate the fragment identifier using substr.
        // This gets rid of the "#" character.
        var fragmentId = location.hash.substr(1);
        

        // Toggle the "active" class on the link currently navigated to.
        setActiveLink(fragmentId);
    }

    // If no fragment identifier is provided,
    if (!location.hash) {

        // default to #home.
        location.hash = "#home";
    }

    // Navigate once to the initial fragment identifier.
    navigate();

    // Navigate whenever the fragment identifier value changes.
    $(window).bind('hashchange', navigate);
}());