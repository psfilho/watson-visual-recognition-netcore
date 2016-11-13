controllers.directive("faceDetection", function () {
    return {
        templateUrl: "views/directives/faceDetection.html",
        restrict: 'E',
        scope: {
        },
        controller: function ($scope, $cookies, $rootScope, serviceService, faceDetectionService, classifierService, message, Upload) {

            $scope.openFaceDetection = function () {
                $(".modal-face-detection").modal("show");
                $scope.faceDetectionResult = null;
                $scope.faceDetectionUrl.url = null;
                $scope.loadingFaceDetection = false;
            };
            $scope.faceDetectionUrl = {
                search: function () {
                    var self = this;
                    $scope.loadingFaceDetection = true;
                    faceDetectionService.faceDetectionUrl($scope.$root.currentService.apiKey, this.url)
                    .then(function (data) {
                        self.url = null;
                        $scope.faceDetectionResult = data;
                        $scope.loadingFaceDetection = false;
                    })
                    .catch(function (err) {
                        message.error(err);
                        $scope.loadingFaceDetection = false;
                    });
                }
            }

            $scope.faceDetectionFile = function () {
                if ($scope.file) {
                    $scope.loadingFaceDetection = true;
                    Upload.upload({
                        url: '/api/FaceDetection/File',
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        },
                        data: {
                            apiKey: $scope.$root.currentService.apiKey
                        },
                        file: $scope.file
                    }).then(function (resp) {
                        $scope.file = null;
                        $scope.faceDetectionResult = resp.data;
                        $scope.loadingFaceDetection = false;
                    }, function (resp) {
                        message.error(resp);
                        $scope.loadingFaceDetection = false;
                    }, function (evt) {
                        var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                        console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                    });
                }
            }

        }
    }
});