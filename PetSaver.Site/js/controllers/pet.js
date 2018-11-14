app.controller('petController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.isRegister = false;

    ctrl.OnInit = function () {

        if (!ctrl.base.StringIsEmpty(sessionStorage.getItem('IdAnuncioAtual'))) {

            var request = {
                IdAnuncio: sessionStorage.getItem('IdAnuncioAtual')
            };

            if (!ctrl.base.StringIsEmpty(sessionStorage.getItem('IdUsuario'))) {
                request.IdUsuario = sessionStorage.getItem('IdUsuario')
            }

            $http({
                method: 'POST',
                url: ctrl.base.servicePath + 'Page/Pet',
                data: request
            }).success(function (response) {

                ctrl.Anunciante = response.Anunciante;
                ctrl.Pet = response.Pet;
                ctrl.Localizacao = response.Localizacao;
                ctrl.Duvidas = response.Duvidas;
                ctrl.Gostei = response.Gostei;
                ctrl.StatusAnuncio = response.StatusAnuncio;

            }).error(function (err, status) {

                if (status == 400) {
                    //TODO: Mostrar mensagem que o anúncio não foi encontrado
                }
                else {
                    //TODO: Implementar tratamento de erro na base
                }

            });

        }
        else {
            //TODO: Mostrar mensagem que o anúncio não foi encontrado
        }

    }

});