import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Sidebar from './components/Sidebar';
import Dashboard from './components/Dashboard';
import Schemas from './components/SchemasOverview';
import Login from './components/Login';
import Logout from './components/Logout';
import PrivateRoute from './components/PrivateRoute';
import PublicRoute from './components/PublicRoute';
import {AuthProvider} from "./context/AuthContext";
import SchemaDetails from "./components/SchemaDetails";
import AddSchema from "./components/AddSchema";
import './styles/global.scss';

const App: React.FC = () => {
    return (
       <AuthProvider>
           <Router>
               <div className="app-container">
                   <Sidebar /> {/* Always render sidebar */}
                   <div className="content">
                       <Routes>
                           <Route path="/login" element={<PublicRoute element={<Login />} />} />
                           <Route path="/" element={<PublicRoute element={<Login />} />} />
                           <Route path="/dashboard" element={<PrivateRoute element={<Dashboard />} />} />
                           <Route path="/schemas" element={<PrivateRoute element={<Schemas />} />} />
                           <Route path="/schemas/:id" element={<PrivateRoute element={<SchemaDetails />} />} />
                           <Route path="/schemas/add" element={<PrivateRoute element={<AddSchema />} />} />
                           <Route path="/logout" element={<Logout />} />
                           <Route path="*" element={<Navigate to="/login" />} />
                       </Routes>
                   </div>
               </div>
           </Router>
       </AuthProvider>
    );
};

export default App;
