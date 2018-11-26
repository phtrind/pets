app.controller('baseController', function ($http) {

    var base = this;

    //#region .: Variáveis Globais :.

    base.servicePath = "http://localhost/PetSaver.WebApi/api/";
    //base.servicePath = "http://173.193.169.235:4000/api/";

    //#endregion

    //#region .: Login / Cadastro Básico :.

    base.AbrirModalLogin = function () {

        base.isRegister = false;

    }

    base.IsLogged = function () {

        if (!base.StringIsEmpty(sessionStorage.getItem('Token')) &&
            !base.StringIsEmpty(sessionStorage.getItem('IdUsuario')) &&
            !base.StringIsEmpty(sessionStorage.getItem('DthValidadeToken'))) {

            //TODO: Mostrar modal informando que o login expirou

            return base.ValidarToken();

        }
        else {
            return false;
        }

    }

    base.ValidarToken = function () {

        try {
            var authDateTime = new Date(sessionStorage.getItem('DthValidadeToken'));

            var dateTimeNow = new Date();

            return authDateTime > dateTimeNow;

        } catch (e) {
            return false;
        }

    }

    base.LimparSessionAuth = function () {

        sessionStorage.removeItem('DthValidadeToken');
        sessionStorage.removeItem('IdLogin');
        sessionStorage.removeItem('IdUsuario');
        sessionStorage.removeItem('Nome');
        sessionStorage.removeItem('Token');

    }

    base.FazerLogoff = function () {

        base.LimparSessionAuth();

    }

    base.FazerLogin = function () {

        //TODO: Implementar loading
        base.Logando = true;

        var contErro = 0;

        if (base.EmailIsValid(base.EmailLogin)) {
            base.ErroEmailLogin = false;
        }
        else {
            base.ErroEmailLogin = true;
            contErro++;
        }

        if (base.StringIsEmpty(base.SenhaLogin)) {
            base.ErroSenhaLogin = true;
            contErro++;
        }
        else {
            base.ErroSenhaLogin = false;
        }

        if (contErro == 0) {

            $http({
                method: 'POST',
                url: base.servicePath + 'token',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                data: "grant_type=password&username=" + base.EmailLogin + "&password=" + base.SenhaLogin
            }).success(function (response) {

                sessionStorage.setItem("Token", response.access_token);

                base.BuscarInformacoesSession(base.EmailLogin);

                $('#modalLogarCadastrar').modal('hide');
                $('#modalLoginRealizado').modal('show');

                base.LimparCamposLoginCadastro();

            }).error(function (err, status) {

                sessionStorage.clear();

                if (status == 400) {
                    base.LimparCamposLoginCadastro();
                    $('#modalErroLogin').modal('show');
                }
                else {
                    //TODO: Implementar tratamento de erro na base
                }

            }).finally(function () {

                base.Logando = false;

            });

        }
        else {
            base.Logando = false;
        }

    }

    base.LimparCamposLoginCadastro = function () {

        base.EmailLogin = "";
        base.SenhaLogin = "";
        base.NomeCadastro = "";
        base.SobrenomeCadastro = "";
        base.DthNascimentoCadastro = "";
        base.EmailCadastro = "";
        base.ConfirmacaoEmailCadastro = "";
        base.SenhaCadastro = "";
        base.ConfirmacaoSenhaCadastro = "";

    }

    base.BuscarInformacoesSession = function (aEmail) {

        $http({
            method: 'GET',
            url: base.servicePath + 'Usuario/InformacoesSession/' + aEmail + '/',
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            sessionStorage.setItem("IdLogin", response.IdLogin);
            sessionStorage.setItem("IdUsuario", response.IdUsuario);
            sessionStorage.setItem("Nome", response.Nome);
            sessionStorage.setItem("DthValidadeToken", response.DthValidadeToken);

            base.NomeUsuario = response.Nome;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    base.FazerCadastroBasico = function () {

        //TODO: Implementar loading
        base.Cadastrando = true;

        var contErro = 0;

        //Nome
        if (base.StringIsEmpty(base.NomeCadastro)) {
            base.ErroNomeCadastro = true;
            contErro++;
        }
        else {
            base.ErroNomeCadastro = false;
        }

        //Sobrenome
        if (base.StringIsEmpty(base.SobrenomeCadastro)) {
            base.ErroSobrenomeCadastro = true;
            contErro++;
        }
        else {
            base.ErroSobrenomeCadastro = false;
        }

        //Data nascimento
        if (base.StringIsEmpty(base.DthNascimentoCadastro)) {
            base.ErroDthNascimentoCadastro = true;
            contErro++;
        }
        else {
            base.ErroDthNascimentoCadastro = false;
        }

        //Email
        if (base.EmailIsValid(base.EmailCadastro)) {
            base.ErroEmailCadastro = false;
        }
        else {
            base.ErroEmailCadastro = true;
            contErro++;
        }

        //Confirmação e-mail
        if (base.ConfirmacaoEmailCadastro != base.EmailCadastro) {
            base.ErroConfirmacaoEmailCadastro = true;
            contErro++;
        }
        else {
            base.ErroConfirmacaoEmailCadastro = false;
        }

        //Senha
        if (base.StringIsEmpty(base.SenhaCadastro)) {
            base.ErroSenhaCadastro = true;
            base.ErroSenhaCadastroVazia = true;
            contErro++;
        }
        else if (base.SenhaCadastro.length < 8) {
            base.ErroSenhaCadastro = true;
            base.ErroSenhaCadastroPequena = true;
            contErro++;
        }
        else {
            base.ErroSenhaCadastro = false;
            base.ErroSenhaCadastroVazia = false;
            base.ErroSenhaCadastroPequena = false;
        }

        //Confirmação senha
        if (base.SenhaCadastro != base.ConfirmacaoSenhaCadastro) {
            base.ErroConfirmacaoSenhaCadastro = true;
            contErro++;
        }
        else {
            base.ErroConfirmacaoSenhaCadastro = false;
        }

        if (contErro == 0) {

            var request = {
                Nome: base.NomeCadastro,
                Sobrenome: base.SobrenomeCadastro,
                DataNascimento: base.DthNascimentoCadastro,
                Email: base.EmailCadastro,
                Senha: base.SenhaCadastro
            };

            $http({
                method: 'POST',
                url: base.servicePath + 'Usuario/CadastrarBasico',
                data: request
            }).success(function (response) {

                $http({
                    method: 'POST',
                    url: base.servicePath + 'token',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    data: "grant_type=password&username=" + request.Email + "&password=" + request.Senha
                }).success(function (response) {

                    sessionStorage.setItem("Token", response.access_token);
                    sessionStorage.setItem("DataHoraAutenticacao", new Date().toLocaleString());
                    sessionStorage.setItem("TokenExpiresIn", response.expires_in);

                    base.BuscarInformacoesSession(base.EmailLogin);

                    base.LimparCamposLoginCadastro();

                }).error(function (err, status) {

                    sessionStorage.clear();

                    //TODO: Implementar tratamento de erro na base

                });

                $('#modalLogarCadastrar').modal('hide');
                $('#modalCadastroRealizado').modal('show');

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {

                base.Cadastrando = false;

            });

        }
        else {
            base.Cadastrando = false;
        }

    }

    //#endregion

    //#region .: Anúncios :.

    base.AbrirAnuncio = function (aIdAnuncio) {

        sessionStorage.setItem("IdAnuncioAtual", aIdAnuncio);

        window.location.href = "pet.html"

    }

    //#endregion

    //#region .: Cadastro Anúncio :.

    base.ctrlCadastroAnuncio = new Object();

    base.ctrlCadastroAnuncio.Animal = null;

    //base.ctrlCadastroAnuncio.petSelection = true;
    base.ctrlCadastroAnuncio.petSelection = true;

    base.ctrlCadastroAnuncio.CarregarPaginaCadastroAnuncio = function () {

        $http({
            method: 'GET',
            url: base.servicePath + 'Page/CadastroAnuncio',
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            base.ctrlCadastroAnuncio.Animais = response.Animais.filter(x => x.Valor != "Cachorro" &&
                x.Valor != "Gato" &&
                x.Valor != "Roedores" &&
                x.Valor != "Aves")

            base.ctrlCadastroAnuncio.Sexos = response.Sexos;
            base.ctrlCadastroAnuncio.Idades = response.Idades;
            base.ctrlCadastroAnuncio.Portes = response.Portes;
            base.ctrlCadastroAnuncio.Pelos = response.Pelos;
            base.ctrlCadastroAnuncio.Cores = response.Cores;
            base.ctrlCadastroAnuncio.CoresSecundarias = response.Cores;
            base.ctrlCadastroAnuncio.Estados = response.Estados;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    base.ctrlCadastroAnuncio.CorPrimariaChange = function () {

        if (!base.StringIsEmpty(base.ctrlCadastroAnuncio.Cor1Pet)) {

            base.ctrlCadastroAnuncio.CoresSecundarias = base.ctrlCadastroAnuncio.Cores.filter(x => x.Chave != base.ctrlCadastroAnuncio.Cor1Pet);

        }

    }

    base.ctrlCadastroAnuncio.SelectPet = function (aPet) {
        if (aPet == 'Cachorro') {
            base.ctrlCadastroAnuncio.dogSelected = true;
            base.ctrlCadastroAnuncio.catSelected = false;
            base.ctrlCadastroAnuncio.hamsterSelected = false;
            base.ctrlCadastroAnuncio.birdSelected = false;
            base.ctrlCadastroAnuncio.othersSelected = false;
            base.ctrlCadastroAnuncio.petSelected = true;
            base.ctrlCadastroAnuncio.comboOutrosMostrar = false;

            base.ctrlCadastroAnuncio.PetSelecionado(1);

            base.ctrlCadastroAnuncio.outrosSelecionado = "";
        }
        else if (aPet == 'Gato') {
            base.ctrlCadastroAnuncio.dogSelected = false;
            base.ctrlCadastroAnuncio.catSelected = true;
            base.ctrlCadastroAnuncio.hamsterSelected = false;
            base.ctrlCadastroAnuncio.birdSelected = false;
            base.ctrlCadastroAnuncio.othersSelected = false;
            base.ctrlCadastroAnuncio.petSelected = true;
            base.ctrlCadastroAnuncio.comboOutrosMostrar = false;

            base.ctrlCadastroAnuncio.PetSelecionado(2);

            base.ctrlCadastroAnuncio.outrosSelecionado = "";
        }
        else if (aPet == 'Roedor') {
            base.ctrlCadastroAnuncio.dogSelected = false;
            base.ctrlCadastroAnuncio.catSelected = false;
            base.ctrlCadastroAnuncio.hamsterSelected = true;
            base.ctrlCadastroAnuncio.birdSelected = false;
            base.ctrlCadastroAnuncio.othersSelected = false;
            base.ctrlCadastroAnuncio.petSelected = true;
            base.ctrlCadastroAnuncio.comboOutrosMostrar = false;

            base.ctrlCadastroAnuncio.PetSelecionado(5);

            base.ctrlCadastroAnuncio.outrosSelecionado = "";
        }
        else if (aPet == 'Ave') {
            base.ctrlCadastroAnuncio.dogSelected = false;
            base.ctrlCadastroAnuncio.catSelected = false;
            base.ctrlCadastroAnuncio.hamsterSelected = false;
            base.ctrlCadastroAnuncio.birdSelected = true;
            base.ctrlCadastroAnuncio.othersSelected = false;
            base.ctrlCadastroAnuncio.petSelected = true;
            base.ctrlCadastroAnuncio.comboOutrosMostrar = false;

            base.ctrlCadastroAnuncio.PetSelecionado(3);

            base.ctrlCadastroAnuncio.outrosSelecionado = "";
        }
        else if (aPet == 'Outros') {
            base.ctrlCadastroAnuncio.ValidarComboOutros();
            base.ctrlCadastroAnuncio.comboOutrosMostrar = true;
            base.ctrlCadastroAnuncio.othersSelected = true;
            base.ctrlCadastroAnuncio.dogSelected = false;
            base.ctrlCadastroAnuncio.catSelected = false;
            base.ctrlCadastroAnuncio.birdSelected = false;
            base.ctrlCadastroAnuncio.hamsterSelected = false;
        }
    }

    base.ctrlCadastroAnuncio.PetSelecionado = function (aIdAnimal) {

        base.ctrlCadastroAnuncio.Animal = aIdAnimal;

        base.ctrlCadastroAnuncio.CmbRacaEspeciePet = "";

    }

    base.ctrlCadastroAnuncio.ValidarComboOutros = function () {
        if (base.StringIsEmpty(base.ctrlCadastroAnuncio.outrosSelecionado)) {
            base.ctrlCadastroAnuncio.petSelected = false;
        }
        else {
            base.ctrlCadastroAnuncio.petSelected = true;

            base.ctrlCadastroAnuncio.PetSelecionado(base.ctrlCadastroAnuncio.outrosSelecionado);
        }
    }

    base.ctrlCadastroAnuncio.PetEscolhido = function (aIsDoacao) {

        $http({
            method: 'GET',
            url: base.servicePath + 'Pet/BuscarRacaEspeciePorAnimal/' + base.ctrlCadastroAnuncio.Animal
        }).success(function (response) {

            base.ctrlCadastroAnuncio.Racas = response;

            if (aIsDoacao) {
                base.ctrlCadastroAnuncio.GoTo(3);
            }
            else {
                base.ctrlCadastroAnuncio.GoTo(2);
            }


        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    base.ctrlCadastroAnuncio.GoTo = function (number) {
        if (number == 1) {
            base.ctrlCadastroAnuncio.petSelection = true;
            base.ctrlCadastroAnuncio.petLocalizacao = false;
            base.ctrlCadastroAnuncio.petInfos1 = false;
            base.ctrlCadastroAnuncio.petObservacoes = false;
            base.ctrlCadastroAnuncio.petFotos = false;
            base.ctrlCadastroAnuncio.petInfosSaude = false;
        }
        else if (number == 2) {
            base.ctrlCadastroAnuncio.petSelection = false;
            base.ctrlCadastroAnuncio.petLocalizacao = true;
            base.ctrlCadastroAnuncio.petInfos1 = false;
            base.ctrlCadastroAnuncio.petObservacoes = false;
            base.ctrlCadastroAnuncio.petFotos = false;
            base.ctrlCadastroAnuncio.petInfosSaude = false;
        }
        else if (number == 3) {
            base.ctrlCadastroAnuncio.SetLocalizacao();
            base.ctrlCadastroAnuncio.petSelection = false;
            base.ctrlCadastroAnuncio.petLocalizacao = false;
            base.ctrlCadastroAnuncio.petInfos1 = true;
            base.ctrlCadastroAnuncio.petObservacoes = false;
            base.ctrlCadastroAnuncio.petFotos = false;
            base.ctrlCadastroAnuncio.petInfosSaude = false;
        }
        else if (number == 4) {
            base.ctrlCadastroAnuncio.petSelection = false;
            base.ctrlCadastroAnuncio.petLocalizacao = false;
            base.ctrlCadastroAnuncio.petInfos1 = false;
            base.ctrlCadastroAnuncio.petObservacoes = true;
            base.ctrlCadastroAnuncio.petFotos = false;
            base.ctrlCadastroAnuncio.petInfosSaude = false;
        }
        else if (number == 5) {
            base.ctrlCadastroAnuncio.petSelection = false;
            base.ctrlCadastroAnuncio.petLocalizacao = false;
            base.ctrlCadastroAnuncio.petInfos1 = false;
            base.ctrlCadastroAnuncio.petObservacoes = false;
            base.ctrlCadastroAnuncio.petFotos = true;
            base.ctrlCadastroAnuncio.petInfosSaude = false;
        }
        else if (number == 6) {
            base.ctrlCadastroAnuncio.petSelection = false;
            base.ctrlCadastroAnuncio.petLocalizacao = false;
            base.ctrlCadastroAnuncio.petInfos1 = false;
            base.ctrlCadastroAnuncio.petObservacoes = false;
            base.ctrlCadastroAnuncio.petFotos = false;
            base.ctrlCadastroAnuncio.petInfosSaude = true;
        }

        window.scrollTo(0, 0);
    }

    base.ctrlCadastroAnuncio.SetLocalizacao = function () {

        if (!base.StringIsEmpty(latitude) && !base.StringIsEmpty(longitude)) {

            base.ctrlCadastroAnuncio.Localizacao = {
                Latitude: latitude,
                Longitude: longitude
            }

        }
        else {

            base.ctrlCadastroAnuncio.Localizacao = null;

        }

    }

    base.ctrlCadastroAnuncio.EstadoSelecionadoChange = function () {

        if (!base.StringIsEmpty(base.ctrlCadastroAnuncio.EstadoPet)) {
            $http({
                method: 'GET',
                url: base.servicePath + 'Cidade/Combo/' + base.ctrlCadastroAnuncio.EstadoPet
            }).success(function (response) {

                base.ctrlCadastroAnuncio.Cidades = response;

            }).error(function (err, status) {

                base.ctrlCadastroAnuncio.Cidades = null;

                //TODO: Implementar tratamento de erro na base

            });
        }
        else {
            base.ctrlCadastroAnuncio.Cidades = null;
        }

    }

    base.ctrlCadastroAnuncio.BtnProximoInfoBasicas = function (aIsDoacao) {

        if (base.ctrlCadastroAnuncio.ValidarInfoBasicasPet()) {
            if (aIsDoacao) {
                base.ctrlCadastroAnuncio.GoTo(6);

            }
            else {
                base.ctrlCadastroAnuncio.GoTo(4);
            }
        }

    }

    base.ctrlCadastroAnuncio.ValidarInfoBasicasPet = function () {

        var contErro = 0;

        //Sexo
        if (base.StringIsEmpty(base.ctrlCadastroAnuncio.CmbSexoPet)) {
            base.ctrlCadastroAnuncio.sexoError = true;
            contErro++;
        }
        else {
            base.ctrlCadastroAnuncio.sexoError = false;
        }

        //Raça / Espécie
        if (base.StringIsEmpty(base.ctrlCadastroAnuncio.CmbRacaEspeciePet)) {
            base.ctrlCadastroAnuncio.racaError = true;
            contErro++;
        }
        else {
            base.ctrlCadastroAnuncio.racaError = false;
        }

        //Idade
        if (base.StringIsEmpty(base.ctrlCadastroAnuncio.CmbIdadePet)) {
            base.ctrlCadastroAnuncio.idadeError = true;
            contErro++;
        }
        else {
            base.ctrlCadastroAnuncio.idadeError = false;
        }

        //Porte
        if (base.StringIsEmpty(base.ctrlCadastroAnuncio.CmbPortePet)) {
            base.ctrlCadastroAnuncio.porteError = true;
            contErro++;
        }
        else {
            base.ctrlCadastroAnuncio.porteError = false;
        }

        //Pelo
        if (base.StringIsEmpty(base.ctrlCadastroAnuncio.CmbPeloPet)) {
            base.ctrlCadastroAnuncio.peloError = true;
            contErro++;
        }
        else {
            base.ctrlCadastroAnuncio.peloError = false;
        }

        //Cor 1
        if (base.StringIsEmpty(base.ctrlCadastroAnuncio.Cor1Pet)) {
            base.ctrlCadastroAnuncio.cor1error = true;
            contErro++;
        }
        else {
            base.ctrlCadastroAnuncio.cor1error = false;
        }

        //Cor 2
        if (base.StringIsEmpty(base.ctrlCadastroAnuncio.Cor2Pet)) {
            base.ctrlCadastroAnuncio.cor2error = true;
            contErro++;
        }
        else {
            base.ctrlCadastroAnuncio.cor2error = false;
        }

        //Estado
        if (base.StringIsEmpty(base.ctrlCadastroAnuncio.EstadoPet)) {
            base.ctrlCadastroAnuncio.estadoErro = true;
            contErro++;
        }
        else {
            base.ctrlCadastroAnuncio.estadoErro = false;
        }

        //Cidade
        if (base.StringIsEmpty(base.ctrlCadastroAnuncio.CidadePet)) {
            base.ctrlCadastroAnuncio.cidadeErro = true;
            contErro++;
        }
        else {
            base.ctrlCadastroAnuncio.cidadeErro = false;
        }

        return contErro == 0;

    }

    base.ctrlCadastroAnuncio.UploadImagens = function () {

        base.ctrlCadastroAnuncio.Cadastrando = true;

        $('#fine-uploader-validation').fineUploader('uploadStoredFiles');

    }

    base.ctrlCadastroAnuncio.DefinirFotoDestaque = function (aIdAnuncio) {

        $http({
            method: 'GET',
            url: base.servicePath + 'Anuncio/BuscarFotos/' + aIdAnuncio
        }).success(function (response) {

            base.ctrlCadastroAnuncio.FotosCadastradas = response;

            base.ctrlCadastroAnuncio.petSelection = false;
            base.ctrlCadastroAnuncio.petInfos1 = false;
            base.ctrlCadastroAnuncio.petInfosSaude = false;
            base.ctrlCadastroAnuncio.petObservacoes = false;
            base.ctrlCadastroAnuncio.petFotos = false;
            base.ctrlCadastroAnuncio.confirmacao = true;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    base.ctrlCadastroAnuncio.SelecionarFotoDestaque = function (aIdFoto) {

        $http({
            method: 'POST',
            url: base.servicePath + 'Anuncio/AlterarFotoDestaque/' + aIdFoto,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            base.ctrlCadastroAnuncio.FotosCadastradas = null;

            base.ctrlCadastroAnuncio.ImgDestaqueSucesso = true;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    //#endregion

    //#region .: Métodos Utilitários :.

    base.GenerateGuid = function () {

        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
                .toString(16)
                .substring(1);
        }

        return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();

    }

    base.recuperarQueryString = function (key) {

        var url = window.location.href;

        var parametros = url.substring(url.indexOf("?") + 1).split("&");

        for (var i = 0; i < parametros.length; i++) {

            var agrupamento = parametros[i].split("=");

            if (agrupamento[0] == key) {
                return agrupamento[1];
            }
        }

        return null;

    }

    //#endregion

    //#region .: Validações :.

    base.StringIsEmpty = function (aString) {
        return aString == "" || aString == null || aString == undefined;
    }

    base.EmailIsValid = function (aEmail) {

        if (aEmail == undefined) {
            return false;
        }

        var er = new RegExp(
            /^[A-Za-z0-9_\-\.]+@[A-Za-z0-9_\-\.]{2,}\.[A-Za-z0-9]{2,}(\.[A-Za-z0-9])?/
        );

        if (typeof aEmail == "string") {
            if (er.test(aEmail)) {
                return true;
            }
        }
        else if (typeof aEmail == "object") {
            if (er.test(aEmail.value)) {
                return true;
            }
        }
        else {
            return false;
        }

    }

    //#endregion

});