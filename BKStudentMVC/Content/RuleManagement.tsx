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
}