app.controller('baseController', function ($http) {

    var base = this;

    base.servicePath = "http://localhost/PetSaver.WebApi/api/";
    //var servicePath = "http://localhost/PetSaver.WebApi/api/";

    //#region .: Login / Cadastro Básico :.

    base.AbrirModalLogin = function () {

        base.isRegister = false;

    }

    base.IsLogged = function () {

        if (!base.StringIsEmpty(sessionStorage.getItem('Token')) &&
            !base.StringIsEmpty(sessionStorage.getItem('IdUsuario')) &&
            !base.StringIsEmpty(sessionStorage.getItem('DthValidadeToken')) &&
            base.ValidarToken()) {

            //TODO: Mostrar modal informando que o login expirou

            return true;

        }
        else {

            base.LimparSessionAuth();

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

            }).error(function (err, status) {

                sessionStorage.clear();

                if (status == 400) {
                    base.EmailLogin = "";
                    base.SenhaLogin = "";
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