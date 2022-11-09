//Users notify.min.js to show alerts
//status, title ,msg  is require and type is string
//position: is string and have default value and ex value top right , top center,... 
//delay is number and have default value
//width is string  and have default value
function microStructAlert(status, title, msg, position = "top right", delay = 5, width = "400") {
    var myIcon = "";
    if (status == 'primary') {
        myIcon = "bx bx-bookmark-heart";
    }
    else if (status == 'secondary') {
        icon = "<i class='bx bx-tag-alt'></i>";
    }
    else if (status == 'success') {
        myIcon = "bx bxs-check-circle";
    }
    else if (status == 'danger' || status == 'error') {
        myIcon = "bx bxs-message-square-x";
    }
    else if (status == 'warning') {
        myIcon = "bx bx-info-circle";
    }
    else if (status == 'info') {
        myIcon = "bx bx-info-square";
    }
    else if (status == 'dark') {
        myIcon = "bx bx-bell";
    }
    else {
        console.log('نوع  cardAlert درست مشخص نشده است')
        return;
    }

    Lobibox.notify(status, {
        pauseDelayOnHover: true,
        continueDelayOnInactiveTab: false,
        position: position,
        icon: myIcon,
        width: width,
        title: title,
        delay: `${delay}e3`,
        //img: 'assets/plugins/notifications/img/4.jpg',
        msg: msg
    });
}