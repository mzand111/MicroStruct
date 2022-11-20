
//6adf8713-cc80-492f-9d83-ebf747e689f0


(function ($) {
    $.fn.w_amountBySectors = function (options) {


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
                series: [140, 230, 210, 170,  100, 120, 170, 210],
                labels: ['Education', 'Entertainment', 'Oil and Gas', 'IT',  'Food Services', 'Mining', 'Agriculture', 'Construction'],
                chart: {
                    type: 'polarArea',
                },
                stroke: {
                    colors: ['#fff']
                },
                fill: {
                    opacity: 0.8
                },
                legend: {
                    show: true,
                    position: 'top',
                    horizontalAlign: 'left',
                    offsetY: 5
                },
                responsive: [{
                    breakpoint: 480,
                    options: {
                        chart: {
                            width: 300
                        },
                        legend: {
                            position: 'bottom'
                        }
                    }
                }]
            };

            console.log(widgetArea);
            var chartArea = widgetArea.find('[data-w_amountBySectors="main"]');
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
            s += '<div data-w_amountBySectors="main"></div>'; 

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


dashboardWidgets["6adf8713-cc80-492f-9d83-ebf747e689f0"] = {
    createWidget: function (item, config) {
        return $(item).w_amountBySectors({ widget: config });
    }
}

