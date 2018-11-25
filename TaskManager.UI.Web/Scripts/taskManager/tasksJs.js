
if (localStorage.token === "" || localStorage.token === undefined) {
    document.location.replace('/home/index');
}

function listTasks() {    
    $.ajax({
        url: '/Task/GetMyTasks/?id=' + localStorage.userId,
        contentType: 'application/json; charset=UTF-8',
        type: 'GET',
        headers: { "Authorization": localStorage.token },
        cache: false,
        success: function (data) {
            $('#tableTasks > tbody').empty();
            for (var i = 0; i < data.length; i++) {
                var table = "";
                table = "<tr>";
                table += "<td>" + data[i].Id + "</td>";
                table += "<td>" + data[i].Owner + "</td>";
                table += "<td>" + data[i].Title + "</td>";
                table += "<td class='" + data[i].Status + "'>" + data[i].Status + "</td>";
                table += "<td>" + data[i].Priority + "</td>";
                table += "<td>" + data[i].Date + "</td>";
                table += "<td><a href='/Task/Edit/?id=" + data[i].Id +"'class='btn btn-light'>View</a></td>";
                table += "<td><button type='button' class='btn btn-danger' onclick='remove(" + data[i].Id + ");'>Delete</button></td>";
                table += "</tr>";

                $(table).appendTo('#tableTasks > tbody');                
            }
        },
        error: function (erro) {
            console.log(erro);
        }
    });

}


function remove(id) {   
    if (confirm('Are you sure you want to remove the Task number '+ id +'?')) {
        $.ajax({
            url: '/Task/Delete?id=' + id ,
            contentType: 'application/json; charset=UTF-8',
            type: 'GET',
            headers: { "Authorization": localStorage.token },
            cache: false,
            success: function (data) {               
                if (data.result) {
                    listTasks();
                } else {
                    alert(data.msg);
                }
            }           
        });
    } 

}


$(function () {
    listTasks();
});


