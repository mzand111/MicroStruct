$(function () {
	"use strict";
	// chart 1
	var options = {
		series: [{
			name: 'پسند ها',
			data: [14, 3, 10, 9, 29, 19, 22, 9, 12, 7, 19, 5]
		}],
		chart: {
			foreColor: '#9ba7b2',
			height: 360,
			type: 'line',
			zoom: {
				enabled: false
			},
			toolbar: {
				show: true
			},
			dropShadow: {
				enabled: true,
				top: 3,
				left: 14,
				blur: 4,
				opacity: 0.10,
			}
		},
		stroke: {
			width: 5,
			curve: 'smooth'
		},
		xaxis: {
			type: 'datetime',
			categories: ['1400/11/1', '1400/11/2', '1400/11/3', '1400/11/4', '1400/11/5', '1400/11/6', '1400/11/7', '1400/11/8', '1400/11/9', '1400/11/10', '1400/11/11', '1400/11/12'],
		},
		title: {
			text: 'نمودار خطی',
			align: 'right',
			style: {
				fontSize: "16px",
				color: '#666'
			}
		},
		fill: {
			type: 'gradient',
			gradient: {
				shade: 'light',
				gradientToColors: ['#8833ff'],
				shadeIntensity: 1,
				type: 'horizontal',
				opacityFrom: 1,
				opacityTo: 1,
				stops: [0, 100, 100, 100]
			},
		},
		markers: {
			size: 4,
			colors: ["#8833ff"],
			strokeColors: "#fff",
			strokeWidth: 2,
			hover: {
				size: 7,
			}
		},
		colors: ["#8833ff"],
		yaxis: {
			title: {
				text: 'نامزدی',
			},
		}
	};
	var chart = new ApexCharts(document.querySelector("#chart1"), options);
	chart.render();


	// chart 2
	var optionsLine = {
		chart: {
			foreColor: '#9ba7b2',
			height: 360,
			type: 'line',
			zoom: {
				enabled: false
			},
			dropShadow: {
				enabled: true,
				top: 3,
				left: 2,
				blur: 4,
				opacity: 0.1,
			}
		},
		stroke: {
			curve: 'smooth',
			width: 5
		},
		colors: ["#8833ff", '#29cc39'],
		series: [{
			name: "موزیک",
			data: [1, 15, 56, 20, 33, 27]
		}, {
			name: "تصاویر",
			data: [30, 33, 21, 42, 19, 32]
		}],
		title: {
			text: 'نمودار چند خطی',
			align: 'right',
			offsetY: 25,
			offsetX: -20
		},
		subtitle: {
			text: 'آمار',
			offsetY: 55,
			offsetX: -20
		},
		markers: {
			size: 4,
			strokeWidth: 0,
			hover: {
				size: 7
			}
		},
		grid: {
			show: true,
			padding: {
				bottom: 0
			}
		},
		labels: ['1400/01/15', '1400/01/16', '1400/01/17', '1400/01/18', '1400/01/19', '1400/01/20'],
		xaxis: {
			tooltip: {
				enabled: false
			}
		},
		legend: {
			position: 'top',
			horizontalAlign: 'right',
			offsetY: -20
		}
	}
	var chartLine = new ApexCharts(document.querySelector('#chart2'), optionsLine);
	chartLine.render();


	// chart 3
	var options = {
		series: [{
			name: 'سری 1',
			data: [31, 40, 68, 31, 92, 55, 100]
		}, {
			name: 'سری 2',
			data: [11, 82, 45, 80, 34, 52, 41]
		}],
		chart: {
			foreColor: '#9ba7b2',
			height: 360,
			type: 'area',
			zoom: {
				enabled: false
			},
			toolbar: {
				show: true
			},
		},
		colors: ["#8833ff", '#f41127'],
		title: {
			text: 'نمودار محیطی',
			align: 'right',
			style: {
				fontSize: "16px",
				color: '#666'
			}
		},
		dataLabels: {
			enabled: false
		},
		stroke: {
			curve: 'smooth'
		},
		xaxis: {
			type: 'datetime',
			categories: ["1400-09-19T00:00:00.000Z", "1400-09-19T01:30:00.000Z", "1400-09-19T02:30:00.000Z", "1400-09-19T03:30:00.000Z", "1400-09-19T04:30:00.000Z", "1400-09-19T05:30:00.000Z", "1400-09-19T06:30:00.000Z"]
		},
		tooltip: {
			x: {
				format: 'yyyy/MM/dd HH:mm'
			},
		},
	};
	var chart = new ApexCharts(document.querySelector("#chart3"), options);
	chart.render();

	// chart 4
	var options = {
		series: [{
			name: 'سود',
			data: [44, 55, 57, 56, 61, 58, 63, 60, 66]
		}, {
			name: 'درآمد',
			data: [76, 85, 101, 98, 87, 105, 91, 114, 94]
		}, {
			name: 'درآمد خالص',
			data: [35, 41, 36, 26, 45, 48, 52, 53, 41]
		}],
		chart: {
			foreColor: '#9ba7b2',
			type: 'bar',
			height: 360
		},
		plotOptions: {
			bar: {
				horizontal: false,
				columnWidth: '55%',
				endingShape: 'rounded'
			},
		},
		dataLabels: {
			enabled: false
		},
		stroke: {
			show: true,
			width: 2,
			colors: ['transparent']
		},
		title: {
			text: 'نمودار ستونی',
			align: 'right',
			style: {
				fontSize: '14px'
			}
		},
		colors: ["#29cc39", '#8833ff', '#e62e2e'],
		xaxis: {
			categories: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر'],
		},
		yaxis: {
			title: {
				text: 'تومان (میلیون)'
			}
		},
		fill: {
			opacity: 1
		},
		tooltip: {
			y: {
				formatter: function (val) {
					return " " + val + " میلیون تومان"
				}
			}
		}
	};
	var chart = new ApexCharts(document.querySelector("#chart4"), options);
	chart.render();


	// chart 5
	var options = {
		series: [{
			data: [400, 430, 448, 470, 540, 580, 690, 610, 800, 980]
		}],
		chart: {
			foreColor: '#9ba7b2',
			type: 'bar',
			height: 350
		},
		colors: ["#8833ff"],
		plotOptions: {
			bar: {
				horizontal: true,
				columnWidth: '35%',
				endingShape: 'rounded'
			}
		},
		dataLabels: {
			enabled: false
		},
		xaxis: {
			categories: ['کره جنوبی', 'ایران', 'کانادا', 'هلند', 'ایتالیا', 'فرانسه', 'ژاپن', 'آمریکا', 'چین', 'آلمان'],
		}
	};
	var chart = new ApexCharts(document.querySelector("#chart5"), options);
	chart.render();


	// chart 6
	var options = {
		series: [{
			name: 'اخبار وبسایت',
			type: 'column',
			data: [440, 505, 414, 671, 227, 413, 201, 352, 752, 320, 257, 160]
		}, {
			name: 'شبکه اجتماعی',
			type: 'line',
			data: [23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16]
		}],
		chart: {
			foreColor: '#9ba7b2',
			height: 350,
			type: 'line',
			zoom: {
				enabled: false
			},
			toolbar: {
				show: true
			},
		},
		stroke: {
			width: [0, 4]
		},
		plotOptions: {
			bar: {
				//horizontal: true,
				columnWidth: '35%',
				endingShape: 'rounded'
			}
		},
		colors: ["#8833ff", "#29cc39"],
		title: {
			text: 'منابع ترافیک'
		},
		dataLabels: {
			enabled: true,
			enabledOnSeries: [1]
		},
		labels: ['02 Jan 1400', '03 Jan 1400', '04 Jan 1400', '05 Jan 1400', '06 Jan 1400', '07 Jan 1400', '08 Jan 1400', '09 Jan 1400', '10 Jan 1400', '11 Jan 1400', '12 Jan 1400', '13 Jan 1400'],
		xaxis: {
			type: 'datetime'
		},
		yaxis: [{
			title: {
				text: 'اخبار وبسایت',
			},
		}, {
			opposite: true,
			title: {
				text: 'شبکه اجتماعی'
			}
		}]
	};
	var chart = new ApexCharts(document.querySelector("#chart6"), options);
	chart.render();


	// chart 7
	var options = {
		series: [{
			name: 'تیم الف',
			type: 'column',
			data: [23, 11, 22, 27, 13, 22, 37, 21, 44, 22, 30]
		}, {
			name: 'تیم ب',
			type: 'area',
			data: [44, 55, 41, 67, 22, 43, 21, 41, 56, 27, 43]
		}, {
			name: 'تیم ج',
			type: 'line',
			data: [30, 25, 36, 30, 45, 35, 64, 52, 59, 36, 39]
		}],
		chart: {
			foreColor: '#9ba7b2',
			height: 350,
			type: 'line',
			stacked: false,
			zoom: {
				enabled: false
			},
			toolbar: {
				show: true
			},
		},
		colors: ["#8833ff", "#17a00e", "#f41127"],
		stroke: {
			width: [0, 2, 5],
			curve: 'smooth'
		},
		plotOptions: {
			bar: {
				columnWidth: '50%'
			}
		},
		fill: {
			opacity: [0.85, 0.25, 1],
			gradient: {
				inverseColors: false,
				shade: 'light',
				type: "vertical",
				opacityFrom: 0.85,
				opacityTo: 0.55,
				stops: [0, 100, 100, 100]
			}
		},
		labels: ['1400/01/01', '1400/01/02', '1400/01/03', '1400/01/04', '1400/01/05', '1400/01/06', '1400/01/07', '1400/01/08', '1400/01/09', '1400/01/10', '1400/01/11'],
		markers: {
			size: 0
		},
		xaxis: {
			type: 'datetime'
		},
		yaxis: {
			title: {
				text: 'امتیاز',
			},
			min: 0
		},
		tooltip: {
			shared: true,
			intersect: false,
			y: {
				formatter: function (y) {
					if (typeof y !== "undefined") {
						return y.toFixed(0) + " امتیاز";
					}
					return y;
				}
			}
		}
	};
	var chart = new ApexCharts(document.querySelector("#chart7"), options);
	chart.render();


	// chart 8
	var options = {
		series: [44, 55, 13, 43, 22],
		chart: {
			foreColor: '#9ba7b2',
			height: 330,
			type: 'pie',
		},
		colors: ["#8833ff", "#6c757d", "#17a00e", "#f41127", "#ffc107"],
		labels: ['تیم الف', 'تیم ب', 'تیم پ', 'تیم ت', 'تیم ث'],
		responsive: [{
			breakpoint: 480,
			options: {
				chart: {
					height: 360
				},
				legend: {
					position: 'bottom'
				}
			}
		}]
	};
	var chart = new ApexCharts(document.querySelector("#chart8"), options);
	chart.render();


	// chart 9
	var options = {
		series: [44, 55, 41, 17, 15],
		chart: {
			foreColor: '#9ba7b2',
			height: 380,
			type: 'donut',
		},
		colors: ["#8833ff", "#29cc39", "#17a00e", "#f41127", "#ffc107"],
		responsive: [{
			breakpoint: 480,
			options: {
				chart: {
					height: 320
				},
				legend: {
					position: 'bottom'
				}
			}
		}]
	};
	var chart = new ApexCharts(document.querySelector("#chart9"), options);
	chart.render();


	// chart 10
	var options = {
		series: [{
			name: 'سری 1',
			data: [80, 50, 30, 40, 100, 20],
		}, {
			name: 'سری 2',
			data: [20, 30, 40, 80, 20, 80],
		}, {
			name: 'سری 3',
			data: [44, 76, 78, 13, 43, 10],
		}],
		chart: {
			foreColor: '#9ba7b2',
			height: 350,
			type: 'radar',
			dropShadow: {
				enabled: true,
				blur: 1,
				left: 1,
				top: 1
			}
		},
		colors: ["#8833ff", "#29cc39", "#17a00e"],
		title: {
			text: 'نمودار رادار'
		},
		stroke: {
			width: 2
		},
		fill: {
			opacity: 0.1
		},
		markers: {
			size: 0
		},
		xaxis: {
			categories: ['1395', '1396', '1397', '1398', '1399', '1400']
		}
	};
	var chart = new ApexCharts(document.querySelector("#chart10"), options);
	chart.render();


	// chart 11
	var options = {
		series: [{
			name: 'سری 1',
			data: [20, 100, 40, 30, 50, 80, 33],
		}],
		chart: {
			foreColor: '#9ba7b2',
			height: 350,
			type: 'radar',
		},
		dataLabels: {
			enabled: true
		},
		plotOptions: {
			radar: {
				size: 140,
				polygons: {
					strokeColors: '#e9e9e9',
					fill: {
						colors: ['#f8f8f8', '#fff']
					}
				}
			}
		},
		title: {
			text: 'نمودار چند ضلعی'
		},
		colors: ["#8833ff"],
		markers: {
			size: 4,
			colors: ['#fff'],
			strokeColor: '#FF4560',
			strokeWidth: 2,
		},
		tooltip: {
			y: {
				formatter: function (val) {
					return val
				}
			}
		},
		xaxis: {
			categories: ['شنبه', 'یکشنبه', 'دوشنبه', 'سه شنبه', 'چهارشنبه', 'پنج شنبه', 'جمعه']
		},
		yaxis: {
			tickAmount: 7,
			labels: {
				formatter: function (val, i) {
					if (i % 2 === 0) {
						return val
					} else {
						return ''
					}
				}
			}
		}
	};
	var chart = new ApexCharts(document.querySelector("#chart11"), options);
	chart.render();



	// chart 12

	var options = {
		series: [70],
		chart: {
			foreColor: '#9ba7b2',
			height: 350,
			type: 'radialBar',
		},
		plotOptions: {
			radialBar: {
				hollow: {
					size: '70%',
				}
			},
		},
		labels: ['کریکت'],
	};

	var chart = new ApexCharts(document.querySelector("#chart12"), options);
	chart.render();



	// chart 13

	var options = {
		series: [44, 55, 67, 83],
		chart: {
			foreColor: '#9ba7b2',
			height: 350,
			type: 'radialBar',
		},
		plotOptions: {
			radialBar: {
				dataLabels: {
					name: {
						fontSize: '22px',
					},
					value: {
						fontSize: '16px',
					},
					total: {
						show: true,
						label: 'مجموع',
						formatter: function (w) {
							// By default this function returns the average of all series. The below is just an example to show the use of custom formatter function
							return 249
						}
					}
				}
			}
		},
		colors: ["#8833ff", "#17a00e", "#f41127", "#ffc107"],
		labels: ['سیب', 'پرتقال', 'موز', 'بلوبری'],
	};

	var chart = new ApexCharts(document.querySelector("#chart13"), options);
	chart.render();




});