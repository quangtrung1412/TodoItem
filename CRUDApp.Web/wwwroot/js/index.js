!async function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/todoItemHub").build();

    //fun update status
    connection.on("UpdateTodoItemStatus", handleUpdateTodoItemStatus)
    await connection.start();


    var statusTdElms = document.querySelectorAll(".table .badge");
    statusTdElms.forEach(statusTdElm => {
        statusTdElm.addEventListener("click", handleClickStatusTdElem);
    })

    async function handleUpdateTodoItemStatus(todoItem) {
        let badgeElm = document.querySelector(`#todoItem-${todoItem.id} .badge`);
        badgeElm.innerText = todoItem.status.name;
        switch (todoItem.status.id) {
            case 0:
                badgeElm.className = "badge bg-secondary";
                badgeElm.dataset.statusId = todoItem.status.id;
                break;
            case 1:
                badgeElm.className = "badge bg-info";
                badgeElm.dataset.statusId = todoItem.status.id;
                break;
            default:
                badgeElm.className = "badge bg-success";
                badgeElm.dataset.statusId = todoItem.status.id;
                break;
        }
    }

    //    target lấy element cick vào 
    async function handleClickStatusTdElem(evt) {

        var target = evt.target;
        var trParent = target.closest("tr");
        //slice lấy từ vị trí thứ mấy
        var todoItemId = trParent.id.slice(9);
        var todoStatusId = target.dataset["statusId"];
        var resp = await updateTodoItemStatus(todoItemId, todoStatusId);

        await connection.invoke("SendUpdateStatusToAll", resp);
    }


    async function updateTodoItemStatus(todoItemId, statusId) {
        return await httpClient("/api/todoItem/update-status/" + todoItemId, "PUT", { todoItemId, statusId });
    }


    async function httpClient(endpoints, method = "GET", data = null) {
        var resp = await fetch(endpoints, {
            method,
            headers: {
                "Content-Type": "application/json"
            },
            body: data ? JSON.stringify(data) : data
        });
        return await resp.json();
    }

    //func updatename
    var todoItemNameTdElms = document.querySelectorAll(".table .todo-item-name span");
    todoItemNameTdElms.forEach(todoItemNameTdElm => {
        todoItemNameTdElm.addEventListener("dblclick", handleDblClickTodoItemNameTdElm)

    })


    async function handleDblClickTodoItemNameTdElm(evt) {
        var target = evt.target;
        var inputElm = target.nextElementSibling;
        inputElm.type = "text";
        document.createAttribute("các").previousEleSibling
    }


    var todoItemNameInputElms = document.querySelectorAll(".table .todo-item-name input");
    todoItemNameInputElms.forEach(todoItemNameInputElm => {
        todoItemNameInputElm.addEventListener("keyup", handleKepressTodoItemNameElm)
    })


    async function handleKepressTodoItemNameElm(evt) {
        var target = evt.target;
        var trParent = target.closest("tr");
        var todoItemId = trParent.id.slice(9);
        var todoItemName = target.value;
        var spanTodoItemName = target.previousElementSibling.textContent.trimEnd().trimStart();
        if (evt.key.toUpperCase() === 'ENTER') {
            target.type = "hidden";
            if (todoItemName.trim() != spanTodoItemName.trim()) {
                var resp = await updateTodoItemName(todoItemId, todoItemName);
                connection.invoke("SendUpdateNameToAll", resp);

            }
        }
        if(evt.key.toUpperCase() === 'ESCAPE'){
            target.type = "hidden";
            target.value = spanTodoItemName;

        }
    }


    async function updateTodoItemName(todoItemId, todoItemName) {
        return await httpClient("/api/todoItem/update-name/" + todoItemId, "PUT", { todoItemId, todoItemName });
    }
    connection.on("UpdateTodoItemName", handleUpdateTodoItemName)
    async function handleUpdateTodoItemName(todoItem) {
        var spanElm = document.querySelector(`#todoItem-${todoItem.id} .todo-item-name span`);
        spanElm.innerText=todoItem.name;
        var inputElm = document.querySelector(`#todoItem-${todoItem.id} .todo-item-name input`);
        inputElm.value =todoItem.name;
    }
}();