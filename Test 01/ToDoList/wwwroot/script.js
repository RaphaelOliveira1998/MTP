function addTask() {
    const taskInput = document.getElementById('taskInput');
    const taskText = taskInput.value.trim();

    if (taskText !== '') {
        var task = {
            name: taskText,
            isComplete: false
        };

        fetch('/api/Task', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(task)
        })
        .then(response => {
            if (!response.ok) {
                return response.text().then(text => {
                    throw new Error(`Failed to add task: ${text}`);
                });
            }
            taskInput.value = '';
            loadTasks();
        })
        .catch(error => console.error(error));
    }
}

function deleteTask(taskId) {
    fetch(`/api/Task/${taskId}`, {
        method: 'DELETE'
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`Failed to delete task: ${response.statusText}`);
        }
        loadTasks();
    })
    .catch(error => console.error(error));
}

function loadTasks() {
    console.log('loadTasks called');
    const taskList = document.getElementById('taskList');
    console.log('taskList:', taskList);
    if (taskList) {
        taskList.innerHTML = '';
        console.log('taskList cleared');
        console.log('Fetching tasks');
        fetch('/api/Task')
            .then(response => {
                console.log('Response received');
                if (!response.ok) {
                    throw new Error(`Failed to load tasks: ${response.statusText}`);
                }
                return response.json();
            })
            .then(tasks => {
                console.log('Tasks received:', tasks);
                for (let task of tasks) {
                    const taskContainer = document.createElement('div');
                    taskContainer.classList.add('task-container');

                    const listItem = document.createElement('li');
                    listItem.textContent = task.name;
                    listItem.classList.add(task.isComplete ? 'complete' : 'incomplete');

                    const deleteButton = document.createElement('button');
                    deleteButton.textContent = 'Delete';
                    deleteButton.classList.add('delete-button');
                    deleteButton.addEventListener('click', () => deleteTask(task.id));

                    taskContainer.appendChild(listItem);
                    taskContainer.appendChild(deleteButton);

                    taskList.appendChild(taskContainer);
                }
            })
            .catch(error => console.error('Error:', error));
    }
}

function toggleTask(taskId, isComplete) {
    var task = {
        id: taskId,
        isComplete: !isComplete
    };

    fetch(`/api/Task/${taskId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(task)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`Failed to toggle task: ${response.statusText}`);
        }
        loadTasks();
    })
    .catch(error => console.error(error));
}

window.onload = loadTasks;