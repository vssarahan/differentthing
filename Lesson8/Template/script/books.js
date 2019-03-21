function getAllBooks(){
    $.ajax({
        type: "GET",
        url: "http://localhost:5000/api/book",
        dataType: "json",
        success: function(data, status){
            let books = "";
            data.forEach(function(elem){
                books += card(elem.id, elem.name);
            });
            $("#content").html(books);
        }
    });
}

function getBooksByCategory(id){
    $.ajax({
        type: "GET",
        url: "http://localhost:5000/api/book/category/"+id,
        dataType: "json",
        success: function(data, status){
            let books = "";
            data.forEach(function(elem){
                books += card(elem.id, elem.name);
            });
            $("#content").html(books);
        }
    });
}