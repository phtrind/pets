var app = angular.module('pets', [])

app.controller('petPerdidoCadastroController', function ($scope, $http, $compile, $sce) {

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
            $scope.birdSelected = false;
            $scope.othersSelected = false;
            $scope.petSelected = true;
            $scope.comboOutrosMostrar = false;
        }
        else if (pet == 2) {
            $scope.dogSelected = false;
            $scope.catSelected = true;
            $scope.birdSelected = false;
            $scope.othersSelected = false;
            $scope.petSelected = true;
            $scope.comboOutrosMostrar = false;
        }
        else if (pet == 3) {
            $scope.dogSelected = false;
            $scope.catSelected = false;
            $scope.birdSelected = true;
            $scope.othersSelected = false;
            $scope.petSelected = true;
            $scope.comboOutrosMostrar = false;
        }
        else if (pet == 4) {
            $scope.ValidarComboOutros();
            $scope.comboOutrosMostrar = true;
            $scope.othersSelected = true;
            $scope.dogSelected = false;
            $scope.catSelected = false;
            $scope.birdSelected = false;
        }
    }

    $scope.ValidarComboOutros = function () {
        if ($scope.outrosSelecionado == "" || $scope.outrosSelecionado == undefined) {
            $scope.petSelected = false;
            }
            else {
            $scope.petSelected = true;
        }
    }

    $scope.GoTo = function (number) {
        if (number == 1) {
            $scope.petSelection = true;
            $scope.petLocalizacao = false;            
            $scope.petInfos1 = false;
            $scope.petObservacoes = false;
            $scope.petFotos = false;
        }
        else if (number == 2) {
            $scope.petSelection = false;
            $scope.petLocalizacao = true;
            $scope.petInfos1 = false;
            $scope.petObservacoes = false;
            $scope.petFotos = false;
        }
        else if (number == 3) {
            $scope.petSelection = false;
            $scope.petLocalizacao = false;
            $scope.petInfos1 = true;
            $scope.petObservacoes = false;
            $scope.petFotos = false;
        }
        else if (number == 4) {
            $scope.petSelection = false;
            $scope.petLocalizacao = false;
            $scope.petInfos1 = false;
            $scope.petObservacoes = true;
            $scope.petFotos = false;
        }

        else if (number == 5) {
            $scope.petSelection = false;
            $scope.petLocalizacao = false;
            $scope.petInfos1 = false;
            $scope.petObservacoes = false;
            $scope.petFotos = true;
        }

        window.scrollTo(0, 0);
    }

    $scope.FinalizarCadastro = function () {
        $scope.petSelection = false;
        $scope.petInfos1 = false;
        $scope.petObservacoes = false;
        $scope.petFotos = false;
        $scope.confirmacao = true;
    }

});