let authors = [];
getdata();

async function getdata() {
    await fetch('http://localhost:29693/author')
        .then(x => x.json())
        .then(y => {
            authors = y;
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    authors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>`
            + "</td></tr>";
    });
}


function create() {
    let name = document.getElementById('authorname').value;
    fetch('http://localhost:29693/author', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { actorName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:29693/author' + id, {
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