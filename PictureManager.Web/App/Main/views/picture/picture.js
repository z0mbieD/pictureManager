(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.picture.picture';
    app.controller(controllerId, [
        '$scope', '$location', '$rootScope', 'abp.services.picturemanager.comment',
        function ($scope, $location, $rootScope, commentService) {
            var vm = this;
            if ($rootScope.pictureObject && $rootScope.isAuth) {
                vm.picture = $rootScope.pictureObject;
                vm.comment = {
                    text: '',
                    pictureId: null,
                    userId: null
                };
                vm.user = {
                    login: $rootScope.userName
                };

                var localize = abp.localization.getSource('PictureManager');

                vm.comments = [];
                vm.comment.pictureId = vm.picture.id;

                commentService.getComments(vm.comment).success(function (data) {
                    vm.comments = data.comments;
                });

                $scope.saveComment = function () {
                    vm.comment.userId = vm.picture.assignedUser.id;
                    vm.comment.pictureId = vm.picture.id;
                    commentService.addComment(vm.comment)
                        .success(function () {
                            $location.path('/');
                        });
                };
            } else {
                $location.path('/');
            }
        }
    ]);
})();