import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom"; // Import useNavigate
import { getTask, updateTask } from "../services/task";
import { toast } from "react-toastify";

function EditTask() {
    const [task, setTask] = useState({
        taskId: "",
        userId: "",
        taskDescription: "",
        startDate: "",
        endDate: "",
        status: "",
        projectId: ""
    });
    const { id } = useParams();
    const navigate = useNavigate(); // Define navigate function

    useEffect(() => {
        const fetchTask = async () => {
            try {
                const result = await getTask(id);
                if (result.status === 'success') {
                    setTask(result.data);
                } else {
                    toast.error(result.error);
                }
            } catch (error) {
                console.error("Error fetching task:", error);
                toast.error("Failed to fetch task");
            }
        };

        fetchTask();
    }, [id]);

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        if (name === 'startDate' || name === 'endDate') {
            const formattedDate = new Date(value).toISOString().split('T')[0];
            setTask(prevTask => ({
                ...prevTask,
                [name]: formattedDate
            }));
        } else {
            setTask(prevTask => ({
                ...prevTask,
                [name]: value
            }));
        }
    };

    const handleUpdateTask = async () => {
        try {
            const result = await updateTask(id, task.userId, task.taskDescription, task.startDate, task.endDate, task.status, task.projectId);
            if (result.status === 'success') {
                toast.success("Task updated successfully");
                navigate('/task');
            } else {
                toast.error(result.error);
            }
        } catch (error) {
            toast.error("Failed to update task");
        }
    };

    return (
        <div>
            <h1>Edit Task</h1>
            <form>
                <label>User ID:</label>
                <input type="text" name="userId" value={task.userId} onChange={handleInputChange} /><br />
                <label>Task Description:</label>
                <input type="text" name="taskDescription" value={task.taskDescription} onChange={handleInputChange} /><br />
                <label>Start Date:</label>
                <input type="date" name="startDate" value={task.startDate} onChange={handleInputChange} /><br />
                <label>End Date:</label>
                <input type="date" name="endDate" value={task.endDate} onChange={handleInputChange} /><br />
                <label>Status:</label>
                <input type="text" name="status" value={task.status} onChange={handleInputChange} /><br />
                <label>Project ID:</label>
                <input type="text" name="projectId" value={task.projectId} onChange={handleInputChange} /><br />
                <button type="button" onClick={handleUpdateTask}>Update</button>
            </form>
        </div>
    );
}

export default EditTask;