var utils = angular.module("utils", ['ngAnimate', 'ngCookies', 'toastr', "jm.i18next", 'ngSanitize']);

utils.config(function (toastrConfig) {
    angular.extend(toastrConfig, {
        autoDismiss: true,
        containerId: 'toast-container',
        maxOpened: 0,
        newestOnTop: true,
        positionClass: 'toast-top-right',
        preventDuplicates: false,
        preventOpenDuplicates: true,
        target: 'body'
    });
});

utils.config([
    '$i18nextProvider', function ($i18nextProvider) {
        $i18nextProvider.options = {
            lng: 'en',
            supportedLngs: ['en'],
            fallbackLng: 'en',
            useCookie: false,
            useLocalStorage: false,
            resGetPath: '/js/culture/__lng__.json',
            defaultLoadingValue: 'Loading'
        };
    }
]);

utils.service('t', function (http, $filter) {
    this.translate = function (input) {
        return $filter("i18next")(input);
    }
});

utils.filter('t', function ($filter) {
    return function (input) {
        return $filter("i18next")(input);
    };
});

function copy(o) {
    var output, v, key;
    output = Array.isArray(o) ? [] : {};
    for (key in o) {
        v = o[key];
        output[key] = (typeof v === "object") ? copy(v) : v;
    }
    return output;
}