var loadForm = function (res) {
    // parse HTML string
    var createHTML = document.createElement('html');
    createHTML.innerHTML = res;
    var forms = createHTML.getElementsByTagName('form');
    var form = forms[0];

    var out = document.getElementById('create-form');
    if (out === null) {
        out = document.createElement('div');
        out.id = 'create-form';

        var footer = document.getElementsByTagName('footer')[0];
        footer.parentNode.insertBefore(out, footer);
    }
    out.innerHTML = '';
    out.appendChild(form);

}

var getCreateForm = function () {
    $.get({
        url: '/Students/Create',
        success: function (res) {
            loadForm(res)
            last_res = res
            // console.log(res)
        }
    })
    // var oReq = new XMLHttpRequest();
    // oReq.addEventListener('load', function (res) {
    //     last_res = res
    //     console.log(res)
    // })
    // oReq.open('POST', '/Students/CreateForm')
    // oReq.send()
}