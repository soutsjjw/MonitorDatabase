"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dbHub").build();


connection.on("DataChange", function (json) {
    json = JSON.parse(json);
    console.log(json.length);
    console.log(json);

    $('table > tbody').empty();

    json.forEach(function (item) {
        var $tbody = $('table > tbody');
        $tbody.append('<tr><th>' + item.Uid + '</th><td>' + item.Name + '</td><td>' + item.Tel + '</td><td>' + item.Company + '</td><td>' + item.Area + '</td><td>' + item.ImageUrl + '</td><td>' + item.Remake + '</td><td>' + item.CreateTime + '</td></tr>');
    });
});

connection.start().then(function () {
    // document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});