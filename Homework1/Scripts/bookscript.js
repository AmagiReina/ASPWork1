$(document).ready(function () {
    let record = $('.record');
    $(record).on('click', function () {
        let id = $(this).attr('id');
        console.log(id);
        $.ajax({
            type: "GET",
            datatype: "json",
            url: "/Book/GetUsersReadBook/",
            data: {
                bookId: id
            },
            success: function (data) {
                $("#displayPartial").html(data);
            },
            error: function () {
                alert("failed");
            }
        });
    });
});