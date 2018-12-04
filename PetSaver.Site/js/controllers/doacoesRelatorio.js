﻿app.controller('doacoesRelatorioController', function ($controller, $http) {

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

        ctrl.FiltrarAnuncios();

    }

    ctrl.abrirAnuncio = function (aIdAnuncio) {

        window.open('../pet.html?idAnuncio=' + aIdAnuncio, '_blank');

    }

    ctrl.DetalharInteressados = function (aIdAnuncio, aInteressados, aStatus) {

        if (aInteressados < 1 || aStatus != 'Ativo') {
            return;
        }

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Anuncio/BuscarInteressados/' + aIdAnuncio,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Interessados = response;

        }).error(function (err, status) {

            ctrl.Interessados = null;

            //TODO: Implementar tratamento de erro na base

        });

    }

});