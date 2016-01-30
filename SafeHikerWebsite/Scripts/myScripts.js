function showpage2() {
    document.getElementById('pagetwo').style.display = '';
    document.getElementById('pageone').style.display = 'none';
}

function showpage1() {
    document.getElementById('pagetwo').style.display = 'none';
    document.getElementById('pageone').style.display = '';
}

$(document).ready(function () {
    // Use allowtimes for adding more granularity
    $(".datetime").datetimepicker();
});