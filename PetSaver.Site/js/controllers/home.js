app.controller('homeController', function ($controller) {

        var ctrl = this;
    
        ctrl.base = $controller('baseController', {});

        ctrl.isRegister = false;

        
    $('#modalSaibaMaisA').on('hidden.bs.modal', function () {
        ctrl.isRegister = true;
    });

    $('#modalSaibaMaisB').on('hidden.bs.modal', function () {
        ctrl.isRegister = true;
    });

    $('#modalSaibaMaisC').on('hidden.bs.modal', function () {
        ctrl.isRegister = true;
    });
    // $scope.changeCollapseImage = function () {

    //     if (formFiltroOpen){

    //     }

    // }

});