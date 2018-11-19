app.controller('daocaoCadastroController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.petSelection = true;
    ctrl.quantidadePets = 1;

    ctrl.SelectPet = function (pet) {
        if (pet == 1) {
            ctrl.dogSelected = true;
            ctrl.catSelected = false;
            ctrl.hamsterSelected = false;
            ctrl.birdSelected = false;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;
        }
        else if (pet == 2) {
            ctrl.dogSelected = false;
            ctrl.catSelected = true;
            ctrl.hamsterSelected = false;
            ctrl.birdSelected = false;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;
        }
        else if (pet == 3) {
            ctrl.dogSelected = false;
            ctrl.catSelected = false;
            ctrl.hamsterSelected = true;
            ctrl.birdSelected = false;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;
        }
        else if (pet == 4) {
            ctrl.dogSelected = false;
            ctrl.catSelected = false;
            ctrl.hamsterSelected = false;
            ctrl.birdSelected = true;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;
        }
        else if (pet == 5) {
            ctrl.ValidarComboOutros();
            ctrl.comboOutrosMostrar = true;
            ctrl.othersSelected = true;
            ctrl.dogSelected = false;
            ctrl.catSelected = false;
            ctrl.birdSelected = false;
            ctrl.hamsterSelected = false;
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
            ctrl.quantidade = false;
            ctrl.petInfos1 = false;
            ctrl.petInfosSaude = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
        }
        else if (number == 2) {
            ctrl.petSelection = false;
            ctrl.quantidade = true;
            ctrl.petInfos1 = false;
            ctrl.petInfosSaude = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
        }
        else if (number == 3) {
            ctrl.petSelection = false;
            ctrl.quantidade = false;
            ctrl.petInfos1 = true;
            ctrl.petInfosSaude = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
        }
        else if (number == 4) {
            ctrl.petSelection = false;
            ctrl.quantidade = false;
            ctrl.petInfos1 = false;
            ctrl.petInfosSaude = true;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
        }
        else if (number == 5) {
            ctrl.petSelection = false;
            ctrl.quantidade = false;
            ctrl.petInfos1 = false;
            ctrl.petInfosSaude = false;
            ctrl.petObservacoes = true;
            ctrl.petFotos = false;
        }
        else if (number == 6) {
            ctrl.petSelection = false;
            ctrl.quantidade = false;
            ctrl.petInfos1 = false;
            ctrl.petInfosSaude = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = true;
        }

        window.scrollTo(0, 0);
    }

    ctrl.alterarQuantidadePets = function (number) {

        var resultado = ctrl.quantidadePets + number;

        if (resultado > 0 && resultado < 9){
            ctrl.quantidadePets = ctrl.quantidadePets + number;
        }
    }

    ctrl.BtnProximoInfoBasicas = function () {

        if (ctrl.ValidarInfoBasicasPet()) {
            ctrl.GoTo(4);
        }

    }

    ctrl.ValidarInfoBasicasPet = function () {

        var contErro = 0;

        //Nome
        if (ctrl.base.StringIsEmpty(ctrl.TxtNomePet)) {
            ctrl.nomeError = true;
            contErro++;
        }
        else {
            ctrl.nomeError = false;
        }

        //Sexo
        if (ctrl.base.StringIsEmpty(ctrl.CmbSexoPet)) {
            ctrl.sexoError = true;
            contErro++;
        }
        else {
            ctrl.sexoError = false;
        }

        //Raça / Espécie
        if (ctrl.base.StringIsEmpty(ctrl.CmbRacaEspeciePet)) {
            ctrl.racaError = true;
            contErro++;
        }
        else {
            ctrl.racaError = false;
        }

        //Idade
        if (ctrl.base.StringIsEmpty(ctrl.CmbIdadePet)) {
            ctrl.idadeError = true;
            contErro++;
        }
        else {
            ctrl.idadeError = false;
        }

        //Porte
        if (ctrl.base.StringIsEmpty(ctrl.CmbPortePet)) {
            ctrl.porteError = true;
            contErro++;
        }
        else {
            ctrl.porteError = false;
        }

        //Pelo
        if (ctrl.base.StringIsEmpty(ctrl.CmbPeloPet)) {
            ctrl.peloError = true;
            contErro++;
        }
        else {
            ctrl.peloError = false;
        }

        //Cor 1
        if (ctrl.base.StringIsEmpty(ctrl.Cor1Pet)) {
            ctrl.cor1error = true;
            contErro++;
        }
        else {
            ctrl.cor1error = false;
        }

        //Cor 2
        if (ctrl.base.StringIsEmpty(ctrl.Cor2Pet)) {
            ctrl.cor2error = true;
            contErro++;
        }
        else {
            ctrl.cor2error = false;
        }

        //Estado
        if (ctrl.base.StringIsEmpty(ctrl.EstadoPet)) {
            ctrl.estadoErro = true;
            contErro++;
        }
        else {
            ctrl.estadoErro = false;
        }

        //Cidade
        if (ctrl.base.StringIsEmpty(ctrl.CidadePet)) {
            ctrl.cidadeErro = true;
            contErro++;
        }
        else {
            ctrl.cidadeErro = false;
        }

        return contErro == 0;

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