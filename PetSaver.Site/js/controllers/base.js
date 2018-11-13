app.controller('baseController', function ($http) {

    var base = this;

    base.servicePath = "http://localhost/PetSaver.WebApi/api/";
    //var servicePath = "http://localhost/PetSaver.WebApi/api/";

    //#region .: Login :.

    base.AbrirModalLogin = function () {
        base.isRegister = false;
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
                sessionStorage.setItem("DataHoraAutenticacao", new Date().toLocaleString());
                sessionStorage.setItem("TokenExpiresIn", response.expires_in);

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

            base.NomeUsuario = response.Nome;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    base.IsLogged = function () {

        return !base.StringIsEmpty(sessionStorage.getItem('Token'));

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