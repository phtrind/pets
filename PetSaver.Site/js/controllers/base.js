app.controller('baseController', function () {

    this.servicePath = "http://localhost/PetSaver.WebApi/api/";
    //var servicePath = "http://localhost/PetSaver.WebApi/api/";

    this.AbrirModalLogin = function () {
        this.isRegister = false;
    }

    this.StringIsEmpty = function (aString) {
        return aString == "" || aString == null || aString == undefined;
    }

});