import { useState } from "react";
import Navbar from "../components/Navbar";
import { toast } from "react-toastify";

export function Home() {
    
    return (
        <>
            <Navbar />
            <div className="container">
                <h1 className="title">Home</h1>

            </div>

        </>
    )
}
export default Home;