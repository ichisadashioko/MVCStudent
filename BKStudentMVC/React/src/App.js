import React, { Component } from "react";
import { hot } from "react-hot-loader";
import "./App.css";

class RuleRow extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <tr>
                <td>{this.props.FullName}</td>
                <td>{this.props.Description}</td>
                <td>{this.props.Active}</td>
            </tr>
        )
    }
}

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            rules: [],
            page: 1,
            hasMore: true,
        };
    }
    updateState(prevState, data) {
        return {
            rules: prevState.rules.concat(data.rules),
            page: prevState.page = 1,
            hasMore: data.hasMore,
        }
    }

    renderRows() {
        return this.state.rules.map((rule) => (<RuleRow props={rule}></RuleRow>));
    }

    loadMoreClicked() {
        let url = '/Home/Rules?page=' + this.state.page;
        let xhr = new XMLHttpRequest();
        xhr.open('GET', url, true);
        xhr.setRequestHeader('Content-Type', 'application/json');

        xhr.onload = () => {
            let data = JSON.parse(xhr.responseText);
            this.setState(this.updateState(this.state, data))
        };
        xhr.send();
    }
    renderMoreRow() {
        if (this.state.hasMore) {
            return (
                <button onClick={this.loadMoreClicked}>Load more</button>
            )
        }
    }

    componentDidMount() {
        let url = '/Home/Rules?page=' + this.state.page;
        let xhr = new XMLHttpRequest();
        xhr.open('GET', url, true);
        xhr.setRequestHeader('Content-Type', 'application/json');

        xhr.onload = () => {
            let data = JSON.parse(xhr.responseText);
            console.log(data)
            this.updateState(data)
        };
        xhr.send();
    }

    render() {
        return (
            <div className="container">
                <table className="table">
                    <thead>
                        <tr>
                            <th>FullName</th>
                            <th>Description</th>
                            <th>Active</th>
                        </tr>

                    </thead>
                    <tbody>
                        {this.renderRows()}
                    </tbody>
                </table>
                {this.renderMoreRow()}
            </div>
        );
    }
}

export default hot(module)(App);