app.controller('maintenanceController', function ($controller) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.MinhaConta = function () {

        window.location = "conta/dashboard.html";

    }

});