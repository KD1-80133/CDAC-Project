import { useState } from 'react';
import { toast } from 'react-toastify';
import { AddEmployee } from '../services/employee';
import { Link, useNavigate } from "react-router-dom";

export function AddEmp() {
    const [employee, setemployee] = useState({ firstName: "", lastName: "", hireDate: "", designationId: "", isResigned: "", hourlyRate: "", deptId: "", managerId: "", userId: "" })
    const [firstName, setfirstName] = useState('');
    const [lastName, setlastName] = useState('');
    const [hireDate, sethireDate] = useState('');
    const [designationId, setdesignationId] = useState('');
    //const [isResigned, setisResigned] = useState('');
    const [deptId, setdeptId] = useState('');
    const [managerId, setmanagerId] = useState('');
    const [userId, setuserId] = useState('');
    const [hourlyRate, sethourlyRate] = useState('');

    const navigate = useNavigate();

    const onAddEmployee = async () => {
        if (firstName.length === 0) {
            toast.warn('Please enter a First Name');
        } else if (lastName.length === 0) {
            toast.warn('Please enter a last Name');
        } else if (hireDate.length === 0) {
            toast.warn('Please enter the hire date')
        } else if (designationId.length === 0) { 
            toast.warn('Enter the designation Id')
        } else if (hourlyRate.length === 0) {
            toast.warn('Please enter hourly rate');
        } else if (deptId.length === 0) {
            toast.warn('Please enter a department ID');
        } else if (managerId.length === 0) {
            toast.warn('Please enter a manager ID');
        } else if (userId.length === 0) {
            toast.warn('Please enter a user ID');
        }else {
            const result = await AddEmployee(firstName, lastName, hireDate, designationId, hourlyRate, deptId, managerId, userId)
            if (result.status === 'success') {
            toast.success('Successfully registered the user')
            navigate('/employee')
        } else {
            toast.error(result.error)
        }
        }
    };

   

    return (
        <>
            <h1 className="title">Add Employee</h1>
            <div className="row">
                <div className="col"></div>
                <div className="col">
                    <div className="form">
                        
                        <div className="mb-3">
                            <label htmlFor="">FirstName</label>
                            <input onChange={e => setfirstName(e.target.value)} type="text" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">LastName</label>
                            <input onChange={e => setlastName(e.target.value)} type="text" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">HireDate</label>
                            <input onChange={e => sethireDate(e.target.value)} type="date" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">DesignatonId</label>
                            <input onChange={e => setdesignationId(e.target.value)} type="number" className="form-control" />
                        </div>

                        <div className="mb-3">
                            <label htmlFor="">HourlyRate</label>
                            <input onChange={e => sethourlyRate(e.target.value)} type="number" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">DeptId</label>
                            <input onChange={e => setdeptId(e.target.value)} type="number" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">ManagerId</label>
                            <input onChange={e => setmanagerId(e.target.value)} type="number" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">userId</label>
                            <input onChange={e => setuserId(e.target.value)} type="number" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <button onClick={onAddEmployee} className="btn btn-primary mt-2">
                                Add
                            </button>
                        </div>
                        </div>
                    </div>
                </div>
                
                <div className="col"></div>
                
        </>
    )
}

export default AddEmp;
