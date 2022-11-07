
Timmer();

function Timmer() {
    var minutes = 2;
    var second = 0;
    showTime(minutes, second);
    interval = setInterval(function () {
        if (second == 0) {
            if (minutes != 0) {
                minutes--;
                second = 59;
            }
        } else {
            second--;
        }

        if (minutes == 0 && second == 0) {
            clearInterval(interval);
            $("#btnResendCode").prop('disabled', false);
            $("#btnResendCode").text("ارسال مجدد کد");
            return;
        }
        showTime(minutes, second);
    }, 1000);
}

function showTime(minutes, second) {
    let time = minutes + ":";
    time += second.toString().length == 2 ? second : "0" + second;
    $("#btnResendCode").prop('disabled', true);
    $("#btnResendCode").text(time);
}

var ajaxFunctionRegisterEmail = function () {
    $.ajax({
        method: "post",
        dataType: "json",
        data: $("#frm").serialize(),
        url: "/Account/SendPasswordRegister"
    }).done(function (data) {
        debugger
        if (data == "Successfully Sent") {
            alertSendSms();
            Timmer();
        } else {
            debugger
            var errorRegisterEmail = document.getElementById("errorRegisterEmail");
            var error = `
                <div id="BOX-errorUndefineNumber">${data.message}</div>
            `;
            errorRegisterEmail.innerHTML = error;
            //alert(data.message);
        }
    });
};


$("#btnResendCode").click(function () {
    ajaxFunctionRegisterEmail();
});


TimmerForForgotPassword();


function TimmerForForgotPassword() {

    var minutes = 2;
    var second = 0;
    showTimeForForgotPassword(minutes, second);
    var intervalForForgotPassword = setInterval(function () {
        if (second == 0) {
            if (minutes != 0) {
                minutes--;
                second = 59;
            }
        } else {
            second--;
        }

        if (minutes == 0 && second == 0) {
            clearInterval(intervalForForgotPassword);
            $("#btnResendCodeForForgotPassword").prop('disabled', false);
            $("#btnResendCodeForForgotPassword").text("ارسال مجدد کد");
            return;
        }
        showTimeForForgotPassword(minutes, second);
    }, 1000);
}


function showTimeForForgotPassword(minutes, second) {
    let time = minutes + ":";
    time += second.toString().length == 2 ? second : "0" + second;
    $("#btnResendCodeForForgotPassword").prop('disabled', true);
    $("#btnResendCodeForForgotPassword").text(time);
}


var ajaxFunctionSendCodeForForgotpassword = function () {
    $.ajax({
        method: "post",
        dataType: "json",
        data: $("#frm").serialize(),
        url: "/Account/SendPasswordRegisterForForgotPassword"
    }).done(function (data) {
        debugger
        if (data == "Successfully Sent") {
            //alertSendSms();
            alertSendSms();
            TimmerForForgotPassword();
        }
        else {
            ivsAlert("ارسال کد با موفقیت انجام نشد", 'error')
        }
    });
};





$("#btnResendCodeForForgotPassword").click(function () {

    ajaxFunctionSendCodeForForgotpassword();

});




function alertSendSms() {
    Lobibox.notify('success', {
        pauseDelayOnHover: true,
        icon: 'bx bx-error',
        continueDelayOnInactiveTab: false,
        position: 'top right',
        size: 'mini',
        msg: 'کد opt مجددا ارسال شد'
    });
}
