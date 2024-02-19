import React, { useState, useEffect } from "react";
import Navbar from "../components/Navbar";
import { getAllProject, deleteProject } from "../services/project";
import { toast } from "react-toastify";
import { Link, useNavigate } from "react-router-dom";

import "./Project.css";

export function Project() {
  const [projects, setProjects] = useState([]);
  const navigate = useNavigate();

  const loadAllProjects = async () => {
    try {
      const result = await getAllProject();
      if (result["status"] === "success") {
        console.log(result.data);
        setProjects(result.data);
      } else {
        toast.error(result["error"]);
      }
    } catch (error) {
      console.error("Error loading projects:", error);
      toast.error("Failed to load projects");
    }
  };

  useEffect(() => {
    loadAllProjects();
  }, []);

  const handleDelete = async (projectId) => {
    try {
      await deleteProject(projectId);
      setProjects(projects.filter((project) => project.projectId !== projectId));
      toast.success("Project deleted successfully");
    } catch (error) {
      console.error("Error deleting project:", error);
      toast.error("Failed to delete project");
    }
  };

  return (
    <>
      <Navbar />
      <center>
        <div className="container">
          <h1 className="title">All Projects</h1>
          <table style={{ width: "100%" }}>
            <div className="table-responsive">
              <table className="table table-bordered myclass" style={{ textAlign: "center" }}>
                <thead>
                  <tr>
                    <th>Project Id</th>
                    <th>Title</th>
                    <th>Start Date</th>
                    <th>End Date</th>
                    <th>Action</th>
                  </tr>
                </thead>
                <tbody>
                  {projects.map((item) => (
                    <tr key={item.projectId}>
                      <td>{item.projectId}</td>
                      <td>{item.title}</td>
                      <td>{item.startDate}</td>
                      <td>{item.endDate}</td>
                      <td>
                        <button className="btn btn-primary mt-2" onClick={() => navigate(`/edit/${item.projectId}`)}>
                          Edit
                        </button>
                      </td>
                      <td>
                        <button onClick={() => handleDelete(item.projectId)} className="btn btn-primary mt-2">
                          Delete
                        </button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
              <Link to="/addproject" className="add-project-link">
                <button className="add-project-button">Add Project here</button>
              </Link>
            </div>
          </table>
        </div>
      </center>
    </>
  );
}

export default Project;
