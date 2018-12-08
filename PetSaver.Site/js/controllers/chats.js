app.controller('chatsController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    var idChat = null;

    ctrl.OnInit = function () {

        idChat = ctrl.base.recuperarQueryString("idChat");

        if (!ctrl.base.IsLogged()) {
            ctrl.base.LimparSessionAuth();

            window.location.href = '../home.html';
        }
        else {
            ctrl.BuscandoMensagens = true;

            var request = {
                IdUsuario: sessionStorage.getItem('IdUsuario'),
                IdInteresse: idChat
            };

            $http({
                method: 'POST',
                url: ctrl.base.servicePath + 'Page/Chat',
                data: request,
                headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
            }).success(function (response) {

                ctrl.IdAnuncio = response.IdAnuncio;
                ctrl.IdInteresse = response.IdInteresse;
                ctrl.Imagem = response.Imagem;
                ctrl.Pet = response.Pet;
                ctrl.ConversandoCom = response.Usuario;
                ctrl.Mensagens = response.Mensagens;

                $(".messages").animate({ scrollTop: 10000000000000000000 }, "fast");

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {
                ctrl.BuscandoMensagens = false;
            });
        }

    }

    ctrl.AtualizarChat = function () {

        ctrl.BuscandoMensagens = true;

        var request = {
            IdUsuario: sessionStorage.getItem('IdUsuario'),
            IdInteresse: idChat
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Inbox/BuscarTodas',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Mensagens = response;
            
            $(".messages").animate({ scrollTop: $('.messages')[0].scrollHeight }, "fast");

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {
            ctrl.BuscandoMensagens = false;
            ctrl.EnviandoMensagem = false;
        });

    }

    ctrl.EnviarMensagem = function () {

        if (!ctrl.Mensagem || ctrl.Mensagem == '' || ctrl.EnviandoMensagem) {
            return false;
        }

        ctrl.EnviandoMensagem = true;

        var request = {
            IdLogin: sessionStorage.getItem('IdLogin'),
            IdUsuario: sessionStorage.getItem('IdUsuario'),
            IdInteresse: idChat,
            Mensagem: ctrl.Mensagem
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Inbox',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            $(".messages").animate({ scrollTop: $('.messages')[0].scrollHeight }, "fast");

            ctrl.Mensagem = '';

            $('#textboxMensagem').focus();

            ctrl.AtualizarChat();

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    ctrl.AbrirAnuncio = function () {

        window.open('../pet.html?idAnuncio=' + ctrl.IdAnuncio, '_blank');

    }

});

$(function () {
    $("#textboxMensagem").keypress(function (e) {
        if (e.which == 13) {
            angular.element('body').controller().EnviarMensagem();
            e.preventDefault();
        }
    });
});