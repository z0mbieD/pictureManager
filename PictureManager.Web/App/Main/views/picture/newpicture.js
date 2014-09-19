(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.picture.newpicture';
    app.controller(controllerId, [
        '$scope', '$location', 'abp.services.picturemanager.picture',
        function ($scope, $location, pictureService) {
            var vm = this;

            vm.picture = {
                pictureName: '',
                tag: '',
                description: '',
                pictureFile: '',
            };

            var localize = abp.localization.getSource('PictureManager');

            $scope.fileSelect = function(files) {
                var file = new FormData();
              //  formData.append("model", angular.toJson(data.model));
                file.append("file", files[0]);
                //  var file = files[0];
                vm.picture.pictureFile = file;

              //  var str = JSON.stringify(event);
                console.log(file);
                
            };

            
         //   debugger;
            vm.savePicture = function () {
                abp.ui.setBusy(null, {
                    promise: pictureService.addPicture(vm.picture)
                        .success(function () {
                            $location.path('/');
                        })
                });
            };

        }
    ]);
})();