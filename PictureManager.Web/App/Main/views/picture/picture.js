(function () {
    var app = angular.module('app');

    var controllerId = 'app.controllers.views.picture';
    app.controller(controllerId, [
        '$scope', function ($scope) {
         /*   var vm = this;

            vm.localize = abp.localization.getSource('PictureManager');
            vm.tasks = [];
            $scope.selectedTaskState = 0;

            $scope.$watch('selectedTaskState', function (value) {
                vm.refreshTasks();
            });

            vm.refreshTasks = function () {
                taskService.getTasks({
                    state: $scope.selectedTaskState > 0 ? $scope.selectedTaskState : null
                }).success(function (data) {
                    vm.tasks = data.tasks;
                });
            }; */
        }    
    ]);
})();