$(document).ready(function () {
    loadTodoItems();

    $('#add-todo-form').submit(function (event) {
        event.preventDefault();
        var todoItem = {
            title: $('#todo-title').val(),
            isCompleted: $('#todo-completed').is(':checked')
        };
        $.ajax({
            type: "POST",
            url: "/api/todo",
            data: JSON.stringify(todoItem),
            contentType: "application/json",
            success: function () {
                loadTodoItems();
                $('#todo-title').val('');
                $('#todo-completed').prop('checked', false);
            },
            error: function (error) {
                console.error("Hata:", error);
            }
        });
    });

    $('#update-todo-btn').click(function () {
        var id = $('#edit-todo-id').val();
        var updatedItem = {
            id: id,
            title: $('#edit-todo-title').val(),
            isCompleted: $('#edit-todo-completed').is(':checked')
        };
        $.ajax({
            type: "PUT",
            url: `/api/todo/${id}`,
            data: JSON.stringify(updatedItem),
            contentType: "application/json",
            success: function () {
                loadTodoItems();
                var myModal = bootstrap.Modal.getInstance(document.getElementById('editModal'));
                if (myModal) {
                    myModal.hide();
                }
            },
            error: function (error) {
                console.error("Hata:", error);
            }
        });
    });
});

function loadTodoItems() {
    $.ajax({
        type: "GET",
        url: "/api/todo",
        success: function (data) {
            $('#todo-list').empty();
            $.each(data, function (i, item) {
                $('#todo-list').append(`
                    <li class="list-group-item">
                        <input type="checkbox" ${item.isCompleted ? 'checked' : ''} disabled> ${item.title} 
                        <button class="btn btn-warning btn-sm float-end ms-2" onclick="showEditModal(${item.id}, '${item.title}', ${item.isCompleted})">Güncelle</button>
                        <button class="btn btn-danger btn-sm float-end" onclick="deleteTodoItem(${item.id})">Sil</button>
                    </li>
                `);
            });
        },
        error: function (error) {
            console.error("Hata:", error);
        }
    });
}

function deleteTodoItem(id) {
    $.ajax({
        type: "DELETE",
        url: `/api/todo/${id}`,
        success: function () {
            loadTodoItems();
        },
        error: function (error) {
            console.error("Hata:", error);
        }
    });
}

function showEditModal(id, title, isCompleted) {
    $('#edit-todo-id').val(id);
    $('#edit-todo-title').val(title);
    $('#edit-todo-completed').prop('checked', isCompleted);
    var myModal = new bootstrap.Modal(document.getElementById('editModal'), {
        keyboard: false
    });
    myModal.show();
}
