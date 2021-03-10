import { createSelector } from "reselect";

const getEventState = (state) => state.events;

export const getEvents = createSelector([getEventState], (s) => s.events);
