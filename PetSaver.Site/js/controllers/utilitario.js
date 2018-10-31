var app = angular.module('pets', []);

app.factory('Utilities', function () {

    return {
        verificarSession: function () {
            if (true) {
                $scope.isLogged = true;
            }
            else {
                $scope.isLogged = false;
            }
        }
    }

});