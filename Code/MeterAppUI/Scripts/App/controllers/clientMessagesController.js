app.controller('clientMessagesController', function ($scope, clientsServices) {
    $scope.init = function (projets) {
        $scope.projectList = true;
        $scope.developerList = false;
        $scope.moduleslist = false;
        $scope.projectList = projets;
        $scope.taskToDeveloper(projets[0]);
    }

    $scope.taskToDeveloper = function (projectName)
    {
        $scope.developerList = true;
        $scope.moduleslist = false;
        var data = clientsServices.GetDeveloperByProjectId(projectName.ProjectId);
        data.then(function (users) {
            $scope.DevelopersList = users.data;
            $scope.SelectedDeveloper
        }, function () { alert("Error in getting records") });
    }

    $scope.SelectedDeveloper = function (developer) {
        $scope.developerList = true;
        $scope.moduleslist = true;
        $scope.media = developer;
    }
    
})
