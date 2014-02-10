$(document).ready(function () {
    //מסלול יחסי בסקריפט
    function getRootWebSitePath() {
        var _location = document.location.toString();
        var applicationNameIndex = _location.indexOf('/', _location.indexOf('://') + 3);
        var applicationName = _location.substring(0, applicationNameIndex) + '/';
        var webFolderIndex = _location.indexOf('/', _location.indexOf(applicationName) + applicationName.length);
        var webFolderFullPath = _location.substring(0, webFolderIndex);

        return webFolderFullPath;
    }



    //NonProfit
    $("#nonProfitReg").click(function () {
        event.preventDefault();
        var path = getRootWebSitePath() + "/publicPages/NonProfitLogin.aspx";
        window.open(path, "a", "top=100, left=500, width=400, height=400");
    });

    //users
    $("#userReg").click(function () {
        event.preventDefault();
        var path = getRootWebSitePath() + "//publicPages/UserLogin.aspx";
        window.open(path, "b", "top=100, left=500, width=400, height=400");
    });

    //company
    $("#companyReg").click(function () {
        event.preventDefault();
        var path = getRootWebSitePath() + "//publicPages/companyLogin.aspx";
        window.open(path, "c", "top=100, left=500, width=400, height=400");
    });

    $('li.headlink').hover(
			function () { $('ul', this).css('display', 'block'); },
			function () { $('ul', this).css('display', 'none'); });
///////////////////////////////////////////////////////////////////////////////

});