function getAllCategories()
{      
    $.ajax(
    {
        type: 'GET',
        url: 'http://localhost:5000/api/category',
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let cat = "";
            data.forEach(function(item)
            {
                cat = cat + category(item.id, item.title);
            });
            $('#category').html(cat);
        } 
    });
    
}; 

function createCategory(title)
{
    $.ajax(
    {
        type: 'POST',
        url: 'http://localhost:5000/api/category',
        dataType : "json",
        contentType: "application/json; charset=utf-8",
        data: `{ "title": "${title}" }`,
        success: function (data, textStatus)
        { 
            getAllBooks();
            getAllCategories();
        }         
    });
};

