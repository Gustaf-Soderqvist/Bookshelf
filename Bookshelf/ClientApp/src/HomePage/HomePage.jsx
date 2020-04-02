import React from 'react';

import { userService, authenticationService } from '@/_services';

class HomePage extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            currentUser: authenticationService.currentUserValue,
            users: null
        };
    }

    componentDidMount() {
    }


    render() {
        const { currentUser, users } = this.state;
        return (
            <div>
                <div className="container">
                    <h1>Hi {currentUser.firstName}!</h1>
                    <p>You're logged in with React & JWT to this book application!!</p>
                </div>
            </div>
        );
    }

}

export { HomePage };