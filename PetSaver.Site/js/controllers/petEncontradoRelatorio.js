app.controller('petEncontradoRelatorioController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    // $scope.nenhumPetEncontrado = true;

    ctrl.OnInit = function () {

        // TODO: ALTERAR NOME IdAnuncioAtual e IdUsuario PARA O CORRETO
        if (!ctrl.base.StringIsEmpty(sessionStorage.getItem('IdAnuncioAtual'))) {

            if (!ctrl.base.StringIsEmpty(sessionStorage.getItem('IdUsuario'))) {
                request.IdUsuario = sessionStorage.getItem('IdUsuario')
            }

            $http({
                method: 'POST',
                url: ctrl.base.servicePath + 'Page/conta/petencontrado_relatorio',
                data: request
            }).success(function (response) {

                ctrl.Pet.Nome = response.Nome;
                ctrl.Pet.RacaEspecie = response.RacaEspecie;
                ctrl.Pet.Status = response.Status;
            })
                }
    }

});