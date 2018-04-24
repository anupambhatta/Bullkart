$(document).ready(function () {
    $("[id$=Address]").validate({ // initialize the plugin
        rules: {
            name: {
                required: true
            },
            address1: {
                required: true
            },
            city: {
                required: true
            },
            state: {
                required: true
            },
            email: {
                required: true,
                email: true
            }
        }
    });

});