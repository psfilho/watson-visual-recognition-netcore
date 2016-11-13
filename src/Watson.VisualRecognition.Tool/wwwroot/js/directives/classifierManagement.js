controllers.directive("classifierManagement", function () {
    return {
        templateUrl: "views/directives/classifierManagement.html",
        restrict: 'E',
        scope: {
            classifier: "=classifier"
        },
        controller: function ($scope, $cookies, $rootScope, serviceService, classifierService, message, Upload) {
            $scope.openClassifierDelete = function () {
                $(".modal-classifier-delete" + $scope.classifier.classifier_id).modal("show");
                $scope.deletingClassifier = false;
            };

            $scope.deleteClassifier = function () {
                $scope.deletingClassifier = true;
                classifierService.delete($scope.$root.currentService.apiKey, $scope.classifier.classifier_id)
                    .then(function (data) {
                        $(".modal-classifier-delete" + $scope.classifier.classifier_id).modal("hide");
                        $scope.$emit('loadClassifiers');
                        message.success("{{ClassifierDeletedSuccessfully}}");
                    })
                    .catch(function (err) {
                        $scope.deletingClassifier = false;
                        message.error(err);
                    });
            }

            $scope.openClassifierUpdate = function () {
                $(".modal-classifier-update" + $scope.classifier.classifier_id).modal("show");
                $scope.updatingClassifier = false;
                $scope.positiveUpdates = [];
                $scope.negativeExample = null;
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

            $scope.updateClassifier = function () {
                if ($scope.positiveExamples.length > 0 || $scope.negativeExamples) {
                    $scope.updatingClassifier = true;
                    var data = {
                        apiKey: $scope.$root.currentService.apiKey,
                        classifierId: $scope.classifier.classifier_id,
                        files: {

                        }
                    };
                    if ($scope.negativeExamples)
                        data.files['negative'] = $scope.negativeExamples;
                    $scope.positiveExamples.forEach(x => {
                        data.files[x.name] = x.file;
                    });
                    Upload.upload({
                        url: '/api/Classifier/Update',
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        },
                        data: data,
                    }).then(function (resp) {
                        $(".modal-classifier-update" + $scope.classifier.classifier_id).modal("hide");
                        $scope.updatingClassifier = false;
                        $scope.$emit('loadClassifiers');
                        message.success("{{ClassifierUpdatedSuccessfully}}");
                    }, function (resp) {
                        message.error(resp);
                        $scope.updatingClassifier = false;
                    }, function (evt) {
                        var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                        console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                    });

                }
            }

            $scope.openClassifierClassify = function () {
                $(".modal-classifier-classify" + $scope.classifier.classifier_id).modal("show");
                $scope.classifyResult = null;
                $scope.classifyUrl.url = null;
                $scope.loadingClassification = false;
            };

            $scope.classifyUrl = {
                search: function () {
                    var self = this;
                    $scope.loadingClassification = true;
                    classifierService.classifyUrl($scope.$root.currentService.apiKey, this.url, [$scope.classifier.classifier_id], null, $scope.threshold)
                    .then(function (data) {
                        self.url = null;
                        $scope.classifyResult = data;
                        $scope.loadingClassification = false;
                    })
                    .catch(function (err) {
                        message.error(err);
                        $scope.loadingClassification = false;
                    });
                }
            }

            $scope.classifyFile = function () {
                if ($scope.file) {
                    $scope.loadingClassification = true;
                    Upload.upload({
                        url: '/api/Classifier/ClassifyFile',
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        },
                        data: {
                            apiKey: $scope.$root.currentService.apiKey,
                            classifiers: [$scope.classifier.classifier_id],
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