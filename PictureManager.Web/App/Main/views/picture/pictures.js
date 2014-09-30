(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.picture.pictures';
    app.controller(controllerId, [
        '$scope', '$rootScope', '$location', 'abp.services.picturemanager.picture',
        function ($scope, $rootScope, $location, pictureService) {
            var vm = this;

            vm.localize = abp.localization.getSource('PictureManager');
            vm.pictures = [];

            pictureService.getPictures({}).success(function (data) {
                vm.pictures = data.pictures;
                $rootScope.pictures = vm.pictures;
            });

            $scope.goToPicture = function (pictureObject) {
                $rootScope.pictureObject = pictureObject;
                $location.path('/picture');
            }
        }    
    ]);
})();
