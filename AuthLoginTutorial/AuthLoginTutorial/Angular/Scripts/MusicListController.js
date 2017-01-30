(function(app) {
    var MusicListController = function($scope, musicService) {

        musicService.getAll()
            .success(function(data) {
                $scope.musics = data;
            });

        $scope.delete = function(music) {
            musicService.delete(music.id)
                .success(function() {
                    removeMusicById(music.id);
                });
        };

        $scope.create = function () {
            $scope.edit = {
                music: {
                    Title: "",
                    Singers: "",
                    ReleaseDate: new Date,
                    RunTime: 0
                }
            };
        };

        var removeMusicById = function(id) {
            for (var i = 0; i < $scope.musics.length; i++) {
                if ($scope.musics[i].id == id) {
                    $scope.musics.splice(i, 1);
                    break;
                }
            }
        };
    };
    app.controller("MusicListController", MusicListController);
}(angular.module("theMusic")));