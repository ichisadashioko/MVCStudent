var loadForm = function (res) {
    var out = document.getElementById('create-form');
    if (out === null) {
        out = document.createElement('div');
        out.id = 'create-form';

        var footer = document.getElementsByTagName('footer')[0];
        footer.parentNode.insertBefore(out, footer);
    }
    out.innerHTML = res;
}

var removeForm = function () {
    var out = document.getElementById('create-form');
    if (out === null) {
        out = document.createElement('div');
        out.id = 'create-form';

        var footer = document.getElementsByTagName('footer')[0];
        footer.parentNode.insertBefore(out, footer);
    }
    out.innerHTML = '';

}

var getCreateForm = function () {
    $.get({
        url: '/Students/AjaxCreate',
        success: function (res) {
            loadForm(res)
            last_res = res
            // console.log(res)
        }
    })
}
var submitCreate = function () {
    var data = {
        FirstName: document.getElementById('FirstName').value,
        LastName: document.getElementById('LastName').value,
        Gender: document.getElementById('Gender').value,
        DoB: document.getElementById('DoB').value,
    }

    console.log('=== Input data ===');
    console.log(data)
    console.log('==================')

    $.post({
        url: "/Students/AjaxCreate",
        data: data,
        success: function (res) {
            console.log('=== Success ===')
            console.log(res)
            if (res['success']) {
                var student = res['student'];
                var FirstName = student['FirstName'];
                var LastName = student['LastName'];
                var Gender = student['Gender'];
                var ID = student['ID'];
                var DoB = student['DoB'];

                var tr = document.createElement('tr')
                var rowHtml = `<td>${FirstName}</td><td>${LastName}</td><td>${DoB}</td><td>${Gender}</td><td><a href="/Students/Edit/${ID}">Edit</a> | <a href="/Students/Details/${ID}">Details</a> | <a href="/Students/Delete/${ID}">Delete</a></td>`
                //var rowHtml = res['rowHtml'];
                tr.innerHTML = rowHtml;

                var table = document.getElementById('student-list');
                var tbody = table.getElementsByTagName('tbody')[0];
                tbody.appendChild(tr);

                removeForm();
            }
        },
        error: function (err) {
            console.log('=== Failed ===')
            console.log(err)
        }
    })
}