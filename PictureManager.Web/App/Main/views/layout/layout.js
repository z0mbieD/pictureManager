(function () {
    var app = angular.module('app');
    
    var languages = [
        {
            name: 'tr',
            displayName: 'Türkçe',
            iconClass: 'famfamfam-flag-tr'
        },
        {
            name: 'en',
            displayName: 'English',
            iconClass: 'famfamfam-flag-england'
        }
    ];
    
    var controllerId = 'app.controllers.views.layout';
    app.controller(controllerId, ['$scope', '$rootScope', '$location', 'routes', 'abp.services.picturemanager.user',
        function ($scope, $rootScope, $location, routes, userService) {
        var that = this;

        that.routes = routes;
        
        that.getLanguageFlagClass = function () {
            var lang = abp.localization.currentCulture.name;
            for (var i = 0; i < languages.length; i++) {
                if (lang.indexOf(languages[i].name) == 0) {
                    return languages[i].iconClass;
                }
            }

            return '';
        };

        that.getLanguageName = function () {
            var lang = abp.localization.currentCulture.name;
            for (var i = 0; i < languages.length; i++) {
                if (lang.indexOf(languages[i].name) == 0) {
                    return languages[i].displayName;
                }
            }
            return '';
        };

        that.isCurrentLanguage = function(lang) {
            return abp.localization.isCurrentCulture(lang);
        };

        $scope.logOut = function () {
            abp.ui.setBusy(null, {
                promise: userService.logOff()
                    .success(function (data) {
                        $rootScope.isAuth = false;
                        $rootScope.userName = '';
                        $location.path('/');
                    })
            });

        };

        $scope.goToProfile = function (userObject) {
            $scope.user = {
                id: 0,
                login: $rootScope.userName
            };
            userService.getUserByName($scope.user)
                .success(function (data) {
                    if (data > 0) {
                        $scope.user.id = data;
                        $rootScope.userObject = $scope.user;
                        $location.path('/profile');
                    } else {
                       // $location.path('/login');
                    }
                });       
        };

    }]);
})();