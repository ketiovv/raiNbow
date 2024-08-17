import React, { ReactNode } from 'react';
import { Navigate } from 'react-router-dom';

interface PrivateRouteProps {
    children: ReactNode;
}

const PrivateRoute: React.FC<PrivateRouteProps> = ({ children }) => {
    const token = localStorage.getItem('token');

    return token ? <>{children}</> : <Navigate to="/login" />;
};

export default PrivateRoute;
