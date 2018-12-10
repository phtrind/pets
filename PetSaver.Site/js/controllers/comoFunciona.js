app.controller('comoFuncionaController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        ctrl.Tipo = ctrl.base.recuperarQueryString("tipo");

    }

});