



(function ($) {
    $.fn.widgetInstantiator = function (options) {


        var container = this;
        var area = null;
        var widgetInstance = null;

        var settings = $.extend({

            widget: null,
            addTemplate: true,


        }, options);


        //container.html(container.html() + getTemplate());
        container.append(getTemplate());

        area = container.find('[data-widgetinstanceID="' + settings.widget.id + '"]');

        var widgetCreationArea = $(document).find('[data-ctrlboxwidgetinstanceID="' + settings.widget.id + '"]');
        //console.log(ipmpWidgets);
        if (typeof dashboardWidgets !== 'undefined') {
            if (dashboardWidgets[settings.widget.widgetID]) {
                widgetInstance = dashboardWidgets[settings.widget.widgetID].createWidget(widgetCreationArea, settings.widget, JSON.parse(settings.widget.config));
            }
        }

        

        function getTemplate() {
           
            var s = "";
            s += '<div style="height: ' + settings.widget.height + '; width: 100%;" class="dashboardControlBoxPanel portlet ui-helper-clearfix card radius-10 w-100 "  data-widgetinstanceID="' + settings.widget.id + '">' +
                       '<div class="dashboardControlBoxHeaderPanel panel-heading ui-sortable-handle">' +
                            '<div class="widgetDragHandler portlet-handler">' +
                               '<i class="fadeIn animated bx bx-grid-vertical"></i>' +
                             
                             '</div>' +
                             '<div class="dashboardControlBoxTitle">' +
                               '<span class="dashboardControlBoxTitleCaption" id="lblCaption">' + settings.widget.title + '</span>' +
                             '</div>' +
                             '<div class="panel-actions">' +
                                '<a href="#" class="panel-action panel-action-edit widgetEdit"></a>' +
                                '<a href="#" class="panel-action panel-action-setting widgetSetting"></a>' +
                                '<a href="#" class="panel-action panel-action-print widgetPrint"></a>' +
                                '<a href="#" class="panel-action panel-action-dismiss widgetClose"></a>' +
                              '</div>' +
                        '</div>' +

                        '<div class="dashboardControlBox" data-ctrlboxwidgetinstanceID="' + settings.widget.id + '">' +
                            // '<div class="dashboarContentPanel"></div>' +
                        '</div>' +
                  '</div>';
               

            s = minifyHtml(s);
           
            return s;
        }

        var thisObj={

            getWidget : function () {
                return settings.widget;
            },
        containerSizeChanged : function (newHeight) {
            if (widgetInstance)
                widgetInstance.containerSizeChanged(newHeight);
        },
        createWidgetSettings : function (widgetCreationArea, config) {
            if (dashboardWidgets[settings.widget.widgetID].createSettings) {
                return dashboardWidgets[settings.widget.widgetID].createSettings(widgetCreationArea, config);
            } else return null;
        },

        setWidgetConfigObject : function (config) {
            if (widgetInstance)
                widgetInstance.setWidgetConfigObject(config);

        },
        getWidgetConfigObject :function () {
            if (widgetInstance)
                widgetInstance.getWidgetConfigObject();
        },

        reBind : function (type, objectID) {
            // alert(settings.widget.Name);
            if (widgetInstance) {
                widgetInstance.reBind(type, objectID);
            }
        },
        destroy: function () {
            if (widgetInstance) {
                widgetInstance.destroy();
            }
        }
    }
        return thisObj;

    }

}(jQuery));