app.controller('petPerdidoCadastroController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.Animal = null;

    ctrl.petSelection = true;

    ctrl.OnInit = function () {

        InitializeMap();

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Page/CadastroAnuncio',
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Animais = response.Animais.filter(x => x.Valor != "Cachorro" &&
                x.Valor != "Gato" &&
                x.Valor != "Roedores" &&
                x.Valor != "Aves")

            ctrl.Sexos = response.Sexos;
            ctrl.Idades = response.Idades;
            ctrl.Portes = response.Portes;
            ctrl.Pelos = response.Pelos;
            ctrl.Cores = response.Cores;
            ctrl.Estados = response.Estados;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    //ctrl.petSelection = true;

    ctrl.SelectPet = function (aPet) {
        if (aPet == 'Cachorro') {
            ctrl.dogSelected = true;
            ctrl.catSelected = false;
            ctrl.hamsterSelected = false;
            ctrl.birdSelected = false;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;

            ctrl.PetSelecionado(1);

            ctrl.outrosSelecionado = "";
        }
        else if (aPet == 'Gato') {
            ctrl.dogSelected = false;
            ctrl.catSelected = true;
            ctrl.hamsterSelected = false;
            ctrl.birdSelected = false;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;

            ctrl.PetSelecionado(2);

            ctrl.outrosSelecionado = "";
        }
        else if (aPet == 'Roedor') {
            ctrl.dogSelected = false;
            ctrl.catSelected = false;
            ctrl.hamsterSelected = true;
            ctrl.birdSelected = false;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;

            ctrl.PetSelecionado(5);

            ctrl.outrosSelecionado = "";
        }
        else if (aPet == 'Ave') {
            ctrl.dogSelected = false;
            ctrl.catSelected = false;
            ctrl.hamsterSelected = false;
            ctrl.birdSelected = true;
            ctrl.othersSelected = false;
            ctrl.petSelected = true;
            ctrl.comboOutrosMostrar = false;

            ctrl.PetSelecionado(3);

            ctrl.outrosSelecionado = "";
        }
        else if (aPet == 'Outros') {
            ctrl.ValidarComboOutros();
            ctrl.comboOutrosMostrar = true;
            ctrl.othersSelected = true;
            ctrl.dogSelected = false;
            ctrl.catSelected = false;
            ctrl.birdSelected = false;
            ctrl.hamsterSelected = false;
        }
    }

    ctrl.PetSelecionado = function (aIdAnimal) {

        ctrl.Animal = aIdAnimal;

        ctrl.CmbRacaEspeciePet = "";

    }

    ctrl.ValidarComboOutros = function () {
        if (ctrl.base.StringIsEmpty(ctrl.outrosSelecionado)) {
            ctrl.petSelected = false;
        }
        else {
            ctrl.petSelected = true;

            ctrl.PetSelecionado(ctrl.outrosSelecionado);
        }
    }

    ctrl.PetEscolhido = function () {

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Anuncio/BuscarRacaEspeciePorAnimal/' + ctrl.Animal,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Racas = response;

            ctrl.GoTo(2);

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

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
            ctrl.SetLocalizacao();
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

        ctrl.Teste = longitude;
    }

    ctrl.SetLocalizacao = function () {

        if (!ctrl.base.StringIsEmpty(latitude) && !ctrl.base.StringIsEmpty(longitude)) {

            ctrl.Localizacao = {
                Latitude: latitude,
                Longitude: longitude
            }

        }
        else {

            ctrl.Localizacao = null;

        }

    }

    ctrl.EstadoSelecionadoChange = function () {

        if (!ctrl.base.StringIsEmpty(ctrl.EstadoPet)) {
            $http({
                method: 'GET',
                url: ctrl.base.servicePath + 'Cidade/Combo/' + ctrl.EstadoPet
            }).success(function (response) {

                ctrl.Cidades = response;

            }).error(function (err, status) {

                ctrl.Cidades = null;

                //TODO: Implementar tratamento de erro na base

            });
        }
        else {
            ctrl.Cidades = null;
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

    ctrl.UploadImagens = function () {

        $('#fine-uploader-validation').fineUploader('uploadStoredFiles');

    }

    ctrl.FinalizarCadastro = function () {

        var request = {
            IdUsuario: sessionStorage.getItem('IdUsuario'),
            Anuncio: {
                Pet: {
                    IdAnimal: ctrl.Animal,
                    Nome: ctrl.TxtNomePet,
                    IdSexo: ctrl.CmbSexoPet,
                    IdRacaEspecie: ctrl.CmbRacaEspeciePet,
                    IdIdade: ctrl.CmbIdadePet,
                    IdPorte: ctrl.CmbPortePet,
                    Peso: ctrl.TxtPesoPet,
                    IdPelo: ctrl.CmbPeloPet,
                    IdCorPrimaria: ctrl.Cor1Pet,
                    IdCorSecundaria: ctrl.Cor2Pet,
                    Vacinado: null,
                    Vermifugado: null,
                    Castrado: null,
                    Descricao: ctrl.TxtDescricaoPet
                },
                Localizacao: {
                    Latitude: latitude,
                    Longitude: longitude
                },
                IdEstado: ctrl.EstadoPet,
                IdCidade: ctrl.CidadePet,
                GuidImagens: guidAnuncio
            }
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/CadastrarPetPerdido',
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') },
            data: request
        }).success(function (response) {

            ctrl.DefinirFotoDestaque(response);

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    ctrl.DefinirFotoDestaque = function (aIdAnuncio) {

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Anuncio/BuscarFotos/' + aIdAnuncio
        }).success(function (response) {

            ctrl.FotosCadastradas = response;

            ctrl.petSelection = false;
            ctrl.petInfos1 = false;
            ctrl.petObservacoes = false;
            ctrl.petFotos = false;
            ctrl.confirmacao = true;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    ctrl.SelecionarFotoDestaque = function (aIdFoto) {

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/AlterarFotoDestaque/' + aIdFoto,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.FotosCadastradas = null;

            ctrl.ImgDestaqueSucesso = true;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

});