import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getEmployee, updateEmployee } from "../services/employee";
import { toast } from "react-toastify";

function EditEmp() {
    const [employee, setEmployee] = useState({
        empId: "",
        firstName: "",
        lastName: "",
        hireDate: "",
        designationId: "",
        isResigned: "",
        hourlyRate: "",
        deptId: "",
        managerId: "",
        userId: ""
    });
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const fetchEmployee = async () => {
            try {
                const result = await getEmployee(id);
                if (result.status === 'success') {
                    setEmployee(result.data);
                } else {
                    toast.error(result.error);
                }
            } catch (error) {
                console.error("Error fetching employee:", error);
                toast.error("Failed to fetch employee");
            }
        };

        fetchEmployee();
    }, [id]);

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        if (name === 'hireDate') {
            // Format the date before setting it in the state
            const formattedDate = new Date(value).toISOString().split('T')[0];
            setEmployee(prevEmployee => ({
                ...prevEmployee,
                [name]: formattedDate
            }));
        } else {
            setEmployee(prevEmployee => ({
                ...prevEmployee,
                [name]: value
            }));
        }
    };
    const handleUpdateEmployee = async () => {
        try {
            const result = await updateEmployee(id, employee.firstName, employee.lastName, employee.hireDate, employee.designationId, employee.hourlyRate, employee.deptId, employee.managerId, employee.userId);
            if (result.status === 'success') {
                toast.success("Employee updated successfully");
                navigate('/employee'); // Navigate to employee details page
            } else {
                toast.error(result.error);
            }
        } catch (error) {
            toast.error("Failed to update employee");
        }
    };

    return (
        <div>
            <h1>Edit Employee</h1>
            <form>
                <label>First Name:</label>
                <input type="text" name="firstName" value={employee.firstName} onChange={handleInputChange} />
                <label>Last Name:</label>
                <input type="text" name="lastName" value={employee.lastName} onChange={handleInputChange} />
                <label>Hire Date:</label>
                <input type="date" name="hireDate" value={employee.hireDate} onChange={handleInputChange} />
                <label>Designation ID:</label>
                <input type="text" name="designationId" value={employee.designationId} onChange={handleInputChange} />
                <label>Hourly Rate:</label>
                <input type="text" name="hourlyRate" value={employee.hourlyRate} onChange={handleInputChange} />
                <label>Department ID:</label>
                <input type="text" name="deptId" value={employee.deptId} onChange={handleInputChange} />
                <label>Manager ID:</label>
                <input type="text" name="managerId" value={employee.managerId} onChange={handleInputChange} />
                <label>User ID:</label>
                <input type="text" name="userId" value={employee.userId} onChange={handleInputChange} />
                <button type="button" onClick={handleUpdateEmployee}>Update</button>
            </form>
        </div>
    );
}

export default EditEmp;
