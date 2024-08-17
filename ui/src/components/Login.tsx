import React, { useState, FormEvent } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const Login: React.FC = () => {
    const [username, setUsername] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const navigate = useNavigate();

    const handleLogin = async (e: FormEvent) => {
        e.preventDefault();
        try {
            const apiUrl = process.env.API_URL as string;
            const response = await axios.post(`${apiUrl}/login`, { username, password });
            const { token } = response.data;
            localStorage.setItem('token', token);
            navigate('/dashboard');
        } catch (error) {
            console.error('Login failed:', error);
        }
    };

    return (
        <form onSubmit={handleLogin}>
            <div>
                <label>Username:</label>
                <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
            </div>
            <div>
                <label>Password:</label>
                <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
            </div>
            <button type="submit">Login</button>
        </form>
    );
};

export default Login;