controllers.controller("appController", function ($scope, $stateParams, $state, $cookies, message,serviceService, classifierService, $rootScope) {

    $scope.$watch('currentService', function (newVal, oldVal) {
        if (newVal) {
            $scope.$emit('loadClassifiers', newVal.apiKey);
        }
        $rootScope.currentService = newVal;
    });
    $scope.$on('loadServices', function (e) {
        $scope.services = serviceService.listServices();
    });
    $scope.$on('loadClassifiers', function (e, apiKey) {
        $scope.loadingClassifiers = true;
        apiKey = apiKey ? apiKey : $rootScope.currentService.apiKey;
        classifierService.list(apiKey)
            .then(function (data) {
                $scope.classifiers = data.classifiers;
                $scope.loadingClassifiers = false;
            })
            .catch(function (err) {
                $scope.loadingClassifiers = false;
                message.error(err);
            });
    });
    $scope.$emit('loadServices');
});