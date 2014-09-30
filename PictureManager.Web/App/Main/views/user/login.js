(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.user.login';
    app.controller(controllerId, [
        '$scope', '$rootScope', '$http', '$location', 'abp.services.picturemanager.user',
        function ($scope, $rootScope, $http, $location, userService) {
            var vm = this;

            vm.user = {
                login: '',
                password: '',
            };

            vm.login = function () {
                abp.ui.setBusy(null, {
                    promise: userService.logon(vm.user)
                        .success(function (data) {
                            if (data != null) {
                                $rootScope.isAuth = true;
                                $rootScope.userName = vm.user.login;
                                $location.path("/");
                            } else {
                                $scope.message = 'Провалено! Попробуйте ещё разок =)';
                                $location.path("/login");
                            }
                        })
                });
            };
        }
    ]);
})();