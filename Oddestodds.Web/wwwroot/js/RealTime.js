const connection = new signalR.HubConnectionBuilder()
    .withUrl("/RealTimeHub")
    .build();
const UpdateOdds = "UpdateOdds";
console.log(connection);

//Connect to Server
start();
connection.onclose(function () {

    start();
});
function start() {
    connection.start().catch((err) => {
        setTimeout(function () {
            start();
        }, 5000);
    });
}

connection.on("Test", (message) => {
    console.log(message);
});

connection.on(UpdateOdds, (data) => {
    //TODO:Received Updated data
    //TODO:Update UI
});
