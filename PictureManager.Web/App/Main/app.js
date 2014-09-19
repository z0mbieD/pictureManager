(function () {
    'use strict';

    var localize = abp.localization.getSource('PictureManager');

    var app = angular.module('app', [
        'ngAnimate',
        'ngRoute',
        'ngSanitize',

        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    app.constant('routes', [
            {
                url: '/', //default
                config: {
                    templateUrl: '/App/Main/views/picture/picture.cshtml',
                    menuText: localize('Picture'),
                    menuItem: 'Picture'
                }
            },
            {
                url: '/new',
                config: {
                    templateUrl: '/App/Main/views/picture/newpicture.cshtml',
                    menuText: localize('New'),
                    menuItem: 'New'
                }
            },
            {
                url: '/singup',
                config: {
                    templateUrl: '/App/Main/views/user/singup.cshtml',
                    menuText: localize('Register'),
                    menuItem: 'Register'
                }
        } 
        ]);

    app.config([
        '$routeProvider', 'routes',
        function ($routeProvider, routes) {
            routes.forEach(function (route) {
                $routeProvider.when(route.url, route.config);
            });

            $routeProvider.otherwise({
                redirectTo: '/'
            });
        }
    ]);

    app.run([
        '$rootScope',
        function ($rootScope) {
            $rootScope.$on('$routeChangeSuccess', function (event, next, current) {
                if (next && next.$$route) {
                    $rootScope.activeMenu = next.$$route.menuItem; //Used in layout.cshtml to make selected menu 'active'.
                }
            });
        }
    ]);
})();