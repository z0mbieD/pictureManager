(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.user.users';
    app.controller(controllerId, [
        '$scope', '$rootScope', '$location', 'abp.services.picturemanager.user',
        function ($scope, $rootScope, $location, userService) {
            var vm = this;

            vm.localize = abp.localization.getSource('PictureManager');
            vm.users = [];     

            userService.getUsers().success(function (data) {
                vm.users = data.users;
            });

            $scope.goToProfile = function (userObject) {
                $rootScope.userObject = userObject;
                $location.path('/profile');
            }
        }    
    ]);
})();