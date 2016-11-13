app.config(["$httpProvider", function ($httpProvider) {
    $httpProvider.defaults.transformResponse.push(function (responseData) {
        convertDateStringsToDates(responseData);
        return responseData;
    });
}]);
var regexIso8601 = /^(\d{4})-0?(\d+)-0?(\d+)[T ]0?(\d+):0?(\d+):0?(\d+)$/;
function convertDateStringsToDates(input) {
    // Ignore things that aren't objects.
    if (typeof input !== "object") return input;

    for (var key in input) {
        if (!input.hasOwnProperty(key)) continue;
        var value = input[key];
        var match;
        // Check for string properties which look like dates.
        if (typeof value === "string" && (match = value.match(regexIso8601))) {
            var milliseconds = Date.parse(match[0]);
            if (!isNaN(milliseconds)) {
                input[key] = new Date(milliseconds);
            }
        } else if (typeof value === "object") {
            // Recurse into object
            convertDateStringsToDates(value);
        }
    }
}


app.config(function ($httpProvider) {
    $httpProvider.interceptors.push(function ($q, $cookies, $rootScope, $injector) {
        return {
            'request': function (config) {
                if (!config.disableLock)
                    $rootScope.lock = true;
                return config;
            },
            'response': function (response) {
                $rootScope.lock = false;
                return response;
            },

            // optional method
            'responseError': function (rejection) {
                $rootScope.lock = false;
                if (rejection.status === 401) {
                    $injector.get('$state').go('home');
                }
                return Promise.reject(rejection);
            }
        };
    });
});