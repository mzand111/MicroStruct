var interval;

var showTime = function (minutes, second) {
    var time = minutes + ":";
    time += second.toString().length == 2 ? second : "0" + second;
    $("#timeConter").text(time);
};

var configure = function (isShow) {

    $("#Login").hide();
    $("#PasswordForm").show();

    if (isShow) {
        $("#resendButton").show();
        $("#resendButtonOtRegister").show();
        $("#resendRegister").show();

    } else {
        $("#resendButton").hide();
        $("#resendButtonOtRegister").hide();
        $("#resendRegister").hide();

    }
}

var general = function (value) {
    if (value === undefined || value === null) {
        value = $("[name='OTLoginType'][checked]").val();
    }
    $("#lblUsername").text(resource[value]);
    let error = $("#Username").attr("data-val-required");
    error = error.replace("\"Username\"", resource[value]);
    error = error.replace(resource["mobile"], resource[value]);
    error = error.replace(resource["email"], resource[value]);
    $("#Username").attr("data-val-required", error);
}

var successFunction = function (data) {
    configure();
    var minutes = 2;
    var second = 0;
    $("#timeConter").show();
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
            $("#timeConter").hide();
            $("#resendButton").show();
            $("#resendButtonOtRegister").show();
            clearInterval(interval);
        }

        showTime(minutes, second);
    }, 1000);
};

var ajaxFunction = function () {
    $.ajax({
        method: "post",
        dataType: "json",
        data: $("#frm").serialize(),
        url: "/Account/OTPassword"
    }).done(function (data) {
        if (data.isSucceded) {
            successFunction(data);
        } else {
            //alert(data.message);
            var errorUndefineNumber = document.getElementById("errorUndefineNumber");
            var errorMessage = `<div id="BOX-errorUndefineNumber">${data.message}</div>`
            errorUndefineNumber.innerHTML = errorMessage;
        }
    });
};



