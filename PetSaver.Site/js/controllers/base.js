app.controller('baseController', function () {

    this.ShowMessage = function (message) {
        alert(message);
    }

    $('#modalLogarCadastrar').on('hidden.bs.modal', function () {
        ctrl.isRegister = true;
        alert('show test');
    });

});