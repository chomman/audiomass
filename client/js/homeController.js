nextGenApp.controller('homeController', function ($scope, authService, $state) {
    $scope.scroll = 0;

    $scope.authService = authService;
 
    
    
       if(localStorage.getItem('id_token') !== null) {
            $state.go('dashboard');
        }

});