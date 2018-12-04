app.controller('contribuirController', function ($controller) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.petSelection = true;

    ctrl.petSelection = true;
    // ctrl.petInfos1 = true;
    // ctrl.petInfosSaude = true;
    // ctrl.petObservacoes = true;
    // ctrl.petFotos = true;
    // ctrl.confirmacao = true;

    ctrl.SelectPet = function (pet) {
        if (pet == 1) {
            ctrl.dogSelected = true;
            ctrl.catSelected = false;
            ctrl.fishSelected = false;
            ctrl.birdSelected = false;
            ctrl.petSelected = true;
        }
        else if (pet == 2) {
            ctrl.dogSelected = false;
            ctrl.catSelected = true;
            ctrl.fishSelected = false;
            ctrl.birdSelected = false;
            ctrl.petSelected = true;
        }
        else if (pet == 3) {
            ctrl.dogSelected = false;
            ctrl.catSelected = false;
            ctrl.fishSelected = true;
            ctrl.birdSelected = false;
            ctrl.petSelected = true;
        }
        else if (pet == 4) {
            ctrl.dogSelected = false;
            ctrl.catSelected = false;
            ctrl.fishSelected = false;
            ctrl.birdSelected = true;
            ctrl.petSelected = true;
        }
    }

    ctrl.GoTo = function (number) {
        if (number == 1) {
            ctrl.petSelection = true;
            ctrl.petInfos1 = false;
            ctrl.petInfosSaude = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
        }
        else if (number == 2) {
            ctrl.petSelection = false;
            ctrl.petInfos1 = true;
            ctrl.petInfosSaude = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
        }
        else if (number == 3) {
            ctrl.petSelection = false;
            ctrl.petInfos1 = false;
            ctrl.petInfosSaude = true;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
        }
        else if (number == 4) {
            ctrl.petSelection = false;
            ctrl.petInfos1 = false;
            ctrl.petInfosSaude = false;
            ctrl.petObservacoes = true;
            ctrl.petFotos = false;
        }
        else if (number == 5) {
            ctrl.petSelection = false;
            ctrl.petInfos1 = false;
            ctrl.petInfosSaude = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = true;
        }

        window.scrollTo(0, 0);
    }

    ctrl.FinalizarCadastro = function () {
        ctrl.petSelection = false;
        ctrl.petInfos1 = false;
        ctrl.petInfosSaude = false;
        ctrl.petObservacoes = false;
        ctrl.petFotos = false;
        ctrl.confirmacao = true;
    }

});