type RuleProps = {
    FullName: string;
    Description: string;
    Active: boolean;
};

type RulesBoxProps = {
    initialRules: RuleProps[];
    page: number;
};

function RulesBox(props: RulesBoxProps) {
    let [state, updateState] = React.useState({
        rules: props.initialRules,
        page: props.page,
        hasMore: true,
        loadingMore: false,
    });

    function loadMoreClicked(evt: { preventDefault: () => void }) {
        let nextPage = state.page + 1;
        let rules = state.rules;
        updateState(prevState => ({
            ...prevState,
            page: nextPage,
            loadingMore: true,
        }));

        let url = '/Home/Rules/' + (state.page + 1);
        let xhr = new XMLHttpRequest();
        xhr.open('GET', url, true);
        xhr.setRequestHeader('Content-Type', 'application/json');

        xhr.onload = () => {
            let data = JSON.parse(xhr.responseText);
            updateState(prevState => ({
                ...prevState,
                rules: rules.concat(data.rules),
                hasMore: data.hasMore,
                loadingMore: false,
            }));
        };
        xhr.send();
        evt.preventDefault();
    }

    let ruleNodes = state.rules.map((rule: RuleProps) => (
        <RuleRow rule={rule}></RuleRow>
    ));

    function renderMoreLink() {
        if (state.loadingMore) {
            return <em>Loading...</em>
        } else if (state.hasMore) {
            return (
                <Reactstrap.Button onClick={loadMoreClicked}>
                    Load More
                </Reactstrap.Button>
            );
        } else {
            return <em>No more rules</em>;
        }
    }

    return (
        <div className="rules">
            <h1>Rules </h1>
            <ol className="ruleList">{ruleNodes}></ol>
            {renderMoreLink()}
            <hr />
        </div>
    );
}

class RuleRow extends React.Component<{ rule: RuleProps }>{
    static propTypes = {
        rule: PropTypes.object.isRequired,
    };

    render() {
        return (
            <tr>
                <td>{this.props.FullName}</td>
                <td>{this.props.Description}</td>
                <td>{this.props.Active}</td>
            </tr>
        );
    }
}