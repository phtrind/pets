app.controller('doacoesRelatorioController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    // $scope.nenhumaDoacao = true;

    ctrl.OnInit = function () {

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

        })
    }

});