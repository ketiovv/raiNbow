import React from 'react';
import { Link } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import './Sidebar.module.scss'; 

const Sidebar: React.FC = () => {
    const { isAuthenticated } = useAuth();

    if (!isAuthenticated) {
        return null; // Do not render Sidebar if not authenticated
    }

    return (
        <div className="sidebar">
            <h2>Menu</h2>
            <ul>
                <li><Link to="/dashboard">Dashboard</Link></li>
                <li><Link to="/schemas">Schemas</Link></li>
                <li><Link to="/logout">Logout</Link></li>
                {/* Add more links as needed */}
            </ul>
        </div>
    );
};

export default Sidebar;
