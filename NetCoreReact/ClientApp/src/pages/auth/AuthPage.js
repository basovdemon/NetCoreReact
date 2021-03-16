import React, { useEffect } from "react";
import { Container, Typography } from "@material-ui/core";
import { connect } from "react-redux";

import AuthForm from "../auth/AuthForm";

import { showAlert } from "../../redux/actions/appActions";
import {
    getProfileByToken,
    loginProfile,
} from "../../redux/actions/authActions";

function AuthPage(props) {
    debugger;
    useEffect(() => {
        props.getProfileByToken();
    });

    return (
        <Container>
            <Typography>
                Current User:{" "}
                {props.profile.username
                    ? props.profile.username
                    : "please Sign In or Sign Up"}
            </Typography>
            <br />
            <AuthForm />
            <br />
            <AuthForm isRegistered="false" />
        </Container>
    );
}

const mapStateToProps = (state) => {
    debugger;
    return { profile: state.profile.profile };
};

const mapDispatchToProps = (dispatch) => ({
    getProfileByToken: () => dispatch(getProfileByToken()),
    loginProfile: (profile) => dispatch(loginProfile(profile)),
    showAlert: () => dispatch(showAlert()),
});

export default connect(mapStateToProps, mapDispatchToProps)(AuthPage);
