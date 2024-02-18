import Navbar from "../components/Navbar";
import { getAllProject, deleteProject } from "../services/project"; // Importing deleteProject function
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { Link } from 'react-router-dom';

export function Project() {
    const [projects, setProjects] = useState([]);

    const loadAllProjects = async () => {
        try {
            const result = await getAllProject();
            setProjects(result.data);
        } catch (error) {
            toast.error("Failed to load projects");
        }
    };

    useEffect(() => {
        loadAllProjects();
    }, []);

    const handleDelete = async (projectId) => {
        try {
            await deleteProject(projectId);
            // After successful deletion, update state or reload projects
            setProjects(projects.filter(project => project.projectId !== projectId));
            toast.success("Project deleted successfully");
        } catch (error) {
            toast.error("Failed to delete project");
        }
    };
    

    return (
        <>
            <Navbar />
            <center>
                <div className="container">
                    <h1 className="title">All Projects</h1>
                    <table className="table table-bordered myclass" style={{ textAlign: "center" }}>
                        <thead>
                            <tr>
                                <th>Project Id</th>
                                <th>Title</th>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th colSpan={2}>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            {projects.map(project => (
                                <tr key={project.projectId}>
                                    <td>{project.projectId}</td>
                                    <td>{project.title}</td>
                                    <td>{project.startDate}</td>
                                    <td>{project.endDate}</td>
                                    <td><Link to={`/edit/${project.projectId}`}>Edit</Link></td>
                                    <td>
                                        <button onClick={() => handleDelete(project.projectId)} className="btn btn-primary mt-2">Delete</button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                    <Link to='/addproject'>Add Project here</Link>
                </div>
            </center>
        </>
    );
}

export default Project;
