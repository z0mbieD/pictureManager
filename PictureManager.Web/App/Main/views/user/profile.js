(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.user.profile';
    app.controller(controllerId, [
        '$scope', '$rootScope', '$location', 'abp.services.picturemanager.picture',
        function ($scope, $rootScope, $location, pictureService) {
            var vm = this;

            vm.localize = abp.localization.getSource('PictureManager');
            vm.pictures = $rootScope.pictures;
            vm.userObject = $rootScope.userObject;

            $scope.goToPicture = function (pictureObject) {
                $rootScope.pictureObject = pictureObject;
                $location.path('/picture');
            }
        }    
    ]);
})();