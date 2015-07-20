$(document).ready(function () {
    $("ul.paging").quickPager({ pagerLocation: "bottom", pageSize: "12" });
});


function ShowModal(img) {

    var divContainer = $(img).parent();
    var title = $(divContainer).data("book");
    var author = $(divContainer).data("author");
    var cant = $(divContainer).data("pages");
    var id = $(divContainer).data("isbn");

    $("#Title").text(title);
    $("#Author").text(author);
    $("#cant").text(cant);
    $("#isbn").val(id);
    $('#myModal').modal();

}

function ShowBook() {
    $('#myModal').modal('hide');
    var isbn = $("#isbn").val();
    window.location.href = "/Book/ReturnBookInPdf?isbn="+isbn;




}

function SearchBook() {
    var text = $("#Search").val();
    var url = "/Book/BookByAuthor";
    var who = $("input[type='radio']:checked").val();

    if (who === "Category")
        url = "/Book/BookByCategory";
       
        
    bookFilter(url, text);

}



function bookFilter(url,key) {

    $.getJSON(url, { filterKey: key }, function (data) {

        $("#shelf").html("");
        $.each(data, function (index, entity) {
            $("#shelf").append("<li>" +
                "<div class='book-element'> " +
                "<img class='image-preview' onclick='ShowModal(this);' src='" + entity.Thumb + "' />" +
                 "<label>" + entity.Book + "</label>" +
               "</div>" +
                "</li>");
        });

        $("ul.paging").quickPager({ pagerLocation: "bottom", pageSize: "12" });
    }).error(function () {
        alert("Please review the author name");
    });
}

