app.controller('indexController', function ($controller) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.AlteracaoFiltroAnimal = function () {

        if (ctrl.FiltroAnimal != "") {

            //implementar busca de filtros especificos do animal
            //implementar busca dos demais filtros 

            if (ctrl.FiltroAnimal == "1" || ctrl.FiltroAnimal == "2") {
                ctrl.LabelRacaEspecie = "Raça";
            }
            else {
                ctrl.LabelRacaEspecie = "Espécie";
            }
        }

    }

});