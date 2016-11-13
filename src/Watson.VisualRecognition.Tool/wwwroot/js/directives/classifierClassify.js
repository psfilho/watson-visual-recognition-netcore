controllers.directive("classifierClassify", function () {
    return {
        templateUrl: "views/directives/classifierClassify.html",
        restrict: 'E',
        scope: {
            classifiers: "=classifiers"
        },
        controller: function ($scope, $cookies, $rootScope, serviceService, classifierService, message, Upload) {

            $scope.openClassifierClassify = function () {
                $(".modal-classifier-classify-all").modal("show");
                $scope.classifyResult = null;
                $scope.classifyUrl.url = null;
                $scope.loadingClassification = false;
                $scope.selectedClassifiers = [];
                $scope.classifierOptions = copy($scope.classifiers);
                $scope.classifierOptions.unshift({
                    name: 'IBM Default',
                    classifier_id: "default",
                    use: true
                });
            };

            $scope.classifyUrl = {
                search: function () {
                    var selectedClassifiers = $scope.classifierOptions.filter(x => x.use).map(x => x.classifier_id);
                    var self = this;
                    $scope.loadingClassification = true;
                    classifierService.classifyUrl($scope.$root.currentService.apiKey, this.url, selectedClassifiers, null, $scope.threshold)
                    .then(function (data) {
                        self.url = null;
                        $scope.classifyResult = data;
                        $scope.loadingClassification = false;
                    })
                    .catch(function (err) {
                        $scope.loadingClassification = false;
                        message.error(err);
                    });
                }
            }

            $scope.classifyFile = function () {
                if ($scope.file) {
                    var selectedClassifiers = $scope.classifierOptions.filter(x => x.use).map(x => x.classifier_id);
                    $scope.loadingClassification = true;
                    Upload.upload({
                        url: '/api/Classifier/ClassifyFile',
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        },
                        data: {
                            apiKey: $scope.$root.currentService.apiKey,
                            classifiers: selectedClassifiers,
                            threshold: $scope.treshold
                        },
                        file: $scope.file
                    }).then(function (resp) {
                        $scope.file = null;
                        $scope.classifyResult = resp.data;
                        $scope.loadingClassification = false;
                    }, function (resp) {
                        message.error(resp);
                        $scope.loadingClassification = false;
                    }, function (evt) {
                        var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                        console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                    });
                }
            }
        }
    }
});
