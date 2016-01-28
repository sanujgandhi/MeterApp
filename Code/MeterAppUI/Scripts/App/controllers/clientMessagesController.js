 app.controller('clientMessagesController', ['$scope', 'clientsServices', function ($scope, clientsServices) {
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
            $scope.SelectedDeveloper(users.data[0]);
        }, function () { alert("Error in getting records") });

    }

    $scope.SelectedDeveloper = function (developer) {
        $scope.developerList = true;
        $scope.moduleslist = true;
        $scope.media = developer;
    }

    //$scope.submit = function () {
    //    alert(JSON.stringify($scope.myfiles.files));
    //}

    $scope.submit = function (data) {
        var a = $("#fileupload").file;
        alert(JSON.stringify(a));
        if ($scope.IsFormValid && $scope.IsFileValid) {
            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription).then(function (d) {
                alert(d.Message);
                ClearForm();
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };

    //$scope.selectFileforUpload = function (file) {
    //    var a=$("#fileupload")[0].file;
    //    alert(JSON.stringify(a));
    //    $scope.SelectedFileForUpload = file[0];
    //    alert(JSON.stringify($scope.SelectedFileForUpload));
    //}

    //$scope.uploadPic = function (file) {
    //    alert(JSON.stringify(file));
    //    $scope.formUpload = true;
    //    if (file != null) {
    //        $scope.upload(file)
    //    }
    //};
    
    $scope.uploadFile = function () {
        var file = $scope.myFile;
        alert(file);
        console.log('file is ');
        console.dir(file);

        var uploadUrl = "/fileUpload";
        fileUpload.uploadFileToUrl(file, uploadUrl);
    };
    }]);