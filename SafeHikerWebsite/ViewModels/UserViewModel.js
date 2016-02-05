var HasUserData = ko.observable(false);
var userData = {
    name: ko.observable(""),
    emergencyEmail1: ko.observable(""),
    emergencyEmail2: ko.observable("")
};

var pages = ['pageone', 'pagetwo', 'pagethree', 'pagefour', 'pagefive'];

$(document).ready(function () {
    //    Use allow times for adding more granularity
    $(".datetime").datetimepicker();
    showpage(pages[0]);

    var userEmail = document.getElementById("userEmail").defaultValue;
    $.ajax({
        url: "https://localhost:44301/SafeHiker/User/" + userEmail,
        contentType: "application/json",
        type: "GET",
        async: false,
        success: function (data) {
            if (data == null) {
                HasUserData(false);
                showpage(pages[1]);
            } else {
                userData.name(data.Name);
                HasUserData(true);
                showpage(pages[2]);
            }
        },
        error: function () {
        }
    });
});

function showpage(pageId) {
    document.getElementById(pageId).style.display = '';
    for (var i = 0; i < pages.length; i++) {
        if (pageId !== pages[i]) {
            document.getElementById(pages[i]).style.display = 'none';
        }
    }
}