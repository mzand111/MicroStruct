
//ac8dcd84-a2d1-4e92-b54c-e002cf964400


(function ($) {
    $.fn.w_siteVisits = function (options) {


        var widgetArea = this;

        var settings = $.extend({
            widget: null,

        }, options);


        widgetArea.html("");

        widgetArea.html(getTemplate());
        buildInterface(widgetArea);
        function buildInterface(area) {
          
        }

        this.reBind = function (type, objectID) {

            var options = {
                series: [{
                    name: 'Visits',
                    data: [4.1, 7.3, 6.2, 6.9, 6.7, 7.5, 5.8, 5.2 ,6.3, 6.7]
                }],
                chart: {
                    type: 'area',
                    foreColor: '#9a9797',
                    height: 250,
                    toolbar: {
                        show: false
                    },
                    zoom: {
                        enabled: false
                    },
                    dropShadow: {
                        enabled: false,
                        top: 3,
                        left: 14,
                        blur: 4,
                        opacity: 0.12,
                        color: '#8833ff',
                    },
                    sparkline: {
                        enabled: false
                    }
                },
                markers: {
                    size: 0,
                    colors: ["#8833ff"],
                    strokeColors: "#fff",
                    strokeWidth: 2,
                    hover: {
                        size: 7,
                    }
                },
                plotOptions: {
                    bar: {
                        horizontal: false,
                        columnWidth: '45%',
                        endingShape: 'rounded'
                    },
                },

                dataLabels: {
                    enabled: false
                },
                stroke: {
                    show: true,
                    width: 3,
                    curve: 'smooth'
                },
                fill: {
                    type: 'gradient',
                    gradient: {
                        shade: 'light',
                        type: 'vertical',
                        shadeIntensity: 0.5,
                        gradientToColors: ['#fff'],
                        inverseColors: false,
                        opacityFrom: 0.8,
                        opacityTo: 0.5,
                        stops: [0, 100]
                    }
                },
                colors: ["#8833ff"],
                grid: {
                    show: true,
                    borderColor: '#ededed',
                    //strokeDashArray: 4,
                },
                yaxis: {
                    labels: {
                        formatter: function (value) {
                            return value + "K";
                        }
                    },
                },
                xaxis: {
                    categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct'],
                },

                tooltip: {
                    theme: 'dark',
                    y: {
                        formatter: function (val) {
                            return "" + val + "K"
                        }
                    }
                }
            };
            console.log(widgetArea);
            var chartArea = widgetArea.find('[data-w_siteVisits="main"]');
            console.log(chartArea);
            var chart = new ApexCharts(chartArea[0], options);
            chart.render();
           // kendo.ui.progress(hh, true);
           
            //$.ajax({
            //    url: settings.getAverageStepTimesApiAddress,
            //    //url: settings.startWfApiAddress ,
            //    type: 'GET',


            //    success: function (data) {

            //        //var gg = $(document).find('[data-ctrlboxwidgetinstanceID="' + settings.widget.ID + '"]');
            //        buildInterface(hh, data);
            //        // gg.css("background-color", "black");
            //        //kendo.ui.progress(hh, false);
            //    },
            //    error: function (x, y, z) {
            //        alert(x + '\n' + y + '\n' + z);
            //        //kendo.ui.progress(hh, false);
            //    }
            //});

        }



        function getTemplate() {
            var s = "";
            s += '<div data-w_siteVisits="main"></div>'; 

            s = minifyHtml(s);

            return s;
        }
        this.getWidgetConfigObject = function () {

        }

        this.setWidgetConfigObject = function (obj) {

        }
        this.containerSizeChanged = function () {

        }

        this.destroy = function () {

        }

        return this;

    }

}(jQuery));


dashboardWidgets["ac8dcd84-a2d1-4e92-b54c-e002cf964400"] = {
    createWidget: function (item, config) {
        return $(item).w_siteVisits({ widget: config });
    }
}

