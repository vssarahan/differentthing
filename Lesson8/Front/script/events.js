$('#all').click(getAllBooks);

$("#category").delegate(".ctg", "click", function(e)
{
        getBooksByCategory(e.target.id);
});

$('#newCtg').click(function()
{
   $('#content').html(createCategoryForm()); 
});

$('#content').delegate("#createCategory","click",function()
{
   createCategory(document.forms.createForm.title.value); 
});

