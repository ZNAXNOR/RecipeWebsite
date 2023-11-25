$.ajax({
    type: "POST",
    url: '/Like/' + id,
}).done(function (result) {
    var html = ""
    for (var i = 0; i < result.length; i++) {
        html += '<tr><td>' + result[i].id + '</td><td>' + result[i].Like + '</td><td><button onclick="Like(' + result[i].id + ',true)">Like</button></td></tr>'
    }
    document.getElementById("UserVotes").innerHTML = html;
});