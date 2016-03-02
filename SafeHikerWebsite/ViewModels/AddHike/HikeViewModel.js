$(document).ready(function () {
    //    Use allow times for adding more granularity
    $(".datetime").datetimepicker();
    UserEmail(document.getElementById("userEmail").defaultValue);
    HelloMessage("Hello " + UserEmail());
    showpage('page6');
    ko.applyBindings();

    $.ajax({
        url: "https://localhost:44301/SafeHiker/User/" + UserEmail(),
        cache: false,
        type: "GET",
        success: function (data) {
            if (data == null) {
                ErrorMessage("The server is down. We apologize for the inconvenience.");
                showpage('page1');
            } else if (data.name == null) {
                HasUserData(false);
                showpage('page2');
            } else {
                UserData.name(data.Name);
                HasUserData(true);
                showpage('page3');
            }
        },
        error: function () {
            ErrorMessage("The server is down. We apologize for the inconvenience.");
            showpage('page1');
        }
    });
});

function clearHikeDetails() {
    clearHikeData();
    showpage('page5');
}

function showNextPage() {
    showpage('page3');
}