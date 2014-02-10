$(document).ready(function () {

    function getRootWebSitePath() {
        var _location = document.location.toString();
        var applicationNameIndex = _location.indexOf('/', _location.indexOf('://') + 3);
        var applicationName = _location.substring(0, applicationNameIndex) + '/';
        var webFolderIndex = _location.indexOf('/', _location.indexOf(applicationName) + applicationName.length);
        var webFolderFullPath = _location.substring(0, webFolderIndex);

        return webFolderFullPath;
    }

    $("#RegisterNonProfitBTN").click(function () {
        window.location = getRootWebSitePath() + "/publicPages/nonProfitReg.aspx";
    });

});