let authors = [];
let connection = null;
getdata();
setupSignalR();

let authorIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:29693/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AuthorCreated", (user, message) => {
        getdata();
    });

    connection.on("AuthorDeleted", (user, message) => {
        getdata();
    });

    connection.on("AuthorUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:29693/author')
        .then(x => x.json())
        .then(y => {
            authors = y;
            console.log(y);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    authors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
        `<button type="button" onclick="remove(${t.id})">Delete</button>` + 
        `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function QueryOne() {
    document.getElementById('one').innerHTML = "";
    fetch('http://localhost:29693/query/QueryOne')
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            document.getElementById('one').innerHTML += data;
            //data.forEach(x => { document.getElementById('one').innerHTML += (x.name + ", ") })
        })
        .catch((error) => { console.error('Error:', error); });
}

function QueryTwo() {
    document.getElementById('two').innerHTML = "";
    fetch('http://localhost:29693/query/QueryTwo')
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            document.getElementById('two').innerHTML += data;
            //data.forEach(x => { document.getElementById('two').innerHTML += (x.title + ", ") })
        })
        .catch((error) => { console.error('Error:', error); });
}

function QueryThree() {
    document.getElementById('three').innerHTML = "";
    fetch('http://localhost:29693/query/QueryThree')
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            document.getElementById('three').innerHTML += data;
            //data.forEach(x => { document.getElementById('three').innerHTML += (x.name + ", ") })
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('authornametoupdate').value = authors.find(t => t['id'] == id)['name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    authorIdToUpdate = id;
}

function remove(id) {
    fetch('http://localhost:29693/author/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('authornametoupdate').value;
    fetch('http://localhost:29693/author', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, Id: authorIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('authorname').value;
    fetch('http://localhost:29693/author', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}