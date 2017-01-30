var LRM = angular.module('LRM', ['ngRoute'])
    .config(function($routeProvider){
        $routeProvider
            .when('/AddItem',{
                templateUrl:'templates/AddItem.html'
            })
            .when('/DetailedItem',{
                templateUrl:'templates/DetailedItem.html'
            })
            .when('/Homepage',{
                templateUrl:'templates/Homepage.html',
                controller:'homeController'
            })
            .when('/QuickItem',{
                templateUrl:'templates/QuickItem.html'
            })
            .when('/SingleItem',{
                templateUrl:'templates/SingleItem.html'
            })
            .when('/UpdateItem',{
                templateUrl:'templates/UpdateItem.html'
            })
            .otherwise({
                templateUrl:'templates/Homepage.html'
                });
    });

LRM.controller('GetController', function ($scope, $http, $location) {
    $http.get('http://10.10.60.121:12346/api/Resources')
        .then(function (response) {
            $scope.resource = response.data;
        });
});

LRM.controller('GetSingleController', function ($scope, $http) {
    $http.get('http://10.10.60.121:12346/api/Resources/' + viewId)
        .then(function (response) {
            $scope.resource = response.data;
        });
});

var viewId = 1;