// Wait for the DOM to be ready
$(document).ready(function () {
    // Custom validation
    $.validator.addMethod("nosymbols", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9_.-]*$/i.test(value);
    }, "No special characters allowed");

    $.validator.addMethod("lettersonly", function (value, element) {
        return this.optional(element) || /^[a-zA-Z]*$/i.test(value);
    }, "Letters only");

    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("#frmResetCredentials").validate({

        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            txtFirstName: {
                required: true,
                maxlength: 25,
                lettersonly: true
            },
            txtLastName: {
                required: true,
                maxlength: 25,
                lettersonly: true
            },
            txtEmail: {
                required: true,
                email: true
            },
            txtUsername: {
                required: true,
                minlength: 3,
                maxlength: 20,
                nosymbols: true
            },
            txtPassword: {
                required: true,
                minlength: 5,
                maxlength: 25
            }
        },

        // Specify validation error messages
        messages: {
            txtFirstName: {
                required: "Required",
                maxlength: "Maximum length is 25 characters",
                lettersonly: "Letters only"
            },
            txtLastName: {
                required: "Required",
                maxlength: "Maximum length is 25 characters",
                lettersonly: "Letters only"
            },
            txtEmail: {
                required: "Required",
                email: "Invalid email entered"
            },
            txtUsername: {
                required: "Required",
                minlength: "Minimum length is 3 characters",
                maxlength: "Maximum length is 20 characters",
                nosymbols: "No special characters allowed"
            },
            txtPassword: {
                required: "Required",
                minlength: "Minimum length is 5 characters",
                maxlength: "Maximum length is 25 characters"
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

function showHideDiv() {
    $("#frmResetCredentials").validate().resetForm();

    if (document.getElementById("radForgotUsername").checked) {
        document.getElementById("usernameDiv").style.display = "none";
        document.getElementById("passwordDiv").style.display = "block";
    } else if (document.getElementById("radForgotPassword").checked) {
        document.getElementById("passwordDiv").style.display = "none";
        document.getElementById("usernameDiv").style.display = "block";
    }
}