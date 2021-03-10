import React from "react";
import { Paper, Button, Typography } from "@material-ui/core";

import { submitAsyncValidation } from "../../utils/forms";

export default ({
    handleSubmit,
    enabledSubmit,
    onSubmit,
    submitText,
    onBottomTextClick,
    bottomText,
    fields,
}) => {
    return (
        <Box>
            <Container>
                <Form
                    onSubmit={submitAsyncValidation(
                        handleSubmit,
                        enabledSubmit,
                        onSubmit
                    )}
                >
                    <Typography>Auth</Typography>
                    {fields}
                    <SubmitButton
                        type="submit"
                        variant="outlined"
                        disabled={!enabledSubmit}
                    >
                        {submitText}
                    </SubmitButton>
                </Form>
            </Container>
            <BottomText
                onClick={onBottomTextClick}
                color="primary"
                size="small"
            >
                {bottomText}
            </BottomText>
        </Box>
    );
};
