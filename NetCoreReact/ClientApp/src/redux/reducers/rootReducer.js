import { combineReducers } from "redux";
import { connectRouter } from "connected-react-router";

import * as eventReducer from "./eventReducer";
import { appReducer } from "./appReducer";
import { notificationsReducer } from "./notificationsReducer";

export const initialState = {
    events: eventReducer.initialState,
};

export const rootReducer = (history) =>
    combineReducers({
        events: eventReducer.reducer,
        notifications: notificationsReducer,
        app: appReducer,
        router: connectRouter(history),
    });
