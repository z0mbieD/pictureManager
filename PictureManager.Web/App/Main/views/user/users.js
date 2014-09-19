(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.picture.picture';
    app.controller(controllerId, [
        '$scope', 'abp.services.picturemanager.picture',
        function ($scope, pictureService) {
            var vm = this;

            vm.localize = abp.localization.getSource('PictureManager');
            vm.pictures = [];     

            pictureService.getPictures().success(function (data) {
                vm.pictures = data.pictures;
            });
        }    
    ]);
})();