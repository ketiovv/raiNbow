import React from 'react';
import styles from './Dashboard.module.scss'; // Import CSS Module styles

const Dashboard: React.FC = () => {
    return (
        <div className={styles.dashboardContainer}>
            <h1 className={styles.welcomeMessage}>Welcome to the Dashboard!</h1>
        </div>
    );
};

export default Dashboard;