var validationUsername = function () {
    let value = $("#frm").serializeArray().filter(o => o.name === "OTLoginType")[0].value;
    let username = $("#Username").val();
    if (value === "mobile") {
        let regex = /(0|\+98)?([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}/ig;
        let isValid = regex.test(username);
        if (!isValid) {
            var mobileRegix = document.getElementById("MobileRegix");
            var error = `
                <div id="BOX-errorUndefineNumber">تلفن همراه نامعتبر است</div>
                    
            `;
            mobileRegix.innerHTML = error;
            //$("[data-valmsg-for='Username']").html('<span id="Username-error" class="alert alert-danger"> تلفن همراه نامعتبر است</span>');
        } else {
            document.getElementById("MobileRegix").innerHTML = "";
        }
        return isValid;
    } else {
        debugger;
        let regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        let isValid = regex.test(username);
        if (!isValid) {
            $("[data-valmsg-for='Username']").html('<span id="Username-error" class="">پست الکترونیک نامعتبر است</span>');
        } else {
            $("[data-valmsg-for='Username']").html("");
        }
        return isValid;
    }
}

var editMessage = function () {
    let value = $("#frm").serializeArray().filter(o => o.name === "OTLoginType")[0].value;
    let error = $("#Username-error").text();
    if (error === undefined || error === null) {
        return;
    }

    error = error.replace("\"Username\"", resource[value]);
    error = error.replace(resource["mobile"], resource[value]);
    error = error.replace(resource["email"], resource[value]);
    $("#Username-error").html(error);
    setTimeout(function () { $("#Username-error").html(error); }, 10);
}

$(function () {
    $("#resendButton").hide();
    $("#resendButtonOtRegister").hide();
    $("#resendRegister").hide();
    //general();

    if (p) {
        configure(true);
    }

    $("#RegisterEmail").click(function () {

        var checkSumbit = true;

        var firstName = document.getElementById('firstName');
        var nullFirstName = document.getElementById('nullFirstName');


        var lastName = document.getElementById('lastName');
        var nullLastName = document.getElementById('nullLastName');


        var email = document.getElementById('email');
        var nullEmail = document.getElementById('nullEmail');


        var checkPassword = checkPasswoedClient('password');

        var ConfirmPassword = document.getElementById('ConfirmPassword');
        var nullConfirmPassword = document.getElementById('nullConfirmPassword');

        //var password1 = document.getElementById('password');

        if (firstName.value == "") {
            nullFirstName.innerHTML = "نام را وارد کنید.";
            checkSumbit = false;
        }
        else {
            nullFirstName.innerHTML = "";
        }

        if (lastName.value == "") {
            nullLastName.innerHTML = "نام خانوادگی را وارد کنید.";
            checkSumbit = false;
        }
        else {
            nullLastName.innerHTML = "";
        }


        if (email.value == "") {
            nullEmail.innerHTML = "ایمیل  را وارد کنید.";
            checkSumbit = false;
        }
        else {
            nullEmail.innerHTML = "";
        }


        if (checkPassword == false) {
            checkSumbit = false;
            document.getElementById('password').focus();

        }

        if (ConfirmPassword.value == "") {
            nullConfirmPassword.innerHTML = "تکرار رمز عبور را وارد کنید.";
            checkSumbit = false;
        }
        else {

            if (ConfirmPassword.value.localeCompare(password.value) != 0) {
                nullConfirmPassword.innerHTML = "رمز عبور با تکرار رمز عبور همخوانی ندارد.";
                checkSumbit = false;
            }
            else {
                nullConfirmPassword.innerHTML = "";
            }

        }

        if (checkSumbit == false) {
            return;
        }

        if (true) {
            ajaxFunctionRegisterEmail();
        }
    });

    $("#RegisterButton").click(function () {
        var checkSumbit = true;

        var firstName = document.getElementById('firstName');
        var nullFirstName = document.getElementById('nullFirstName');


        var lastName = document.getElementById('lastName');
        var nullLastName = document.getElementById('nullLastName');



        var mobile = document.getElementById('Username');
        var nullMobile = document.getElementById('nullMobile');



        if (firstName.value == "") {
            nullFirstName.innerHTML = "نام را وارد کنید.";
            checkSumbit = false;
        }
        else {
            nullFirstName.innerHTML = "";
        }

        if (lastName.value == "") {
            nullLastName.innerHTML = "نام خانوادگی را وارد کنید.";
            checkSumbit = false;
        }
        else {
            nullLastName.innerHTML = "";
        }

        if (mobile.value == "") {
            nullMobile.innerHTML = "موبایل را وارد کنید.";
            checkSumbit = false;
        }
        else {
            nullMobile.innerHTML = "";
        }

        if (checkSumbit === false) {
            return;
        }

        if (validationUsername()) {
            ajaxFunctionRegister();
        }
    });

    $("#loginButton").click(function () {
        if (validationUsername()) {
            ajaxFunction();
        }
    });

    $("#resendButton").click(function () {
        if (validationUsername()) {
            ajaxFunction();
        }
    });

    $("#resendButtonOtRegister").click(function () {
        if (validationUsername()) {
            ajaxFunctionRegister();
        }
    });

    $("#resendRegister").click(function () {
        ajaxFunctionRegisterEmail();
    });

    $("#buttonForgotPassword").click(function () {

        if (document.getElementById("emailForgotPassword").value == "") {
            document.getElementById("errorForgotPassword").innerHTML = "ایمیل خود را وارد کنید.";
            return;
        } else {
            document.getElementById("errorForgotPassword").innerHTML = "";
        }

        ajaxFunctionForgotPassword();
    });

    


    $("[name='OTLoginType']").change(function () {
        general($(this).val());
        editMessage();
    });

    $("#btnCancel").click(function () {
        $("#Login").show();
        $("#PasswordForm").hide();
        /*clearInterval(interval);*/
        //$.ajax({
        //    method: "post",
        //    dataType: "json",
        //    data: $("#frm").serialize(),
        //    url: "/Account/OTCancel"
        //}).done(function (data) {
        //});
    });

    $("#Username").change(function () {
        editMessage();
    });
    $("#Username").blur(function () {
        editMessage();
    });
});

var ajaxFunctionForgotPassword = function () {

    $.ajax({
        method: "post",
        dataType: "json",
        data: $("#frm").serialize(),
        url: "/Account/ForgotPassword"
    }).done(function (data) {
        if (data.isSucceded) {
            successFunction(data);
        } else {
            //alert(data.message);
            var ForgoterrorRegisterEmail = document.getElementById("ForgoterrorRegisterEmail");
            var error = `
                <div id="BOX-errorUndefineNumber">${data.message}</div>
                    
            `;
            ForgoterrorRegisterEmail.innerHTML = error;

        }
    });
};

var ajaxFunctionRegister = function () {

    $.ajax({
        method: "post",
        dataType: "json",
        data: $("#frm").serialize(),
        url: "/Account/OTPasswordRegister"
    }).done(function (data) {
        if (data.isSucceded) {
            successFunction(data);
        } else {
            //alert(data.message);
            var errorMobileRepeatRegister = document.getElementById("errorMobileRepeatRegister");
            var error = `
                <div id="BOX-errorUndefineNumber">${data.message}</div>
                    
            `;
            errorMobileRepeatRegister.innerHTML = error;

        }
    });
};

var ajaxFunctionRegisterEmail = function () {
    $.ajax({
        method: "post",
        dataType: "json",
        data: $("#frm").serialize(),
        url: "/Account/SendPasswordRegister"
    }).done(function (data) {
        if (data.isSucceded) {
            successFunction(data);
        } else {
            var errorRegisterEmail = document.getElementById("errorRegisterEmail");
            var error = `
                <div id="BOX-errorUndefineNumber">${data.message}</div>
            `;
            errorRegisterEmail.innerHTML = error;
            //alert(data.message);

        }
    });
};


function checkPasswoedClient(id) {

    var password = document.getElementById('password').value;
    var addOkLength = document.getElementById("addOkLength");
    var addOkNumner = document.getElementById('addOkNumner');
    var addOkSpecial = document.getElementById('addOkSpecial');
    var addOkLower = document.getElementById("addOkLower");
    var addOkUpper = document.getElementById("addOkUpper");

    var boolUpper = false;
    var boolLower = false;
    var boolSpecial = false;
    var boolNumber = false;
    var boolLengh = false;


    var upperCasePattern = /[A-Z]/;
    if (upperCasePattern.test(password) == true) {
        document.getElementById('checkUpperCase').style.color = 'green';

        addOkUpper.style.fill = "green";

        addOkUpper.innerHTML = `<path d="M504 256c0 136.967-111.033 248-248 248S8 392.967 8 256 119.033 8 256 8s248 111.033 248 248zM227.314 387.314l184-184c6.248-6.248 6.248-16.379 0-22.627l-22.627-22.627c-6.248-6.249-16.379-6.249-22.628 0L216 308.118l-70.059-70.059c-6.248-6.248-16.379-6.248-22.628 0l-22.627 22.627c-6.248 6.248-6.248 16.379 0 22.627l104 104c6.249 6.249 16.379 6.249 22.628.001z"/>`;

        boolUpper = true;

    }
    else {

        document.getElementById('checkUpperCase').style.color = colorError;

        addOkUpper.style.fill = colorError;
        addOkUpper.innerHTML = `<path d="M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm121.6 313.1c4.7 4.7 4.7 12.3 0 17L338 377.6c-4.7 4.7-12.3 4.7-17 0L256 312l-65.1 65.6c-4.7 4.7-12.3 4.7-17 0L134.4 338c-4.7-4.7-4.7-12.3 0-17l65.6-65-65.6-65.1c-4.7-4.7-4.7-12.3 0-17l39.6-39.6c4.7-4.7 12.3-4.7 17 0l65 65.7 65.1-65.6c4.7-4.7 12.3-4.7 17 0l39.6 39.6c4.7 4.7 4.7 12.3 0 17L312 256l65.6 65.1z" />`;

        boolUpper = false;
    }




    var LowerCasePattern = /[a-z]/;
    if (LowerCasePattern.test(password) == true) {
        document.getElementById('checkLowerCase').style.color = 'green';


        addOkLower.style.fill = "green";
        addOkLower.innerHTML = `<path d="M504 256c0 136.967-111.033 248-248 248S8 392.967 8 256 119.033 8 256 8s248 111.033 248 248zM227.314 387.314l184-184c6.248-6.248 6.248-16.379 0-22.627l-22.627-22.627c-6.248-6.249-16.379-6.249-22.628 0L216 308.118l-70.059-70.059c-6.248-6.248-16.379-6.248-22.628 0l-22.627 22.627c-6.248 6.248-6.248 16.379 0 22.627l104 104c6.249 6.249 16.379 6.249 22.628.001z"/>`;


        boolLower = true;
    }
    else {

        document.getElementById('checkLowerCase').style.color = colorError;
        addOkLower.style.fill = colorError;
        addOkLower.innerHTML = `<path d="M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm121.6 313.1c4.7 4.7 4.7 12.3 0 17L338 377.6c-4.7 4.7-12.3 4.7-17 0L256 312l-65.1 65.6c-4.7 4.7-12.3 4.7-17 0L134.4 338c-4.7-4.7-4.7-12.3 0-17l65.6-65-65.6-65.1c-4.7-4.7-4.7-12.3 0-17l39.6-39.6c4.7-4.7 12.3-4.7 17 0l65 65.7 65.1-65.6c4.7-4.7 12.3-4.7 17 0l39.6 39.6c4.7 4.7 4.7 12.3 0 17L312 256l65.6 65.1z" />`;

        boolLower = false;
    }



    var spetialCharPatter = /[!,@,#,$,%,^,&,*]/;
    if (spetialCharPatter.test(password) == true) {
        document.getElementById('checkSpecial').style.color = 'green';
        addOkSpecial.style.fill = "green";
        addOkSpecial.innerHTML = `<path d="M504 256c0 136.967-111.033 248-248 248S8 392.967 8 256 119.033 8 256 8s248 111.033 248 248zM227.314 387.314l184-184c6.248-6.248 6.248-16.379 0-22.627l-22.627-22.627c-6.248-6.249-16.379-6.249-22.628 0L216 308.118l-70.059-70.059c-6.248-6.248-16.379-6.248-22.628 0l-22.627 22.627c-6.248 6.248-6.248 16.379 0 22.627l104 104c6.249 6.249 16.379 6.249 22.628.001z"/>`;

        boolSpecial = true;
    }
    else {

        document.getElementById('checkSpecial').style.color = colorError;
        addOkSpecial.style.fill = colorError;
        addOkSpecial.innerHTML = `<path d="M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm121.6 313.1c4.7 4.7 4.7 12.3 0 17L338 377.6c-4.7 4.7-12.3 4.7-17 0L256 312l-65.1 65.6c-4.7 4.7-12.3 4.7-17 0L134.4 338c-4.7-4.7-4.7-12.3 0-17l65.6-65-65.6-65.1c-4.7-4.7-4.7-12.3 0-17l39.6-39.6c4.7-4.7 12.3-4.7 17 0l65 65.7 65.1-65.6c4.7-4.7 12.3-4.7 17 0l39.6 39.6c4.7 4.7 4.7 12.3 0 17L312 256l65.6 65.1z" />`;

        boolSpecial = false;
    }



    var numbersPattern = /\d/;
    if (numbersPattern.test(password) == true) {
        document.getElementById('checkNumber').style.color = 'green';
        addOkNumner.style.fill = "green";
        addOkNumner.innerHTML = `<path d="M504 256c0 136.967-111.033 248-248 248S8 392.967 8 256 119.033 8 256 8s248 111.033 248 248zM227.314 387.314l184-184c6.248-6.248 6.248-16.379 0-22.627l-22.627-22.627c-6.248-6.249-16.379-6.249-22.628 0L216 308.118l-70.059-70.059c-6.248-6.248-16.379-6.248-22.628 0l-22.627 22.627c-6.248 6.248-6.248 16.379 0 22.627l104 104c6.249 6.249 16.379 6.249 22.628.001z"/>`;


        boolNumber = true;
    }
    else {

        document.getElementById('checkNumber').style.color = colorError;
        addOkNumner.style.fill = colorError;
        addOkNumner.innerHTML = `<path d="M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm121.6 313.1c4.7 4.7 4.7 12.3 0 17L338 377.6c-4.7 4.7-12.3 4.7-17 0L256 312l-65.1 65.6c-4.7 4.7-12.3 4.7-17 0L134.4 338c-4.7-4.7-4.7-12.3 0-17l65.6-65-65.6-65.1c-4.7-4.7-4.7-12.3 0-17l39.6-39.6c4.7-4.7 12.3-4.7 17 0l65 65.7 65.1-65.6c4.7-4.7 12.3-4.7 17 0l39.6 39.6c4.7 4.7 4.7 12.3 0 17L312 256l65.6 65.1z" />`;

        boolNumber = false;
    }



    var lenghPassPatten = /\S{8}/;
    if (lenghPassPatten.test(password) == true) {
        document.getElementById('checkLengh').style.color = 'green';
        addOkLength.style.fill = "green";
        addOkLength.innerHTML = `<path d="M504 256c0 136.967-111.033 248-248 248S8 392.967 8 256 119.033 8 256 8s248 111.033 248 248zM227.314 387.314l184-184c6.248-6.248 6.248-16.379 0-22.627l-22.627-22.627c-6.248-6.249-16.379-6.249-22.628 0L216 308.118l-70.059-70.059c-6.248-6.248-16.379-6.248-22.628 0l-22.627 22.627c-6.248 6.248-6.248 16.379 0 22.627l104 104c6.249 6.249 16.379 6.249 22.628.001z"/>`;

        boolLengh = true;

    }
    else {
        document.getElementById('checkLengh').style.color = colorError;
        addOkLength.style.fill = colorError;
        addOkLength.innerHTML = `<path d="M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm121.6 313.1c4.7 4.7 4.7 12.3 0 17L338 377.6c-4.7 4.7-12.3 4.7-17 0L256 312l-65.1 65.6c-4.7 4.7-12.3 4.7-17 0L134.4 338c-4.7-4.7-4.7-12.3 0-17l65.6-65-65.6-65.1c-4.7-4.7-4.7-12.3 0-17l39.6-39.6c4.7-4.7 12.3-4.7 17 0l65 65.7 65.1-65.6c4.7-4.7 12.3-4.7 17 0l39.6 39.6c4.7 4.7 4.7 12.3 0 17L312 256l65.6 65.1z" />`;

        boolLengh = false;

    }


    if (boolUpper == true && boolLower == true && boolSpecial == true && boolNumber == true && boolLengh == true) {
        document.getElementById("password").style.border = "1px solid green";
        return true;
    }
    document.getElementById("password").style.border = "1px solid " + colorError;
    return false;

}
