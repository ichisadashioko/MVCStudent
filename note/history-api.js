var container = document.querySelector('.gallery');

container.addEventListener('click', function (e) {
    if (e.target != e.currentTarget) {
        e.preventDefault();
        // e.target is the image inside the link we just clicked
    }
    e.stopPropagation()
    var data = e.target.getAttribute('data-name'), url = data + '.html';
    history.pushState(data, null, url)

    // here we can fix the current classes
    // and update text with the data variable
    // and make an Ajax request for the .content element
    // finally we can manually update the document's title
}, false)

function requestContent(file) {
    $('.content').load(file + '.content')
}
window.addEventListener('popstate', function (e) {
    // e.state is equal to the data-attribute of the last image we clicked
    var character = e.state

    if (character == null) {
        removeCurrentClass()
        textWrapper.innerHTML = " ";
        content.innerHTML = " ";
        document.title = defaultTitle;
    } else {
        updateText(character);
        resquestContent(character + '.html')
        addCurrentClass(character)
        document.title = "Ghostbuster | " + character;
    }
})

