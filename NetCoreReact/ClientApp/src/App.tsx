import * as React from "react";
import { Redirect, Route } from "react-router";
import { connect } from "react-redux";

import Layout from "./pages/app/components/Layout";
import EventsPage from "./pages/events/EventsPage";
import EventsNotifications from "./pages/notifications/EventsNotifications";
import AuthPage from "./pages/auth/AuthPage";
import { AlertCustom } from "./pages/app/components/AlertCustom";

import "./custom.css";

export default (/*props*/) => (
    <Layout>
        {/* {props.alert && <AlertCustom text={props.alert} />} */}
        <Route exact path="/" render={() => <Redirect to="/events" />} />

        <Route path="/events" component={EventsPage} />
        <Route path="/notification" component={EventsNotifications} />
        <Route path="/auth" component={AuthPage} />
    </Layout>
);

// const mapStateToProps = (state) => ({
//     alert: state.app.alert,
// });

// export default connect(mapStateToProps, null)(App);
