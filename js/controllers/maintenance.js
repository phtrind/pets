var app = angular.module('pets', [])

app.controller('maintenanceController', function ($scope, $http, $compile, $sce) {

    $scope.clickBtnResponderPesquisa = function () {

        ga('send', {
            hitType: 'event',
            eventCategory: 'Pesquisa',
            eventAction: 'Click',
            eventLabel: 'Responder Pesquisa'
        });

    }

});