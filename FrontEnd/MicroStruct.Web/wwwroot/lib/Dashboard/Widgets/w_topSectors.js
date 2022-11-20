
//aec919fa-4ac2-4b13-9ed4-f9d0a4e06b2a


(function ($) {
    $.fn.w_topSectors = function (options) {


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
                    name: 'Finished Flows',
                    data: [18, 12, 9, 5, 3 , 3, 2, 2]

                }, {
                    name: 'In Progress',
                    data: [6, 7, 2, 3, 2, 1, 1, 1]
                }],
                chart: {
                    foreColor: '#9ba7b2',
                    type: 'bar',
                    height: 370,
                    stacked: false,
                    toolbar: {
                        show: false
                    },
                },
                plotOptions: {
                    bar: {
                        horizontal: true,
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
                            return value ;
                        }
                    },
                },
                xaxis: {
                    categories: ['Construction', 'Entertainment', 'Oil and Gas', 'Agriculture', 'Mining', 'IT', 'Food Services', 'Education'],
                    labels: {
                       
                    },
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
                            return "" + val + " Requests"
                        }
                    }
                }
            };
            console.log(widgetArea);
            var chartArea = widgetArea.find('[data-w_topSectors="main"]');
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
            s += '<div data-w_topSectors="main"></div>'; 

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


dashboardWidgets["98a06b79-102c-49ad-be92-fd8b484b2f17"] = {
    createWidget: function (item, config) {
        return $(item).w_topSectors({ widget: config });
    }
}

