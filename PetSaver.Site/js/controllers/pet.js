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
                ctrl.TipoAnuncio = response.TipoAnuncio;

                if (ctrl.StatusAnuncio != "Ativo") {
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

            }).error(function (err, status) {

                if (status == 400) {
                    //TODO: Mostrar mensagem que o anúncio não foi encontrado
                }
                else {
                    //TODO: Implementar tratamento de erro na base
                }

            });

            ctrl.PreencherLinksCompartilhamento();

        }
        else {
            //TODO: Mostrar mensagem que o anúncio não foi encontrado
        }

    }

    ctrl.PreencherLinksCompartilhamento = function () {

        ctrl.linkCompartilharWpp = "https://api.whatsapp.com/send?text=" + "Olá, veja esse pet na PetSaver: " + "http://petsaver.com.br/pet.html?pet=" + sessionStorage.getItem('IdAnuncioAtual');
        ctrl.linkCompartilharFace = "http://www.facebook.com/soupetsaver" + "Olá, veja esse pet na PetSaver: " + "http://petsaver.com.br/pet.html?pet=" + sessionStorage.getItem('IdAnuncioAtual');

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
            IdAnuncio: sessionStorage.getItem('IdAnuncioAtual'),
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
            IdAnuncio: sessionStorage.getItem('IdAnuncioAtual'),
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

            ctrl.ErroTxtPergunta = false;

            var request = {
                IdAnuncio: sessionStorage.getItem('IdAnuncioAtual'),
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
            IdAnuncio: sessionStorage.getItem('IdAnuncioAtual'),
            IdUsuario: sessionStorage.getItem('IdUsuario')
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Anuncio/CadastrarInteresse',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.HabilitarAcoes = false;

            $('#modalQueroAdotar').modal('hide');
            $('#modalInteresseRealizado').modal('show');

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

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

});