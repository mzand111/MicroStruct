﻿
//aec919fa-4ac2-4b13-9ed4-f9d0a4e06b2a


(function ($) {
    $.fn.w_averageStepTimes = function (options) {


        var widgetArea = this;

        var settings = $.extend({
            widget: null,
            getAverageStepTimesApiAddress: '/api/cartable/GetUserCartableSummery',

        }, options);


        widgetArea.html("");

        widgetArea.html(getTemplate());
        buildInterface(widgetArea);
        function buildInterface(area) {
          
        }

        this.reBind = function (type, objectID) {

            var options = {
                series: [{
                    name: 'Finished Flows',
                    data: [8.3, 2.7, 7.3, 12, 17.3,18.2]

                }, {
                    name: 'In Progress',
                    data: [6, 3.3, 5.1, 15.8, 16.6, 0 ]
                }],
                chart: {
                    foreColor: '#9ba7b2',
                    type: 'bar',
                    height: 260,
                    stacked: false,
                    toolbar: {
                        show: false
                    },
                },
                plotOptions: {
                    bar: {
                        horizontal: false,
                        columnWidth: '45%',
                        endingShape: 'rounded'
                    },
                },
                legend: {
                    show: true,
                    position: 'top',
                    horizontalAlign: 'left',
                    offsetX: -20,
                    offsetY: 5
                },
                dataLabels: {
                    enabled: false
                },
                stroke: {
                    show: true,
                    width: 3,
                    colors: ['transparent']
                },
                colors: ["#8833ff", '#cba6ff'],
                yaxis: {
                    labels: {
                        formatter: function (value) {
                            return value + " Days";
                        }
                    },
                },
                xaxis: {
                    categories: ['Initial Check', 'Customer Document Upload', 'Expert Document Review', 'Document Approve', 'Final Check', 'Payment Start'],

                },
                grid: {
                    show: true,
                    borderColor: '#ededed',
                    //strokeDashArray: 4,
                },
                fill: {
                    opacity: 1
                },
                tooltip: {
                    theme: 'dark',
                    y: {
                        formatter: function (val) {
                            return "" + val + " Days"
                        }
                    }
                }
            };
            console.log(widgetArea);
            var chartArea = widgetArea.find('[data-wAverageStepTimes="main"]');
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
            s += '<div data-wAverageStepTimes="main"></div>'; 

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


dashboardWidgets["a5660356-2693-433f-8c66-a29d5c4a887c"] = {
    createWidget: function (item, config) {
        return $(item).w_averageStepTimes({ widget: config });
    }
}

