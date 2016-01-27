app.controller("projectTechnologiesController", function ($scope, $http) {
    var response = $http({
        method: "get",
        url: "/Admin/GetTechnologies",
    }).success(function (data) {
        alert(data);
        alert(JSON.stringify(data));
        //$(data).each(function(key, value) {
            $scope.Technologies = data;
        //});
    }).error(function (status, data) { alert("Ajax Error " + status); });
});


