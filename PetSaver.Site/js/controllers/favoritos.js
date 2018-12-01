app.controller('favoritosController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

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

        }).finally(function () {
            ctrl.Buscando = false;
        });

    }

});