
//aec919fa-4ac2-4b13-9ed4-f9d0a4e06b2a


(function ($) {
    $.fn.w_canadaGeographicalMapDistribution = function (options) {


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
            widgetArea.html("");
            widgetArea.html(getTemplate());
            var chartArea = widgetArea.find('[data-canadaGeographicalMapDistribution="main"]');

            chartArea.vectorMap({
                map: 'ca_mill',
                backgroundColor: 'transparent',
                borderColor: '#818181',
                borderOpacity: 0.25,
                borderWidth: 1,
                zoomOnScroll: false,
                color: '#009efb',
                regionStyle: {
                    initial: {
                        fill: '#6c757d'
                    }
                },
                markerStyle: {
                    initial: {
                        r: 9,
                        'fill': '#fff',
                        'fill-opacity': 1,
                        'stroke': '#000',
                        'stroke-width': 5,
                        'stroke-opacity': 0.4
                    },
                },
                enableZoom: true,
                hoverColor: '#009efb',
                markers: [
                    {
                        
                        attribute: 'fill',
                        scale: ['#f4ecff', '#8833ff'],
                        normalizeFunction: 'polynomial',
                        values: [408, 512, 550, 781],
                        legend: {
                            title: 'legend',
                            vertical: true
                        }
                    },
                    {
                        latLng: [53.52, -113.77],
                        name: 'High Request Point',
                    }],
                series: {
                    regions: [{
                        scale: {
                            800: '#8833ff',
                            700: '#b885ff',
                            600: '#be91fc',
                            500: '#c7a2fa',
                            400: '#d3b6fb',
                            300: '#dec9fb',
                            200: '#eaddfb',
                            100: '#f4ecff',
                        },
                        attribute: 'fill',
                        values: {
                            'CA-ON': '800',
                            'CA-MB': '200',
                            'CA-SK': '500',
                            'CA-YT': '200',
                            'CA-NL': '400',
                            'CA-NU': '200',
                            'CA-QC': '300',
                            'CA-NB': '100',
                            'CA-AB': '800',
                            'CA-BC': '700',
                            'CA-NT': '800',

                        },
                        legend: {
                            title: 'Region Request Count',
                            vertical: true
                        }
                    }]
                },
                hoverOpacity: null,
                normalizeFunction: 'linear',
                scaleColors: ['#b6d6ff', '#005ace'],
                selectedColor: '#c9dfaf',
                selectedRegions: [],
                showTooltip: true,
                onRegionClick: function (element, code, region) {
                    var message = 'You clicked "' + region + '" With code : ' + code.toUpperCase();
                    alert(message);
                }
            });


        }



        function getTemplate() {
            var s = "";
            s += '<div data-canadaGeographicalMapDistribution="main" style="width: 100%; height: 400px"></div>';

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


dashboardWidgets["c9d86403-f653-4645-a61a-353dc9e20053"] = {
    createWidget: function (item, config) {
        return $(item).w_canadaGeographicalMapDistribution({ widget: config });
    }
}

