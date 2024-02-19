import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { toast } from 'react-toastify';
import { getAllEmployee, deleteEmployee } from "../services/employee";
import { Link } from "react-router-dom";
import Navbar from "../components/Navbar";

function Employee() {
  const navigate = useNavigate();
  const [employees, setEmployees] = useState([]);
  

  const loadAllEmployees = async () => {
    try {
      const result = await getAllEmployee();
      setEmployees(result.data);
    } catch (error) {
      toast.error("Failed to load employees");
    }
  };



  useEffect(() => {
    loadAllEmployees();
  }, []);

  const handleDelete = async (empId) => {
    try {
      await deleteEmployee(empId);
      setEmployees(employees.filter((employee) => employee.empId !== empId));
      toast.success("Employee deleted successfully");
    } catch (error) {
      toast.error("Failed to delete employee");
    }
  };



  return (
    <>
      <Navbar />
      <div className="container">
        <h1 className="title">Employee List</h1>
      </div>
      <table style={{ width: "100%" }}>
        <div className="table-responsive">
          <table className="table table-bordered myclass" style={{ textAlign: "center" }}>
            <thead>
              <tr>
                <th>EmpId</th>
                <th>FirstName</th>
                <th>LastName</th>
                <th>HireDate</th>
                <th>DesignationId</th>
                <th>DeptId</th>
                <th>ManagerId</th>
                <th>UserId</th>
                <th>HourlyRate</th>
                <th>Edit</th>
                <th>Delete</th>
                
              </tr>
            </thead>
            <tbody>
              {employees.map((employee) => (
                <tr key={employee.empId}>
                  <td>{employee.empId}</td>
                  <td>{employee.firstName}</td>
                  <td>{employee.lastName}</td>
                  <td>{employee.hireDate}</td>
                  <td>{employee.designationId}</td>
                  <td>{employee.deptId}</td>
                  <td>{employee.managerId}</td>
                  <td>{employee.userId}</td>
                  <td>{employee.hourlyRate}</td>
                  <td>
                    <Link to={`/editemp/${employee.empId}`}>
                      <button className="btn btn-primary mt-2">Edit</button>
                    </Link>
                  </td>
                  <td>
                    <button
                      className="btn btn-danger"
                      onClick={() => handleDelete(employee.empId)}
                    >
                      Delete
                    </button>
                  </td>
                
                  
                </tr>
              ))}
            </tbody>
          </table>
          <div className="container">
            <Link to="/addemp">
              <button className="btn btn-primary">Add Employee</button>
            </Link>
          </div>
        </div>
      </table>
    </>
  );
}

export default Employee;
