
$.validator.addMethod("filesize", function (value, element, param) {
    return this.optional(element) || element.files[0].size <= 1048576
});
 
$(document).ready(function () {
    $('#CoverImage').on('change', function () {
        $('#cover-image').attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none');
    });

    $('#SelectedDevices').select2();
    $('#CategoryId').select2();

});
