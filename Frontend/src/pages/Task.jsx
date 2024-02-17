import React, { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import { getAllTask } from "../services/task";
import { toast } from "react-toastify";
import { Link } from "react-router-dom";

export function Task() {
    const [items, setItems] = useState([]);
    const [error, setError] = useState(null);

    const loadAllTask = async () => {
        try {
            const result = await getAllTask();
            if (result.status === 'success') {
                console.log(result.data);
                setItems(result.data);
            } else {
                setError(result.error);
            }
        } catch (error) {
            setError('An error occurred while fetching tasks.');
        }
    };

    useEffect(() => {
        loadAllTask();
    }, []);

    return (
        <>
            <Navbar />
            <center>
                <div className="container">
                    <h1 className="title"> All Tasks</h1>

                    {error ? (
                        <p>Error: {error.message}</p>
                    ) : (
                        <table style={{ width: "100%" }}>
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
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                {items.map(item => (
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
                                        <td>
                                            <Link to={`/edit/${item.taskId}`}>
                                                Edit
                                            </Link>
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    )}

                    <Link to="/addtask">Add Task here</Link>
                </div>
            </center>
        </>
    );
}

export default Task;
