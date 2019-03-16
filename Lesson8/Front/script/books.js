function getAllBooks()
{   
    $.ajax(
    {
        type: 'GET',
        url: 'http://localhost:5000/api/book',
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let books = "";
            data.forEach(function(item)
            {
                books = books + card(item.id, item.name);
            });
            $('#content').html(books);
        } 
    });
};

function getBooksByCategory(id)
{
    $.ajax(
    {
        type: 'GET',
        url: `http://localhost:5000/api/book/category/${id}`,
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let books = "";
            data.forEach(function(item)
            {
                books = books + card(item.id, item.name);
            });
            $('#content').html(books);
        } 
    });
};