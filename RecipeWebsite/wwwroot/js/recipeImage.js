function checkFileDetails() {
    var fileUpload = document.getElementById('imgInp');

    if (fileUpload.files.length > 0) {      // FIRST CHECK IF ANY FILE IS SELECTED.

        for (var i = 0; i <= fileUpload.files.length - 1; i++) {
            var fileName, fileExtension, fileSize, fileType, dateModified;

            // FILE NAME AND EXTENSION.
            fileName = fileUpload.files.item(i).name;
            fileExtension = fileName.replace(/^.*\./, '');

            // get image info using fileReader()
            readImageFile(fileUpload.files.item(i));
        }

        // GET THE IMAGE WIDTH AND HEIGHT USING fileReader() API.
        function readImageFile(imgInp) {
            var reader = new FileReader(); // Create a new instance.

            reader.onload = function (e) {
                var img = new Image();
                img.src = e.target.result;

                img.onload = function () {
                    var width = this.width;
                    var height = this.height;

                    if (height != 720 || width != 1080) {
                        const errorString = "<b>Image dimentions are inavlid</b>";
                        document.getElementById('fileInfo').innerHTML = errorString.fontcolor("red");
                        return false;
                    }
                    else {
                        document.getElementById('fileInfo').innerHTML =
                            document.getElementById('fileInfo').innerHTML + '<br /> ' +
                            'Name: <b>' + imgInp.name + '</b> <br />' +
                            'File Extension: <b>' + fileExtension + '</b> <br />' +
                            'Size: <b>' + Math.round((imgInp.size / 1024)) + '</b> KB <br />' +
                            'Width: <b>' + width + '</b> <br />' +
                            'Height: <b>' + height + '</b> <br />' +
                            'Type: <b>' + imgInp.type + '</b> <br />' +
                            'Last Modified: <b>' + imgInp.lastModifiedDate + '</b> <br />';
                        return true;
                    }
                }
            };
            reader.readAsDataURL(imgInp);
        }
    }
}