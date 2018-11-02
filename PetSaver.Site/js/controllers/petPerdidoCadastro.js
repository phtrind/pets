app.controller('petPerdidoCadastroController', function ($controller) {

        var ctrl = this;
    
        ctrl.base = $controller('baseController', {});
    
        ctrl.petSelection = true;

    ctrl.SelectPet = function (pet) {
        if (pet == 1) {
            ctrl.dogSelected = true;
            ctrl.catSelected = false;
            ctrl.birdSelected = false;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;
        }
        else if (pet == 2) {
            ctrl.dogSelected = false;
            ctrl.catSelected = true;
            ctrl.birdSelected = false;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;
        }
        else if (pet == 3) {
            ctrl.dogSelected = false;
            ctrl.catSelected = false;
            ctrl.birdSelected = true;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;
        }
        else if (pet == 4) {
            ctrl.ValidarComboOutros();
            ctrl.comboOutrosMostrar = true;
            ctrl.othersSelected = true;
            ctrl.dogSelected = false;
            ctrl.catSelected = false;
            ctrl.birdSelected = false;
        }
    }

    ctrl.ValidarComboOutros = function () {
        if (ctrl.outrosSelecionado == "" || ctrl.outrosSelecionado == undefined) {
            ctrl.petSelected = false;
            }
            else {
            ctrl.petSelected = true;
        }
    }

    ctrl.GoTo = function (number) {
        if (number == 1) {
            ctrl.petSelection = true;
            ctrl.petLocalizacao = false;            
            ctrl.petInfos1 = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
        }
        else if (number == 2) {
            ctrl.petSelection = false;
            ctrl.petLocalizacao = true;
            ctrl.petInfos1 = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
        }
        else if (number == 3) {
            ctrl.petSelection = false;
            ctrl.petLocalizacao = false;
            ctrl.petInfos1 = true;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
        }
        else if (number == 4) {
            ctrl.petSelection = false;
            ctrl.petLocalizacao = false;
            ctrl.petInfos1 = false;
            ctrl.petObservacoes = true;
            ctrl.petFotos = false;
        }

        else if (number == 5) {
            ctrl.petSelection = false;
            ctrl.petLocalizacao = false;
            ctrl.petInfos1 = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = true;
        }

        window.scrollTo(0, 0);
    }

    ctrl.FinalizarCadastro = function () {
        ctrl.petSelection = false;
        ctrl.petInfos1 = false;
        ctrl.petObservacoes = false;
        ctrl.petFotos = false;
        ctrl.confirmacao = true;
    }

});