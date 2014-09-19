(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.user.singup';
    app.controller(controllerId, [
        '$scope', 'abp.services.picturemanager.user',
        function ($scope, userService) {
            var vm = this;

            vm.user = {
                login: '',
                password: '',
            };

            var localize = abp.localization.getSource('PictureManager');

            vm.saveUser = function () {
                abp.ui.setBusy(null, {
                    promise: userService.addUser(vm.user)
                        .success(function () {

                        })
                });
            };

        }
    ]);
})();