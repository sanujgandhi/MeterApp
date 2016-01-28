app.factory('clientsServices', function ($http) {

    var factory = {};
    factory.getUsers = function (id) {
        return $http.get("/Admin/GetUsers?id=" + id).error(function (status,data) { alert("Ajax Error " + status); });
    }

    factory.AddUser = function (user) {
        var response = $http({
            method: "post",
            url: "/Admin/AddUser",
            data: JSON.stringify(user),
            dataType: "json"
        }).error(function (status, data) { alert("Ajax Error " + status); });
        return response;
    }

    factory.UpdateUser = function(user) {
        return $http({
            method: "post",
            url: "/Admin/UpdateUser",
            data: JSON.stringify(user),
            dataType: "json"
        }).error(function (status, data) { alert("Ajax Error " + status); });
    }

    factory.DeleteUser = function (id) {
        return $http.post("/Admin/DeleteUser?id=" + id).error(function (status, data) { alert("Ajax Error " + status); });
    }

    factory.GetDeveloperSkills = function (id) {
        return $http.get("/Admin/GetDevelopersSkills?id=" + id).error(function (status, data) { alert("Ajax Error" + status); });
    }

    factory.GetDeveloperSkillsById = function (id) {
        return $http.get("/Admin/GetDeveloperSkillsById?id=" + id).error(function (status, data) { alert("Ajax Error" + status); });
    }

    factory.GetDeveloperSkillsById = function (id) {
        return $http.get("/Admin/GetDeveloperSkillsById?id=" + id).error(function (status, data) { alert("Ajax Error" + status); });
    }

    factory.GetClientMessages = function (id) {
        return $http.get("/Client/Messages?id=" + id).error(function (status, data) { alert("Ajax Error" + status); });
    }

    factory.GetDeveloperByProjectId = function (id) {
        return $http.get("/Client/GetDevelopersByProjectId?id=" + id).error(function (status, data) { alert("Ajax Error" + status); });
    }

    return factory;
});