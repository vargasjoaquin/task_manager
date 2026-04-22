import React, { useState } from 'react';
import { useTasks } from './hooks/useTasks';
import { TaskForm } from './components/TaskForm';
import './App.css';

function App() {
  const { taskList, loadingData, apiError, tasksList, createTask, updateTask, deleteTask } = useTasks();
  const [taskBeingEdited, setTaskBeingEdited] = useState(null);
  const [activeFilter, setActiveFilter] = useState("");

  const handleFilterSelection = (statusName) => {
    setActiveFilter(statusName);
    tasksList(statusName);
  };

  const startEditing = (task) => {
    setTaskBeingEdited(task);
    window.scrollTo({ top: 0, behavior: 'smooth' });
  };

  return (
    <div className="app-container">
      <header><h1>Gestor de tareas</h1></header>
      <main>
        <TaskForm 
          onTaskSubmit={createTask}
          onTaskUpdate={(id, data) => { updateTask(id, data); setTaskBeingEdited(null); }}
          taskToEdit={taskBeingEdited}
          onCancelEdit={() => setTaskBeingEdited(null)}
        />
        <div className="list-header">
          <h3>Mis Tareas</h3>
          <div className="filter-buttons">
            <button className={activeFilter === "" ? "active" : ""} onClick={() => handleFilterSelection("")}>Todas</button>
            <button className={activeFilter === "Pendiente" ? "active" : ""} onClick={() => handleFilterSelection("Pendiente")}>Pendientes</button>
            <button className={activeFilter === "En progreso" ? "active" : ""} onClick={() => handleFilterSelection("En progreso")}>En progreso</button>
            <button className={activeFilter === "Completada" ? "active" : ""} onClick={() => handleFilterSelection("Completada")}>Completadas</button>
          </div>
        </div>
        {loadingData && <div className="status-message">⏳ Actualizando...</div>}
        {apiError && <div className="error-box">⚠️ Error: {apiError}</div>}
        <div className="task-grid">
          {taskList.length == 0 && !loadingData && <p className="empty-msg">No hay tareas.</p>}
          {taskList.map(task => (
            <div key={task.id} className="task-item">
              <div className="task-body">
                {}
                <span className={`badge ${task.estadoNombre ? task.estadoNombre.toLowerCase().replace(" ", "") : ""}`}>
                  {task.estadoNombre}
                </span>
                <h4>{task.titulo}</h4>
                <p>{task.descripcion}</p>
                <small>Creado el: {new Date(task.fechaCreacion).toLocaleDateString()}</small>
              </div>
              <div className="task-footer">
                <button className="edit-link" onClick={() => startEditing(task)}>Editar</button>
                <button className="delete-link" onClick={() => deleteTask(parseInt(task.id))}>Eliminar</button>
              </div>
            </div>
          ))}
        </div>
      </main>
    </div>
  );
}

export default App;