const initialState = {
    notificationsList: [],
};

export const notificationsReducer = (state = initialState, action) => {
    switch (action.type) {
        case "PUSH_NOTIFICATION":
            return { ...state, loading: true };

        default:
            return state;
    }
};
