var re = /^([A-Za-z]+)((\s[A-Za-z]+)+)?$/;

text = [
    'alex',
    'alex alan',
    'alex ',
    'al12',
    '23 wer',
]

for(let i = 0; i < text.length; i++){
    txt = text[i]
    console.log(`=== ${txt} ===`)
    x = re.exec(txt)
    b = x === null
    console.log(x)
    console.log(b)
}