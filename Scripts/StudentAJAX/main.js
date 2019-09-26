StudentAJAX = {}

StudentAJAX.defaultURL = '/Students'

// StudentAJAX.list = function () {
//     $.post({
//         url: "/Students/JsonList",
//         success: function (res) {
//             console.log(typeof res)
//             console.log(res)
//         }
//     })
// }

// StudentAJAX.delete = function (id) {
//     var url = `/Students/Delete/${id}`;
//     $.get({
//         url: url,
//         success: function (res) {
//             // modify the url
//             window.history.pushState(res, null, url)

//             // update the whole page content
//             document.open()
//             document.write(res)
//             document.close()
//             // console.log(res)
//         }
//     })
//     return false;
// }

window.addEventListener('popstate', function (e) {
    console.log(`e.state = ${e.state}`)
    if (e.state == null) {
        StudentAJAX.get(StudentAJAX.defaultURL)
    } else {
        StudentAJAX.get(e.state)
    }
})

StudentAJAX.get = function (url) {
    if (!url) {
        return
    }
    console.log(`Getting ${url}`)
    $.get({
        url: url,
        success: function (res) {

            // update the whole page content
            document.open()
            document.write(res)
            document.close()
            // console.log(res)
        }
    })
}

StudentAJAX.anchors = document.getElementsByTagName('a')

for (let i = 0; i < StudentAJAX.anchors.length; i++) {
    StudentAJAX.anchors[i].addEventListener('click', function (e) {
        if (e.target != e.currentTarget) {
            e.preventDefault()
        }
        e.stopPropagation()
        var url = e.target.getAttribute('href')

        StudentAJAX.get(url)

        // modify the url
        window.history.pushState(url, null, url)
    }, false)
}

// StudentAJAX.anchors.foreach(function (element) {
//     element.addEventListener('click', function (e) {
//         if (e.target != e.currentTarget) {
//             e.preventDefault()
//         }
//         e.stopPropagation()
//         var url = e.target.getAttribute('href')

//         StudentAJAX.get(url)
//     }, false)
// })
