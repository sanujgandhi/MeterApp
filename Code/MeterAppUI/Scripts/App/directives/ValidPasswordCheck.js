app.directive("validPasswordC", function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            //ctrl.$parsers.unshift(function(viewValue, $scope) {
            //    var noMatch = viewValue !== scope.userForm.Password.$viewValue;
            //    ctrl.$setValidity('noMatch', !noMatch);
            //});

            
            var me = attrs.ngModel;
            var matchTo = attrs.validPasswordC;
            scope.$watch('[me, matchTo]', function(value) {
                ctrl.$setValidity('noMatch', scope[me] === scope[matchTo]);
            });
        }
        }
});