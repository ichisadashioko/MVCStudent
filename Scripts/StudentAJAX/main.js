StudentAJAX = {}

StudentAJAX.list = function () {
    $.post({
        url: "/Students/JsonList",
        success: function (res) {
            console.log(typeof res)
            console.log(res)
        }
    })
}