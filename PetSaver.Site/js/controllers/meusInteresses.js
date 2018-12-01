app.controller('meusInteressesController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        ctrl.Buscando = true;

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Page/Interesses/' + sessionStorage.getItem('IdUsuario'),
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Animais = response.Filtros.Animais;
            ctrl.TiposAnuncio = response.Filtros.TiposAnuncio;

            ctrl.Interesses = response.Interesses;

            if (!ctrl.Interesses || ctrl.Interesses.length < 1) {
                ctrl.nenhumInteresse = true;
            }
            else {
                ctrl.nenhumInteresse = false;
            }

        }).finally(function () {
            ctrl.Buscando = false;
        });
    }

    ctrl.FiltrarInteresses = function () {

        ctrl.Buscando = true;

        var request = {
            IdUsuario: sessionStorage.getItem('IdUsuario'),
            Nome: ctrl.Nome,
            IdAnimal: ctrl.Animal,
            IdTipoAnuncio: ctrl.TipoAnuncio
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/RelatorioInteresses',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Interesses = response;

        }).finally(function () {
            ctrl.Buscando = false;
        });

    }

    ctrl.LimparFiltros = function () {

        ctrl.Nome = "";
        ctrl.Animal = "";
        ctrl.TipoAnuncio = "";

        ctrl.FiltrarInteresses();

    }

    ctrl.abrirAnuncio = function (aIdAnuncio) {

        window.open('../pet.html?idAnuncio=' + aIdAnuncio, '_blank');

    }

});