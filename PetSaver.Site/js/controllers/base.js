app.controller('baseController', function ($http) {

    var base = this;

    //#region .: Variáveis Globais :.

    base.servicePath = "http://localhost/PetSaver.WebApi/api/";
    //base.servicePath = "http://www.petsaver.com.br/api/";

    //#endregion

    //#region .: Login / Cadastro Básico :.

    base.getNomeUsuario = function () {
        return sessionStorage.getItem('Nome');
    }

    base.AbrirModalLogin = function () {

        base.isRegister = false;

        base.ErroEmailEsqueciSenhaInvalido = false;
        base.ErroEmailEsqueciSenha = false;
        base.ErroEmailEsqueciSenhaInexistente = false;
        base.EmailEsqueciSenha = '';

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
        sessionStorage.removeItem('DataHoraAutenticacao');
        sessionStorage.removeItem('TokenExpiresIn');

    }

    base.FazerLogoff = function () {

        base.LimparSessionAuth();

    }

    base.FazerLogoffInside = function () {

        base.LimparSessionAuth();

        window.location.href = '../home.html';

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

        //E-mail existente
        $http({
            method: 'GET',
            url: base.servicePath + 'Login/VerificarEmailExistente/' + base.EmailCadastro + '/'
        }).success(function (response) {

            if (response == true) {
                base.ErroEmailCadastro = true;
                base.ErroEmailCadastroExistente = true;
                contErro++;
            }
            else {
                base.ErroEmailCadastroExistente = false;
            }

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

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
        if (!base.DthNascimentoIsValid(base.DthNascimentoCadastro)) {
            base.ErroDthNascimentoCadastro = true;
            contErro++;
        }
        else {
            base.ErroDthNascimentoCadastro = false;
        }

        //Email
        if (base.EmailIsValid(base.EmailCadastro)) {
            base.ErroEmailCadastro1 = false;
        }
        else {
            base.ErroEmailCadastro = true;
            base.ErroEmailCadastro1 = true;
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
        else if (base.SenhaCadastro.length < 6) {
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

                    base.BuscarInformacoesSession(request.Email);

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

    base.EsqueceuSenha = function () {

        $('#modalLogarCadastrar').modal('hide');
        $('#modalEsqueciSenha').modal('show');

    }

    base.ConfirmarEsqueceuSenha = function () {

        base.RecuperandoSenha = true;

        if (!base.EmailIsValid(base.EmailEsqueciSenha)) {
            base.ErroEmailEsqueciSenhaInvalido = true;
            base.ErroEmailEsqueciSenha = true;

            base.RecuperandoSenha = false;
        }
        else {
            base.ErroEmailEsqueciSenhaInvalido = false;
            base.ErroEmailEsqueciSenha = false;

            $http({
                method: 'GET',
                url: base.servicePath + 'Login/EsqueceuSenha/' + base.EmailEsqueciSenha + '/',
            }).success(function (response) {

                $('#modalEsqueciSenha').modal('hide');
                $('#modalEsqueciSenhaSucesso').modal('show');

                base.EmailEsqueciSenha = '';

            }).error(function (err, status) {

                if (status == 400) {
                    base.ErroEmailEsqueciSenhaInexistente = true;
                    base.ErroEmailEsqueciSenha = true;
                }
                else {
                    //TODO: Implementar tratamento de erro na base
                }

            }).finally(function () {

                base.RecuperandoSenha = false;

            });

        }

    }

    //#endregion

    //#region .: Header :.

    base.btnQueroDoar = function () {

        if (base.IsLogged()) {
            window.location.href = "conta/doacoes_cadastro.html";
        }
        else {
            base.AbrirModalLogin();
            $('#modalLogarCadastrar').modal('show');
        }

    }

    base.btnPerdiPet = function () {

        if (base.IsLogged()) {
            window.location.href = "conta/petperdido_cadastro.html";
        }
        else {
            base.AbrirModalLogin();
            $('#modalLogarCadastrar').modal('show');
        }

    }

    base.btnEncontreiPet = function () {

        if (base.IsLogged()) {
            window.location.href = "conta/petencontrado_cadastrar.html";
        }
        else {
            base.AbrirModalLogin();
            $('#modalLogarCadastrar').modal('show');
        }

    }

    //#endregion

    //#region .: Anúncios :.

    base.AbrirAnuncio = function (aIdAnuncio) {
        window.location.href = "pet.html?idAnuncio=" + aIdAnuncio;
    }

    base.AbrirAnuncioConta = function (aIdAnuncio) {
        window.location.href = "../pet.html?idAnuncio=" + aIdAnuncio;
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

    base.ctrlCadastroAnuncio.ValidarPeso = function () {

        base.ctrlCadastroAnuncio.TxtPesoPet = base.ctrlCadastroAnuncio.TxtPesoPet.replace(/\D/g, '');

    }

    //#endregion

    //#region .: Relatório Anúncios :.

    base.buscarStyleStatus = function (aStatus) {

        if (aStatus === 'Em análise') {
            return 'badge-info';
        }
        else if (aStatus === 'Ativo') {
            return 'badge-success';
        }
        else if (aStatus === 'Cancelado') {
            return 'badge-danger';
        }
        else if (aStatus === 'Adotado') {
            return 'badge-primary';
        }
        else if (aStatus === 'Finalizado') {
            return 'badge-secondary';
        }
        else if (aStatus === 'Lar provisório') {
            return 'badge-primary';
        }
        else if (aStatus === 'De volta ao lar') {
            return 'badge-primary';
        }

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

    base.DthNascimentoIsValid = function (aDthNascimento) {

        if (base.StringIsEmpty(aDthNascimento)) {
            return false;
        }

        var date = new Date(aDthNascimento);

        var today = new Date().setDate(0, 0, 0, 0);

        return date < today;

    }

    //#endregion

    //#region .: Fale conosco :.

    base.BtnFaleConoscoClick = function () {

        base.EmailFaleConosco = '';
        base.MensagemFaleConosco = '';
        base.ErroEmailFaleConsco = false;
        base.ErroMensagemFaleConsco = false;

        $('#modalFaleConosco').modal('show');

    }

    base.EnviarMensagemFaleConosco = function () {

        if (base.ValidarMensagemFaleConosco()) {

            base.EnviandoFaleConosco = true;

            var request = {
                IdUsuario: sessionStorage.getItem('IdUsuario'),
                Email: base.EmailFaleConosco == '' ? null : base.EmailFaleConosco,
                Mensagem: base.MensagemFaleConosco
            };

            $http({
                method: 'POST',
                url: base.servicePath + 'FaleConosco',
                data: request
            }).success(function (response) {

                $('#modalFaleConosco').modal('hide');
                $('#modalFaleConoscoSucesso').modal('show');

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {

                base.EnviandoFaleConosco = false;

            });

        }

    }

    base.ValidarMensagemFaleConosco = function () {

        var contErro = 0;

        if (!base.IsLogged() && !base.EmailIsValid(base.EmailFaleConosco)) {
            base.ErroEmailFaleConsco = true;
            contErro++;
        }
        else {
            base.ErroEmailFaleConsco = false;
        }

        if (base.StringIsEmpty(base.MensagemFaleConosco)) {
            base.ErroMensagemFaleConsco = true;
            contErro++;
        }
        else {
            base.ErroEmailFaleConsco = false;
        }

        return contErro == 0;

    }

    //#endregion

    base.BtnFaqClick = function () {

        window.open('faq.html', '_blank');

    }
});