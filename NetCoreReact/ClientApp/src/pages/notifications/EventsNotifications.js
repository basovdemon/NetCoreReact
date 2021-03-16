import React, { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";
import { connect } from "react-redux";
import { Button, Container } from "@material-ui/core";

import { addEvent } from "../../redux/actions/eventActions";
import { showAlert } from "../../redux/actions/appActions";
import CreateEvent from "../events/CreateEvent";

function EventsNotifications(props) {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/notification")
        .build();

    hubConnection
        .start()
        .then(() => console.log("SignalR connection started!"))
        .catch((error) =>
            console.log("Error while establishing connection =(")
        );

    debugger;

    let list = ["rjulf", "kzlm"];

    const NotificationsList = (props) => {
        const [date, setDate] = useState();

        useEffect(() => {
            debugger;
            props.notificationsProps.on("sendToReact", (notification) => {
                list.push(notification);
                setDate(new Date());
            });
        }, []);

        return (
            <>
                {list.map((notification, index) => (
                    <p key={`notification${index}`}>{notification}</p>
                ))}
            </>
        );
    };

    // const CreateEventTest = () => {
    //     const [notification, setNotification] = useState("");

    //     const notificationChange = (event) => {
    //         if (event && event.target) {
    //             setNotification(event.target.value);
    //         }
    //     };

    //     const notificationSubmit = (event) => {
    //         debugger;
    //         // axios
    //         //     .post(
    //         //         `${process.env.REACT_APP_EVENT_SERVICE}/notification`,
    //         //         notification
    //         //     )
    //         //     .then((response) => {
    //         //         console.log(response.data);
    //         //     })
    //         //     .catch((error) => console.log(error));

    //         try {
    //             fetch(`${process.env.REACT_APP_EVENT_SERVICE}/notification`, {
    //                 method: "POST",
    //                 body: JSON.stringify({ notification: notification }),
    //                 headers: {
    //                     "Content-Type": "application/json",
    //                 },
    //             });
    //         } catch (e) {
    //             console.log("Creating notification failed.", e);
    //         }

    //         setNotification("");
    //     };

    //     return (
    //         <>
    //             <label>Event title:_</label>
    //             <input
    //                 type="text"
    //                 onChange={notificationChange}
    //                 value={notification}
    //             />
    //             <button onClick={notificationSubmit}>AddEvent</button>
    //         </>
    //     );
    // };

    const [notification, setNotification] = useState({
        title: "",
        description: "",
        startDate: "",
        endDate: "",
        allDay: "",
        place: "",
        users: "",
    });

    const notificationSubmit = (event) => {
        debugger;
        // setNotification(event);

        try {
            fetch(`${process.env.REACT_APP_EVENT_SERVICE}/notification`, {
                method: "POST",
                body: JSON.stringify({ notification: event }),
                headers: {
                    "Content-Type": "application/json",
                },
            });
        } catch (e) {
            console.log("Creating notification failed.", e);
        }

        setNotification("");
    };

    function createEventHandler(eventItem) {
        if (!eventItem.title.trim()) {
            return props.showAlert("Title can't be empty");
        }

        debugger;
        props.addEvent({
            title: eventItem.title,
            description: eventItem.description,
            startDate: eventItem.startDate,
            endDate: eventItem.endDate,
            allDay: eventItem.allDay,
            place: eventItem.place,
            users: eventItem.users,
        });
    }

    return (
        <>
            <Container maxWidth="md">
                <CreateEvent
                    onCreate={(createEventHandler, notificationSubmit)}
                />
                {/* <br />
                <CreateEventTest /> */}
                <br />
                <h4>Notifications:</h4>
                <NotificationsList notificationsProps={hubConnection} />
            </Container>
        </>
    );
}

const mapDispatchToProps = {
    addEvent,
    showAlert,
};

export default connect(null, mapDispatchToProps)(EventsNotifications);
