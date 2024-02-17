import { useState } from 'react';
import { toast } from 'react-toastify';
import { addProject } from '../services/project';
import { Link, useNavigate } from "react-router-dom";

export function AddProject() {
    const [title, setTitle] = useState('');
    const [startDate, setStartDate] = useState(new Date());
    const [endDate, setEndDate] = useState(new Date());
    
    const navigate = useNavigate();

    const onAddProject = async () => {
        if (title.length === 0) {
            toast.warn('Please enter title');
        }  else if (!startDate || !endDate) {
            toast.warn('Please select both start and end dates')
        } else if (startDate === endDate) { 
            toast.warn('Start date cannot be equal to end date')
        }else {
            const result = await addProject( title, startDate, endDate);
            if (result.status === 'success') {
                toast.success('Successfully added project');
                navigate('/project');
            } else {
                toast.error(result.error);
            }
        }
    };

    return (
        <>
            <h1 className="title">Add Project</h1>
            <div className="row">
                <div className="col"></div>
                <div className="col">
                    <div className="form">
                        
                        <div className="mb-3">
                            <label htmlFor="">Task Description</label>
                            <input onChange={e => setTitle(e.target.value)} type="text" className="form-control" />
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
                            <button onClick={onAddProject} className="btn btn-primary mt-2">
                                Add Project
                            </button>
                        </div>
                    </div>
                </div>
                <div className="col"></div>
            </div>
        </>
    )
}

export default AddProject;
