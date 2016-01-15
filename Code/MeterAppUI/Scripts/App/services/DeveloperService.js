app.factory('DeveloperService', function ($http) {

    var factory = {};

    factory.GetDeveloperSkills = function (id) {
        return $http.get("/Admin/GetDevelopersSkills?id=" + id).error(function (status, data) { alert("Ajax Error" + status); });
    }

    return factory;
});