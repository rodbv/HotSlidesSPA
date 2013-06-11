define(function () {
    toastr.options.timeOut = 4000;
    toastr.options.positionClass = 'toast-bottom-right';

    var imageSettings = {
        imageBasePath: '../content/images/photos/',
        unknownPersonImageSource: 'unknown_person.jpg'
    };

    var routes = [{
        url: 'home',
        moduleId: 'viewmodels/home',
        name: 'Home',
        visible: true,
        caption: '<i class="icon-book"></i> Home'
    }, {
        url: 'chat',
        moduleId: 'viewmodels/chat',
        name: 'Chat',
        visible: true,
        caption: '<i class="icon-user"></i> Chat'
    }];


    return {
        debugEnabled: ko.observable(true),
        imageSettings: imageSettings,
        routes: routes
    };
});