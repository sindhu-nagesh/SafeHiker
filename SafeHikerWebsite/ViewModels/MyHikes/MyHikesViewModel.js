var numOfPages = 2;

$(document).ready(function () {
    $(".datetime").datetimepicker();
    ko.applyBindings();
    clearHikeData();
    showpage('page1');
});

function showNextPage() {
    showpage('page1');
}

function clearHikeDetails() {
    clearHikeData();
    showpage('page2');
}