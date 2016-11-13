services.service('faceDetectionService', function ($cookies, http) {
    this.faceDetectionUrl = function (apiKey, url) {
        return http.post("FACE_DETECTION_URL",
            {
                apiKey: apiKey,
                url: url
            })
            .then(function (response) {
                return response.data;
            })
            .catch(function (response) {
                return Promise.reject(response.data);
            });
    }
});