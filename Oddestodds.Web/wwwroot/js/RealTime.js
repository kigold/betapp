const connection = new signalR.HubConnectionBuilder()
    .withUrl("/RealTimeHub")
    .build();
const UpdateOdds = "UpdateOdds";
let OddsListStore = [];
let table = document.getElementById("odds-table");

//Connect to Server
start();
connection.onclose(function () {
    //attempts to reconnect when disconnected
    start();
});


connection.on(UpdateOdds, (data) => {
    //TODO:Received Updated data
    //TODO:Update UI    
    UpdateSavedOdds(data);
});

//Methods
function start() {
    connection.start().catch((err) => {
        setTimeout(function () {
            start();
        }, 5000);
    });
}

function UpdateSavedOdds(dataList) {
    //TODO: Optimaize, so that the whole page doesnt refresh
    OddsListStore = dataList.concat();
    //Delete all rows
    const l = table.rows.length;
    for (let i = 1; i < l; i++) {
        table.deleteRow(1)
        console.log(i, table.rows.length)
    }
    UpdateTableWithOdds(OddsListStore);
}

function UpdateTableWithOdds(dataList) {
    if (dataList != undefined && Array.isArray(dataList)) {
        if (table != undefined) {
            console.log(dataList.length)
            for (let i = dataList.length - 1; i >= 0; i--) {
                console.log(i)
                const item = dataList[i];
                let row = table.insertRow(1);                
                let cell1 = row.insertCell(0);
                cell1.innerHTML = item.id
                let cell2 = row.insertCell(1);
                cell2.innerHTML = item.name
                let cell3 = row.insertCell(2);
                cell3.innerHTML = item.home
                let cell4 = row.insertCell(3);
                cell4.innerHTML = item.away
                let cell5 = row.insertCell(4);
                cell5.innerHTML = item.draw
                let cell6 = row.insertCell(5);
                cell6.innerHTML = "<Button>View</Button>"
            }
        }
    }
}
