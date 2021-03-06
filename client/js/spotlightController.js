nextGenApp.controller('spotlightController', function ($scope, $localStorage, $rootScope, spotlightService, $timeout, $http) {
    // All User Data
    $scope.$storage = $localStorage;
    $scope.dateToggle = null;
    

    var metaLookup = {
        1: 'soundcloud',
        2: 'youtube',
        3: 'bands in town'
    };

    // User Info
    spotlightService.fetchUserSpotlight().success(function (response) {
        for (var i = 0; i < response.length; i++) {
            response[i].event.type = metaLookup[response[i].event.type];
        }
        $scope.spotlightResult = response;

    });
    // Open Dates
    $scope.lookupDates = function (artist) {

        $http.get('https://api.songkick.com/api/3.0/artists/' + artist.event.uri + '/calendar.json?apikey=jwzmbEyCAIwD7HCy').success(function (data) {
            $scope.tourDates = data;
            
            artist.dateToggle = true;

        });

    };
    // Close Dates
    $scope.closeDates = function(artist){
        artist.dateToggle = false;

    };


    $localStorage.selectedItems = $localStorage.selectedItems || [];

    $localStorage.likedArtist = $localStorage.likedArtist || [];

    $scope.alreadyLiked = false;

    $scope.currentlyPlayingVideo = null;

    $scope.like = function (item) {

        if (!~$localStorage.likedArtist.indexOf(item)) {
            $localStorage.likedArtist.push(item);
            console.log(item.id);
        } else {
            $scope.alreadyLiked = true;
        }
        $timeout(function () {

            $scope.alreadyLiked = false;
        }, 3000);


    };

    $scope.addToQueue = function (item) {
        item.$$hashKey = null;
        var blendedQueue = $.unique([].concat(
            $.map($localStorage.selectedItems, function (p) {
                p.$$hashKey = null;
                return p;
            }), [item]
        ));


        $localStorage.selectedItems = blendedQueue;

        $rootScope.$broadcast('addSongFromQueue', item.event.uri);
    };
    // youtube player controls
    $scope.playerVars = {
        controls: 1,
        autoplay: 0
    };

    // when playing
    $scope.isPlayingVideo = function (card) {
        return $scope.currentlyPlayingVideo === card.event.uri;
    };

    $scope.playVideo = function (card) {
        $scope.currentlyPlayingVideo = card.event.uri;
    };
    // closing video
    $scope.closeVideo = function () {
        $scope.currentlyPlayingVideo = null;
    };

    // on video ending
    $scope.$on('youtube.player.ended', function ($event, player) {
        player.stopVideo();
        $scope.closeVideo();
    });


});