app.controller('dashboardController', function ($controller) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        if (!ctrl.base.IsLogged()) {
            window.location.href = '../home.html';
        }

    }

});