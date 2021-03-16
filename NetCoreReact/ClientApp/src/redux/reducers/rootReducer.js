import { combineReducers } from "redux";
import { connectRouter } from "connected-react-router";

import { eventReducer } from "./eventReducer";
import { usersReducer } from "./usersReducer";
import { authReducer } from "./authReducer";
import { appReducer } from "./appReducer";
import { notificationsReducer } from "./notificationsReducer";

export const initialState = {
    profile: authReducer.initialState,
    events: eventReducer.initialState,
    users: usersReducer.initialState,
};

export const rootReducer = (history) =>
    combineReducers({
        profile: authReducer,
        events: eventReducer,
        users: usersReducer,
        app: appReducer,
        notifications: notificationsReducer,
        router: connectRouter(history),
    });
