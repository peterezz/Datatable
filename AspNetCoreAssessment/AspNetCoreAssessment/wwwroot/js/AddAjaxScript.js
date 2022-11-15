//$("#btnSubmit").click(function () {

//    var Ssn = $("#Ssn").val();
//    var FirstName = $("#FirstName").val();
//    var LastName = $("#LastName").val();
//    var Gender = $("#Gender").val();
//    var PhoneNumber = $("#PhoneNumber").val();
//    var Birthday = $("#Birthday").val();
//    var Stage = $("#Stage").val();
//    var EmailAddress = $("#EmailAddress").val();
//    var Address = $("#Address").val();
//    var PhotoFile = $('#PhotoFile').prop("files");
//    $.ajax({
//        async: true,
//        type: "POST",
//        url: "/Student/Add",
//        dataType: "JSON",
//        data: {
//            Ssn: Ssn,
//            FirstName: FirstName,
//            LastName: LastName,
//            Gender: Gender,
//            PhoneNumber: PhoneNumber,
//            Birthday, Birthday,
//            Stage: Stage,
//            EmailAddress: EmailAddress,
//            Address: Address,

//        },
//        success: function (data) {
//            alert("suc");
//        }
//        });
//});
//$("#btnSubmit").click(function () {


function SerializeFormData(formId, formData) {
    if (formData == null) {
        formData = new FormData();
    }
    $(`#${formId}`).find(`input,select,textarea`).each(function () {
        var name = $(this).attr('name');
        if (name != null) {
            if ($(this).attr('type') == 'checkbox') {
                formData.append(name, $(this).is(':checked'));
            }
            else if ($(this).attr('type') == 'radio') {
                var _val = $("input[name=" + name + "]:checked").val();
                formData.append(name, _val);
            }
            else if ($(this).attr('type') == 'file') {
                var files = this.files;
                if (files.length > 0) {
                    for (var i = 0; i < files.length; i++) {
                        formData.append(name + "[" + i + "]", files[i]);
                    }
                }
            }
            else if ($(this).hasClass("ckeditor")) {
                var value = CKEDITOR.instances[name].getData();
                formData.append(name, value);
            }
            else {
                formData.append(name, $(this).val());
            }
        }
    });
    return formData;
}


$("#btnSubmit").click(function () {

    var _formdata = SerializeFormData("idForm");
    var _saveUrl = "/Student/Add";
    // _formdata.append("pppppp", Value);

    $.ajax({
        url: _saveUrl,
        data: _formdata,
        type: 'POST',
        dataType: 'json',
        processData: false,
        contentType: false,
        success: function (data) {

        },
        error: function () {
        }
    });


});





//$("#idForm").submit(function (e) {
//    e.preventDefault();

//    var form = $(this);
//    var actionUrl = form.attr('action');
//    $.ajax({
//        url: "/Student/Add",
//        type: "POST",
//        data: form.serialize(), // serializes the form's elements.,
//        success: function (data) {
//            alert("suc");
//        }
//    });
//}); 