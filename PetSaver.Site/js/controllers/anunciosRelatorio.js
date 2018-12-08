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

        }).error(function (err, status) {

            ctrl.Interessados = null;

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.BuscandoInteressados = false;

        });

        $("html, body").animate({ scrollTop: $('#tableAnuncios')[0].scrollHeight }, 1000);
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

    ctrl.BtnAlterarStatus = function (aIdAnuncio, aStatus, aInteressados) {

        if (!ctrl.HabilitarAlterarStatus(aStatus)) {
            return;
        }

        $('#modalAlterarStatus').modal('show');

        ctrl.selecaoStatus = true;
        ctrl.confirmacaoFinalizacao = false;
        ctrl.selecaoInteressado = false;
        ctrl.sucessoFinalizacao = false;

        ctrl.idAnuncioAlteracaoStatus = aIdAnuncio;
        ctrl.BtnConcretizarModalDisabled = aInteressados < 1;

    }

    ctrl.HabilitarAlterarStatus = function (aStatus) {

        return aStatus == 'Ativo' || aStatus == 'Em análise';

    }

    ctrl.BtnSelecaoStatus = function (aStatus) {

        if (aStatus == 'Finalizar' || aStatus == 'Cancelar') {

            ctrl.selecaoStatus = false;
            ctrl.confirmacaoFinalizacao = true;

            ctrl.StatusFinalizarModal = aStatus;

        }
        else if (aStatus == 'Concretizar') {

            ctrl.selecaoStatus = false;
            ctrl.confirmacaoFinalizacao = false;
            ctrl.selecaoInteressado = true;

        }

    }

    ctrl.BtnSelecionarSaver = function () {

        $('#modalAlterarStatus').modal('hide');

        $("html, body").animate({ scrollTop: $('#tableAnuncios')[0].scrollHeight }, 1000);

        ctrl.DetalharInteressados(ctrl.idAnuncioAlteracaoStatus, 1, 'Ativo');

        ctrl.idAnuncioAlteracaoStatus = null;

    }

    ctrl.FinalizarAnuncio = function () {

        ctrl.loadingFinalizacao = true;
        ctrl.confirmacaoFinalizacao = false;

        var request = {
            IdLogin: sessionStorage.getItem('IdLogin'),
            IdUsuario: sessionStorage.getItem('IdUsuario'),
            IdAnuncio: ctrl.idAnuncioAlteracaoStatus,
            Status: ctrl.StatusFinalizarModal
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/FinalizarAnuncio',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.sucessoFinalizacao = true;

            ctrl.FiltrarAnuncios();

            ctrl.Interessados = null;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.loadingFinalizacao = false;

        });

        ctrl.idAnuncioAlteracaoStatus = null;

    }

    ctrl.AbrirChat = function (aIdInteresse, aStatus) {

        if (aStatus != 'Em andamento') {
            return;
        }

        window.location.href = 'chats.html?idChat=' + aIdInteresse;

    }

});