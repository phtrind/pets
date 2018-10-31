var app = angular.module('pets', [])

app.controller('maintenanceController', function ($scope, $http, $compile, $sce) {

    $scope.clickBtnResponderPesquisa = function () {

        gtag('event',
            'Click',
            {
                'event_category': 'Pesquisa',
                'event_label': 'Responder Pesquisa',
                'value': 1
            });

    }

    $scope.clickBtnFacebook = function () {

        gtag('event',
            'Click',
            {
                'event_category': 'Redes Sociais',
                'event_label': 'Facebook',
                'value': 1
            });

    }

    $scope.clickBtnInstagram = function () {

        gtag('event',
            'Click',
            {
                'event_category': 'Redes Sociais',
                'event_label': 'Instagram',
                'value': 1
            });

    }

});