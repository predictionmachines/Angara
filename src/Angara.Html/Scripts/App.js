﻿require.config({
    map: {
        'angara.tablejs': {
            'idd': 'idd.umd'
        }
    },
    paths: {
        "Angara.Serialization.umd": "angara.serializationjs/dist/Angara.Serialization.umd",
        "Chart": "angara.chartjs/dist/Chart",
        "Table": "angara.tablejs/dist/Table",
        "angara.tablejs": "angara.tablejs/dist/angara.tablejs",
        "jquery.dataTables": "DataTables/media/js/jquery.dataTables",
        "jquery.dataTables-css": "DataTables/media/css/jquery.dataTables",
        "idd.umd": "idd/dist/idd.umd",
        "idd-css": "idd/dist/idd",
        "domReady": "domReady/domReady",
        "jquery": "jquery/dist/jquery.min",
        "jquery-ui": "jquery-ui/jquery-ui.min",
        "jquery-mousewheel": "jquery-mousewheel/jquery.mousewheel.min",
        "css": "require-css/css.min",
        "rx": "rxjs/dist/rx.lite.min",
        "svg": "svg.js/dist/svg.min",
        "filesaver": "FileSaver.js/FileSaver.min"
    }
});

require(["Main"]);