app.controller('meusInteressesController', function ($controller, $http) {

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

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {
                ctrl.Buscando = false;
            });
        }

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

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

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

    ctrl.BtnCancelarInteresse = function (aIdAnuncio, aStatus) {

        if (aStatus == 'Em andamento') {
            ctrl.anuncioCancelamento = aIdAnuncio;

            $('#modalConfirmarCancelamento').modal('show');
        }

    }

    ctrl.CancelarInteresse = function () {

        $('#modalConfirmarCancelamento').modal('hide');

        var request = {
            IdUsuario: sessionStorage.getItem('IdUsuario'),
            IdLogin: sessionStorage.getItem('IdLogin'),
            IdInteresse: ctrl.anuncioCancelamento
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/CancelarInteresse',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function () {

            $('#modalConfirmacaoCancelamento').modal('show');

            ctrl.FiltrarInteresses();

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });
    }

    ctrl.AbrirChat = function (aIdInteresse, aStatus) {

        if (aStatus != 'Em andamento') {
            return;
        }

        window.location.href = 'chats.html?idChat=' + aIdInteresse;

    }

});