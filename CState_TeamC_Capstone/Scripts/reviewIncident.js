// Wait for the DOM to be ready
$(function () {
    $.validator.addMethod("dropDownValidator", function (value, element, param) {
        if (value == '-1')
            return false;
        else
            return true;
    }, "This field is required.");

    // Initialize form validation
    $("#frmReviewIncident").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            sltNearMissReportID: {
                dropDownValidator: true,
            },
            sltAssignIncident: {
                required: true,
            },
            sltSeverityLevel: {
                required: true,
            },
            sltRiskLevel: {
                required: true,
            },
            txaComments: {
                required: false,
            }
        },

        // Specify validation error messages
        messages: {
            sltNearMissReportID: {
                dropDownValidator: "Select a report to modify"
            },
            sltAssignIncident: "Select person to assign to",
            sltSeverityLevel: "Select severity of injury",
            sltRiskLevel: "Select risk level"
        },

        // Uncomment for eager validation - Validate when focus leaves
        //onfocusout: function (element) {
        //    this.element(element);
        //},

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});