import { error } from "jquery"

function RegisterModel()
{
    var Name = document.getElementById("Name")
    var UserName = document.getElementById("UserName")
    var Password = document.getElementById("Password")
    var Age = document.getElementById("Age")

    var Mail = document.getElementById("Mail")

    var Profession = document.getElementById("PRofession")

    RegisterFormModel = {
        Rname=name,
        Uname=UserName,
        RPassword=Password,
        RAge=Age,
        Rmail=Mail,
        RProfession=Profession
    }
}
function Register() {
    var RegisterModel = RegisterModel();
    $.ajax({
        type:'POST',
        url: '/Home/Register',
        data: { data=RegisterModel },
        success: function (result) {
            console.log('Success')
        },
        error: function (ex) {
            console.log('error')
        }
    })
}