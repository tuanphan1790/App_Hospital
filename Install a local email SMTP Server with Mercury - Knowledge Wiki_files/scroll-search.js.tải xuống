(function($) {
    'use strict';

    window.SCROLL_WEBHELP = window.SCROLL_WEBHELP || {};
    window.SCROLL_WEBHELP.search = window.SCROLL_WEBHELP.search || {};


    window.SCROLL_WEBHELP.search.performSearch = function(query, onResultsAvailableCallback) {
        var action = $('#search').attr('action');
        var url = "q=" + query;

        var version = $('#search #version');
        if (typeof version != 'undefined' && version.length > 0) {
            url = url + "&" + version.attr('name') + "=" + version.attr('value');
        }

        var variant = $('#search #variant');
        if (typeof variant != 'undefined' && variant.length > 0) {
            url = url + "&" + variant.attr('name') + "=" + variant.attr('value');
        }

        var language = $('#search #language');
        if (typeof language != 'undefined' && language.length > 0) {
            url = url + "&" + language.attr('name') + "=" + language.attr('value');
        }

        $('.ht-search-dropdown.ht-dropdown').append('<div style="display:none;" id="temp-search-results-container"></div>');

        var tempContainer = $('#temp-search-results-container');
        tempContainer.load(action + " #quick-search-results>ul", url + "&quicksearch=true", function () {
            var results = [];

            $.each(tempContainer.find('li a'), function(index, val) {
                var item = $(this);
                results.push({
                    title: item.text(),
                    link: item.attr('href')
                });
            });

            tempContainer.remove();

            onResultsAvailableCallback(results, query);
        });
    };


    window.SCROLL_WEBHELP.search.navigateToSearchPage = function(query) {
        var url = $('form#search').attr('action') + "?q=" + query;

        var version = $('#search #version');
        if (typeof version != 'undefined' && version.length > 0) {
            url = url + "&" + version.attr('name') + "=" + version.attr('value');
        }

        var variant = $('#search #variant');
        if (typeof variant != 'undefined' && variant.length > 0) {
            url = url + "&" + variant.attr('name') + "=" + variant.attr('value');
        }

        var language = $('#search #language');
        if (typeof language != 'undefined' && language.length > 0) {
            url = url + "&" + language.attr('name') + "=" + language.attr('value');
        }

        window.location.href = url;
    };

})($);
