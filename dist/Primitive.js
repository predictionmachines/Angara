define(["require", "exports", "jquery"], function (require, exports, $) {
    "use strict";
    exports.Show = function (content, container) {
        var $value = $("<div></div>").addClass("angara-show-primitive").appendTo($(container));
        if (content === undefined)
            $value.text("The value is <undefined>");
        else if (content === null)
            $value.text("The value is <null>");
        else if (typeof (content) === "boolean")
            $value.text(content);
        else if (content instanceof Date)
            $value.text(content.toLocaleString());
        else if (typeof (content) === "number")
            $value.text(content);
        else if (typeof (content) === "string")
            $value.addClass("angara-show-string").text(content);
        else
            $value.addClass("angara-show-errormessage").text("Unsupported data type");
    };
});
//# sourceMappingURL=Primitive.js.map