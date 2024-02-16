import Navbar from "../components/Navbar";
import { getAllProject } from "../services/project";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { Link, useNavigate } from 'react-router-dom';

export function Project() {
    
    const [items , setItems]=useState([])

    const loadAllProjects=async ()=>{
        const result = await getAllProject()
        if(result['status']== 'success'){

            console.log(result.data);
            
            setItems(result.data)
        } else{
            toast.error(result['error'])
        }
    }
    useEffect(() => {loadAllProjects()} , [])

    return (
        <>
            <Navbar />
           <center>
           <div className="container">
                <h1 className="title">All Projects</h1>

                <table style={{width:"100%"}}>
                <div className="table-responsive">
                    <table className="table table-bordered myclass"
                            style={{textAlign: "center"}}>
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
                        {
                            items.map(item=>{
                                return (
                                <tr>
                                <td>{item.projectId}</td>
                                <td>{item.title}</td>
                                <td>{item.startDate}</td>
                                <td>{item.endDate}</td>
                                <td><Link to='/edit'>Edit</Link></td>
                                </tr>)
                            })
                        }
                        </tbody>
                        </table>
                        {/* <button className="btn btn-primary mt-2"> 
                       Add Project */}
                       <Link to='/addproject'>Add Project here</Link>
                       {/* </button> */}
                       
                </div>
                </table>

            </div>
           </center>

        </>
    )
}
export default Project;