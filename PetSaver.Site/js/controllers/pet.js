app.controller('petController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.isRegister = false;

    var idAnuncio = null;

    ctrl.OnInit = function () {

        idAnuncio = ctrl.base.recuperarQueryString("idAnuncio");

        if (!ctrl.base.StringIsEmpty(idAnuncio)) {

            var request = {
                IdAnuncio: idAnuncio
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
                ctrl.TipoAnuncio = response.TipoAnuncio;

                if (ctrl.Anunciante.Id == sessionStorage.getItem('IdUsuario')) {
                    ctrl.DonoAuncio = true;
                }
                else {
                    ctrl.Duvidas = ctrl.Duvidas.filter(x => x.Resposta && x.Resposta.length > 0);
                    ctrl.DonoAuncio = false;
                }

                if (ctrl.StatusAnuncio != "Ativo") {
                    $('#modalStatusAnuncio').modal('show');
                    ctrl.HabilitarAcoes = false;
                }
                else {
                    ctrl.HabilitarAcoes = response.HabilitarAcoes;
                }

                if (ctrl.TipoAnuncio != "Doação") {
                    ctrl.MostarGostei = false;
                }
                else {
                    ctrl.MostarGostei = true;
                }


                if (ctrl.Pet.Sexo == "Fêmea") {
                    ctrl.preGenero = "a";
                }
                else {
                    ctrl.preGenero = "o";
                }

                if (ctrl.Pet.Nome == "Desconhecido") {
                    if (ctrl.TipoAnuncio == "Doação") {
                        ctrl.btnInteresseText = "Quero adotar";
                    }
                    else if (ctrl.TipoAnuncio == "Pet perdido") {
                        ctrl.btnInteresseText = "Encontrei esse pet!";
                    }
                    else if (ctrl.TipoAnuncio == "Pet encontrado") {
                        ctrl.btnInteresseText = "Esse pet é meu!";
                    }
                }
                else {
                    if (ctrl.TipoAnuncio == "Doação") {
                        ctrl.btnInteresseText = "Quero adotar " + ctrl.preGenero + " " + ctrl.Pet.Nome;
                    }
                    else if (ctrl.TipoAnuncio == "Pet perdido") {
                        ctrl.btnInteresseText = "Encontrei " + ctrl.preGenero + " " + ctrl.Pet.Nome;
                    }
                    else if (ctrl.TipoAnuncio == "Pet encontrado") {
                        ctrl.btnInteresseText = "Estou procurando " + ctrl.preGenero + " " + ctrl.Pet.Nome;
                    }
                }

                ctrl.FotoDestaque = response.Pet.Fotos.filter(x => x.Chave == "True")[0];
                ctrl.Fotos = response.Pet.Fotos.filter(x => x.Chave != "True");

                if (response.Localizacao) {

                    ctrl.Localizacao = response.Localizacao

                    ctrl.InicializarMapa();
                }

                ctrl.notFound = false;

            }).error(function (err, status) {

                if (status == 400) {
                    ctrl.notFound = true;
                }
                else {
                    //TODO: Implementar tratamento de erro na base
                }

            });

        }
        else {
            //TODO: Mostrar mensagem que o anúncio não foi encontrado

            ctrl.notFound = true;
        }

    }

    ctrl.AcoesDisabled = function () {
        return !ctrl.HabilitarAcoes || (ctrl.Anunciante.Id == sessionStorage.getItem('IdUsuario'));
    }


    //#region .: Gostar :.

    ctrl.BtnGostarClick = function () {

        if (!ctrl.base.IsLogged()) {
            ctrl.base.AbrirModalLogin();
            $('#modalLogarCadastrar').modal('show');
        }
        else {
            if (ctrl.Gostei) {
                ctrl.RemoverGostei();
            }
            else {
                ctrl.CadastrarGostei();
            }
        }

    }

    ctrl.RemoverGostei = function () {

        var request = {
            IdAnuncio: idAnuncio,
            IdUsuario: sessionStorage.getItem('IdUsuario')
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/RemoverGostei',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Gostei = false;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    ctrl.CadastrarGostei = function () {

        var request = {
            IdAnuncio: idAnuncio,
            IdUsuario: sessionStorage.getItem('IdUsuario')
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/CadastrarGostei',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Gostei = true;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    //#endregion

    //#region .: Perguntar :.

    ctrl.BtnFazerPergunta = function () {

        if (ctrl.base.IsLogged()) {
            $('#modalFazerPergunta').modal('show');
        }
        else {
            ctrl.base.AbrirModalLogin();
            $('#modalLogarCadastrar').modal('show');
        }

    }

    ctrl.BtnConfirmarPergunta = function () {

        //validar campos

        if (ctrl.base.StringIsEmpty(ctrl.TxtPergunta) || ctrl.TxtPergunta.length < 5) {
            ctrl.ErroTxtPergunta = true;
        }
        else {

            ctrl.EnviandoPergunta = true;

            ctrl.ErroTxtPergunta = false;

            var request = {
                IdAnuncio: idAnuncio,
                IdUsuario: sessionStorage.getItem('IdUsuario'),
                Pergunta: ctrl.TxtPergunta
            };

            $http({
                method: 'POST',
                url: ctrl.base.servicePath + 'Anuncio/CadastrarDuvida',
                data: request,
                headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
            }).success(function (response) {

                ctrl.TxtPergunta = "";

                $('#modalFazerPergunta').modal('hide');
                $('#modalPerguntaRealizada').modal('show');

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {

                ctrl.EnviandoPergunta = false;

            });
        }
    }

    ctrl.ResponderPergunta = function (aIdDuvida, aPergunta) {

        ctrl.IdDuvidaAtual = aIdDuvida;
        ctrl.DuvidaAtual = aPergunta;

        $('#modalRespostaPergunta').modal('show');
    }

    ctrl.BtnConfirmarResposta = function () {

        //validar campos

        if (ctrl.base.StringIsEmpty(ctrl.TxtResposta)) {
            ctrl.ErroTxtResposta = true;
        }
        else {

            ctrl.EnviandoResposta = true;

            ctrl.ErroTxtResposta = false;

            var request = {
                IdDuvida: ctrl.IdDuvidaAtual,
                IdUsuario: sessionStorage.getItem('IdUsuario'),
                IdLogin: sessionStorage.getItem('IdLogin'),
                Resposta: ctrl.TxtResposta
            };

            $http({
                method: 'POST',
                url: ctrl.base.servicePath + 'Anuncio/CadastrarResposta',
                data: request,
                headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
            }).success(function (response) {

                ctrl.TxtResposta = "";

                $('#modalRespostaPergunta').modal('hide');
                $('#modalRespostaRealizada').modal('show');

                ctrl.OnInit();

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {

                ctrl.EnviandoResposta = false;

            });
        }
    }

    //#endregion

    //#region .: Demonstrar Interesse :.

    ctrl.BtnInteresse = function () {

        if (ctrl.base.IsLogged()) {
            $('#modalQueroAdotar').modal('show');
        }
        else {
            ctrl.base.AbrirModalLogin();
            $('#modalLogarCadastrar').modal('show');
        }

    }

    ctrl.BtnConfirmarInteresse = function () {

        var request = {
            IdAnuncio: idAnuncio,
            IdUsuario: sessionStorage.getItem('IdUsuario')
        };

        ctrl.DemonstrandoInteresse = true;

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/CadastrarInteresse',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.HabilitarAcoes = false;

            $('#modalQueroAdotar').modal('hide');
            $('#modalInteresseRealizado').modal('show');

            ctrl.IdInteresseCadastrado = response;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.DemonstrandoInteresse = false;

        });

    }

    ctrl.AbrirChat = function () {

        window.location = "conta/chats.html?idChat=" + ctrl.IdInteresseCadastrado;

    }

    //#endregion

    //#region .: Fotos :.

    ctrl.AbrirImagem = function (aSrc) {

        ctrl.Fotos.push(ctrl.FotoDestaque);

        ctrl.FotoDestaque = ctrl.Fotos.filter(x => x.Valor == aSrc)[0];

        ctrl.Fotos = ctrl.Fotos.filter(function (obj) {
            return obj.Valor != aSrc;
        });

    }

    ctrl.ExpandirImagemDestaque = function () {

        $('#modalImagemDestaque').modal('show');

    }

    //#endregion

    //#region .: Mapa :.

    ctrl.InicializarMapa = function () {

        var latlng = new google.maps.LatLng(ctrl.Localizacao.Latitude, ctrl.Localizacao.Longitude);

        var options = {
            zoom: 15,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            mapTypeControl: false,
            zoomControl: true,
            zoomControlOptions: {
                position: google.maps.ControlPosition.RIGHT_BOTTOM
            },
            streetViewControl: true,
            streetViewControlOptions: {
                position: google.maps.ControlPosition.RIGHT_TOP
            },
            fullscreenControl: true
        };

        map = new google.maps.Map(document.getElementById("mapa"), options);

        new google.maps.Marker({
            map: map,
            position: { lat: ctrl.Localizacao.Latitude, lng: ctrl.Localizacao.Longitude }
        })

    }

    //#endregion

    //#region .: Mapa :.

    ctrl.CopyLink = function () {

        var text_to_share = location.href;

        // create temp element
        var copyElement = document.createElement("span");
        copyElement.appendChild(document.createTextNode(text_to_share));
        copyElement.id = 'tempCopyToClipboard';
        angular.element(document.body.append(copyElement));

        // select the text
        var range = document.createRange();
        range.selectNode(copyElement);
        window.getSelection().removeAllRanges();
        window.getSelection().addRange(range);

        // copy & cleanup
        document.execCommand('copy');
        window.getSelection().removeAllRanges();
        copyElement.remove();

        $('#modalLinkCopiado').modal('show');

    }

    ctrl.ShareWpp = function () {

        var encodedMenssage = encodeURI("Olá, acesse o link e nos ajude a salvar a vida de mais um Pet:");

        var encodedLink = encodeURI(location.href);

        window.open('https://wa.me/?text=' + encodedMenssage + "%0D%0A" + encodedLink, '_blank');

    }

    ctrl.ShareFacebook = function () {

        window.open('https://www.facebook.com/sharer/sharer.php?u=' + encodeURI(location.href), '_blank');

    }

    //#endregion
});