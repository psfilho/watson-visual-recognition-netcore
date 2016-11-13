services.service('classifierService', function ($cookies, http) {
    this.list = function (apiKey) {
        return http.get("CLASSIFIER_LIST", "?apiKey=" + apiKey)
            .then(function (response) {
                return response.data;
            })
            .catch(function (response) {
                return Promise.reject(response.data);
            });
    };

    this.delete = function (apiKey, classifierId) {
        return http.delete("CLASSIFIER_DELETE", "?apiKey=" + apiKey + "&classifierId=" + classifierId)
            .then(function (response) {
                return response.data;
            })
            .catch(function (response) {
                return Promise.reject(response.data);
            });
    };

    this.classifyUrl = function (apiKey, url, classifiers, owners, threshold) {
        return http.post("CLASSIFY_URL",
            {
                apiKey: apiKey,
                url: url,
                classifiers: classifiers,
                owners: owners,
                threshold: threshold
            })
            .then(function (response) {
                return response.data;
            })
            .catch(function (response) {
                return Promise.reject(response.data);
            });
    }
});