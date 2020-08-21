// Wait for the DOM to be ready
$(function () {

    // Custom validation
    $.validator.addMethod("nosymbols", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9_.-]*$/i.test(value);
    }, "No special characters allowed");

    $.validator.addMethod("lettersonly", function (value, element) {
        return this.optional(element) || /^[a-zA-Z]*$/i.test(value);
    }, "Letters only");

    // Initialize form validation
    $("#frmNewUser").validate({
        // Specify validation rules
        rules: {

            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            txtFirstName: {
                required: true,
                minlength: 1,
                maxlength: 50,
                lettersonly: true
            },
            txtMiddleName: {
                maxlength: 50,
                lettersonly: true
            },
            txtLastName: {
                required: true,
                minlength: 1,
                maxlength: 50,
                lettersonly: true
            },
            txtEmployeeID: {
                required: true,
                minlength: 6,
                maxlength: 6,
                number: true
            },
            txtEmail: {
                required: true,
                email: true,
                remote: function () {
                    var r = {
                        url: "newUser.aspx/CheckDuplicateEmail",
                        type: "post",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: "{'strEmail': '" + $('#txtEmail').val() + "'}",
                        dataFilter: function (data) {
                            return (JSON.parse(data)).d;
                        }
                    }
                    return r;
                }
            },
            sltDepartment: {
                required: true
            },
            txtUsername: {
                required: true,
                minlength: 3,
                maxlength: 20,
                nosymbols: true,
                remote: function () {
                    var r = {
                        url: "newUser.aspx/CheckDuplicateUsername",
                        type: "post",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: "{'strUsername': '" + $('#txtUsername').val() + "'}",
                        dataFilter: function (data) {
                            return (JSON.parse(data)).d;
                        }
                    }
                    return r;
                }
            },
            txtPassword: {
                required: true,
                minlength: 5,
                maxlength: 25
            },

        },

        // Specify validation error messages
        messages: {
            txtFirstName: {
                required: "Enter first name",
                minlength: "Minimum length is 1 character",
                maxlength: "Maximum length is 50 characters",
                letteronly: "Enter letters only"
            },
            txtMiddleName: {
                maxlength: "Maximum length is 50 characters",
                letteronly: "Letters only"
            },
            txtLastName: {
                required: "Enter last name",
                minlength: "Minimum length is 1 character",
                maxlength: "Maximum length is 50 characters",
                letteronly: "Enter letters only"
            },
            txtEmployeeID: {
                required: "Enter employee ID",
                minlength: "Must be 6 digits",
                maxlength: "Must be 6 digits",
                number: "Enter numbers only"
            },
            txtEmail: {
                required: "Enter email",
                email: "Invalid email entered",
                remote: "Email already in use"
            },
            sltDepartment: {
                required: "Select department"
            },
            txtUsername: {
                required: "Enter username",
                minlength: "Minimum length is 3 characters",
                maxlength: "Maximum length is 20 characters",
                nosymbols: "No special characters allowed",
                remote: "Username already in use"
            },
            txtPassword: {
                required: "Enter password",
                minlength: "Minimum length is 3 characters",
                maxlength: "Maximum length is 25 characters",
            }
        },

        // Uncomment for eager validation - Validate when focus leaves
        //onfocusout: function (element) {
        //    this.element(element);
        //},

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function(form) {
            form.submit();
        },
    });
});