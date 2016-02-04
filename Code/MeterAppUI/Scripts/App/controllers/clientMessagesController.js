 app.controller('clientMessagesController', ['$scope', 'clientsServices', function ($scope, clientsServices) {
    $scope.init = function (projets) {
        $scope.projectList = true;
        $scope.developerList = false;
        $scope.moduleslist = false;
        $scope.projectList = projets;
        $scope.step = "/FileUploads/0a6a5ac9-4322-4690-8ca0-3cde158e39e9_1231dcfe-3bb5-4a04-b345-c06d6d5c23d2_2016-02-01_17-16-24-PM_images.jpg";
        $scope.taskToDeveloper(projets[0]);
    }

    $scope.taskToDeveloper = function (project)
    {
        $scope.developerList = true;
        $scope.moduleslist = false;
        $scope.seletedProjectss = project;
        var data = clientsServices.GetDeveloperByProjectId(project.ProjectId);
        data.then(function (users) {
            $scope.DevelopersList = users.data;
            $scope.SelectedDeveloper(users.data[0]);
        }, function () { alert("Error in getting records") });

    }

    $scope.SelectedDeveloper = function (developer) {
        $scope.developerList = true;
        $scope.moduleslist = true;
        $scope.media = developer;
        $scope.muduleSelected = $scope.media.Module[0];
        $scope.ShowMessages();
    }

    //$scope.submit = function () {
    //    alert(JSON.stringify($scope.myfiles.files));
    //}


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
     $scope.ShowMessages=function()
     {
         var projectId = $scope.muduleSelected.ProjectId;
         var developerId = $scope.media.UserId;
         var clientId = $scope.seletedProjectss.ClientId;
         var message = {
             SenderId: clientId,
             ReceiverID: developerId,
             ProjectId: projectId
         };
         var data = clientsServices.ShowMessages(message);
         data.then(function (response) {
             $scope.messageList = response.data.messages;
             $scope.fileName=response.data.filename;
             alert(JSON.stringify($scope.messageList));
         }, function () { alert("Error in getting records") });
     }

     $scope.uploadFile = function () {
        var file = $scope.fileupload;
        var moduleId = $scope.muduleSelected.ModuleId;
        var projectId = $scope.muduleSelected.ProjectId;
        var developerId = $scope.media.UserId;
        var clientId = $scope.seletedProjectss.ClientId;
        var description = $scope.textArea;
        var message = {
            ClientId: clientId,
            DeveloperId: developerId,
            ModuleId: moduleId,
            Description: description,
            ProjectId:projectId
        };
        var uploadUrl = "/Client/fileupload";
        clientsServices.uploadFileToUrl(file, uploadUrl,message);
    };

    $scope.downloadFile = function (filepath) {
        alert(filepath);
        //  alert(JSON.stringify(developer.Module));
        clientsServices.DownloadFile(filepath);
    }
    }]);