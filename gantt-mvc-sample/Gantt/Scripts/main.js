(function () {

    // add month scale
    gantt.config.scale_unit = "week";
    gantt.config.step = 1;
    gantt.templates.date_scale = function (date) {
        var dateToStr = gantt.date.date_to_str("%d %M");
        var endDate = gantt.date.add(gantt.date.add(date, 1, "week"), -1, "day");
        return dateToStr(date) + " - " + dateToStr(endDate);
    };
    gantt.config.subscales = [
        { unit: "day", step: 1, date: "%D" }
    ];
    gantt.config.scale_height = 50;

    // configure milestone description
    gantt.templates.rightside_text = function (start, end, task) {
        if (task.type == gantt.config.types.milestone) {
            return task.text;
        }
        return "";
    };
    // add section to type selection: task, project or milestone
    gantt.config.lightbox.sections = [
		{ name: "description", height: 70, map_to: "text", type: "textarea", focus: true },
		{ name: "type", type: "typeselect", map_to: "type" },
		{ name: "time", height: 72, type: "duration", map_to: "auto" }
    ];
           
    gantt.config.xml_date = "%Y-%m-%d %H:%i:%s"; // format of dates in XML
    gantt.init("ganttContainer"); // initialize gantt
    gantt.load("/Home/Data", "json");

    // enable dataProcessor
    var dp = new dataProcessor("/Home/Save");
    dp.init(gantt);

})();