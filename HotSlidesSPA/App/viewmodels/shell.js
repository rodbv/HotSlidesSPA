﻿define(['config', 'durandal/system', 'durandal/plugins/router', 'services/logger'],
    function (config, system, router, logger) {
        var shell = {
            activate: activate,
            router: router
        };

        return shell;

        //#region Internal Methods
        function activate() {
            return boot();
        }

        function boot() {
            router.map(config.routes);
            log('Hot Towel SPA Loaded!', null, true);
            return router.activate('home');
        }

        function log(msg, data, showToast) {
            logger.log(msg, data, system.getModuleId(shell), showToast);
        }
        //#endregion
    });