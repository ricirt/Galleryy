function addFormModel() {
    var aname = document.getElementById("inputName").value;
    var aborn = document.getElementById("inputBorn").value;
    var adie = document.getElementById("inputDie").value;
    var awork = document.getElementById("inputWork").value;
    var ainfo = document.getElementById("inputInfo").value;

    formModel = {
        Aname: aname,
        Aborn: aborn,
        Adie: adie,
        AnumberOfWork: awork,
        Ainformation: ainfo
    }
    return formModel;
}
function myFunction() {
    console.log("Deneme");
    var dataModel = addFormModel();
    $.ajax({
        type: 'POST',
        url: '/home/SubmitForm',
        data: { artist: dataModel },
        success: function (result) {

            console.log("İşlem başarılı")

        },
        error: function (ex) {
            console.log("İşlem Başarısız")
        }
    });
}
function AddArtWorkModel() {
    var awname = document.getElementById("inputName").value;
    var awdate = document.getElementById("inputDate").value;
    var awtype = document.getElementById("inputType").value;
    var awinformation = document.getElementById("inputInformation").value;
    var awvalue = document.getElementById("inputValue").value;
    var aartist = document.getElementById("inputArtist").value;

    formModel = {
        Awname: awname,
        Awdate: awdate,
        Awtype: awtype,
        Awinformation: awinformation,
        Awvalue: awvalue,
        Aid: aartist
        
    }
    return formModel;
}
function AddArtWorkFunction() {

    var dataModel = AddArtWorkModel();
    $.ajax({
        type: 'POST',
        url: '/home/AddArtWork',
        data: { artwork: dataModel },
        success: function (result) {

            console.log("İşlem başarılı")

        },
        error: function (ex) {
            console.log("İşlem Başarısız")
        }
    });
}
function AddGroupModel() {
    var gname = document.getElementById("inputName").value;
    var ginfo = document.getElementById("inputInfo").value;

    formModel = {
        Gname: gname,
        Ginfo: ginfo,

    }
    return formModel;
}
function AddGroup() {
    var dataModel = AddGroupModel();
    $.ajax({
        type: 'POST',
        url: '/Home/AddGroup',
        data: { group: dataModel },
        success: function (result) {
            console.log("Başarılı")
        },
        error: function (ex) {
            console.log("Başarısız")
        }
    });
}