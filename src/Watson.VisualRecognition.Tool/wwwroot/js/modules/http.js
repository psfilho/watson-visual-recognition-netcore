
var httpModule = angular.module('http', ['utils', 'angular-loading-bar']);

httpModule.constant("api", {
    "CLASSIFIER_LIST": "/api/Classifier/List",
    "CLASSIFIER_DELETE": "/api/Classifier/Delete",
    "CLASSIFY_URL": "/api/Classifier/ClassifyUrl",
    "FACE_DETECTION_URL": "/api/FaceDetection/Url",
});

httpModule.factory('http', function (api, $http) {
    return {
        prepareConfig: function (config) {
            if (!config)
                config = {};
            config.headers = config.headers ? config.headers : {};
            config.auth = true;
            if (config.headers)
                config.headers["Content-Type"] = "application/json";
            return config;
        },
        delete: function (key, params, config) {
            config = this.prepareConfig(config);
            return $http.delete(api[key] + params, config)
                .catch(function (response) {
                    if (response.status == -1) {
                        response.data = '{{NoConnectionMessage}}';
                    }
                    return Promise.reject(response);
                });
        },
        get: function (key, params, config) {
            if (params == undefined)
                params = "";
            config = this.prepareConfig(config);
            return $http.get(api[key] + params, config)
                .catch(function (response) {
                    if (response.status == -1) {
                        response.data = '{{NoConnectionMessage}}';
                    }
                    return Promise.reject(response);
                });
        },
        post: function (key, data, config) {
            config = this.prepareConfig(config);
            return $http.post(api[key], data, config)
                .catch(function (response) {
                    if (response.status == -1) {
                        response.data = '{{NoConnectionMessage}}';
                    }
                    return Promise.reject(response);
                });
        },
        put: function (key, data, config) {
            config = this.prepareConfig(config);
            return $http.post(api[key], data, config)
                .catch(function (response) {
                    if (response.status == -1) {
                        response.data = '{{NoConnectionMessage}}';
                    }
                    return Promise.reject(response);
                });
        }
    }
});


