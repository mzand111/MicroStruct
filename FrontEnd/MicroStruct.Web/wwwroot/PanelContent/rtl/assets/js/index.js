$(function () {
    "use strict";

    // chart 1
    var options = {
        series: [{
            name: 'Sessions',
            data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
        }],
        chart: {
            type: 'line',
            height: 60,
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
                enabled: true
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
            width: 2.5,
            curve: 'smooth'
        },
        colors: ["#8833ff"],
        xaxis: {
            categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر', 'دی', 'بهم', 'اسف'],
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            theme: 'dark',
            fixed: {
                enabled: false
            },
            x: {
                show: false
            },
            y: {
                title: {
                    formatter: function (seriesName) {
                        return ''
                    }
                }
            },
            marker: {
                show: false
            }
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart1"), options);
    chart.render();



    // chart 2
    var options = {
        series: [{
            name: 'مجموع کاربران',
            data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
        }],
        chart: {
            type: 'bar',
            height: 60,
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
                color: '#f41127',
            },
            sparkline: {
                enabled: true
            }
        },
        markers: {
            size: 0,
            colors: ["#f41127"],
            strokeColors: "#fff",
            strokeWidth: 2,
            hover: {
                size: 7,
            }
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '40%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2.5,
            curve: 'smooth'
        },
        colors: ["#f41127"],
        xaxis: {
            categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر', 'دی', 'بهم', 'اسف'],
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            theme: 'dark',
            fixed: {
                enabled: false
            },
            x: {
                show: false
            },
            y: {
                title: {
                    formatter: function (seriesName) {
                        return ''
                    }
                }
            },
            marker: {
                show: false
            }
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart2"), options);
    chart.render();


    // chart 3
    var options = {
        series: [{
            name: 'بازدیدهای صفحه',
            data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
        }],
        chart: {
            type: 'area',
            height: 60,
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
                color: '#ffc107',
            },
            sparkline: {
                enabled: true
            }
        },
        markers: {
            size: 0,
            colors: ["#ffc107"],
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
            width: 2.5,
            curve: 'smooth'
        },
        colors: ["#ffc107"],
        xaxis: {
            categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر', 'دی', 'بهم', 'اسف'],
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            theme: 'dark',
            fixed: {
                enabled: false
            },
            x: {
                show: false
            },
            y: {
                title: {
                    formatter: function (seriesName) {
                        return ''
                    }
                }
            },
            marker: {
                show: false
            }
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart3"), options);
    chart.render();



    // chart 4
    var options = {
        series: [{
            name: 'Bounce Rate',
            data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
        }],
        chart: {
            type: 'bar',
            height: 60,
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
                color: '#0dcaf0',
            },
            sparkline: {
                enabled: true
            }
        },
        markers: {
            size: 0,
            colors: ["#0dcaf0"],
            strokeColors: "#fff",
            strokeWidth: 2,
            hover: {
                size: 7,
            }
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '40%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2.4,
            curve: 'smooth'
        },
        colors: ["#0dcaf0"],
        xaxis: {
            categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر', 'دی', 'بهم', 'اسف'],
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            theme: 'dark',
            fixed: {
                enabled: false
            },
            x: {
                show: false
            },
            y: {
                title: {
                    formatter: function (seriesName) {
                        return ''
                    }
                }
            },
            marker: {
                show: false
            }
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart4"), options);
    chart.render();




    // chart 5
    var options = {
        series: [{
            name: 'Avg. Session Duration',
            data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
        }],
        chart: {
            type: 'line',
            height: 60,
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
                color: '#29cc39',
            },
            sparkline: {
                enabled: true
            }
        },
        markers: {
            size: 0,
            colors: ["#29cc39"],
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
            width: 2.5,
            curve: 'smooth'
        },
        colors: ["#29cc39"],
        xaxis: {
            categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر', 'دی', 'بهم', 'اسف'],
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            theme: 'dark',
            fixed: {
                enabled: false
            },
            x: {
                show: false
            },
            y: {
                title: {
                    formatter: function (seriesName) {
                        return ''
                    }
                }
            },
            marker: {
                show: false
            }
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart5"), options);
    chart.render();




    // chart 6
    var options = {
        series: [{
            name: 'فروش',
            data: [4, 8, 6, 9, 6, 7, 4, 5, 2.5, 3]
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
            categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر', 'دی'],
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
    var chart = new ApexCharts(document.querySelector("#chart6"), options);
    chart.render();



    // chart 7
    var options = {
        series: [{
            name: 'بازدیدکننده جدید',
            data: [66, 76, 85, 101, 65, 87, 105, 91, 86]

        }, {
            name: 'بازدیدکننده قدیمی',
            data: [55, 44, 55, 57, 56, 61, 58, 63, 60]
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
            show: false,
            position: 'top',
            horizontalAlign: 'left',
            offsetX: -20
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
                    return value + "K";
                }
            },
        },
        xaxis: {
            categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر'],
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
                    return "" + val + "K"
                }
            }
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart7"), options);
    chart.render();



    // chart 8
    var options = {
        series: [{
            name: 'Sessions',
            data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
        }],
        chart: {
            type: 'bar',
            height: 60,
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
                enabled: true
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
            // curve: 'smooth'
        },
        colors: ["#8833ff"],
        xaxis: {
            categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر', 'دی', 'بهم', 'اسف'],
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            theme: 'dark',
            fixed: {
                enabled: false
            },
            x: {
                show: false
            },
            y: {
                title: {
                    formatter: function (seriesName) {
                        return ''
                    }
                }
            },
            marker: {
                show: false
            }
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart8"), options);
    chart.render();



    // chart 9
    var options = {
        series: [{
            name: 'Sessions',
            data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
        }],
        chart: {
            type: 'area',
            height: 60,
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
                color: '#f41127',
            },
            sparkline: {
                enabled: true
            }
        },
        markers: {
            size: 0,
            colors: ["#f41127"],
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
            // curve: 'smooth'
        },
        colors: ["#f41127"],
        xaxis: {
            categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر', 'دی', 'بهم', 'اسف'],
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            theme: 'dark',
            fixed: {
                enabled: false
            },
            x: {
                show: false
            },
            y: {
                title: {
                    formatter: function (seriesName) {
                        return ''
                    }
                }
            },
            marker: {
                show: false
            }
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart9"), options);
    chart.render();


    // chart 10
    var options = {
        series: [{
            name: 'Sessions',
            data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
        }],
        chart: {
            type: 'area',
            height: 60,
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
                color: '#17a00e',
            },
            sparkline: {
                enabled: true
            }
        },
        markers: {
            size: 0,
            colors: ["#17a00e"],
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
            // curve: 'smooth'
        },
        colors: ["#17a00e"],
        xaxis: {
            categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر', 'دی', 'بهم', 'اسف'],
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            theme: 'dark',
            fixed: {
                enabled: false
            },
            x: {
                show: false
            },
            y: {
                title: {
                    formatter: function (seriesName) {
                        return ''
                    }
                }
            },
            marker: {
                show: false
            }
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart10"), options);
    chart.render();



    // chart 11
    var options = {
        chart: {
            height: 330,
            type: 'radialBar',
            toolbar: {
                show: false
            }
        },
        plotOptions: {
            radialBar: {
                startAngle: -130,
                endAngle: 130,
                hollow: {
                    margin: 0,
                    size: '78%',
                    //background: '#fff',
                    image: undefined,
                    imageOffsetX: 0,
                    imageOffsetY: 0,
                    position: 'front',
                    dropShadow: {
                        enabled: false,
                        top: 3,
                        left: 0,
                        blur: 4,
                        color: 'rgba(0, 169, 255, 0.25)',
                        opacity: 0.65
                    }
                },
                track: {
                    background: '#dfecff',
                    //strokeWidth: '67%',
                    margin: 0, // margin is in pixels
                    dropShadow: {
                        enabled: false,
                        top: -3,
                        left: 0,
                        blur: 4,
                        color: 'rgba(0, 169, 255, 0.85)',
                        opacity: 0.65
                    }
                },
                dataLabels: {
                    showOn: 'always',
                    name: {
                        offsetY: -25,
                        show: true,
                        color: '#6c757d',
                        fontSize: '16px'
                    },
                    value: {
                        formatter: function (val) {
                            return val + "%";
                        },
                        color: '#000',
                        fontSize: '45px',
                        show: true,
                        offsetY: 10,
                    }
                }
            }
        },
        fill: {
            type: 'gradient',
            gradient: {
                shade: 'dark',
                type: 'horizontal',
                shadeIntensity: 0.5,
                gradientToColors: ['#8e2de2'],
                inverseColors: false,
                opacityFrom: 1,
                opacityTo: 1,
                stops: [0, 100]
            }
        },
        colors: ["#4a00e0"],
        series: [84],
        stroke: {
            lineCap: 'round',
            //dashArray: 4
        },
        labels: ['فعالیت امروز'],
    }
    var chart = new ApexCharts(document.querySelector("#chart11"), options);
    chart.render();



    // chart 12
    Highcharts.chart('chart12', {
        chart: {
            width: '190',
            height: '190',
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie',
            styledMode: true
        },
        credits: {
            enabled: false
        },
        exporting: {
            buttons: {
                contextButton: {
                    enabled: false,
                }
            }
        },
        title: {
            useHTML: true,
            text: ''
        },
        tooltip: {
            useHTML: true,
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        accessibility: {
            point: {
                valueSuffix: '%'
            }
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },
                showInLegend: false
            }
        },
        series: [{
            name: 'کاربران',
            colorByPoint: true,
            data: [{
                name: 'مرد',
                y: 61.41,
                sliced: true,
                selected: true
            }, {
                name: 'زن',
                y: 11.84
            }]
        }]
    });



    // chart 13
    // Create the chart
    Highcharts.chart('chart13', {
        chart: {
            useHTML: true,
            height: 360,
            type: 'column',
            styledMode: true
        },
        credits: {
            useHTML: true,
            enabled: false
        },
        title: {
            useHTML: true,
            text: 'وضعیت منابع ترافیک، اردیبهشت 1400'
        },
        accessibility: {
            announceNewData: {
                useHTML: true,
                enabled: true
            }
        },
        xAxis: {
            useHTML: true,
            type: 'category'
        },
        yAxis: {
            title: {
                useHTML: true,
                text: 'وضعیت منابع ترافیک'
            }
        },
        legend: {
            useHTML: true,
            enabled: false
        },
        plotOptions: {
            series: {
                borderWidth: 0,
                dataLabels: {
                    enabled: true,
                    format: '{point.y:.1f}%'
                }
            }
        },
        tooltip: {
            useHTML: true,
            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> از مجموع کل<br/>'
        },
        series: [{
            useHTML: true,
            name: "منابع ترافیک",
            colorByPoint: true,
            data: [{
                useHTML: true,
                name: "جستجوی اصلی",
                y: 62.74,
                drilldown: "Organic Search"
            }, {
                name: "مستقیم",
                y: 40.57,
                drilldown: "Direct"
            }, {
                name: "ارجاع داده شده",
                y: 25.23,
                drilldown: "Referral"
            }, {
                name: "دیگر",
                y: 10.58,
                drilldown: "Others"
            }]
        }],

    });


    // chart 14
    // Create the chart
    Highcharts.chart('chart14', {
        chart: {
            useHTML: true,
            height: 360,
            type: 'column',
            styledMode: true
        },
        credits: {
            useHTML: true,
            enabled: false
        },
        title: {
            useHTML: true,
            text: 'وضعیت گروه سنی بازدیدکنندگان'
        },
        accessibility: {
            announceNewData: {
                useHTML: true,
                enabled: true
            }
        },
        xAxis: {
            useHTML: true,
            type: 'category'
        },
        yAxis: {
            title: {
                useHTML: true,
                text: 'وضعیت گروه سنی'
            }
        },
        legend: {
            useHTML: true,
            enabled: false
        },
        plotOptions: {
            series: {
                borderWidth: 0,
                dataLabels: {
                    enabled: true,
                    format: '{point.y:.1f}K'
                }
            }
        },
        tooltip: {
            useHTML: true,
            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> از مجموع کل<br/>'
        },
        series: [{
            name: "گروه سنی",
            colorByPoint: true,
            data: [{
                name: "18-24",
                y: 35.74,
                //drilldown: "Organic Search"
            }, {
                name: "25-34",
                y: 65.57,
                //drilldown: "Direct"
            }, {
                name: "35-44",
                y: 30.23,
                //drilldown: "Referral"
            }, {
                name: "45-54",
                y: 20.58,
                //drilldown: "Others"
            }, {
                name: "55-64",
                y: 15.58,
                //drilldown: "Others"
            }, {
                name: "65-80",
                y: 8.58,
                //drilldown: "Others"
            }]
        }],

    });



    // world map

    jQuery('#geographic-map').vectorMap({
        map: 'world_mill_en',
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
        markers: [{
            latLng: [21.00, 78.00],
            name: 'متن نمونه'
        }],
        series: {
            regions: [{
                values: {
                    IN: '#29cc39',
                    US: '#8833ff',
                    CN: '#f41127',
                    CA: '#e91e63',
                    AU: '#ffd200'
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
            var message = 'شما کلیک کردید کشور "' + region + '" کد کد آن برابر است با : ' + code.toUpperCase();
            alert(message);
        }
    });





});