app.controller('petPerdidoCadastroController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        InitializeMap();

        ctrl.base.ctrlCadastroAnuncio.CarregarPaginaCadastroAnuncio();

    }

    ctrl.FinalizarCadastro = function () {

        var request = {
            IdUsuario: sessionStorage.getItem('IdUsuario'),
            Anuncio: {
                Pet: {
                    IdAnimal: ctrl.base.ctrlCadastroAnuncio.Animal,
                    Nome: ctrl.base.ctrlCadastroAnuncio.TxtNomePet,
                    IdSexo: ctrl.base.ctrlCadastroAnuncio.CmbSexoPet,
                    IdRacaEspecie: ctrl.base.ctrlCadastroAnuncio.CmbRacaEspeciePet,
                    IdIdade: ctrl.base.ctrlCadastroAnuncio.CmbIdadePet,
                    IdPorte: ctrl.base.ctrlCadastroAnuncio.CmbPortePet,
                    Peso: ctrl.base.ctrlCadastroAnuncio.TxtPesoPet,
                    IdPelo: ctrl.base.ctrlCadastroAnuncio.CmbPeloPet,
                    IdCorPrimaria: ctrl.base.ctrlCadastroAnuncio.Cor1Pet,
                    IdCorSecundaria: ctrl.base.ctrlCadastroAnuncio.Cor2Pet,
                    Vacinado: null,
                    Vermifugado: null,
                    Castrado: null,
                    Descricao: ctrl.base.ctrlCadastroAnuncio.TxtDescricaoPet
                },
                Localizacao: {
                    Latitude: latitude,
                    Longitude: longitude
                },
                IdEstado: ctrl.base.ctrlCadastroAnuncio.EstadoPet,
                IdCidade: ctrl.base.ctrlCadastroAnuncio.CidadePet,
                GuidImagens: guidAnuncio
            }
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/CadastrarPetPerdido',
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') },
            data: request
        }).success(function (response) {

            ctrl.base.ctrlCadastroAnuncio.DefinirFotoDestaque(response);

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.base.ctrlCadastroAnuncio.Cadastrando = false;

        });

    }

});