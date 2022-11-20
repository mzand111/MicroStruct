



(function ($) {
    $.fn.dashboardModuleContainer = function (options) {


        var area = this;
        var widgets = [];
        var currentContainerStructureID;
        var currentObjectID;
        var widgetSettingWindow = null;
        var widgetConfigWindow = null;
        var currentConfigCtrl = null;
        var settingHeightCtrl;

        var settings = $.extend({
            getUserContainerStructureWidgetInstanceListApiAddress: '/api/DashboardClient/GetMyContainerStructureWidgetInstanceList',
            getDefaultContainerStructureWidgetInstanceListApiAddress: '/api/DashboardClient/GetDefaultContainerStructureWidgetInstanceList',
            addWidget: "/api/DashboardClient/AddWidgetInstanceToMyContainer",
            saveWidgetInstanceConfigApiAddress: '/api/DashboardClient/SaveWidgetInstanceConfig',
            saveWidgetInstanceSettingsApiAddress: '/api/DashboardClient/SaveWidgetInstanceSettings',
            saveLayoutApiAddress: '/api/DashboardClient/SaveLayout',
            getWidgetsApiAddress: '/api/DashboardClient/GetMyAvailableWidgets',
            type: 'default',
            objectID: -1,
            addTemplate: false



        }, options);


        function makeFormReady() {

            var that = this;
            //ToDo: KendoChange
            //widgetSettingWindow = $('#widgetSettingWindow').kendoWindow({
            //    height: "150px",
            //    modal: true,
            //    title: dashboardStrs.widgetTotalSettings,
            //    visible: false,
            //    width: "300px",
            //    //close: function () { viewModel.cancel() }
            //}).data("kendoWindow");

            //widgetConfigWindow = $('#widgetConfigWindow').kendoWindow({
            //    height: "150px",
            //    modal: true,
            //    title: dashboardStrs.widgetConfigs,
            //    visible: false,
            //    width: "300px",
            //    //close: function () { viewModel.cancel() }
            //}).data("kendoWindow");

            $('#ddlWidgets').find('option').remove();

            $.ajax({
                url: settings.getWidgetsApiAddress,
                type: 'GET',
                success: function (data) {

                    for (var i = 0; i < data.length; i++) {
                        $('#ddlWidgets').append('<option value="' + data[i].id + '" data-image="../images/dashboard/widgets/' + data[i].id + '.png">' + data[i].name + ' </option>');
                    }
                    $('#ddlWidgets').msDropdown({ visibleRows: 4 });

                },
                error: function (x, y, z) {
                    microStructAlert('error', "", x + '\n' + y + '\n' + z);
                }
            });

            $(document).mouseup(function (e) {
                var container = $("#hiddenWidgets");

                if (!container.is(e.target) // if the target of the click isn't the container...
                    && container.has(e.target).length === 0) // ... nor a descendant of the container
                {
                    $('#showWidgetsBtn').addClass('dashboardWidgetsButtonDown');
                    $('#showWidgetsBtn').removeClass('dashboardWidgetsButtonUp');
                    container.hide();
                }

                var hiddenMenuContainer = $("#hiddenMenu");

                if (!hiddenMenuContainer.is(e.target) // if the target of the click isn't the container...
                    && hiddenMenuContainer.has(e.target).length === 0) // ... nor a descendant of the container
                {
                    $('#showMenuBtn').addClass('dashboardSettingButtonDown');
                    $('#showMenuBtn').removeClass('dashboardSettingButtonUp');
                    hiddenMenuContainer.hide();
                }


                var hiddenMenuTotalSettingContainer = $("#hiddenMenuTotalSetting");

                if (!hiddenMenuTotalSettingContainer.is(e.target) // if the target of the click isn't the container...
                    && hiddenMenuTotalSettingContainer.has(e.target).length === 0) // ... nor a descendant of the container
                {
                    $('#showDashboardTotalSetting').attr('class', 'dashboardListSettingButtonDown');
                    hiddenMenuTotalSettingContainer.hide();
                }

            });


            $(".dashcol").sortable({
                connectWith: ".dashcol",
                refreshPositions: true,
                handle: ".widgetDragHandler",
                helper: 'clone',
                placeholder: 'ui-placeholder',
                tolerance: 'pointer',
                'start': function (event, ui) {
                    ui.placeholder.height(ui.item.children().height());
                    ui.placeholder.html("<div class='dashboardControlBoxPanel portlet ui-helper-clearfix' style='width:100%;height:100%;background-color:#ffebed;text-align:center;  border-radius: 20px 5px 20px 5px;'>Drop Here<div>");

                    $(".dashcol").addClass("dragTimeColumn");
                },
                'stop': function (event, ui) {

                    $(".dashcol").removeClass("dragTimeColumn");
                    var droppedWidgetInstanceID = ui.item.attr("data-widgetinstanceid");
                    saveLayout(currentContainerStructureID, false);

                    for (var i = 0; i < widgets.length; i++) {

                        if (widgets[i].getWidget().ID == droppedWidgetInstanceID) {
                            widgets[i].containerSizeChanged(parseInt(ui.item.css("height")));
                            $("#widgetSettingWindow").modal('hide');
                            break;
                        }
                    }
                }

            });
            $(".dashboardControlBoxPanel").addClass("portlet ui-helper-clearfix")
                .find(".dashboardControlBoxHeaderPanel")
                .addClass("portlet-header")

                .end()
                .find(".dashboardControlBox");



            $(".widgetClose").off("click").on("click", function () {
                $(this).parent().parent().parent().remove();
                saveLayout(currentContainerStructureID, false);
            });

            $(".widgetPrint").off("click").on("click", function () {

                var t = $(this).parent().parent().parent().find(".dashboardControlBox");
                //console.log(t);
                $(".hidden-print", t).hide();
                t.printElement();
                $(".hidden-print", t).show();


            });


            $(".dashcol").disableSelection();


            $('#ddlContainers').msDropdown({ visibleRows: 4 });


            $('#btnAddWidget').off("click").on("click", function () {
                var widgetID = $('#ddlWidgets').data('dd').value;
                var containerID = $('#ddlContainers').data('dd').value;
                //alert(widgetID);
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: settings.addWidget + "?containerID=" + containerID + "&containerStructureUniqID=" + currentContainerStructureID + "&widgetID=" + widgetID,
                    dataType: "text",
                    success: function (data) {
                        microStructAlert('success', "", dashboardStrs.widget_add_succeed); 
                        bind(currentContainerStructureID, currentObjectID);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        debugger;
                    }
                });

            });

            //To save the contents
            // alert("3 " + ContainerStructureUniqID);
            $("#saveDashboardBtn").off("click").on("click", function () {
                saveLayout(currentContainerStructureID, true);
            });
            $("#loadDefaultBtn").off("click").on("click", function () {
                if (confirm(dashboardStrs.layout_replaceWithDefaultConfirm)) {

                    for (var i = 0; i < widgets.length; i++) {
                        widgets[i].destroy();
                    }
                    widgets = [];

                    $("#divTopDashboard").html('');

                    $("#divCenter1RightDashboard").html('');
                    $("#divCenter1LeftDashboard").html('');

                    $("#divCenter2RightDashboard").html('');
                    $("#divCenter2LeftDashboard").html('');

                    $("#divBottomDashboard").html('');

                    $.ajax({
                        url: settings.getDefaultContainerStructureWidgetInstanceListApiAddress + "?containerStructureID=" + currentContainerStructureID,
                        type: 'GET',
                        success: function (data) {
                            for (var i = 0; i < data.length; i++) {
                                var g = $("#" + data[i].containerID).widgetInstantiator({
                                    widget: data[i]

                                });

                                widgets.push(g);
                            }

                            for (var i = 0; i < widgets.length; i++) {
                                widgets[i].reBind(currentContainerStructureID, currentObjectID);
                            }
                            makeFormReady();
                            //kendo.ui.progress(area, false);
                            microStructAlert('success', "", dashboardStrs.layout_replacedWithDefaultInfo);
                        },
                        error: function (x, y, z) {
                            microStructAlert('error', "", x + '\n' + y + '\n' + z);
                        }
                    });


                }
            });
            //$(document).tooltip();


            //ToDo:KendoChange
            settingHeightCtrl = $("#widgetSettings_height");
            //settingHeightCtrl = $("#widgetSettings_height").kendoNumericTextBox({
            //    min: 50,
            //    step: 10,
            //    decimals: 0,
            //    format:'n0',
            //}).data("kendoNumericTextBox");

            $(".widgetEdit").off("click").on("click", function (e) {
                //alert($(this).parent().parent().parent().attr("data-widgetinstanceid"));
                var p = $(this).parent().parent().parent();
                console.log(p);
                $("#widgetSettingSave").attr("data-current-widgetinstanceid", p.attr("data-widgetinstanceid"));
                $("#widgetSettings_title").val(p.find('.dashboardControlBoxTitleCaption').text());
                settingHeightCtrl.val(p.css("height").replace('px', ''));
                $("#widgetSettingWindow").modal('show');
             

            });
            $(".widgetSetting").off("click").on("click", function (e) {
                // alert($(this).parent().parent().parent().attr("data-widgetinstanceid"));

                if (currentConfigCtrl) {
                    currentConfigCtrl.destroy();
                    $("#widgetConfig").html('');
                }

                var p = $(this).parent().parent().parent();
                var widgetInstanceID = p.attr("data-widgetinstanceid");
                console.log(widgetInstanceID);
                console.log(widgets);
                for (var i = 0; i < widgets.length; i++) {
                    console.log(widgets[i]);
                    if (widgets[i].getWidget().id == widgetInstanceID) {
                        currentConfigCtrl = widgets[i].createWidgetSettings($("#widgetConfig"), getConfigObjectFromString(widgets[i].getWidget().config));
                        
                        if (currentConfigCtrl) {
                            $("#widgetConfigSave").attr("data-current-widgetinstanceid", p.attr("data-widgetinstanceid"));
                           
                            $('#widgetConfigWindow').modal('show');
                            
                        } else {
                            microStructAlert('info', "", dashboardStrs.widgetHasNoConfig);
                        }
                        break;
                    }
                }
            });


            $("#widgetSettingSave").off("click").on("click", function (e) {
                var widgetInstanceID = $("#widgetSettingSave").attr("data-current-widgetinstanceid");


                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: settings.saveWidgetInstanceSettingsApiAddress + "?widgetInstanceID=" + widgetInstanceID + "&titleMultilang=&title=" + $("#widgetSettings_title").val() + "&height=" + $("#widgetSettings_height").val(),
                    dataType:"text",
                    success: function (data) {



                        var cbox = $(document).find('[data-widgetinstanceid="' + widgetInstanceID + '"]');
                        cbox.css("height", settingHeightCtrl.val());
                        cbox.find('.dashboardControlBoxTitleCaption').text($("#widgetSettings_title").val());

                        for (var i = 0; i < widgets.length; i++) {

                            if (widgets[i].getWidget().id == widgetInstanceID) {
                                widgets[i].containerSizeChanged(settingHeightCtrl.val());
                                $("#widgetSettingWindow").modal('hide');
                                break;
                            }
                        }

                        microStructAlert('success', "", dashboardStrs.widget_settingsSaved_succeed);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        debugger;
                    }
                });


                //console.log(widgets);


                $("#widgetSettingWindow").modal('hide');
            });
            $("#widgetSettingCancel").off("click").on("click", function (e) {
                $("#widgetSettingWindow").modal('hide');
            });


            $("#widgetConfigSave").off("click").on("click", function (e) {
                var widgetInstanceID = $("#widgetConfigSave").attr("data-current-widgetinstanceid");



                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: settings.saveWidgetInstanceConfigApiAddress + "?widgetInstanceID=" + widgetInstanceID + "&configString=" + JSON.stringify(currentConfigCtrl.getConfigObject()),

                    success: function (data) {


                        for (var i = 0; i < widgets.length; i++) {

                            if (widgets[i].getWidget().ID == widgetInstanceID) {
                                var ff = currentConfigCtrl.getConfigObject();
                                widgets[i].getWidget().config = JSON.stringify(currentConfigCtrl.getConfigObject());
                                widgets[i].setWidgetConfigObject(ff);
                                widgetConfigWindow.close();
                                break;
                            }
                        }
                        microStructAlert('success', "", dashboardStrs.widget_configSaved_succeed);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        debugger;
                    }
                });


                //console.log(widgets);


                $("#widgetSettingWindow").modal('hide');
            });
            $("#widgetConfigCancel").off("click").on("click", (function (e) {
               
                $("#widgetConfigWindow").modal('hide');
            }));

        }

        function getConfigObjectFromString(str) {
            return JSON.parse(str);
        }
        function saveLayout(ContainerStructureUniqID, showMessage) {
            var divs = $.map($("div.dashcol div.dashboardControlBoxPanel"), function (item, index) {
                var WidgetInfo = new Object();
                WidgetInfo.WidgetInstanceID = $(item).attr("data-widgetinstanceid");
                WidgetInfo.Order = index + 1;
                WidgetInfo.ContainerID = $(item).parent().attr("id");
                return WidgetInfo;
            });

            var jsonDivs = JSON.stringify(divs);
            //console.log(jsonDivs);

            $.ajax({
                type: "POST",
                url: settings.saveLayoutApiAddress,
                contentType: "application/json",
                dataType: "text",
                data: JSON.stringify( {
                    Widgets: divs,
                    ContainerStructureUniqID: ContainerStructureUniqID
                }),


               
                success: function (data) {
                    if (showMessage) {
                        microStructAlert('success', "", dashboard.layout_save_succeed); 
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    debugger;
                }
            });
        }

        function bind(ContainerStructureID, objectID) {

            // makeFormReady();
            // $("#showWidgetsBtn").hide();
            //$("#showMenuBtn").hide();
            //return;
            currentContainerStructureID = ContainerStructureID;
            currentObjectID = objectID;
            for (var i = 0; i < widgets.length; i++) {
                widgets[i].destroy();
            }
            widgets = [];

            $("#divTopDashboard").html('');

            $("#divCenter1RightDashboard").html('');
            $("#divCenter1LeftDashboard").html('');

            $("#divCenter2RightDashboard").html('');
            $("#divCenter2LeftDashboard").html('');

            $("#divBottomDashboard").html('');

            $.ajax({
                url: settings.getUserContainerStructureWidgetInstanceListApiAddress + "?containerStructureID=" + ContainerStructureID,
                type: 'GET',
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        try {
                            var g = $("#" + data[i].containerID).widgetInstantiator({
                                widget: data[i]

                            });

                            widgets.push(g);
                            
                        } catch (exception) {
                            if (widgets[i]) {
                                console.log("error loading widget '" + widgets[i].getWidget().title + "' With ID :'" + widgets[i].getWidget().id + "' error :" + exception);
                            } else {
                                console.log("error loading widget '" + data[i].title + "' With ID :'" + data[i].id + "' error :" + exception);
                            }
                        }
                    }



                    for (var i = 0; i < widgets.length; i++) {
                        try {
                            widgets[i].reBind(ContainerStructureID, currentObjectID);
                        } catch (exception) {
                            console.log("error loading widget '" + widgets[i].getWidget().title + "' With ID :'" + widgets[i].getWidget().id + "' error :" + exception);
                        }
                    }
                    makeFormReady();
                    //kendo.ui.progress(area, false);
                },
                error: function (x, y, z) {
                    alert(x + '\n' + y + '\n' + z);
                }
            });

        }

        this.reBind = function (ContainerStructureID, objectID) {
            //kendo.ui.progress(area, true);
            
            if (currentContainerStructureID !== ContainerStructureID) {
                bind(ContainerStructureID, objectID);
            } else if (currentContainerStructureID === ContainerStructureID && currentObjectID !== objectID) {
                currentObjectID = objectID;
                for (var i = 0; i < widgets.length; i++) {
                    try {
                        widgets[i].reBind(currentContainerStructureID, currentObjectID);
                    } catch (exception) {
                        console.log("error rebinding widget '" + widgets[i].getWidget().Title + "' With ID :'" + widgets[i].getWidget().ID + "' error :" + exception);
                    }

                }
                //kendo.ui.progress(area, false);
            } else {
                //kendo.ui.progress(area, false);
            }
        }




        return this;

    }

}(jQuery));