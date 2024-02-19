// Home.js
import React from 'react';
import Navbar from "../components/Navbar";
import './Signin.css'; // Import your CSS file for styling

const Home = () => {
  return (
    <>
      <Navbar />

      {/* Home Container */}
      <div className="container mt-4">
        <div className="row">
          {/* Image column */}
          <div className="col-md-8">
            <img src="Login12.jpg" alt="Login" className="img-fluid rounded" />
          </div>

          {/* Welcome Section */}
          <div className="col-md-4 welcome-section">
            <h1 className="title">Welcome to the Employee Task Management System</h1>
            <div className="card">
              <div className="card-body">
                <p className="welcome-text">Empower your team to achieve greater efficiency and collaboration in managing tasks, projects, and designations with our Employee Task Management System.</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Home;
