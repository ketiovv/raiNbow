import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const Logout: React.FC = () => {
    const navigate = useNavigate();

    useEffect(() => {
        // Clear the token from localStorage
        localStorage.removeItem('accessToken');
        // Redirect to login page or another public page
        navigate('/login');
    }, [navigate]);

    return <div>Logging out...</div>; // Optional loading state or message
};

export default Logout;