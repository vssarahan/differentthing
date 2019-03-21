$('#category').delegate('.ctg','click',function(e){
    getBooksByCategory(e.target.id);
});

$('#all').click(getAllBooks);

$('#newCtg').click(function(){
    $('#content').html(createCategoryForm());
});

$('#content').delegate("#createCategory","click",function(e){
    createCategory(document.forms.createForm.title.value);
});