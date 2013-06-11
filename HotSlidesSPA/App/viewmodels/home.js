define(['services/logger'], function (logger) {
    var vm = {
        activate: activate,
        viewAttached: viewAttached,
        title: 'Home View'
    };

    return vm;

    //#region Internal Methods

    function viewAttached() {
        App.init();
    }

    function activate() {
        logger.log('Home View Activated', null, 'home', true);
        return true;
    }
    //#endregion
});