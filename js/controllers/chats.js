var app = angular.module('pets', [])

app.controller('chatsController', function ($scope, $http, $compile, $sce) {

    //this method runs after page load
    angular.element(document).ready(function () {
        $scope.minimizarMenu();
    });
    
    $scope.minimizarMenu = function () {
        $("body").addClass("mini-sidebar");
        $(".header .navbar .navbar-header .navbar-brand span").css("display", "none");
        $(".header .navbar .navbar-header .navbar-brand b").css("display", "inline-block");
    }

});