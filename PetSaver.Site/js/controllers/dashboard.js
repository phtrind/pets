// var app = angular.module('pets', []);

app.controller('dashboardController', function ($controller) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

});