app.controller('favoritosController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        if (!ctrl.base.IsLogged()) {
            ctrl.base.LimparSessionAuth();

            window.location.href = '../home.html';
        }
        else {
            ctrl.Buscando = true;

            $http({
                method: 'GET',
                url: ctrl.base.servicePath + 'Page/Favoritos/' + sessionStorage.getItem('IdUsuario'),
                headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
            }).success(function (response) {

                ctrl.Anuncios = response;

                if (!ctrl.Anuncios || ctrl.Anuncios.length < 1) {
                    ctrl.nenhumInteresse = true;
                }
                else {
                    ctrl.nenhumInteresse = false;
                }

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {
                ctrl.Buscando = false;
            });
        }

    }

});