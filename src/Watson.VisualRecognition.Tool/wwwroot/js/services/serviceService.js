services.service('serviceService', function ($cookies) {
    this.listServices = function () {
        var services = $cookies.getObject("services");
        return services ? services : [];
    };
    this.addService = function (service) {
        var services = this.listServices();
        services.push(service);
        $cookies.putObject("services", services);
    };
    this.deleteService = function (service) {
        var services = this.listServices();
        var serviceToDelete = services.findIndex(x => x.apiKey == service.apiKey);
        services.splice(serviceToDelete, 1);
        $cookies.putObject("services", services);
    };
});