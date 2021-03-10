import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import EventsCalendar from "./EventsCalendar";

import { getEvents } from "../../redux/selectors/eventSelector";
import {
    startAddingEvent,
    startDeletingEvent,
    startUpdatingEvent,
    startSettingEvent,
    startSettingEvents,
} from "../../redux/actions/eventActions";

function EventsPage(props) {
    return (
        <div>
            <EventsCalendar events={props.events} />
        </div>
    );
}

const mapStateToProps = (state) => {
    return { events: getEvents(state) };
};

const mapDispatchToProps = (dispatch) => ({
    startAddingEvent: bindActionCreators(startAddingEvent, dispatch),
    startDeletingEvent: bindActionCreators(startDeletingEvent, dispatch),
    startUpdatingEvent: bindActionCreators(startUpdatingEvent, dispatch),
    startSettingEvent: bindActionCreators(startSettingEvent, dispatch),
    startSettingEvents: bindActionCreators(startSettingEvents, dispatch),
});

export default connect(mapStateToProps, mapDispatchToProps)(EventsPage);
