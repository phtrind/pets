app.controller('dashboardController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        if (!ctrl.base.IsLoggedFuncionario()) {
            ctrl.base.LimparSessionAuth();

            window.location.href = 'login.html';
        }
        else {
            ctrl.Loading = true;

            $http({
                method: 'GET',
                url: ctrl.base.servicePath + 'Page/Webad/Dashboard',
                headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
            }).success(function (response) {

                ctrl.QuantidadeAnunciosAtivos = response.QuantidadeAnunciosAtivos;
                ctrl.QuantidadeAnunciosPendentes = response.QuantidadeAnunciosPendentes;
                ctrl.QuantidadeInteracoes = response.QuantidadeInteracoes;
                ctrl.QuantidadeFaleConosco = response.QuantidadeFaleConosco;

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {

                ctrl.Loading = false;

            });

        }

    }

});