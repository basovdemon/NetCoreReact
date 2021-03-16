import React, { useState } from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import {
    Button,
    DialogTitle,
    DialogContent,
    DialogContentText,
    TextField,
    Dialog,
    DialogActions,
    Box,
} from "@material-ui/core";

import { showAlert } from "../../redux/actions/appActions";
import { registerProfile, loginProfile } from "../../redux/actions/authActions";

function useInputValue(
    defaultValues = { username: "", email: "", password: "" }
) {
    const [values, setValue] = useState(defaultValues);

    return {
        bind: {
            values,
            onChange: (event) =>
                setValue({
                    ...values,
                    [event.target.name]: event.target.value,
                }),
        },
        clear: () => setValue(defaultValues),
        value: () => values,
    };
}

function AuthForm({ registerProfile, loginProfile, showAlert, isRegistered }) {
    const [open, setOpen] = React.useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    const defaultValues = { username: "", email: "", password: "" };

    const input = useInputValue(defaultValues); //

    const saveHandler = (event) => {
        event.preventDefault();

        if (input.value()) {
            onCreate(input.value());
            input.clear();
            handleClose();
        }
    };

    function onCreate(parms) {
        debugger;
        if (
            // !parms.username.trim() ||
            !parms.email.trim() ||
            !parms.password.trim()
        ) {
            return showAlert("Name can't be empty");
        }

        const profile = {
            email: parms.email,
            username: parms.username,
            password: parms.password,
        };

        {
            isRegistered ? loginProfile(profile) : registerProfile(profile);
        }
    }

    return (
        <Box>
            <Button variant="outlined" onClick={handleClickOpen}>
                {isRegistered ? "Sign In" : "Sign Up"}
            </Button>
            <Dialog
                open={open}
                onClose={handleClose}
                aria-labelledby="form-dialof-contact"
            >
                <DialogTitle id="form-dialof-contact">Profile</DialogTitle>
                <DialogContent>
                    <DialogContentText>Enter your data:</DialogContentText>
                    {!isRegistered && (
                        <TextField
                            autoFocus
                            margin="dense"
                            id="username"
                            label="Userame"
                            type="text"
                            name="username"
                            defaultValue={defaultValues.username}
                            fullWidth
                            {...input.bind}
                        />
                    )}
                    <TextField
                        margin="dense"
                        id="email"
                        label="Email"
                        type="email"
                        name="email"
                        defaultValue={defaultValues.email}
                        fullWidth
                        {...input.bind}
                    />
                    <TextField
                        margin="dense"
                        id="password"
                        label="Password"
                        type="password"
                        name="password"
                        defaultValue={defaultValues.password}
                        fullWidth
                        {...input.bind}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Cancel</Button>
                    <Button onClick={saveHandler}>
                        {isRegistered ? "Login" : "Register"}
                    </Button>
                </DialogActions>
            </Dialog>
        </Box>
    );
}

AuthForm.propTypes = {
    isRegistered: PropTypes.bool,
};

const mapStateToProps = (state) => {
    return { profile: state.profile };
};

const mapDispatchToProps = (dispatch) => ({
    registerProfile: (profile) => dispatch(registerProfile(profile)),
    loginProfile: (profile) => dispatch(loginProfile(profile)),
    showAlert: () => dispatch(showAlert()),
});

export default connect(mapStateToProps, mapDispatchToProps)(AuthForm);
