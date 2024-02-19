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
      const result = await updateEmployee(
        id,
        employee.firstName,
        employee.lastName,
        employee.hireDate,
        employee.designationId,
        employee.hourlyRate,
        employee.deptId,
        employee.managerId,
        employee.userId
      );

      if (result.status === 'success') {
        toast.success("Employee updated successfully");
        navigate('/employee'); // Navigate to the employee details page
      } else {
        toast.error(result.error);
      }
    } catch (error) {
      toast.error("Failed to update employee");
    }
  };

  return (
    <div className="container mt-4">
      <h1>Edit Employee</h1>
      <form>
        <div className="mb-3">
          <label className="form-label">First Name:</label>
          <input
            type="text"
            className="form-control col-4"
            name="firstName"
            value={employee.firstName}
            onChange={handleInputChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Last Name:</label>
          <input
            type="text"
            className="form-control col-4"
            name="lastName"
            value={employee.lastName}
            onChange={handleInputChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Hire Date:</label>
          <input
            type="date"
            className="form-control col-4"
            name="hireDate"
            value={employee.hireDate}
            onChange={handleInputChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Designation ID:</label>
          <input
            type="text"
            className="form-control col-4"
            name="designationId"
            value={employee.designationId}
            onChange={handleInputChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Hourly Rate:</label>
          <input
            type="text"
            className="form-control col-4"
            name="hourlyRate"
            value={employee.hourlyRate}
            onChange={handleInputChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Department ID:</label>
          <input
            type="text"
            className="form-control col-4"
            name="deptId"
            value={employee.deptId}
            onChange={handleInputChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Manager ID:</label>
          <input
            type="text"
            className="form-control col-4"
            name="managerId"
            value={employee.managerId}
            onChange={handleInputChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">User ID:</label>
          <input
            type="text"
            className="form-control col-4"
            name="userId"
            value={employee.userId}
            onChange={handleInputChange}
          />
        </div>
        <button
          type="button"
          className="btn btn-primary"
          onClick={handleUpdateEmployee}
        >
          Update
        </button>
      </form>
    </div>
  );
}

export default EditEmp;
