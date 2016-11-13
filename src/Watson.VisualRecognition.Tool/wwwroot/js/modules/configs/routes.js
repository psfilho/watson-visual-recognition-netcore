routes = [
    { state: "layout", content: "/views/layout.html" },
    {
        state: "app",
        title: "Home",
        layout: "layout",
        url: "/",
        content: "/views/app.html"
    }
];

app.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    if (window.history && window.history.pushState) {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    }
    $urlRouterProvider.otherwise("/");
    for (var i = 0; i < routes.length; i++) {
        var route = routes[i];
        if (route.url) {
            var routeObject = {
                templateUrl: route.content,
                parent: route.layout || "layout",
                url: route.url,
                cache: false,
                roles: route.roles,
                title: route.title,
                permissions: route.permissions,
                resolve: {
                    i18next: function ($i18next) {
                        return $i18next;
                    }
                }
            };
            $stateProvider.state(route.state, routeObject);
        } else {
            var layoutObject = {
                templateUrl: route.content,
                parent: route.layout,
                resolve: {
                    i18next: function ($i18next) {
                        return $i18next;
                    }
                }
            };

            $stateProvider.state(route.state, layoutObject);
        }
    }

});