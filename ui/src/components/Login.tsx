import React, { useState, FormEvent } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import styles from './Login.module.scss';

export interface LoginResponse{
    accessToken: string,
    tokenType: string,
    expiresIn: 3600,
    refreshToken: string,
}

const Login: React.FC = () => {
    const [email, setEmail] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const [error, setError] = useState<string | null>(null);
    const navigate = useNavigate();

    const handleLogin = async (e: FormEvent) => {
        e.preventDefault();
        try {
            const response = await axios.post<LoginResponse>(
                `${process.env.REACT_APP_API_URL}/login`,
                { email, password }
            );
            const { accessToken, refreshToken, expiresIn } = response.data;
            localStorage.setItem('accessToken', accessToken);
            localStorage.setItem('refreshToken', refreshToken);
            localStorage.setItem('expiresIn', expiresIn.toLocaleString());
            
            navigate('/dashboard'); // Redirect to the dashboard
        } catch (error) {
            setError('Login failed. Please check your credentials.');
        }
    };

    return (
        <div className={styles.loginContainer}>
            <h2>Login</h2>
            {error && <p className={styles.error}>{error}</p>}
            <form onSubmit={handleLogin}>
                <div>
                    <label htmlFor="username">Email:</label>
                    <input
                        type="text"
                        id="username"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="password">Password:</label>
                    <input
                        type="password"
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Login</button>
            </form>
        </div>
    );
};

export default Login;