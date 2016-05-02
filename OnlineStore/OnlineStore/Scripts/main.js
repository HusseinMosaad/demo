var ToastSuccess = "showSuccessToast";
var ToastError = "showErrorToast";


function showErrorMessage(message) {
    $().toastmessage(ToastError, message);
}

function showSuccessMessage(message) {
    $().toastmessage(ToastSuccess, message);
}
