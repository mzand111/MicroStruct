
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
        function buildInterface(nn, data) {
            var s = "<ul class='dashboardUl'>";
            for (var i = 0; i < data.length; i++) {

                s += '<li class="dashboardUlli">';
                s += '<div class="k-edit-label">';
                s += '<label for="' + data[i].ID + '"> ' + data[i].Name + ':</label>';

                s += "</div>";
                s += '<a target="_blank" href="/General/ActivityCartable?tabid=' + data[i].ItemTabID + '">' + data[i].Count + '</a>';
                s += '</li>';
            }
            s += '</ul>';
            nn.html(s);
        }

        this.reBind = function (type, objectID) {

            var hh = $(document).find('[data-ctrlboxwidgetinstanceID="' + settings.widget.ID + '"]');
            hh.html("");
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
            s += '<div> </div>'; 

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

