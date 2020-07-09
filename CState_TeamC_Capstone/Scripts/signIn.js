// Wait for the DOM to be ready
$(document).ready(function () {
    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("#frmSignIn").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            txtUsername: {
                required: true,
                minlength: 3,
                maxlength: 20
            },
            txtPassword: {
                required: true,
                minlength: 5,
                maxlength: 25
            }
        },
        // Specify validation error messages
        messages: {
            txtUsername: {
                required: "Enter a username",
                minlength: "Minimum username length is 3 characters",
                maxlength: "Maximum username length is 20 characters"
            },
            txtPassword: {
                required: "Enter a password",
                minlength: "Minimum password length is 5 characters",
                maxlength: "Maximum password length is 25 characters"
            }
        },
        // Show validation summary at the top
        errorContainer: "#incompleteWrapper, #incompleteInput",
        errorLabelContainer: "#incompleteInput",
        wrapper: "li",
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function(form) {
            form.submit();
        },
    });
});