app.controller('adminController', function ($scope, clientsServices) {
    $scope.usersList = true;
    $scope.userDiv = false;
    // This function get the id from the 
    $scope.init = function (id) {
        var getData = clientsServices.getUsers(id);
        getData.then(function (user) {
            $scope.users = user.data;
        }, function () { alert("Error in getting records") });
    }

    $scope.AddUpdateUser = function (id) {
        if ($scope.userForm.$valid) {
            var getAction = $scope.Action;
            var user =
            {
                FirstName: $scope.FirstName,
                LastName: $scope.LastName,
                Email: $scope.Email,
                Password: $scope.Password,
                PhoneNumber: $scope.PhoneNumber,
                UserName: $scope.UserName,
                Address: $scope.Address,
                SkillList: $scope.skills
            }
            var getData;
            if (getAction === "Update") {
                user.UserId = $scope.UserId;
                user.Role = id;
                getData = clientsServices.UpdateUser(user);
                getData.then(function (msg) {
                    $scope.init(id);
                    alert(msg.data);
                    $scope.userDiv = false;
                    $scope.usersList = true;
                }, function () { alert("Controller Error in Updating records") });
            } else {
                user.Role = id;
                getData = clientsServices.AddUser(user);
                getData.then(function (msg) {
                    $scope.init(id);
                    alert(msg.data);
                    $scope.userDiv = false;
                    $scope.usersList = true;
                }, function () { alert("Controller Error in Adding records") });
            }
        } else {
            alert("Form is invalid");
        }

    }

    $scope.DeleteUser = function (user, index) {
        var getData = clientsServices.DeleteUser(user.Id);
        if (getData != null) {
            $scope.users.splice(index, 1);
        }


    }

    $scope.AddUserBtn = function () {
        $scope.Action = "Add";
        $scope.userDiv = true;
        $scope.usersList = false;
        var getData = clientsServices.GetDeveloperSkills(1);
        getData.then(function (users) {
            $scope.Developerskills = users.data;

        }, function () { alert("Error in getting records") });     
    }

    $scope.EditClient = function (client) {
        $scope.Action = "Update";
        $scope.userDiv = true;
        $scope.usersList = false;
        $scope.isDisabled = true;
        $scope.UserName = client.UserName;
        $scope.FirstName = client.FirstName;
        $scope.LastName = client.LastName;
        $scope.Email = client.Email;
        $scope.Address = client.Address;
        $scope.PhoneNumber = client.PhoneNumber;
        $scope.Password = client.PasswordHash;
        var getData = clientsServices.GetDeveloperSkills(1);
        getData.then(function (users) {
            $scope.Developerskills = users.data;

        }, function () { alert("Error in getting records") });

        var data = clientsServices.GetDeveloperSkillsById(client.Id)
        data.then(function (users) {
            $scope.skills = users.data;

        }, function () { alert("Error in getting records") });
    }


    $scope.submitUserForm = function () {
        if ($scope.userForm.$valid) {
            alert('our form is amazing');
        } else {
            alert("form is invalid");
        }
    }

    $scope.ShowUserList = function () {
        $scope.userDiv = false;
        $scope.usersList = true;
    }

    $scope.ShowInTextArea = function (value) {
        $scope.developerSkillsTextArea += " ," + value;
        $scope.developerSkills.delete(value);
    }

    $scope.Logout = function () {
        alert("Done");
    }
    $scope.LogoutName = "Logout";

});
