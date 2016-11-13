var app = angular.module("app", ["ui.router", 'ngSanitize', "anim-in-out", "controllers", 'ngFileUpload', 'ui.bootstrap', 'ngclipboard']);

app.run(function ($rootScope, $cookies, $state) {
    $rootScope.$on('$stateChangeStart', function (ev, to, toParams, from, fromParams) {
        $rootScope.title = to.title;
    });
});

