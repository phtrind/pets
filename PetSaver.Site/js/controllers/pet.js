app.controller('petController', function ($controller) {

        var ctrl = this;

        ctrl.base = $controller('baseController', {});

        ctrl.isRegister = false;

});