import React from 'react';
import { render } from 'react-dom';

const App = () => (
    <React.Fragment>
        <h1>React in ASP.NET MVC!</h1>
        <div>Hello React World</div>
    </React.Fragment>
)

render(<App />, document.getElementById('app'));