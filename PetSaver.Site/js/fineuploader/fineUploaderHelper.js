var GenerateGuid = function () {

    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }

    return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();

}

var guidAnuncio = null;

$(document).ready(function () {
    guidAnuncio = angular.element('body').controller();
});

$('#fine-uploader-validation').fineUploader({
    debug: true,
    autoUpload: false,
    template: 'qq-template-validation',
    multiple: true,
    request: {
        endpoint: 'http://localhost/PetSaver.WebApi/api/FileUploader',
        forceMultipart: true,
        method: 'POST',
        customHeaders: {
            Authorization: 'Bearer ' + sessionStorage.getItem('Token')
        },
        params: {
            Guid: guidAnuncio
        }
    },
    thumbnails: {
        placeholders: {
            waitingPath: '../images/loading.gif',
            notAvailablePath: '../icons/close.png'
        }
    },
    validation: {
        allowedExtensions: ['jpeg', 'jpg', 'png'],
        itemLimit: 4
    },
    retry: {
        enableAuto: true
    },
    scaling: {
        sendOriginal: false,
        sizes: [
            { name: "compress", maxSize: 750 }
        ]
    },
    callbacks: {
        onAllComplete: function () {

            angular.element('body').controller().FinalizarCadastro();

        },
        onStatusChange: function (id, oldStatus, newStatus) {

            if (newStatus == "canceled") {
                desconsiderarImagem();
            }
            else if (newStatus == "submitted") {
                $("#btnFinalizarCadastro").removeClass("disabled");
                $("#btnFinalizarCadastro").prop("disabled", false);
            }

        }
    }
});

var desconsiderarImagem = function () {

    if ($('#fine-uploader-validation').fineUploader('getUploads').filter(x => x.status == "submitted").length <= 0) {
        $("#btnFinalizarCadastro").addClass("disabled");
        $("#btnFinalizarCadastro").prop("disabled", true);
    }

};