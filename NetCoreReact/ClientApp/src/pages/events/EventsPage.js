import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import EventsCalendar from "./EventsCalendar";

// import { getEvents } from "../../redux/selectors/eventSelector";
import {
    startAddingEvent,
    startDeletingEvent,
    startUpdatingEvent,
    startSettingEvent,
    startSettingEvents,
} from "../../redux/actions/eventActions";

function EventsPage(props) {
    return (
        <>
            <EventsCalendar events={props.events} />
        </>
    );
}

// const mapStateToProps = (state) => {
//     return { events: state.events.events };
// };

const mapDispatchToProps = (dispatch) => ({
    startAddingEvent: bindActionCreators(startAddingEvent, dispatch),
    startDeletingEvent: bindActionCreators(startDeletingEvent, dispatch),
    startUpdatingEvent: bindActionCreators(startUpdatingEvent, dispatch),
    startSettingEvent: bindActionCreators(startSettingEvent, dispatch),
    startSettingEvents: bindActionCreators(startSettingEvents, dispatch),
});

export default connect(null, mapDispatchToProps)(EventsPage);
