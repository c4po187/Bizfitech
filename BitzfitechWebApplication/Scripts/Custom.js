$(document).ready(function () {
    if (location.pathname.split('/').slice(-1)[0] == '') {
        $('#body').addClass('zero-padding-bottom');
    }
});