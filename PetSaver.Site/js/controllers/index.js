app.controller('indexController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        //TODO: Implementar inicialização a partir do filtro da tela anterior

        var request = {
            Quantidade: 16,
            Pagina: 1
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Page/Anuncios',
            data: request
        }).success(function (response) {

            ctrl.Anuncios = response.Anuncios;
            ctrl.Estados = response.Filtros.Estados;
            ctrl.Animais = response.Filtros.Animais;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    ctrl.AnimalSelecionadoChange = function () {

        if (!ctrl.base.StringIsEmpty(ctrl.Animal)) {

            //TODO: implementar busca de filtros especificos do animal
            //TODO: implementar busca dos demais filtros 

            if (ctrl.Animal == "1" || ctrl.Animal == "2") {
                ctrl.LabelRacaEspecie = "Raça";
            }
            else {
                ctrl.LabelRacaEspecie = "Espécie";
            }
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

});