angular.module('nextGenApp')

.controller('NavbarCtrl', function ($scope, $rootScope, $state, authService, userService) {
    
    
    // User Info
    userService.fetchUserQueue().success(function (response) {
        $scope.user = response;
    });
    
    $scope.login = function(){
        authService.facebookLogin(function(err){
           if(!err){
               authService.authenticateAndGetProfile();
           } 
        });
    };
    
    $scope.isAuthenticated = function(){
      //return localStorage.getItem('profile') !== null;
    };
    
    $scope.logoutBtn = function(){
        authService.logout();
        $state.go('home'); // go to login
    };

    $scope.currentSong = '';
    
    $rootScope.$on("playSongFromQueue", function(evt,data){ 
  
        $scope.currentSong =  data;

//document.getElementById('scPlayer').contentWindow.location.reload(true);

        
    });
    
    
$(window).on("scroll", function() {
    if($(window).scrollTop() > 50) {
        $(".main-nav").addClass("whiteBg");
    } else {
        //remove the background property so it comes transparent again (defined in your css)
       $(".main-nav").removeClass("whiteBg");
    }
});
    
});
