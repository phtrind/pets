var app = angular.module('pets', [])

app.controller('daocaoCadastroController', function ($scope, $http, $compile, $sce) {

    $scope.petSelection = true;
    $scope.quantidadePets = 1;

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
            $scope.quantidade = false;
            $scope.petInfos1 = false;
            $scope.petInfosSaude = false;
            $scope.petObservacoes = false;
            $scope.petFotos = false;
        }
        else if (number == 2) {
            $scope.petSelection = false;
            $scope.quantidade = true;
            $scope.petInfos1 = false;
            $scope.petInfosSaude = false;
            $scope.petObservacoes = false;
            $scope.petFotos = false;
        }
        else if (number == 3) {
            $scope.petSelection = false;
            $scope.quantidade = false;
            $scope.petInfos1 = true;
            $scope.petInfosSaude = false;
            $scope.petObservacoes = false;
            $scope.petFotos = false;
        }
        else if (number == 4) {
            $scope.petSelection = false;
            $scope.quantidade = false;
            $scope.petInfos1 = false;
            $scope.petInfosSaude = true;
            $scope.petObservacoes = false;
            $scope.petFotos = false;
        }
        else if (number == 5) {
            $scope.petSelection = false;
            $scope.quantidade = false;
            $scope.petInfos1 = false;
            $scope.petInfosSaude = false;
            $scope.petObservacoes = true;
            $scope.petFotos = false;
        }
        else if (number == 6) {
            $scope.petSelection = false;
            $scope.quantidade = false;
            $scope.petInfos1 = false;
            $scope.petInfosSaude = false;
            $scope.petObservacoes = false;
            $scope.petFotos = true;
        }

        window.scrollTo(0, 0);
    }

    $scope.alterarQuantidadePets = function (number) {

        var resultado = $scope.quantidadePets + number;

        if (resultado > 0 && resultado < 9){
            $scope.quantidadePets = $scope.quantidadePets + number;
        }
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