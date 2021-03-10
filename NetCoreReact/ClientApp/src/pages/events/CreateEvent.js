import React, { useState } from "react";
import PropTypes from "prop-types";
import {
    Button,
    DialogTitle,
    DialogContent,
    DialogContentText,
    FormControlLabel,
    TextField,
    Dialog,
    DialogActions,
    Box,
    Checkbox,
    Select,
    MenuItem,
    Typography,
} from "@material-ui/core";
import MultiSelect from "react-multi-select-component";

function CreateEvent({ onCreate, isEdit = false, editedEvent = null }) {
    const users = [
        { id: 0, name: "King", label: "King", value: "King" },
        { id: 1, name: "Nick", label: "Nick", value: "Nick" },
        { id: 2, name: "Mike", label: "Mike", value: "Mike" },
        { id: 3, name: "Steve", label: "Steve", value: "Steve" },
        { id: 4, name: "Jack", label: "Jack", value: "Jack" },
    ];

    function useInputValue(
        defaultValues = {
            title: "Enter title",
            description: "Enter description",
            startDate: new Date(),
            endDate: new Date(),
            allDay: false,
            place: "",
            users: [],
        }
    ) {
        const [values, setValue] = useState(defaultValues);

        return {
            bind: {
                values,
                onChange: (event) =>
                    setValue({
                        ...values,
                        [event.target.name]: event.target.value,
                    }),
            },
            clear: () => setValue(defaultValues),
            value: () => values,
        };
    }

    const [selectedUsers, setSelectedUsers] = useState([]);

    const [open, setOpen] = React.useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    const defaultValues = {
        title: "Enter title",
        description: "Enter description",
        startDate: "2021-03-25",
        endDate: "2021-03-26",
        allDay: false,
        place: "",
        users: [],
    };
    const input = useInputValue(defaultValues); //

    const saveHandler = (event) => {
        event.preventDefault();

        if (input.value()) {
            onCreate(input.value());
            input.clear();
            handleClose();
        }
    };

    function handleChange() {
        debugger;
        input.bind.values.allDay = !input.bind.values.allDay;
    }

    return (
        <Box>
            <Button variant="outlined" onClick={handleClickOpen}>
                {isEdit ? "Edit event" : "Create event"}
            </Button>
            <Dialog
                open={open}
                onClose={handleClose}
                aria-labelledby="form-dialof-contact"
            >
                <DialogTitle id="form-dialof-contact">Create event</DialogTitle>
                <DialogContent>
                    {/* <DialogContentText>Enter event</DialogContentText> */}
                    <TextField
                        autoFocus
                        margin="dense"
                        id="title"
                        label="Title"
                        type="text"
                        name="title"
                        defaultValue={defaultValues.title}
                        fullWidth
                        {...input.bind}
                    />
                    <TextField
                        margin="dense"
                        id="description"
                        label="Description"
                        type="text"
                        name="description"
                        defaultValue={defaultValues.description}
                        multiline
                        fullWidth
                        {...input.bind}
                    />
                    <TextField
                        margin="dense"
                        id="start"
                        label="Event Start Date"
                        type="datetime-local"
                        name="startDate"
                        defaultValue={defaultValues.startDate}
                        InputLabelProps={{
                            shrink: true,
                        }}
                        {...input.bind}
                    />
                    <br />
                    <TextField
                        margin="dense"
                        id="end"
                        label="Event End Date"
                        type="datetime-local"
                        name="endDate"
                        defaultValue={defaultValues.endDate}
                        InputLabelProps={{
                            shrink: true,
                        }}
                        {...input.bind}
                    />
                    <br />
                    <FormControlLabel
                        control={
                            <Checkbox name="allDay" onChange={handleChange} />
                        }
                        label="is event for all day?"
                    />
                    <br />
                    <FormControlLabel
                        fullWidth
                        // style={{ paddingLeft: "20px", width: "180px" }}
                        control={
                            <Select
                                id="selectPlace"
                                label="place for event"
                                fullWidth
                                name="place"
                                {...input.bind}
                            >
                                <MenuItem value="Office">Office</MenuItem>
                                <MenuItem value="Skype">Skype</MenuItem>
                                <MenuItem value="Zoom">Zoom</MenuItem>
                            </Select>
                        }
                        label="Place: "
                        labelPlacement="start"
                    />
                    <br />

                    <MultiSelect
                        options={users}
                        name="users"
                        value={selectedUsers}
                        onChange={setSelectedUsers}
                        labelledBy={"Select"}
                        overrideStrings={{
                            selectSomeItems: "Select users...",
                            allItemsAreSelected: "All users are selected.",
                        }}
                    />
                </DialogContent>

                <DialogActions>
                    <Button onClick={handleClose}>Cancel</Button>
                    <Button onClick={saveHandler}>Save</Button>
                </DialogActions>
            </Dialog>
        </Box>
    );
}

CreateEvent.propTypes = {
    onCreate: PropTypes.func.isRequired,
    isEdit: PropTypes.bool,
    editedEvent: PropTypes.object,
};

export default CreateEvent;
