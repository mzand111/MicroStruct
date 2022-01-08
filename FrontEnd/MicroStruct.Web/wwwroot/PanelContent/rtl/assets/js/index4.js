$(function () {
	"use strict";
	// chart 1
	Highcharts.chart('chart1', {
		chart: {
			useHTML: true,
			height: 350,
			plotBackgroundColor: null,
			plotBorderWidth: null,
			plotShadow: false,
			type: 'pie',
			styledMode: true
		},
		credits: {
			enabled: false
		},
		title: {
			useHTML: true,
			text: 'دستگاه جلسات'
		},
		legend: {
			rtl: true
		},
		subtitle: {
			useHTML: true,
			text: 'نسبت دستگاههایی که توسط کاربران استفاده می شود'
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
				innerSize: 120,
				dataLabels: {
					enabled: true,
					format: '<b>{point.name}</b>: {point.percentage:.1f} %'
				},
				showInLegend: true
			}
		},
		//colors: ['#ff9ad5', '#50b5ff', '#5a65dc'],
		series: [{
			name: 'کاربران',
			colorByPoint: true,
			data: [{
				name: 'دسکتاپ',
				y: 56
			}, {
				name: 'موبایل',
				y: 30
			}, {
				name: 'تبلت',
				y: 14
			}]
		}],
		responsive: {
			rules: [{
				condition: {
					maxWidth: 500
				},
				chartOptions: {
					plotOptions: {
						pie: {
							innerSize: 140,
							dataLabels: {
								enabled: false
							}
						}
					},
				}
			}]
		}
	});
	// chart 2
	// Create the chart
	Highcharts.chart('chart2', {
		chart: {
			height: 350,
			type: 'column',
			styledMode: false
		},
		credits: {
			enabled: false
		},
		title: {
			useHTML: true,
			text: 'استفاده از مرورگر'
		},
		subtitle: {
			useHTML: true,
			text: 'سوابق استفاده از مرورگر توسط کاربران'
		},
		accessibility: {
			announceNewData: {
				enabled: true
			}
		},
		xAxis: {
			type: 'category'
		},
		yAxis: {
			title: {
				text: 'استفاده از مرورگرها توسط کاربران'
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
		colors: ['#ff6459', '#f5964b', '#56aafb', '#62aedf', '#9a78f0', '#5bb75f'],
		series: [{
			name: "مرورگرها",
			colorByPoint: true,
			data: [{
				name: "کروم",
				y: 47.29,
				drilldown: "Chrome"
			}, {
				name: "فایرفاکس",
				y: 24.25,
				drilldown: "Firefox"
			}, {
				name: "اینترنت اکسپلورر",
				y: 41.48,
				drilldown: "Internet Explorer"
			}, {
				name: "سافاری",
				y: 44.32,
				drilldown: "Safari"
			}, {
				name: "مایکروسافت اج",
				y: 76.39,
				drilldown: "Edge"
			}, {
				name: "اپرا",
				y: 16.92,
				drilldown: "Opera"
			}]
		}],
		drilldown: {
			series: [{
				name: "کروم",
				id: "Chrome",
				data: [
					["v65.0",
						0.1
					],
					["v64.0",
						1.3
					],
					["v63.0",
						53.02
					],
					["v62.0",
						1.4
					],
					["v61.0",
						0.88
					],
					["v60.0",
						0.56
					],
					["v59.0",
						0.45
					],
					["v58.0",
						0.49
					],
					["v57.0",
						0.32
					],
					["v56.0",
						0.29
					],
					["v55.0",
						0.79
					],
					["v54.0",
						0.18
					],
					["v51.0",
						0.13
					],
					["v49.0",
						2.16
					],
					["v48.0",
						0.13
					],
					["v47.0",
						0.11
					],
					["v43.0",
						0.17
					],
					["v29.0",
						0.26
					]
				]
			}, {
				name: "فایرفاکس",
				id: "Firefox",
				data: [
					["v58.0",
						1.02
					],
					["v57.0",
						7.36
					],
					["v56.0",
						0.35
					],
					["v55.0",
						0.11
					],
					["v54.0",
						0.1
					],
					["v52.0",
						0.95
					],
					["v51.0",
						0.15
					],
					["v50.0",
						0.1
					],
					["v48.0",
						0.31
					],
					["v47.0",
						0.12
					]
				]
			}, {
				name: "اینترنت اکسپلورر",
				id: "Internet Explorer",
				data: [
					["v11.0",
						6.2
					],
					["v10.0",
						0.29
					],
					["v9.0",
						0.27
					],
					["v8.0",
						0.47
					]
				]
			}, {
				name: "سافاری",
				id: "Safari",
				data: [
					["v11.0",
						3.39
					],
					["v10.1",
						0.96
					],
					["v10.0",
						0.36
					],
					["v9.1",
						0.54
					],
					["v9.0",
						0.13
					],
					["v5.1",
						0.2
					]
				]
			}, {
				name: "مایکروسافت اج",
				id: "Edge",
				data: [
					["v16",
						2.6
					],
					["v15",
						0.92
					],
					["v14",
						0.4
					],
					["v13",
						0.1
					]
				]
			}, {
				name: "اپرا",
				id: "Opera",
				data: [
					["v50.0",
						0.96
					],
					["v49.0",
						0.82
					],
					["v12.1",
						0.14
					]
				]
			}]
		}
	});
	// chart 3
	Highcharts.chart('chart3', {
		chart: {
			height: 330,
			type: 'column',
			styledMode: true
		},
		credits: {
			enabled: false
		},
		title: {
			useHTML: true,
			text: 'نمای کلی مخاطبان وب سایت',
			style: {
				display: 'none',
			}
		},
		subtitle: {
			useHTML: true,
			text: 'نمای کلی مخاطبان وب سایت',
			style: {
				display: 'none',
			}
		},
		xAxis: {
			categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد', 'شهر', 'مهر', 'آبا', 'آذر', 'دی', 'بهم', 'اسف'],
			crosshair: true
		},
		yAxis: {
			min: 0,
			title: {
				text: 'بازدید',
				style: {
					display: 'none',
				}
			}
		},
		exporting: {
			buttons: {
				contextButton: {
					enabled: false,
				}
			}
		},
		tooltip: {
			useHTML: true,
			headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
			pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' + '<td style="padding:0"><b>{point.y:.1f}</b></td></tr>',
			footerFormat: '</table>',
			shared: true,
			useHTML: true
		},
		legend: {
			rtl: true
		},
		plotOptions: {
			column: {
				pointPadding: 0.2,
				borderWidth: 0
			}
		},
		//colors: ['#50b5ff', '#ff9ad5'],
		series: [{
			name: 'بازدیدکنندگان جدید',
			data: [70.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4]
		}, {
			name: 'بازگشت بازدید کنندگان',
			data: [48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0, 59.6, 52.4, 65.2, 59.3, 51.2]
		}]
	});
	// chart 4
	// Make monochrome colors
	var pieColors = (function () {
		var colors = ['#0370e6', 'rgb(3 112 230 / 76%)', 'rgb(3 112 230 / 60%)', 'rgb(3 112 230 / 46%)', 'rgb(3 112 230 / 26%)'],
			base = Highcharts.getOptions().colors[0],
			i;
		for (i = 0; i < 10; i += 1) {
			// Start out with a darkened base color (negative brighten), and end
			// up with a much brighter color
			colors.push(Highcharts.color(base).brighten((i - 3) / 7).get());
		}
		return colors;
	}());
	// Build the chart
	Highcharts.chart('chart4', {
		chart: {
			useHTML: true,
			//height:380,
			plotBackgroundColor: null,
			plotBorderWidth: null,
			plotShadow: false,
			type: 'pie',
			//styledMode: true
		},
		credits: {
			useHTML: true,
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
			text: 'بازدید کنندگان براساس مکان'
		},
		tooltip: {
			useHTML: true,
			pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
		},
		accessibility: {
			point: {
				useHTML: true,
				valueSuffix: '%'
			}
		},
		plotOptions: {
			pie: {
				allowPointSelect: true,
				cursor: 'pointer',
				innerSize: 0,
				colors: pieColors,
				dataLabels: {
					enabled: true,
					useHTML: true,
					format: '<b>{point.name}</b><br>{point.percentage:.1f} %',
					distance: -50,
					filter: {
						property: 'percentage',
						operator: '>',
						value: 4
					}
				}
			}
		},
		series: [{
			useHTML: true,
			name: 'بازدیدکنندگان',
			data: [{
				name: 'ایران',
				y: 61.41
			}, {
				name: 'استرالیا',
				y: 11.84
			}, {
				name: 'هند',
				y: 4.67
			}, {
				name: 'چین',
				y: 4.18
			}, ]
		}]
	});
	// chart 5
	Highcharts.chart('chart5', {
		chart: {
			type: 'line',
			styledMode: true
		},
		title: {
			useHTML: true,
			text: 'صفحات محبوب'
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
		yAxis: {
			title: {
				text: 'صفحات محبوب',
				style: {
					display: 'none',
				}
			}
		},
		xAxis: {
			categories: ['فرو', 'ارد', 'خرد', 'تیر']
		},
		tooltip: {
			useHTML: true
		},
		legend: {
			useHTML: true,
			layout: 'vertical',
			align: 'right',
			rtl: true,
			verticalAlign: 'middle'
		},
		plotOptions: {
			series: {
				label: {
					connectorAllowed: false
				},
				pointStart: 2010
			}
		},
		//colors: ['#dc3545', '#01adff', '#673ab7'],
		series: [{
			name: 'جستجو',
			data: [43934, 52503, 57177, 69658, 97031, 119931, 137133, 154175]
		}, {
			name: 'پرداخت',
			data: [24916, 24064, 29742, 29851, 32490, 30282, 38121, 40434]
		}, {
			name: 'پروفایل',
			data: [11744, 17722, 16005, 19771, 20185, 24377, 32147, 39387]
		}],
		responsive: {
			rules: [{
				condition: {
					maxWidth: 500
				},
				chartOptions: {
					legend: {
						layout: 'horizontal',
						align: 'center',
						verticalAlign: 'bottom'
					}
				}
			}]
		}
	});
	// chart 6
	Highcharts.chart('chart6', {
		chart: {
			type: 'bar',
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
		//colors: ['#7c6cfb', '#02c9ef', '#f7a103'],
		title: {
			useHTML: true,
			text: 'بازدید کننده بر اساس جنسیت'
		},
		xAxis: {
			useHTML: true,
			categories: ['فرو', 'ارد', 'خرد', 'تیر', 'مرد']
		},
		yAxis: {
			min: 0,
			title: {
				text: 'بازدید کننده بر اساس جنسیت',
				style: {
					display: 'none',
				}
			}
		},
		legend: {
			useHTML: true,
			reversed: false
		},
		tooltip: {
			useHTML: true
		},
		legend: {
			rtl: true
		},
		plotOptions: {
			series: {
				stacking: 'normal'
			}
		},
		series: [{
			name: 'مرد',
			data: [5, 3, 4, 7, 2]
		}, {
			name: 'زن',
			data: [2, 2, 3, 2, 1]
		}, {
			name: 'دیگر',
			data: [3, 4, 4, 2, 5]
		}]
	});
});