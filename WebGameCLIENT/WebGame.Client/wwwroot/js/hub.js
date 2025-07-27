var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7123/gamehub").build();


connection.on("ReceiveConnectionId", function (connectionId) {
    console.log("Connection ID:", connectionId);
    localStorage.setItem("connectionId", connectionId);
    
});

connection.on("ReceiveLobby", async () => {
    console.log("new lobby created");
    await window.loadLobbies();
});



connection.start().then(function () {
        console.log("started");
    }).catch(function (err) {
        console.log("connect failed");
    });
