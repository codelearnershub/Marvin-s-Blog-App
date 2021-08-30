function JSalert() {

    // A confirm dialog

    alertify.confirm("Are you sure, you want to log Out?", function (e) {

        if (e) {

            alertify.alert("File is Removed!");

        } else {

            alertify.alert("File is safe!");

        }

    });

}