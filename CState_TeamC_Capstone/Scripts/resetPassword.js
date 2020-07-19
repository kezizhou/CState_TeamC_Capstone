// Wait for the DOM to be ready
$(document).ready(function () {

    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("#frmNewPassword").validate({

        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            txtPassword: {
                required: true,
                minlength: 5,
                maxlength: 25
            },
            txtConfirmedPassword: {
                required: true,
                equalTo: "#txtPassword"
            }
        },

        // Specify validation error messages
        messages: {
            txtPassword: {
                required: "Required",
                minlength: "Minimum length is 5 characters",
                maxlength: "Maximum length is 25 characters"
            },
            txtConfirmedPassword: {
                required: "Required",
                equalTo: "Passwords do not match"
            }
        },

        // Uncomment for eager validation - Validate when focus leaves
        //onfocusout: function (element) {
        //    this.element(element);
        //},

        // Remove focus on validate
        focusInvalid: false,

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        },
    });
});