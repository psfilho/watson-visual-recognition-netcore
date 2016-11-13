controllers.directive("classifierCreate", function () {
    return {
        templateUrl: "views/directives/classifierCreate.html",
        restrict: 'E',
        controller: function ($scope, $cookies, $rootScope, serviceService, classifierService, message, Upload) {
            $scope.openClassifierCreate = function () {
                $(".modal-classifier-create").modal("show");
                $scope.creatingClassifier = false;
                $scope.positiveExamples = [];
                $scope.negativeExamples = null;
                $scope.name = null;
            };

            $scope.positiveExamples = [];

            $scope.negativeExamples = null;

            $scope.addPositive = function ($files) {
                if ($files) {
                    for (var k in $files) {
                        var file = $files[k];
                        if (file) {
                            $scope.positiveExamples.push({
                                name: "",
                                file: file
                            });
                        }
                    }
                }
            }

            $scope.addNegative = function ($file) {
                if ($file) {
                    $scope.negativeExamples = $file;
                }
            }

            $scope.createClassifier = function () {
                if ($scope.positiveExamples.length > 0 || $scope.negativeExamples) {
                    $scope.creatingClassifier = true;
                    var data = {
                        apiKey: $scope.$root.currentService.apiKey,
                        name: $scope.name,
                        files: {

                        }
                    };
                    if ($scope.negativeExamples)
                        data.files['negative'] = $scope.negativeExamples;

                    $scope.positiveExamples.forEach(x => {
                        data.files[x.name] = x.file;
                    });

                    Upload.upload({
                        url: '/api/Classifier/Create',
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        },
                        data: data,
                    }).then(function (resp) {
                        $scope.creatingClassifier = false;
                        $(".modal-classifier-create").modal("hide");
                        $scope.$emit('loadClassifiers');
                        message.success("{{ClassifierDeletedSuccessfully}}");
                    }, function (resp) {
                        $scope.creatingClassifier = false;
                        message.error(resp);
                    }, function (evt) {
                        var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                        console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                    });

                }
            }

        }
    }
});