import React, { useState, useEffect } from 'react';

export const TaskForm = ({ onTaskSubmit, onTaskUpdate, taskToEdit, onCancelEdit }) => {
  const defaultFormState = { titulo: '', descripcion: '', idEstado: 1, idUsuario: 1 };
  const [formData, setFormData] = useState(defaultFormState);

  useEffect(() => {

    if (taskToEdit) 
    {
      const status = 
      { 
        "Pendiente": 1,
        "En progreso": 2,
        "Completada": 3 
      };
      setFormData({
        titulo: taskToEdit.titulo,
        descripcion: taskToEdit.descripcion,
        idEstado: status[taskToEdit.estadoNombre] || 1,
        idUsuario: 1
      });
    } 
    else 
    {
      setFormData(defaultFormState);
    }
  }, [taskToEdit]);

  const handleChange = (e) => {

    const { name, value } = e.target;

    setFormData({
      ...formData,
      [name]: (name == "idEstado" || name == "idUsuario") ? parseInt(value) : value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (taskToEdit) 
    {
      onTaskUpdate(parseInt(taskToEdit.id), formData); 
    } 
    else 
    {
      onTaskSubmit(formData);
    }
    setFormData(defaultFormState);
  };

  return (
    <div className="task-form-wrapper">
      <h2>{taskToEdit ? '📝 Editando Tarea' : '➕ Nueva Tarea'}</h2>
      <form onSubmit={handleSubmit} className="main-form">
        <input name="titulo" placeholder="Título" value={formData.titulo} onChange={handleChange} required />
        <textarea name="descripcion" placeholder="Descripción" value={formData.descripcion} onChange={handleChange} />
        <div className="select-group">
          <label>Cambiar Estado:</label>
          <select name="idEstado" value={formData.idEstado} onChange={handleChange}>
            <option value="1">Pendiente</option>
            <option value="2">En progreso</option>
            <option value="3">Completada</option>
          </select>
        </div>
        <div className="form-buttons">
          <button type="submit" className="btn-submit">
            {taskToEdit ? 'Guardar Cambios' : 'Crear Tarea'}
          </button>
          {taskToEdit && <button type="button" onClick={onCancelEdit} className="btn-cancel">Cancelar</button>}
        </div>
      </form>
    </div>
  );
};