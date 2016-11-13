controllers.directive("serviceManagement", function () {
    return {
        templateUrl: "views/directives/serviceManagement.html",
        restrict: 'E',
        controller: function ($scope, $cookies, serviceService) {
            $scope.open = function () {
                $(".modal-service-management").modal("show");
            };
            $scope.close = function () {
                $(".modal-service-management").modal("hide");
            }
            $scope.addService = function () {
                if ($scope.addFormService.$valid) {
                    serviceService.addService($scope.newService);
                    $scope.newService = null;
                    $scope.$emit('loadServices');
                }
            }
            $scope.deleteService = function (service) {
                serviceService.deleteService(service);
                $scope.services = serviceService.listServices();
            }
        }
    }
});