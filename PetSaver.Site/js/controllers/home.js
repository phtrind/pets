app.controller('homeController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.isRegister = false;

    $('#modalSaibaMaisA').on('hidden.bs.modal', function () {
        ctrl.isRegister = true;
    });

    $('#modalSaibaMaisB').on('hidden.bs.modal', function () {
        ctrl.isRegister = true;
    });

    $('#modalSaibaMaisC').on('hidden.bs.modal', function () {
        ctrl.isRegister = true;
    });

    ctrl.OnInit = function () {

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Page/Home'
        }).success(function (response) {

            ctrl.Anuncios = response.Anuncios;
            ctrl.Estados = response.Filtros.Estados;
            ctrl.Animais = response.Filtros.Animais;
            ctrl.Sexos = response.Filtros.Sexos;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    ctrl.EstadoSelecionadoChange = function () {

        if (!ctrl.base.StringIsEmpty(ctrl.Estado)) {
            $http({
                method: 'GET',
                url: ctrl.base.servicePath + 'Cidade/Combo/' + ctrl.Estado
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

    ctrl.BuscarAnuncios = function () {

        var parameters = "";
        var url = "index.html";

        if (!ctrl.base.StringIsEmpty(ctrl.Estado)) {
            parameters = parameters + "estado=" + ctrl.Estado + "&";
        }

        if (!ctrl.base.StringIsEmpty(ctrl.Cidade)) {
            parameters = parameters + "cidade=" + ctrl.Cidade + "&";
        }

        if (!ctrl.base.StringIsEmpty(ctrl.Animal)) {
            parameters = parameters + "pet=" + ctrl.Animal + "&";
        }

        if (!ctrl.base.StringIsEmpty(ctrl.Sexo)) {
            parameters = parameters + "sexo=" + ctrl.Sexo;
        }

        if (!ctrl.base.StringIsEmpty(parameters)) {

            if (parameters[parameters.length - 1] == "&") {
                parameters = parameters.substring(0, parameters.length - 1);
            }

            url = url + "?" + parameters;

        }

        document.location.href = url;

    }

});