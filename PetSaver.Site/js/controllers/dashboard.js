app.controller('dashboardController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        if (!ctrl.base.IsLogged()) {
            ctrl.base.LimparSessionAuth();

            window.location.href = '../home.html';
        }
        else {

            $http({
                method: 'GET',
                url: ctrl.base.servicePath + 'Page/Dashboard/' + sessionStorage.getItem('IdUsuario'),
                headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
            }).success(function (response) {

                ctrl.QuantidadeAnuncios = response.QuantidadeAnuncios;
                ctrl.QuantidadeFavoritos = response.QuantidadeFavoritos;
                ctrl.QuantidadeInteracoes = response.QuantidadeInteracoes;

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            });

        }

    }

});