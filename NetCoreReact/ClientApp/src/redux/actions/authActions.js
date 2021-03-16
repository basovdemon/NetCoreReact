import axios from "axios";

// export function registerProfile(profile) {
//     return {
//         type: "REGISTER_USER",
//         payload: profile,
//     };
// }

export const loginProfile = (profile) => {
    return (dispatch, getState) => {
        debugger;
        axios
            .post(`${process.env.REACT_APP_EVENT_SERVICE}/auth/login`, profile)
            .then((response) => {
                debugger;
                localStorage.setItem("token", response.data.access_token);
                dispatch(setProfile(response.data.profile));
            })
            .catch((error) => console.log(error));
    };
};

export const registerProfile = (profile) => {
    return (dispatch, getState) => {
        debugger;
        axios
            .post(
                `${process.env.REACT_APP_EVENT_SERVICE}/auth/register`,
                profile
            )
            .then((response) => {
                debugger;
                // dispatch(setToken(response.data));
            })
            .catch((error) => console.log(error));
    };
};

export const getProfileByToken = () => {
    return (dispatch, getState) => {
        debugger;
        axios
            .get(`${process.env.REACT_APP_EVENT_SERVICE}/auth/getProfile`, {
                headers: { Authorization: `Bearer ${localStorage.token}` },
            })
            .then((response) => {
                debugger;
                dispatch(loginProfile(response.data.profile));
            })
            .catch((error) => console.log(error));
    };
};

export const setProfile = (profile) => ({
    type: "SET_PROFILE",
    profile,
});

export const logoutProfile = (profile) => ({
    type: "LOGOUT_PROFILE",
    profile,
});
