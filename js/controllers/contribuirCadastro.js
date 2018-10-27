var app = angular.module('pets', [])

app.controller('contribuirController', function ($scope, $http, $compile, $sce) {

    $scope.petSelection = true;
    // $scope.petInfos1 = true;
    // $scope.petInfosSaude = true;
    // $scope.petObservacoes = true;
    // $scope.petFotos = true;
    // $scope.confirmacao = true;

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
            $scope.petInfosSaude = false;
            $scope.petObservacoes = false;
            $scope.petFotos = false;
        }
        else if (number == 2) {
            $scope.petSelection = false;
            $scope.petInfos1 = true;
            $scope.petInfosSaude = false;
            $scope.petObservacoes = false;
            $scope.petFotos = false;
        }
        else if (number == 3) {
            $scope.petSelection = false;
            $scope.petInfos1 = false;
            $scope.petInfosSaude = true;
            $scope.petObservacoes = false;
            $scope.petFotos = false;
        }
        else if (number == 4) {
            $scope.petSelection = false;
            $scope.petInfos1 = false;
            $scope.petInfosSaude = false;
            $scope.petObservacoes = true;
            $scope.petFotos = false;
        }
        else if (number == 5) {
            $scope.petSelection = false;
            $scope.petInfos1 = false;
            $scope.petInfosSaude = false;
            $scope.petObservacoes = false;
            $scope.petFotos = true;
        }

        window.scrollTo(0, 0);
    }

    $scope.FinalizarCadastro = function () {
        $scope.petSelection = false;
        $scope.petInfos1 = false;
        $scope.petInfosSaude = false;
        $scope.petObservacoes = false;
        $scope.petFotos = false;
        $scope.confirmacao = true;
    }

});