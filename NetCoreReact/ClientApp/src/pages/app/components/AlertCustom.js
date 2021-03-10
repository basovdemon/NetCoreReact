import React from "react";
import { Alert } from "@material-ui/lab";
import { Container } from "@material-ui/core";

export const AlertCustom = ({ text }) => (
    <Container>
        <Alert variant="outlined" severity="warning">
            {text}
        </Alert>
    </Container>
);
