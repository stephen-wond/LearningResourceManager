(function() {
    var app = angular.module("theMusic", ["ngRoute"]);

    var config = function($routeProvider) {
        $routeProvider.when("/list",  
                { templateUrl: "/Angular/MusicApp/Views/list.html", controller: "MusicListController" })  
            .when("/details/:id",
                { templateUrl: "/Angular/MusicApp/Views/details.html", controller: "DetailsController" })
            .otherwise(  
                { redirectTo: "/list", controller: "MusicListController" });  
    };

    app.config(config);
    app.constant("musicApiUrl", "/api/musics/")
}());