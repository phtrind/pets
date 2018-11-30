app.controller('doacoesRelatorioController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        ctrl.Buscando = true;

        var request = {
            IdUsuario: sessionStorage.getItem('IdUsuario')
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Page/RelatorioDoacoes',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Animais = response.Filtros.Animais;
            ctrl.Status = response.Filtros.Status;

            ctrl.Anuncios = response.Anuncios;

            if (!ctrl.Anuncios || ctrl.Anuncios.length < 1) {
                ctrl.nenhumaDoacao = true;
            }
            else {
                ctrl.nenhumaDoacao = false;
            }

        }).finally(function () {
            ctrl.Buscando = false;
        });
    }

    ctrl.FiltrarAnuncios = function () {

        ctrl.Buscando = true;

        var request = {
            IdUsuario: sessionStorage.getItem('IdUsuario'),
            Filtro: {
                Nome: ctrl.Nome,
                Animal: ctrl.Animal,
                DataCadastroInicio: ctrl.DthInicio,
                DataCadastroFim: ctrl.DthFim,
                Status: ctrl.StatusSelecionado
            }
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/RelatorioDoacoes',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Anuncios = response;

        }).finally(function () {
            ctrl.Buscando = false;
        });

    }

    ctrl.LimparFiltros = function () {

        ctrl.Nome = "";
        ctrl.Animal = "";
        ctrl.DthInicio = "";
        ctrl.DthFim = "";
        ctrl.StatusSelecionado = "";

        ctrl.FiltrarAnuncios();

    }

    ctrl.abrirAnuncio = function (aIdAnuncio) {

        window.open('../pet.html?idAnuncio=' + aIdAnuncio, '_blank');

    }

});