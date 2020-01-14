$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Book/GetGenres",
        datatype: "Json",
        success: function (data) {
            $.each(data, function (index, value) {
                $('#GenreId').append('<option value="' + value.Id + '">' + value.GenreName + '</option>');
            });
        }
    });
});