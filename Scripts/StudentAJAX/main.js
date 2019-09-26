StudentAJAX = {}

// StudentAJAX.list = function () {
//     $.post({
//         url: "/Students/JsonList",
//         success: function (res) {
//             console.log(typeof res)
//             console.log(res)
//         }
//     })
// }

StudentAJAX.delete = function (id) {
    var url = `/Students/Delete/${id}`;
    $.get({
        url: url,
        success: function (res) {
            document.open()
            document.write(res)
            document.close()
            // console.log(res)
            window.history.pushState(res, document.title, url)
        }
    })
    return false;
}