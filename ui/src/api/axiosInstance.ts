import axios from 'axios';

// Create an Axios instance
const axiosInstance = axios.create({
    baseURL: process.env.REACT_APP_API_URL, // Base URL from environment variable
});

// Add a request interceptor to include the token
axiosInstance.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('accessToken'); // Retrieve token from localStorage
        console.log(token)
        if (token) {
            config.headers.Authorization = `Bearer ${token}`; // Set the Authorization header
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default axiosInstance;
