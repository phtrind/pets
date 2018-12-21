app.controller('faleConoscoController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        if (!ctrl.base.IsLoggedFuncionario()) {
            ctrl.base.LimparSessionAuth();

            window.location.href = 'login.html';
        }
        else {
            ctrl.Buscando = true;

            $http({
                method: 'GET',
                url: ctrl.base.servicePath + 'Page/Webad/AnunciosPendentes',
                headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
            }).success(function (response) {

                ctrl.Anuncios = response;

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {

                ctrl.Buscando = false;

            });

        }

    }

    ctrl.DetalharAnuncio = function (aIdAnuncio) {

        ctrl.BuscandoDetalhes = true;

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Anuncio/DetalharAnuncioAprovacao/' + aIdAnuncio,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Detalhes = response;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.BuscandoDetalhes = false;

        });

        $("html, body").animate({ scrollTop: $('#tableAnuncios')[0].scrollHeight }, 1000);

    }

    ctrl.FecharDetalhes = function () {

        ctrl.Detalhes = null;

        $("html, body").animate({ scrollTop: $('html').offset().top }, 1000);

    }

    ctrl.AprovarAnuncio = function (aIdAnuncio) {

        ctrl.Aprovando = true;

        var request = {
            IdLogin: sessionStorage.getItem('IdLogin'),
            IdFuncionario: sessionStorage.getItem('IdFuncionario'),
            IdAnuncio: aIdAnuncio
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/AtivarAnuncio',
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') },
            data: request
        }).success(function (response) {

            $('#modalConfirmacaoAtivacao').modal('hide');
            $('#modalSucessoAtivacao').modal('show');

            ctrl.FecharDetalhes();

            ctrl.OnInit();

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.Aprovando = false;

        });

    }

    ctrl.AbrirModalConfirmacao = function () {

        $('#modalConfirmacaoAtivacao').modal('show');

    }

});