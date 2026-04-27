$(document).ready(function () {
    showAlertFromTempData();
});

function showAlertFromTempData() {
    var alertData = $('#SystemAlertTempData').val();
    if (alertData && alertData !== '') {
        try {
            var result = JSON.parse(alertData);
            const notyf = new Notyf({
                duration: 5000,
                position: { x: 'left', y: 'top' },
                dismissible: true  // اضافه کردن دکمه بستن
            });

            if (result.Status === 200) { // Success
                notyf.success(result.Message || 'عملیات با موفقیت انجام شد');
            } else if (result.Status === 10) { // Error
                notyf.error(result.Message || 'خطایی رخ داده است');
            } else if (result.Status === 404) { // NotFound
                notyf.error(result.Message || 'اطلاعات یافت نشد');
            }

            $('#SystemAlertTempData').val('');
        } catch (e) {
            console.error('خطا:', e);
        }
    }
}

