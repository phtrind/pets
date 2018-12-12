app.controller('meusDadosController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        ctrl.Loading = true;

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Usuario/Completo/' + sessionStorage.getItem('IdUsuario'),
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            ctrl.Nome = response.Nome;
            ctrl.Sobrenome = response.Sobrenome;
            ctrl.DthNascimento = new Date(response.Nascimento);
            ctrl.Sexo = response.Sexo;
            ctrl.CpfCnpj = response.Documento;
            ctrl.Email = response.Email;
            ctrl.Senha = response.Senha;
            ctrl.ConfirmacaoSenha = response.Senha;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {
            ctrl.Loading = false;
        });

    }

    ctrl.AtualizarMeusDados = function () {

        if (ctrl.ValidarDados() != 0) {
            return;
        }

        ctrl.Atualizando = true;

        var request = {
            IdLogin: sessionStorage.getItem('IdLogin'),
            IdUsuario: sessionStorage.getItem('IdUsuario'),
            Nome: ctrl.Nome,
            Sobrenome: ctrl.Sobrenome,
            Sexo: ctrl.Sexo,
            Documento: ctrl.CpfCnpj,
            Senha: ctrl.Senha
        };

        $http({
            method: 'POST',
            url: ctrl.base.servicePath + 'Usuario/AlterarDados',
            data: request,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('Token') }
        }).success(function (response) {

            $('#modalAlteracaoCadastroSucesso').modal('show');

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        }).finally(function () {

            ctrl.Atualizando = false;

        });

    }

    ctrl.ValidarDados = function () {

        var contErro = 0;

        //Nome
        if (ctrl.base.StringIsEmpty(ctrl.Nome)) {
            ctrl.ErroNomeMeusDados = true;
            contErro++;
        }
        else {
            ctrl.ErroNomeMeusDados = false;
        }

        //Sobrenome
        if (ctrl.base.StringIsEmpty(ctrl.Sobrenome)) {
            ctrl.ErroSobrenomeMeusDados = true;
            contErro++;
        }
        else {
            ctrl.ErroSobrenomeMeusDados = false;
        }

        //CPF/CNPJ
        if (ctrl.CpfCnpj != undefined && ctrl.CpfCnpj.length != 11 && ctrl.CpfCnpj.length != 14) {
            ctrl.ErroCpfCnpjMeusDados = true;
            contErro++;
        }
        else {
            ctrl.ErroCpfCnpjMeusDados = false;
        }

        //Senha
        if (ctrl.base.StringIsEmpty(ctrl.Senha) || ctrl.Senha.length < 6) {
            ctrl.ErroSenhaMeusDados = true;
            ctrl.ErroSenhaMeusDadosPequena = true;
            contErro++;
        }
        else {
            ctrl.ErroSenhaMeusDados = false;
            ctrl.ErroSenhaMeusDadosPequena = false;
        }

        //Confirmação senha
        if (ctrl.Senha != ctrl.ConfirmacaoSenha) {
            ctrl.ErroConfirmacaoSenhaMeusDados = true;
            contErro++;
        }
        else {
            ctrl.ErroConfirmacaoSenhaMeusDados = false;
        }

        return contErro;
    }

    ctrl.SomenteNumero = function () {

        ctrl.CpfCnpj = ctrl.CpfCnpj.replace(/\D/g, '');

    }

});