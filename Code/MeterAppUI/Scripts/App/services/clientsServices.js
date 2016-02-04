app.factory('clientsServices', function ($http) {

    var factory = {};
    factory.getUsers = function (id) {
        return $http.get("/Admin/GetUsers?id=" + id).error(function (status, data) { alert("Ajax Error " + status); });
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

    factory.UpdateUser = function (user) {
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
    factory.UploadFile = function (user) {
        $.ajax({
            type: "POST",
            url: "/Client/fileupload",
            cache: false,
            dataType: 'json',
            processData: false, // Don't process the files
            contentType: false,
            data: user
        });
    }


    factory.uploadFileToUrl = function (file, uploadUrl, user) {
        var fd = new FormData();
        fd.append('data',file);
        fd.append('Clientid', user.ClientId);
        fd.append('DeveloperId', user.DeveloperId);
        fd.append('ModuleId', user.ModuleId);
        fd.append('description', user.Description);
        fd.append('projectId', user.ProjectId);
        $http.post(uploadUrl, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
            
        .success(function (data) {
            alert(json.stringify(data));
        })
            
        .error(function(){
        });
    }

    //factory.uploadFileToUrl = function (file, uploadUrl) {
    //    var formData = new FormData(file);
    //    alert(file.name);
    //    $.ajax({
    //        type: 'POST',
    //        url: "/Client/fileupload",
    //        data: formData,
    //        cache: false,
    //        contentType: false,
    //        processData: false,
    //        success: function (view) {
    //        },
    //        complete: function () {
    //        }
    //    });
    //}
    factory.DownloadFile = function (id) {
        $.ajax({
            type: "POST",
            url: "/Client/DownloadFile",
            data: { fileName: id },
            dataType: 'json',
            success: function (data) {
            }
        });
    }

    //factory.ShowMessages = function (id) {
    //   return $.ajax({
    //        type: "POST",
    //        url: "/Client/GetMessagesBYSenderIdReceiverIdAndProjectId",
    //        data: { senderId: id.SenderId, receiverId: id.ReceiverID, pojectId: id.ProjectId },
    //        dataType: 'json',
    //        success: function (data) {
    //            alert(JSON.stringify(data));
    //            return data;
    //        }
    //    });
    //}


    factory.ShowMessages = function (id) {
        return $http({
            method: "post",
            url: "/Client/GetMessagesBYSenderIdReceiverIdAndProjectId",
            data: { senderId: id.SenderId, receiverId: id.ReceiverID, pojectId: id.ProjectId },
            dataType: "json"
        }).error(function (status, data) { alert("Ajax Error " + status); });
    }
        return factory;

});