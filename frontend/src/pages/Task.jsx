import { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import { getAllTask } from "../services/task";
import { toast } from "react-toastify";
import { Link, useNavigate } from "react-router-dom";


export function Task() {
    const [items , setItems]=useState([])

    const loadAllTask=async ()=>{
        const result = await getAllTask()
        if(result['status']== 'success'){

            console.log(result.data);
            
            setItems(result.data)
        } else{
            toast.error(result['error'])
        }
    }
    useEffect(() => {loadAllTask()} , [])

    return (
        <>
            <Navbar />
            <center>
            <div className="container">
                <h1 className="title"> All Tasks</h1>

                <table style={{width:"100%"}}>
                <div className="table-responsive">
                    <table className="table table-bordered myclass"
                            style={{textAlign: "center"}}>
                        <thead>
                           <tr>
                            <th>TaskId</th>
                            <th>UserId</th>
                            <th>Task Description</th>
                            <th>Start Date</th>
                            <th>End Date</th>
                            <th>Work Hours</th>
                            <th>Status</th>
                            <th>Project Id</th>
                            <th>Percentage</th>
                            <th>Action</th>
                           </tr>
                        </thead>
                        <tbody>
                        {
                            items.map(item=>{
                                return (
                                <tr key={Task.taskId}>
                                <td>{item.taskId}</td>
                                <td>{item.userId}</td>
                                <td>{item.taskDescription}</td>
                                <td>{item.startDate}</td>
                                <td>{item.endDate}</td>
                                <td>{item.workHours}</td>
                                <td>{item.status}</td>
                                <td>{item.projectId}</td>
                                <td>{item.percentage}</td>
                                <td><Link to='/edit'>Edit</Link></td>
                                </tr>)
                            })
                        }
                        </tbody>
                        </table>
                        
                       {/* <button className="btn btn-primary mt-2"> 
                       Add Task */}
                       <Link to='/addtask'>Add Task here</Link>
                       {/* </button> */}
                      
                </div>
                </table>

            </div>
            </center>

        </> )
        }

export default Task;


