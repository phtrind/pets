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
            ctrl.Buscando = true;

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

            }).error(function (err, status) {

                //TODO: Implementar tratamento de erro na base

            }).finally(function () {
                ctrl.Buscando = false;
            });
        }

    }

    ctrl.AtualizarChat = function () {

        $(".messages").animate({ scrollTop: $(document).height() }, "fast");

        ctrl.Mensagens = [
            {
                Mensagem: "How the hell am I supposed to get a jury to believe you when I am not even sure that I do?!",
                Enviada: true
            },
            {
                Mensagem: "How the hell am I supposed to get a jury to believe you when I am not even sure that I do?!",
                Enviada: false
            },
            {
                Mensagem: "How the hell am I supposed to get a jury to believe you when I am not even sure that I do?!",
                Enviada: true
            },
            {
                Mensagem: "How the hell am I supposed to get a jury to believe you when I am not even sure that I do?!",
                Enviada: false
            },
            {
                Mensagem: "How the hell am I supposed to get a jury to believe you when I am not even sure that I do?!",
                Enviada: true
            },
            {
                Mensagem: "How the hell am I supposed to get a jury to believe you when I am not even sure that I do?!",
                Enviada: false
            },
            {
                Mensagem: "How the hell am I supposed to get a jury to believe you when I am not even sure that I do?!",
                Enviada: true
            },
            {
                Mensagem: "How the hell am I supposed to get a jury to believe you when I am not even sure that I do?!",
                Enviada: false
            },
            {
                Mensagem: "How the hell am I supposed to get a jury to believe you when I am not even sure that I do?!",
                Enviada: true
            },
        ];

    }

    ctrl.EnviarMensagem = function () {

        if (!ctrl.Mensagem || ctrl.Mensagem == '') {
            return false;
        }

        ctrl.Mensagens.push({ Mensagem: ctrl.Mensagem, Enviada: true })

        $(".messages").animate({ scrollTop: $('.messages')[0].scrollHeight }, "fast");

        ctrl.Mensagem = '';

        $('#textboxMensagem').focus();

    }

    ctrl.AbrirAnuncio = function () {

        window.open('../pet.html?idAnuncio=' + ctrl.IdAnuncio, '_blank');

    }

});