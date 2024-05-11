document.addEventListener("DOMContentLoaded", function () {
    loadTasks();
});

function loadTasks() {
    fetch('/api/Task')
        .then(response => response.json())
        .then(tasks => renderTasks(tasks))
        .catch(error => console.error('Failed to fetch tasks:', error));
}

function addTask() {
    const taskInput = document.getElementById('taskInput');
    const taskText = taskInput.value.trim();

    if (taskText !== '') {
        fetch('/api/Task', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(taskText)
        })
        .then(() => {
            taskInput.value = '';
            loadTasks();
        })
        .catch(error => console.error('Failed to add task:', error));
    }
}

function deleteTask(index) {
    fetch(`/api/Task/${index}`, {
        method: 'DELETE'
    })
    .then(() => loadTasks())
    .catch(error => console.error('Failed to delete task:', error));
}

function toggleTask(index) {
    fetch(`/api/Task/${index}`, {
        method: 'PUT'
    })
    .then(() => loadTasks())
    .catch(error => console.error('Failed to toggle task:', error));
}

function renderTasks(tasks) {
    const taskList = document.getElementById('taskList');
    taskList.innerHTML = '';

    tasks.forEach((task, index) => {
        const li = document.createElement('li');
        
        const taskContainer = document.createElement('div');
        taskContainer.classList.add('task-container');

        const taskText = document.createElement('span');
        taskText.textContent = task;
        taskContainer.appendChild(taskText);

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.classList.add('delete-button');
        deleteButton.addEventListener('click', (event) => {
            event.stopPropagation();
            deleteTask(index);
        });
        taskContainer.appendChild(deleteButton);

        li.appendChild(taskContainer);
        li.addEventListener('click', () => toggleTask(index));
        
        taskList.appendChild(li);
    });
}
