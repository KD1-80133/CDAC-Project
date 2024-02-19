import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getProject, updateProject } from "../services/project";
import { toast } from "react-toastify";
import "./EditProj.css"; // Import your CSS file

function EditProj() {
  const [project, setProject] = useState({
    projId: "",
    title: "",
    startDate: "",
    endDate: ""
  });

  const { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchProject = async () => {
      try {
        const result = await getProject(id);
        if (result.status === "success") {
          setProject(result.data);
        } else {
          toast.error(result.error);
        }
      } catch (error) {
        console.error("Error fetching project:", error);
        toast.error("Failed to fetch project");
      }
    };

    fetchProject();
  }, [id]);

  const formatDate = (value) => {
    return new Date(value).toISOString().split("T")[0];
  };

  const handleInputChange = ({ target: { name, value } }) => {
    setProject((prevProj) => ({
      ...prevProj,
      [name]: name === "startDate" || name === "endDate" ? formatDate(value) : value
    }));
  };

  const handleUpdateProject = async () => {
    try {
      const result = await updateProject(id, project.title, project.startDate, project.endDate);
      if (result.status === "success") {
        toast.success("Project updated successfully");
        navigate("/project"); // Navigate to project details page
      } else {
        toast.error(result.error);
      }
    } catch (error) {
      toast.error("Failed to update project");
    }
  };

  return (
    <div className="edit-project-container">
      <h1>Edit Project</h1>
      <form>
        <label>Title:</label>
        <input type="text" name="title" value={project.title} onChange={handleInputChange} /><br />
        <label>Start Date:</label>
        <input type="date" name="startDate" value={project.startDate} onChange={handleInputChange} /><br />
        <label>End Date:</label>
        <input type="date" name="endDate" value={project.endDate} onChange={handleInputChange} /><br />
        <button type="button" onClick={handleUpdateProject}>Update</button>
      </form>
    </div>
  );
}

export default EditProj;
