app.controller("projectTechnologiesController", function ($scope, $http) {
    $scope.init = function (id) {
        $scope.projectId = id;
    }
    var response = $http({
        method: "get",
        url: "/Admin/GetTechnologies"
    }).success(function (data) {
            $scope.Technologies = data;
    }).error(function (status, data) { alert("Ajax Error " + status); });


    $scope.CreateProjectTechnologies = function () {
        $http({
            contentType: 'application/json; charset=utf-8',
            method: "Post",
            url: "/Admin/CreateProjectTechnologies",
            traditional: true,
            data: JSON.stringify({
                projectId: $scope.projectId,
                technologies : $scope.skills
            })
        }).success(function (data) {
            debugger;
            $("#backToProjects").click();
        }).error(function (status, data) { alert("Ajax Error " + data.status); });
    }

});


