app.controller('indexController', function ($controller, $http, $scope) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    var pagina = 1;

    var scrollLiberado = true;

    var proximaPaginaLiberada = true;

    ctrl.OnInit = function () {

        ctrl.Buscando = true;

        var estado = ctrl.base.recuperarQueryString("estado");
        var cidade = ctrl.base.recuperarQueryString("cidade");
        var pet = ctrl.base.recuperarQueryString("pet");
        var sexo = ctrl.base.recuperarQueryString("sexo");
        var tipo = ctrl.base.recuperarQueryString("tipo");

        if (!ctrl.base.StringIsEmpty(tipo)) {
            ctrl.TipoAnuncio = tipo;
        }

        var request = {
            IdEstado: estado,
            IdCidade: cidade,
            IdAnimal: pet,
            IdSexo: sexo,
            IdTipo: tipo,
            Quantidade: 12,
            Pagina: pagina
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Page/Anuncios',
            data: request
        }).success(function (response) {

            ctrl.Anuncios = response.Anuncios;
            ctrl.Estados = response.Filtros.Estados;
            ctrl.Animais = response.Filtros.Animais;
            ctrl.Sexos = response.Filtros.Sexos;
            ctrl.Pelos = response.Filtros.Pelos;
            ctrl.Idades = response.Filtros.Idades;
            ctrl.Cores = response.Filtros.Cores;
            ctrl.Portes = response.Filtros.Portes;

            if (!ctrl.base.StringIsEmpty(estado)) {
                ctrl.Estado = estado;
                ctrl.EstadoSelecionadoChange();
            }

            if (!ctrl.base.StringIsEmpty(cidade)) {
                ctrl.Cidade = cidade;
            }

            if (!ctrl.base.StringIsEmpty(pet)) {
                ctrl.Animal = pet;
                ctrl.AnimalSelecionadoChange();
            }

            if (!ctrl.base.StringIsEmpty(sexo)) {
                ctrl.Sexo = sexo;
            }

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.Buscando = false;

        });

    }

    ctrl.AnimalSelecionadoChange = function () {

        if (!ctrl.base.StringIsEmpty(ctrl.Animal)) {

            $http({
                method: 'GET',
                url: ctrl.base.servicePath + 'Pet/BuscarRacaEspeciePorAnimal/' + ctrl.Animal
            }).success(function (response) {

                ctrl.RacasEspecies = response;
                ctrl.RacaEspecie = "";

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            });

            if (ctrl.Animal == "1" || ctrl.Animal == "2") {
                ctrl.LabelRacaEspecie = "Raça";
            }
            else {
                ctrl.LabelRacaEspecie = "Espécie";
            }
        }
        else {
            ctrl.Sexo = "";
            ctrl.RacaEspecie = "";
            ctrl.Pelo = "";
            ctrl.Idade = "";
            ctrl.Core = "";
            ctrl.Porte = "";
            ctrl.RacasEspecies = null;
        }

    }

    ctrl.EstadoSelecionadoChange = function () {

        if (!ctrl.base.StringIsEmpty(ctrl.Estado)) {
            $http({
                method: 'GET',
                url: ctrl.base.servicePath + 'Cidade/Combo/' + ctrl.Estado
            }).success(function (response) {

                ctrl.Cidades = response;

            }).error(function (err, status) {

                ctrl.Cidades = null;

                //TODO: Implementar tratamento de erro na base

            });
        }
        else {
            ctrl.Cidades = null;
        }

    }

    ctrl.AplicarFiltros = function () {

        ctrl.BuscarAnuncios(1, 12, false);

        pagina = 1;

        proximaPaginaLiberada = true;

    }

    ctrl.LimparFiltros = function () {

        ctrl.Estado = "";
        ctrl.Cidade = "";
        ctrl.Animal = "";
        ctrl.Sexo = "";
        ctrl.RacaEspecie = "";
        ctrl.Pelo = "";
        ctrl.Idade = "";
        ctrl.Cor = "";
        ctrl.Porte = "";
        ctrl.Nome = "";

        ctrl.BuscarAnuncios(1, 12, false);

        pagina = 1;

        proximaPaginaLiberada = true;

    }

    ctrl.BuscarAnuncios = function (aPagina, aQuantidade, aAdicionar) {

        ctrl.Buscando = true;

        var request = {
            IdEstado: ctrl.Estado,
            IdCidade: ctrl.Cidade,
            IdAnimal: ctrl.Animal,
            IdSexo: ctrl.Sexo,
            IdPorte: ctrl.Porte,
            IdRacaEspecie: ctrl.RacaEspecie,
            IdPelo: ctrl.Pelo,
            IdIdade: ctrl.Idade,
            IdCor: ctrl.Cor,
            Nome: ctrl.Nome,
            IdTipo: ctrl.TipoAnuncio,
            Quantidade: aQuantidade,
            Pagina: aPagina,
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/BuscarAnuncios/',
            data: request
        }).success(function (response) {

            if (aAdicionar) {
                ctrl.Anuncios = ctrl.Anuncios.concat(response);
            }
            else {
                ctrl.Anuncios = response;
            }

            if (response.length <= 0) {
                proximaPaginaLiberada = false;
            }


        }).error(function (err, status) {

            ctrl.Anuncios = null;

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.Buscando = false;

            scrollLiberado = true;

        });

    }

    ctrl.CadastrarAnuncio = function (tipoAnuncio) {

        if (!ctrl.base.IsLogged()) {
            ctrl.base.AbrirModalLogin();
            $('#modalLogarCadastrar').modal('show');
        }
        else {
            if (tipoAnuncio == "doacao") {
                document.location.href = "conta/doacoes_cadastro.html";
            }
            else if (tipoAnuncio == "petPerdido") {
                document.location.href = "conta/petperdido_cadastro.html";
            }
            else if (tipoAnuncio == "petEncontrado") {
                document.location.href = "conta/petencontrado_cadastrar.html";
            }
        }
    }

    ctrl.CarregarProximaPagina = function () {

        if (scrollLiberado && proximaPaginaLiberada) {

            ctrl.BuscarAnuncios(pagina + 1, 12, true);

            pagina++;

            scrollLiberado = false;
        }
    }

});