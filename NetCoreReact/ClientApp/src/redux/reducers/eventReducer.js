export const initialState = {
    events: [
        {
            id: 1,
            title: "Atjumania",
            decription: "p'et sot atjumanyi s'em raz na djzen",
            eventDate: new Date("2021-03-01T11:11:00"),
        },
        {
            id: 2,
            title: "Atjumania",
            decription: "p'et sot atjumanyi s'em raz na djzen",
            eventDate: new Date("2021-03-02T11:11:00"),
        },
        {
            id: 3,
            title: "Atjumania",
            decription: "p'et sot atjumanyi s'em raz na djzen",
            eventDate: new Date("2021-03-03T11:11:00"),
        },
        {
            id: 4,
            title: "Atjumania",
            decription: "p'et sot atjumanyi s'em raz na djzen",
            eventDate: new Date("2021-03-04T11:11:00"),
        },
    ],
};

export const reducer = (state = initialState, action) => {
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
