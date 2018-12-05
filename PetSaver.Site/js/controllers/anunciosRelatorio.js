app.controller('anunciosRelatorioController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        if (!ctrl.base.IsLogged()) {
            ctrl.base.LimparSessionAuth();

            window.location.href = '../home.html';
        }
        else {
            ctrl.Buscando = true;

            var request = {
                IdUsuario: sessionStorage.getItem('IdUsuario')
            };

            $http({
                method: 'POST',
                url: ctrl.base.servicePath + 'Page/RelatorioAnuncios',
                data: request,
                headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
            }).success(function (response) {

                ctrl.Animais = response.Filtros.Animais;
                ctrl.Status = response.Filtros.Status;
                ctrl.TiposAnuncios = response.Filtros.TiposAnuncio;

                ctrl.Anuncios = response.Anuncios;

                if (!ctrl.Anuncios || ctrl.Anuncios.length < 1) {
                    ctrl.nenhumaDoacao = true;
                }
                else {
                    ctrl.nenhumaDoacao = false;
                }

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {
                ctrl.Buscando = false;
            });
        }

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
                Status: ctrl.StatusSelecionado,
                TipoAnuncio: ctrl.TipoAnuncioSelecionado
            }
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/RelatorioAnuncios',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Anuncios = response;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

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
        ctrl.TipoAnuncioSelecionado = "";

        ctrl.FiltrarAnuncios();

    }

    ctrl.abrirAnuncio = function (aIdAnuncio) {

        window.open('../pet.html?idAnuncio=' + aIdAnuncio, '_blank');

    }

    ctrl.DetalharInteressados = function (aIdAnuncio, aInteressados, aStatus) {

        if (aInteressados < 1 || aStatus != 'Ativo' || ctrl.Buscando) {
            return;
        }

        ctrl.BuscandoInteressados = true;

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Anuncio/BuscarInteressados/' + aIdAnuncio,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Interessados = response;

            $("html, body").animate({ scrollTop: $('#tableAnuncios')[0].scrollHeight }, 1000);

        }).error(function (err, status) {

            ctrl.Interessados = null;

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.BuscandoInteressados = false;

        });

    }

    ctrl.ConcretizarDoacao = function (aIdInteresse, aStatus) {

        if (aStatus != 'Em andamento') {
            return;
        }

        ctrl.interesseConcretizacao = aIdInteresse;

        $('#modalConfirmarConcretizacao').modal('show');

    }

    ctrl.ConfirmarConcretizacaoDoacao = function () {

        var request = {
            IdUsuario: sessionStorage.getItem('IdUsuario'),
            IdLogin: sessionStorage.getItem('IdLogin'),
            IdInteresse: ctrl.interesseConcretizacao
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/ConcretizarInteresse',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.FiltrarAnuncios();

            $('#modalConfirmarConcretizacao').modal('hide');

            $('#modalConfirmacaoConcretizacao').modal('show');

            ctrl.Interessados = null;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    ctrl.FecharInteresses = function () {

        ctrl.Interessados = null

        $("html, body").animate({ scrollTop: $('html').offset().top }, 1000);

    }

});