import axios from "axios";

export const addEvent = (evnt) => ({
    type: "ADD_EVENT",
    evnt,
});

export const updateEvent = (evnt) => ({
    type: "UPDATE_EVENT",
    evnt,
});

export const removeEvent = (id) => ({
    type: "UPDATE_EVENT",
    id,
});

export const setEvent = (evnt) => ({
    type: "SET_EVENT",
    evnt,
});

export const setEvents = (events) => ({
    type: "SET_EVENTS",
    events,
});

export const startAddingEvent = (evnt) => {
    return (dispatch, getState) => {
        axios
            .post(`${process.env.REACT_APP_EVENT_SERVICE}/event`, evnt)
            .then((response) => {
                dispatch(addEvent(response.data));
            })
            .catch((error) => console.log(error));
    };
};

export const startUpdatingEvent = (evnt) => {
    return (dispatch, getState) => {
        axios
            .put(
                `${process.env.REACT_APP_EVENT_SERVICE}/event/${evnt.id}`,
                evnt
            )
            .then((response) => {
                dispatch(updateEvent(evnt));
            })
            .catch((error) => console.log(error));
    };
};

export const startDeletingEvent = (id) => {
    return (dispatch, getState) => {
        axios
            .delete(`${process.env.REACT_APP_EVENT_SERVICE}/event/${id}`, id)
            .then((response) => {
                dispatch(addEvent(id));
            })
            .catch((error) => console.log(error));
    };
};

export const startSettingEvents = () => {
    return (dispatch, getState) => {
        axios
            .post(`${process.env.REACT_APP_EVENT_SERVICE}/event`)
            .then((response) => {
                dispatch(setEvents(response.data));
            })
            .catch((error) => console.log(error));
    };
};

export const startSettingEvent = (id) => {
    return (dispatch, getState) => {
        axios
            .post(`${process.env.REACT_APP_EVENT_SERVICE}/event/${id}`)
            .then((response) => {
                dispatch(setEvent(response.data));
            })
            .catch((error) => console.log(error));
    };
};
