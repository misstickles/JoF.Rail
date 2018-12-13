;(function () {
    "use strict";

    var connection = new signalR.HubConnectionBuilder().withUrl("/darwinHub").build();

    connection.on("ReceiveMessage", function(user, message) {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = user + " says " + msg;
        var li = document.createElement("li");
        li.textContent = encodedMsg;
        $("#messagesList")[0].appendChild(li);
    });

    connection.start().catch(function(err) {
        return console.error(err.toString());
    });

    $("#sendButton").on("click", function(event) {
        var user = $("#userInput")[0].value;
        var message = $("#messageInput")[0].value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
    //connection.on("ReceiveMessage", (user, message) => {
    //    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //    var encodedMsg = user + " says " + msg;
    //    var li = document.createElement("li");
    //    li.textContent = encodedMsg;
    //    $("#messagesList")[0].appendChild(li);
    //});

    //connection.start().catch((err) => {
    //    return console.error(err.toString());
    //});

    //$("#sendButton").on("click", event => {
    //    var user = $("#userInput")[0].value;
    //    var message = $("#messageInput")[0].value;
    //    connection.invoke("SendMessage", user, message).catch(function (err) {
    //        return console.error(err.toString());
    //    });
    //    event.preventDefault();
    //});
})();