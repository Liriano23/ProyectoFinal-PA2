﻿function SaveAsFile(filename, bytesBase64) {


    if (navigator.msSaveBlob) {

        var data = window.atob(bytesBase64);
        var bytes = new Unit8Array(data.length);

        for (var i = 0; i < data.length; i++) {
            bytes[i] = data.charCodeAt(i);
        }

        var blob = new Blob([bytes.buffer], { type: "application/octet-stream" });
        //navigator.msSaveBlob(blob, filename);
        navigator.msSaveOrOpenBlob(blob, filename)
    }
    else {
        var link = document.createElement("a");
        link.download = filename;
        link.href = "data:application/octet-stream;base64," + bytesBase64;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);

    }
}
