import { useState, useEffect, useCallback } from 'react';

//const TASK_API_URL = '';

export const useTasks = () => {
  const [taskList, setTaskList] = useState([]);
  const [loadingData, setLoadingData] = useState(false);
  const [apiError, setApiError] = useState(null);

  const tasksList = useCallback(async (statusName = "") => {
    setLoadingData(true);
    setApiError(null);
    
    try 
    {
      const statusQuery = statusName ? `?status=${statusName}` : "";
      const finalUrl = `${TASK_API_URL}${statusQuery}`;
      
      const response = await fetch(finalUrl);

      if (!response.ok) 
        throw new Error("No se pudo conectar a la API");
      
      const data = await response.json();
      setTaskList(data);
    } 
    catch (err) 
    {
      setApiError(err.message);
    } 
    finally 
    {
      setLoadingData(false);
    }
  }, []);

  const createTask = async (taskPayload) => {
    try {
      const response = await fetch(TASK_API_URL, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(taskPayload),
      });

      if (response.ok) 
        tasksList(); 
    } 
    catch (err) 
    {
      console.error("Error al crear una tarea:", err);
    }
  };

  const updateTask = async (taskId, taskPayload) => {
    try{
        const response = await fetch(`${TASK_API_URL}/${taskId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(taskPayload),
      });

      if (response.ok) 
        tasksList();
    }
    catch{
        console.error("Error al actualizar la tarea:", err);
    }
  };

  const deleteTask = async (taskId) => {
    try {
      const response = await fetch(`${TASK_API_URL}/${taskId}`, { method: 'DELETE' });

      if (response.ok) 
        tasksList();
    } 
    catch (err) 
    {
      console.error("Error al borrar una tarea:", err);
    }
  };

  useEffect(() => {
    tasksList();
  }, [tasksList]);

  return { 
    taskList, 
    loadingData, 
    apiError, 
    tasksList, 
    createTask,
    updateTask, 
    deleteTask 
  };
};