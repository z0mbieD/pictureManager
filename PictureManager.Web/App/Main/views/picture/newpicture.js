(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.picture.newpicture';
    app.controller(controllerId, [
        '$scope', '$http', '$location', '$rootScope', 'abp.services.picturemanager.picture', 'abp.services.picturemanager.user',
        function ($scope, $http, $location, $rootScope, pictureService, userService) {
            var vm = this;

            $scope.picture = {
                pictureName: '',
                tags: '',
                description: '',
                pictureFile: '',
                pictureMimeType: '',
                userId: null,
                pictureData: ''
            };

            var localize = abp.localization.getSource('PictureManager');

            document.getElementById('file-input').onchange = function (e) {
                loadImage(
                    e.target.files[0],
                    function (img) {
                        document.getElementById("ItemPreview").appendChild(img);
                        var imgData = getBase64Image(img);
                        $scope.picture.pictureData = imgData;
                        $scope.picture.pictureMimeType = img._type;
                    },
                    { maxWidth: 400 }
                );
            }; 

            function getBase64Image(imgElem) {
                var canvas = document.createElement('CANVAS');
                var ctx = canvas.getContext('2d');
                var img = new Image;
                img = imgElem;
                
                var outputFormat = imgElem._type;
                    canvas.height = img.height;
                    canvas.width = img.width;
                    ctx.drawImage(img, 0, 0);
                    var dataURL = canvas.toDataURL(outputFormat || 'image/png');
                    return dataURL.replace(/^data:image\/(png|jpg|jpeg);base64,/, "");
                    canvas = null;
            }
            
            $scope.savePicture = function () {
                if ($rootScope.userName != '') {
                    $scope.user = {
                        login: $rootScope.userName
                    };

                    userService.getUserByName($scope.user)
                        .success(function (data) {
                            if (data > 0) {
                                $scope.picture.userId = data;
                                pictureService.addPicture($scope.picture)
                                    .success(function () {
                                        $location.path('/');
                                    });
                            } else {
                                $location.path('/login');
                            }
                        });
                }
            };
        }
    ]);
})();