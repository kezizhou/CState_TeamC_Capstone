// Wait for the DOM to be ready
$(function () {
    // Custom validation
    $.validator.addMethod("greaterThan", function (value, element, params) {
        if (!/Invalid|NaN/.test(new Date(value))) {
            return new Date(value) > new Date($(params).val());
        }

        return isNaN(value) && isNaN($(params).val())
            || (Number(value) > Number($(params).val()));
    }, "Must be greater than {0}");

    $.validator.addMethod("maxDate", function (value, element) {
        var curDate = new Date();
        var inputDate = new Date(value);
        return this.optional(element) || inputDate <= curDate;
    }, "Start date cannot be after today");

    $("#frmDateRange").validate({
        rules: {
            dteStart: {
                required: true,
                maxDate: true
            },
            dteEnd: {
                required: true,
                greaterThan: "#dteStart"
            }
        },
        messages: {
            dteStart: {
                required: "Select start date",
                maxDate: "Start cannot be after today"
            },
            dteEnd: {
                required: "Select end date",
                greaterThan: "End must occur after start"
            }
        },

        errorPlacement: function (error, element) {
            element.parent().find(".errorText").append(error);
        },

        // Remove focus on validate
        focusInvalid: false,

        // Uncomment for eager validation - Validate when focus leaves
        //onfocusout: function (element) {
        //    this.element(element);
        //},

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        },
    });
});