$.ajax({
    type: "POST",
    url: '/Dislike/' + id,
}).done(function (result) {
    var html = ""
    for (var i = 0; i < result.length; i++) {
        html += '<tr><td>' + result[i].id + '</td><td>' + result[i].Dislike + '</td><td><button onclick="Dislike(' + result[i].id + ',true)">Dislikes</button></td></tr>'
    }
    document.getElementById("UserVotes").innerHTML = html;
});