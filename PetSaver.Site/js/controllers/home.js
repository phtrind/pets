app.controller('homeController', function ($controller, $http) {

    var ctrl = this;

    ctrl.base = $controller('baseController', {});

    ctrl.OnInit = function () {

        $http({
            method: 'GET',
            url: ctrl.base.servicePath + 'Page/Home'
        }).success(function (response) {

            ctrl.Anuncios = response.Anuncios;
            ctrl.Estados = response.Filtros.Estados;
            ctrl.Animais = response.Filtros.Animais;
            ctrl.Sexos = response.Filtros.Sexos;

        }).error(function (err, status) {

            //TODO: Implementar tratamento de erro na base

        });

    }

    ctrl.EstadoSelecionadoChange = function () {

        if (!ctrl.base.StringIsEmpty(ctrl.Estado)) {
            $http({
                method: 'GET',
                url: ctrl.base.servicePath + 'Cidade/Combo/' + ctrl.Estado
            }).success(function (response) {

                ctrl.Cidades = response;

            }).error(function (err, status) {

                ctrl.Cidades = null;

                //TODO: Implementar tratamento de erro na base

            });
        }
        else {
            ctrl.Cidades = null;
        }

    }

    ctrl.BuscarAnuncios = function () {

        var parameters = "";
        var url = "index.html";

        if (!ctrl.base.StringIsEmpty(ctrl.Estado)) {
            parameters = parameters + "estado=" + ctrl.Estado + "&";
        }

        if (!ctrl.base.StringIsEmpty(ctrl.Cidade)) {
            parameters = parameters + "cidade=" + ctrl.Cidade + "&";
        }

        if (!ctrl.base.StringIsEmpty(ctrl.Animal)) {
            parameters = parameters + "pet=" + ctrl.Animal + "&";
        }

        if (!ctrl.base.StringIsEmpty(ctrl.Sexo)) {
            parameters = parameters + "sexo=" + ctrl.Sexo;
        }

        if (!ctrl.base.StringIsEmpty(parameters)) {

            if (parameters[parameters.length - 1] == "&") {
                parameters = parameters.substring(0, parameters.length - 1);
            }

            url = url + "?" + parameters;

        }

        document.location.href = url;

    }

    ctrl.AbrirComoFunciona = function (aTipo) {

        window.open('como_funciona.html?tipo=' + aTipo, '_blank');

    }

});

//#region .: Scroll :.

//--- DEFINE a reusable animation function: ---//
function scrollThere(targetElement, speed) {
    // initiate an animation to a certain page element:
    $('html, body').stop().animate(
        { scrollTop: targetElement.offset().top }, // move window so target element is at top of window
        speed, // speed in milliseconds
        'swing' // easing
    ); // end animate
} // end scrollThere function definition


//--- START SCROLL EVENTS ---//
// detect a mousewheel event (note: relies on jquery mousewheel plugin):
$(window).on('mousewheel', function (e) {

    // get Y-axis value of each div:
    var div1y = $('#header').offset().top,
        div2y = $('#servicos').offset().top,
        div3y = $('#porque').offset().top,
        div4y = $('#pets').offset().top,
        div5y = $('#buscar').offset().top,
        // get window's current scroll position:
        lastScrollTop = $(this).scrollTop(),
        // for getting user's scroll direction:
        scrollDirection,
        // for determining the previous and next divs to scroll to, based on lastScrollTop:
        targetUp,
        targetDown,
        // for determining which of targetUp or targetDown to scroll to, based on scrollDirection:
        targetElement;

    // get scroll direction:
    if (e.originalEvent.deltaY < 0) {
        scrollDirection = 'up';
    } else {
        scrollDirection = 'down';
    } // end if

    // prevent default behavior (page scroll):
    e.preventDefault();

    // condition: determine the previous and next divs to scroll to, based on lastScrollTop:
    if (lastScrollTop === div1y) {
        targetUp = $('#header');
        targetDown = $('#servicos');
    } else if (lastScrollTop === div2y) {
        targetUp = $('#header');
        targetDown = $('#porque');
    } else if (lastScrollTop === div3y) {
        targetUp = $('#servicos');
        targetDown = $('#pets');
    } else if (lastScrollTop === div4y) {
        targetUp = $('#porque');
        targetDown = $('#buscar');
    } else if (lastScrollTop === div5y) {
        targetUp = $('#pets');
        targetDown = $('#buscar');
    } else if (lastScrollTop < div2y) {
        targetUp = $('#header');
        targetDown = $('#servicos');
    } else if (lastScrollTop < div3y) {
        targetUp = $('#servicos');
        targetDown = $('#porque');
    } else if (lastScrollTop < div4y) {
        targetUp = $('#porque');
        targetDown = $('#pets');
    } else if (lastScrollTop < div5y) {
        targetUp = $('#pets');
        targetDown = $('#buscar');
    } else if (lastScrollTop > div5y) {
        targetUp = $('#buscar');
        targetDown = $('#buscar');
    } // end else if

    // condition: determine which of targetUp or targetDown to scroll to, based on scrollDirection:
    if (scrollDirection === 'down') {
        targetElement = targetDown;
    } else if (scrollDirection === 'up') {
        targetElement = targetUp;
    } // end else if

    // scroll smoothly to the target element:
    scrollThere(targetElement, 400);

}); // end on mousewheel event
//--- END SCROLL EVENTS ---//

//#endregion