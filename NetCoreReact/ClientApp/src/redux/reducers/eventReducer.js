export const initialState = {
    events: [
        {
            id: 1,
            title: "Atjumania",
            decription: "p'et sot atjumanyi s'em raz na djzen",
            startDate: new Date("2021-03-01T11:11:00"),
            endDate: new Date("2021-03-01T12:11:00"),
            allDay: false,
            users: [],
        },
    ],
};

export const eventReducer = (state = initialState, action) => {
    switch (action.type) {
        case "SET_EVENTS":
            return { ...state, events: action.events };
        case "ADD_EVENT":
            return { ...state, events: [...state.events, action.evnt] };
        case "UPDATE_EVENT":
            return {
                ...state,
                events: action.events.map((evnt) => {
                    if (evnt.id === action.evnt.id) return action.evnt;
                    else {
                        return evnt;
                    }
                }),
            };
        case "REMOVE_EVENT":
            return {
                ...state,
                events: action.events.filter(({ id }) => id !== action.id),
            };

        default:
            return state;
    }
};
