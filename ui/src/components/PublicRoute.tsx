import React from 'react';
import { Route, Navigate } from 'react-router-dom';

const PublicRoute: React.FC<{ element: JSX.Element }> = ({ element }) => {
    const isAuthenticated = !!localStorage.getItem('accessToken'); // Check if user is authenticated

    return !isAuthenticated ? element : <Navigate to="/dashboard" />;
};

export default PublicRoute;
