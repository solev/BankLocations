(function () {
    'use strict';

    angular.module('app', [
        'ngRoute',
        'ngJsTree'
    ])
        .config(function ($routeProvider) {
            $routeProvider
                .when("/", {
                    templateUrl: 'App/views/cadLocations/cadLocations.html',
                    controller: 'cadLocations'
                })
                .when("/cadVendor", {
                    templateUrl: 'App/views/cadVendor/cadVendor.html',
                    controller: 'cadVendor'
                })
        })
})();