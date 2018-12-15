app.controller('loginController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.FazerLogin = function () {

        if (ctrl.ValidarCampos() != 0) {
            return;
        }

        ctrl.Logando = true;

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'token',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            data: "grant_type=password&username=" + ctrl.usuario + "&password=" + ctrl.senha
        }).success(function (response) {

            ctrl.VerificarFuncionario(response.access_token);

            //sessionStorage.setItem("Token", response.access_token);

        }).error(function (err, status) {

            ctrl.Logando = false;

            sessionStorage.clear();

            if (status == 400) {
                ctrl.loginIncorreto = true;
                ctrl.usuario = null;
                ctrl.senha = null;
            }
            else {
                //TODO: Implementar tratamento de erro na base
            }

        });

    }

    ctrl.VerificarFuncionario = function (aToken) {

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Funcionario/Verificar/' + ctrl.usuario + '/',
            headers: { 'Authorization': 'Bearer ' + aToken }
        }).success(function (response) {

            if (!response.IsFuncionario) {
                ctrl.loginIncorreto = true;
                ctrl.usuario = null;
                ctrl.senha = null;

                return;
            }

            sessionStorage.setItem("Token", aToken);
            sessionStorage.setItem("IdLogin", response.IdLogin);
            sessionStorage.setItem("IdFuncionario", response.IdFuncionario);
            sessionStorage.setItem("Nome", response.Nome);
            sessionStorage.setItem("DthValidadeToken", response.DthValidadeToken);

            window.location = "dashboard.html";

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.Logando = false;

        });

    }

    ctrl.ValidarCampos = function () {

        var contErro = 0;

        if (ctrl.base.StringIsEmpty(ctrl.usuario)) {
            ctrl.erroUsuario = true;
            contErro++;
        }
        else {
            ctrl.erroUsuario = false;
        }

        if (ctrl.base.StringIsEmpty(ctrl.senha)) {
            ctrl.erroSenha = true;
            contErro++;
        }
        else {
            ctrl.erroSenha = false;
        }

        return contErro;
    }

});