app.controller('meusDadosController', function ($controller) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});
    
    ctrl.AtualizarMeusDados = function () {

        //TODO: Implementar loading
        ctrl.Atualizando = true;

        var contErro = 0;

        //Nome
        if (ctrl.base.StringIsEmpty(ctrl.NomeMeusDados)) {
            ctrl.ErroNomeMeusDados = true;
            contErro++;
        }
        else {
            ctrl.ErroNomeMeusDados = false;
        }

        //Sobrenome
        if (ctrl.base.StringIsEmpty(ctrl.SobrenomeMeusDados)) {
            ctrl.ErroSobrenomeMeusDados = true;
            contErro++;
        }
        else {
            ctrl.ErroSobrenomeMeusDados = false;
        }

        //Data nascimento
        if (ctrl.base.StringIsEmpty(ctrl.DthNascimentoMeusDados)) {
            ctrl.ErroDthNascimentoMeusDados = true;
            contErro++;
        }
        else {
            ctrl.ErroDthNascimentoMeusDados = false;
        }

        //Sexo
        if (ctrl.base.StringIsEmpty(ctrl.SexoMeusDados)) {
            ctrl.ErroSexoMeusDados = true;
            contErro++;
        }
        else {
            ctrl.ErroSexoMeusDados = false;
        }

        //Email
        if (ctrl.base.EmailIsValid(ctrl.EmailMeusDados)) {
            ctrl.ErroEmailMeusDados = false;
        }
        else {
            ctrl.ErroEmailMeusDados = true;
            contErro++;
        }

        //Senha
        if (ctrl.base.StringIsEmpty(ctrl.SenhaMeusDados)) {
            ctrl.ErroSenhaMeusDados = true;
            ctrl.ErroSenhaMeusDadosVazia = true;
            contErro++;
        }
        else if (ctrl.SenhaMeusDados.length < 8) {
            ctrl.ErroSenhaMeusDados = true;
            ctrl.ErroSenhaMeusDadosPequena = true;
            contErro++;
        }
        else {
            ctrl.ErroSenhaMeusDados = false;
            ctrl.ErroSenhaMeusDadosVazia = false;
            ctrl.ErroSenhaMeusDadosPequena = false;
        }

        //Confirmação senha
        if (ctrl.SenhaMeusDados != ctrl.ConfirmacaoSenhaMeusDados) {
            ctrl.ErroConfirmacaoSenhaMeusDados = true;
            contErro++;
        }
        else {
            ctrl.ErroConfirmacaoSenhaMeusDados = false;
        }

        if (!ctrl.base.StringIsEmpty(ctrl.CepMeusDados) ||
            !ctrl.base.StringIsEmpty(ctrl.BairroMeusDados) ||
            !ctrl.base.StringIsEmpty(ctrl.NumeroMeusDados) ||
            !ctrl.base.StringIsEmpty(ctrl.ComplementoMeusDados) ||
            !ctrl.base.StringIsEmpty(ctrl.LogradouroMeusDados))
        {
            //Cep
            if (ctrl.base.StringIsEmpty(ctrl.CepMeusDados)) {
                ctrl.ErroCepMeusDados = true;
                contErro++;
            }
            else {
                ctrl.ErroCepMeusDados = false;
            }
            //Logradouro
            if (ctrl.base.StringIsEmpty(ctrl.LogradouroMeusDados)) {
                ctrl.ErroLogradouroMeusDados = true;
                contErro++;
            }
            else {
                ctrl.ErroLogradouroMeusDados = false;
            }
            //Bairro
            if (ctrl.base.StringIsEmpty(ctrl.BairroMeusDados)) {
                ctrl.ErroBairroMeusDados = true;
                contErro++;
            }
            else {
                ctrl.ErroBairroMeusDados = false;
            }
        }

        //TODO: CONTINUAR VALIDAÇÃO DE ADOS DO ENDEREÇO E NA TELA TAMBEM

        if (contErro == 0) {

        //    var request = {
        //        Nome: ctrl.NomeMeusDados,
        //        Sobrenome: ctrl.SobrenomeMeusDados,
        //        DataNascimento: ctrl.DthNascimentoMeusDados,
        //        Sexo: ctrl.Sexo,
        //        Email: ctrl.EmailMeusDados,
        //        Senha: ctrl.SenhaMeusDados
        //    };

        //    $http({
        //        method: 'POST',
        //        url: base.servicePath + 'Usuario/AlterarDados',
        //        data: request
        //    }).success(function (response) {

        //        $http({
        //            method: 'POST',
        //            url: ctrl.base.servicePath + 'token',
        //            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        //            data: "grant_type=password&username=" + request.Email + "&password=" + request.Senha
        //        }).success(function (response) {

        //            sessionStorage.setItem("Token", response.access_token);
        //            sessionStorage.setItem("DataHoraAutenticacao", new Date().toLocaleString());
        //            sessionStorage.setItem("TokenExpiresIn", response.expires_in);

        //            ctrl.base.BuscarInformacoesSession(ctrl.base.EmailLogin);

        //        }).error(function (err, status) {

        //            sessionStorage.clear();

        //            //TODO: Implementar tratamento de erro na base

        //        });

        //    }).error(function (err, status) {

        //        //TODO: Implementar tratamento de erro na base

        //    }).finally(function () {

        //        ctrl.Atualizando = false;

        //    });

        }
        else {
                ctrl.Atualizando = false;
            }

        }

    });