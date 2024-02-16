import { useState } from 'react';
import { toast } from 'react-toastify';
import { addTask } from '../services/task';
import { useNavigate } from "react-router-dom";

export function AddTask() {
    const [userId, setUserId] = useState('');
    const [taskDescription, setTaskDescription] = useState('');
    const [startDate, setStartDate] = useState(new Date());
    const [endDate, setEndDate] = useState(new Date());
    const [projectId, setProjectId] = useState('');
    const [Status, setStatus] = useState('Pending');
    const navigate = useNavigate();

    const onAddTask = async () => {
        if (userId.length === 0) {
            toast.warn('Please enter a user ID');
        } else if (taskDescription.length === 0) {
            toast.warn('Please enter a task description');
        } else if (!startDate || !endDate) {
            toast.warn('Please select both start and end dates')
        } else if (startDate === endDate) { 
            toast.warn('Start date cannot be equal to end date')
        } else if (Status.length === 0) {
            toast.warn('Please select a status');
        } else if (projectId.length === 0) {
            toast.warn('Please enter a project ID');
        } else {
            const result = await addTask(userId, taskDescription, startDate, endDate, Status, projectId);
            if (result.status === 'success') {
                toast.success('Successfully added task');
                navigate('/task');
            } else {
                toast.error(result.error);
            }
        }
    };

    return (
        <>
            <h1 className="title">Add Task</h1>
            <div className="row">
                <div className="col"></div>
                <div className="col">
                    <div className="form">
                        <div className="mb-3">
                            <label htmlFor="">User Id</label>
                            <input onChange={e => setUserId(e.target.value)} type="number" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">Project Id</label>
                            <input onChange={e => setProjectId(e.target.value)} type="number" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">Task Description</label>
                            <input onChange={e => setTaskDescription(e.target.value)} type="text" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">Start Date</label>
                            <input onChange={e => setStartDate(e.target.value)} type="date" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">End Date</label>
                            <input onChange={e => setEndDate(e.target.value)} type="date" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">Status</label>
                            <select value={Status} onChange={e => setStatus(e.target.value)} className="form-control">
                                <option value="Pending">Pending</option>
                                <option value="Completed">Completed</option>
                                <option value="In Progress">In Progress</option>
                            </select>
                        </div>
                        <div className="mb-3">
                            <button onClick={onAddTask} className="btn btn-primary mt-2">
                                Add Task
                            </button>
                        </div>
                    </div>
                </div>
                <div className="col"></div>
            </div>
        </>
    )
}

export default AddTask;
