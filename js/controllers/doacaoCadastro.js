var app = angular.module('pets', [])

app.controller('daocaoCadastroController', function ($scope, $http, $compile, $sce) {

    $scope.petSelection = true;
    // $scope.petInfos1 = true;

    $scope.SelectPet = function (pet) {
        if (pet == 1) {
            $scope.dogSelected = true;
            $scope.catSelected = false;
            $scope.fishSelected = false;
            $scope.birdSelected = false;
            $scope.petSelected = true;
        }
        else if (pet == 2) {
            $scope.dogSelected = false;
            $scope.catSelected = true;
            $scope.fishSelected = false;
            $scope.birdSelected = false;
            $scope.petSelected = true;
        }
        else if (pet == 3) {
            $scope.dogSelected = false;
            $scope.catSelected = false;
            $scope.fishSelected = true;
            $scope.birdSelected = false;
            $scope.petSelected = true;
        }
        else if (pet == 4) {
            $scope.dogSelected = false;
            $scope.catSelected = false;
            $scope.fishSelected = false;
            $scope.birdSelected = true;
            $scope.petSelected = true;
        }
    }

    $scope.GoTo = function (number) {
        if (number == 1) {
            $scope.petSelection = true;
            $scope.petInfos1 = false;
        }
        else if (number == 2) {
            $scope.petSelection = false;
            $scope.petInfos1 = true;
        }
    }

});