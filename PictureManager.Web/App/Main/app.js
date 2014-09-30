var isAuth = false;
var userName = "";
var pictures = [];
var pictureObject = [];
var userObject = [];
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
                    templateUrl: '/App/Main/views/picture/pictures.cshtml',
                    menuText: 'Картинки',
                    menuItem: 'Pictures',
                    menuVisible: true
                }
            },
            {
                url: '/new',
                config: {
                    templateUrl: '/App/Main/views/picture/newpicture.cshtml',
                    menuText: 'Добавить',
                    menuItem: 'New',
                    menuVisible: true
                }
            },
            {
                url: '/singup',
                config: {
                    templateUrl: '/App/Main/views/user/singup.cshtml',
                    menuText: localize('Register'),
                    menuItem: 'Register',
                    menuVisible: false
                }
            },
            {
                url: '/login',
                config: {
                    templateUrl: '/App/Main/views/user/login.cshtml',
                    menuText: localize('Login'),
                    menuItem: 'Login',
                    menuVisible: false
                }
            },
            {
                url: '/users',
                config: {
                    templateUrl: '/App/Main/views/user/users.cshtml',
                    menuText: 'Пользователи',
                    menuItem: 'Users',
                    menuVisible: true
                }
            },
            {
                url: '/picture',
                config: {
                    templateUrl: '/App/Main/views/picture/picture.cshtml',
                    menuText: localize('Picture'),
                    menuItem: 'Picture',
                    menuVisible: false
                }
            },
            {
                url: '/profile',
                config: {
                    templateUrl: '/App/Main/views/user/profile.cshtml',
                    menuText: localize('Profile'),
                    menuItem: 'Profile',
                    menuVisible: false
                }
            },
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
        '$rootScope', 'abp.services.picturemanager.user',
        function ($rootScope, userService) {           
            $rootScope.$on('$routeChangeSuccess', function (event, next, current) {
                if (next && next.$$route && next.$$route.menuVisible == true) {
                    $rootScope.activeMenu = next.$$route.menuItem; //Used in layout.cshtml to make selected menu 'active'. 
                }
            });

            $rootScope.$apply(function () {
                userService.getCurrentUser().then(function (userName) {
                    if (userName.data != "") {
                        $rootScope.isAuth = true;
                        $rootScope.userName = userName.data;
                    }
                });

                return '';
            });
        }
    ]
    );
})();