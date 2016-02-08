var HasUserData = ko.observable(false);

var UserData = {
    name: ko.observable(""),
    emergencyEmail1: ko.observable(""),
    emergencyEmail2: ko.observable("")
};

function clearUserData() {
    UserData.name("");
    UserData.emergencyEmail1("");
    UserData.emergencyEmail2("");
    showpage('pagefour');
}