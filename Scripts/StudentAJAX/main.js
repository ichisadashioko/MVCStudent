StudentAJAX = {}

StudentAJAX.defaultURL = '/Students'

window.addEventListener('popstate', function (e) {
    console.log(`e.state = ${e.state}`)
    if (e.state == null) {
        StudentAJAX.get(StudentAJAX.defaultURL)
    } else {
        StudentAJAX.get(e.state)
    }
})
StudentAJAX.overlayOn = function () {
    document.querySelector("#overlay").style.display = "block";
}

StudentAJAX.overlayOff = function () {
    document.querySelector("#overlay").style.display = "none";
}

StudentAJAX.get = function (url) {
    console.log(`Getting ${url}`)
    $.get({
        url: url,
        success: function (res) {

            // update the whole page content
            document.open()
            document.write(res)
            document.close()
            // console.log(res)

            // modify the url
            window.history.pushState(url, null, url)
            StudentAJAX.overlayOff()
        }
    })
}


window.addEventListener("onload", function (evt) {
    StudentAJAX.anchors = document.getElementsByTagName('a')

    for (let i = 0; i < StudentAJAX.anchors.length; i++) {
        StudentAJAX.anchors[i].addEventListener('click', function (e) {
            if (e.target != e.currentTarget) {
                e.preventDefault()
            }
            e.stopPropagation()
            var url = e.target.getAttribute('href')
            if (url) {
                StudentAJAX.overlayOn()
                StudentAJAX.get(url)
            }


        }, false)
    }
})