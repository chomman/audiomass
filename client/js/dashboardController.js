nextGenApp.controller('dashboardController', function ($scope, $state, userService) {
  $scope.scroll = 0;

    // User Info
    userService.fetchUserQueue().success(function (response) {
        $scope.user = response;
    });
       if(localStorage.getItem('id_token') === null) {
            $state.go('dashboard');
        }

});