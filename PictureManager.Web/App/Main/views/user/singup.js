(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.user.singup';
    app.controller(controllerId, [
        '$scope', '$location', 'abp.services.picturemanager.user',
        function ($scope, $location, userService) {
            var vm = this;

            vm.isAuth = false;

            vm.user = {
                login: '',
                password: '',
            };

            var localize = abp.localization.getSource('PictureManager');

            vm.saveUser = function () {
                abp.ui.setBusy(null, {
                    promise: userService.addUser(vm.user)
                        .success(function () {
                            vm.isAuth = true;
                            vm.userName = vm.user.login;
                            $location.path("/");
                        })
                });
            };

        }
    ]);
})();