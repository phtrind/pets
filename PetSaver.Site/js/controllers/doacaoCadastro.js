app.controller('daocaoCadastroController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.perguntaVacinado = true;
    ctrl.SaudePendente = true;

    ctrl.OnInit = function () {

        ctrl.base.ctrlCadastroAnuncio.CarregarPaginaCadastroAnuncio();

    }

    ctrl.RespostaVacinado = function (aResposta) {

        ctrl.Vacinado = aResposta;

        ctrl.perguntaVacinado = false;
        ctrl.perguntaVermifugado = true;

    }

    ctrl.RespostaVermifugado = function (aResposta) {

        ctrl.Vermifugado = aResposta;

        ctrl.perguntaVermifugado = false;
        ctrl.perguntaCastrado = true;

    }

    ctrl.RespostaCastrado = function (aResposta) {

        ctrl.Castrado = aResposta;

        ctrl.perguntaCastrado = false;
        ctrl.perguntaVacinado = true;

        ctrl.SaudePendente = false;

        ctrl.base.ctrlCadastroAnuncio.GoTo(4);

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
                    Peso: ctrl.base.ctrlCadastroAnuncio.TxtPesoPet ? ctrl.base.ctrlCadastroAnuncio.TxtPesoPet.replace(",", ".") : null,
                    IdPelo: ctrl.base.ctrlCadastroAnuncio.CmbPeloPet,
                    IdCorPrimaria: ctrl.base.ctrlCadastroAnuncio.Cor1Pet,
                    IdCorSecundaria: ctrl.base.ctrlCadastroAnuncio.Cor2Pet,
                    Vacinado: ctrl.Vacinado,
                    Vermifugado: ctrl.Vermifugado,
                    Castrado: ctrl.Castrado,
                    Descricao: ctrl.base.ctrlCadastroAnuncio.TxtDescricaoPet
                },
                IdEstado: ctrl.base.ctrlCadastroAnuncio.EstadoPet,
                IdCidade: ctrl.base.ctrlCadastroAnuncio.CidadePet,
                GuidImagens: guidAnuncio
            }
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/CadastrarDoacao',
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