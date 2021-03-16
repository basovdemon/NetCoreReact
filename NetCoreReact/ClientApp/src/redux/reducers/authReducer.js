export const initialState = {
    profile: {
        id: "",
        email: "",
        username: "",
        password: "",
    },
};

export const authReducer = (state = initialState, action) => {
    debugger;
    switch (action.type) {
        case "REGISTER_PROFILE":
            return { ...state, profile: action.payload };
        case "LOGIN_PROFILE":
            return { ...state, profile: action.payload };
        case "SET_PROFILE":
            return { ...state, profile: action.profile };
        case "LOGOUT_PROFILE":
            return { ...state, profile: action.payload };

        default:
            return state;
    }
};
