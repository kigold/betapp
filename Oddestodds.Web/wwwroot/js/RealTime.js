//set up signalR connection for real time connection
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/RealTimeHub")
    .build();
let connectionRetry = 0;
const connectionRetryLimit = 10;

const ActionUpdateOdds = "ActionUpdateOdds";
const ActionCreateModifyOdds = "ActionCreateModifyOdds";
const ActionCreateOdds = "ActionCreateOdds";
const ActionEditOdds = "ActionEditOdds";
const ActionDeleteOdds = "ActionDeleteOdds";

let OddsListStore = [];
let table = document.getElementById("odds-table");
let submitBtn = document.getElementById("submit-btn");

if (submitBtn != undefined) {
    submitBtn.onclick = handleFormSubmit;
}
//console.log(window.location.pathname);



//Connect to Server
start();
connection.onclose(function () {
    //attempts to reconnect when disconnected
    start();
});


connection.on(ActionUpdateOdds, (data) => {
    UpdateSavedOdds(data);
    RefreshTable(OddsListStore);
});

connection.on(ActionCreateModifyOdds, (data) => {
    UpdateSavedOdds(data, true);
    RefreshTable(OddsListStore);
});


connection.on(ActionDeleteOdds, (data) => {
    OddsListStore = OddsListStore.filter(x => x.id != data);
    UpdateSavedOdds(OddsListStore);
    RefreshTable(OddsListStore);
});


//Methods
//TODO: Limit to number of connection retries
function start() {
    connection.start().catch((err) => {
        setTimeout(function () {
            start();
        }, 5000);
    });
}

function UpdateSavedOdds(dataList, append=false) {
    if (!append) {
        OddsListStore = dataList.concat();
    }
    else {
        //TODO: Test
        let len = dataList.length;
        for (let i = 0; i < len; i++) {
            const id = OddsListStore.findIndex(x => x.Id == dataList[i].Id)
            if (id != -1)
                OddsListStore[id] = dataList[i]
            else {
                OddsListStore.push(dataList[i])
            }
        }

    }
    
}
function RefreshTable(OddsListStore) {
    //Delete all rows
    if (table != undefined) {
        const length = table.rows.length;
        for (let i = 1; i < length; i++) {
            table.deleteRow(1)
        }
        UpdateTableWithOdds(OddsListStore);
    }
}

function UpdateTableWithOdds(dataList) {
    if (dataList != undefined && Array.isArray(dataList)) {
        if (table != undefined) {
            for (let i = dataList.length - 1; i >= 0; i--) {
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
                let selBtnHtml = "<Button class='btn-success' data-name='"+item.name+"' id='" + item.id + "' onclick='HandleSelectOdds(this)'>Select</Button>";
                let delBtnHtml = "<Button class='btn-danger' id='" + item.id + "' onclick='HandleDeleteOdds(this)'>Delete</Button>";
                let editBtnHtml = "<Button class='btn-info' id='" + item.id + "' onclick='HandleEditOdds(this)' >Edit</button>"
                if (window.location.pathname.includes('OddsHandler')) {
                    //cell6.innerHTML = "<span>" + delBtnHtml + "</span>" + "<span>" + editBtnHtml + "</span>"
                    cell6.innerHTML = delBtnHtml + editBtnHtml;
                }
                else {
                    cell6.innerHTML = selBtnHtml;
                }
                
            }
        }
    }
}

function HandleDeleteOdds(elem) {
    connection.invoke(ActionDeleteOdds, elem.id);
}
function HandleEditOdds(elem) {
    window.location = "/OddsHandler/edit/" + elem.id;
}

function HandleSelectOdds(elem) {
    //TODO:
    console.log(elem.getAttribute('data-name'));
    window.alert("Selected Odds " + elem.getAttribute('data-name'));
}

function handleFormSubmit(e) {
    e.preventDefault();
    let form = document.getElementsByTagName("Form")[0];
    let hubPath = ActionCreateOdds
    if (form.action.includes("Edit")) {
        hubPath = ActionEditOdds
    }
    let formData = {};
    console.log(form.elements[0].name)
    for (let i = 0; i < form.elements.length; i++) {
        formData[form.elements[i].name] = form.elements[i].value
    }
    connection.invoke(hubPath, formData);
    window.location.href = "/OddsHandler"

}
