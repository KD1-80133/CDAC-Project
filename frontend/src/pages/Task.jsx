import { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import { getAllTask } from "../services/task";
import { toast } from "react-toastify";
import { Link } from "react-router-dom";
import { deleteTask } from "../services/task";

export function Task() {
    const [tasks , setTasks] = useState([]);

    const loadAllTask = async () => {
        try {
            const result = await getAllTask();
            if (result.status === 'success') {
                setTasks(result.data);
            } else {
                toast.error(result.error);
            }
        } catch (error) {
            toast.error("Failed to fetch tasks");
        }
    };

    useEffect(() => {
        loadAllTask();
    }, []);

    const handleDelete = async (taskId) => {
        try {
            await deleteTask(taskId);
            setTasks(tasks.filter(task => task.taskId !== taskId));
            toast.success("Task deleted successfully");
        } catch (error) {
            toast.error("Failed to delete task");
        }
    };

    return (
        <>
            <Navbar />
            <center>
                <div className="container">
                    <h1 className="title"> All Tasks</h1>

                    <table style={{ width: "100%" }}>
                        <div className="table-responsive">
                            <table className="table table-bordered myclass" style={{ textAlign: "center" }}>
                                <thead>
                                    <tr>
                                        <th>TaskId</th>
                                        <th>UserId</th>
                                        <th>Task Description</th>
                                        <th>Start Date</th>
                                        <th>End Date</th>
                                        <th>Work Hours</th>
                                        <th>Status</th>
                                        <th>Project Id</th>
                                        <th>Percentage</th>
                                        <th colSpan={2}>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {tasks.map(item => (
                                        <tr key={item.taskId}>
                                            <td>{item.taskId}</td>
                                            <td>{item.userId}</td>
                                            <td>{item.taskDescription}</td>
                                            <td>{item.startDate}</td>
                                            <td>{item.endDate}</td>
                                            <td>{item.workHours}</td>
                                            <td>{item.status}</td>
                                            <td>{item.projectId}</td>
                                            <td>{item.percentage}</td>
                                            <td><Link to={`/edit/${item.taskId}`}>Edit</Link></td>
                                            <td>
                                                <button onClick={() => handleDelete(item.taskId)} className="btn btn-primary mt-2">Delete</button>
                                            </td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>

                            <Link to='/addtask'>Add Task here</Link>
                        </div>
                    </table>
                </div>
            </center>
        </>
    );
}

export default Task;
