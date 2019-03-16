function category(id, title)
{
    return `<button class="btn btn-outline-info btn-block ctg" id="${id}">${title}</button>`;
};

function card(id, name)
{
    return `<div class="card col-3 mx-4 my-2" style="width:100%" id="${id}">
        <img class="card-img-top" src="img/book.png" alt="Card image" style="width:100%">
        <div class="card-body"> 
            <h4 class="card-title">${name}</h4>
            <p class="card-text">Описание, которое я забыл добавить в модели :(</p>
        </div>
    </div>`;
    
};

function createCategoryForm()
{
    return `<div class="col-12 text-center">
                <h5>Создать новую категорию</h5>
            </div>
            <div class="col-12">
            <form name="createForm">
                <div class="form-group">
                    <label>Название</label>
                    <input class="form-control" name="title" />
                </div>
            </form>
            <button class="btn btn-outline-success btn-block" id="createCategory">Добавить</button>
            </div`;
}


