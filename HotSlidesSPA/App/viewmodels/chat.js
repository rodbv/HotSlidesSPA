define(['services/logger'], function (logger) {
    var chatInfo = ko.observable(),
       messages = ko.observableArray(),
       chatRoom = $.connection.chathub,
       chatUser = ko.observable({
           Owner: {
               Avatar: '/Content/Assets/img/avatar2.jpg',
               UserName: 'Daniel de Oliveira',
               UserNick: '@daniel'
           }
       }),
       messageToSend = ko.observable();

    var init = function () {
        chatRoom.server.getChatInfo().done(function (data) {
            chatInfo(data);
            logger.log('Chat Initialized', null, 'Chat Init', true);
        });
    };

    function initClient() {
        chatRoom.client.broadcastMessage = function (message) {
            messages.push(message);
            var cont = $('#chats');
            var list = $('.chats', cont);
            $('.scroller', cont).slimScroll({
                scrollTo: list.height()
            });
        };
    };

    var sendMessage = function () {
        if (messageToSend() === '' || messageToSend() === undefined)
            return;
        var message = { Time: '', Owner: chatUser().Owner, Body: messageToSend() };
        chatRoom.server.send(message).done(messageToSend(''));
    };

    function initChat() {
        var cont = $('#chats');
        var list = $('.chats', cont);
        var form = $('.chat-form', cont);
        var input = $('.messageToSend', form);

        var handleClick = function () {
            var text = input.val();
            if (text.length == 0) {
                return;
            }

            sendMessage();
        };

        $('.scroller', cont).slimScroll({
            scrollTo: list.height()
        });

        input.keypress(function (e) {
            if (e.which == 13) {
                handleClick();
                return false; //<---- Add this line
            }
        });
    };

    function viewAttached() {
        // App.init();
        initChat();
    }

    function activate() {
        logger.log('Chat View Activated', null, 'home', true);
        return Q.all([initClient(), $.connection.hub.start().done(init)]);
    }

    var vm = {
        activate: activate,
        viewAttached: viewAttached,
        chatInfo: chatInfo,
        messages: messages,
        messageToSend: messageToSend,
        chatUser: chatUser,
        sendMessage: sendMessage,
        title: 'Chat View'
    };

    return vm;

});