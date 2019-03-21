function getCategories(){
    $.ajax({
        type: "GET",
        url: "http://localhost:5000/api/category",
        dataType: "json",
        success: function(data, status){
            let ctg = "";
            data.forEach(function(elem){
                ctg += category(elem.id, elem.title);
            });
            $('#category').html(ctg);
        }
    });
}

function createCategory(title){
    $.ajax({
        type: "POST",
        url: "http://localhost:5000/api/category",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: `{"title": "${title}"}`,
        success: function(data){
            getAllBooks();
            getCategories();
        }
    });
}