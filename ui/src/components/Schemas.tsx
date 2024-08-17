import React, { useEffect, useState } from 'react';
import axiosInstance from '../api/axiosInstance'; // Import the configured axios instance
import styles from './Schemas.module.scss';
import {Schema} from "../types"; // Import CSS Module styles

const Schemas: React.FC = () => {
    const [schemas, setSchemas] = useState<Schema[]>([]);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchSchemas = async () => {
            try {
                const response = await axiosInstance.get<Schema[]>('/cms/schemas');
                setSchemas(response.data);
            } catch (error) {
                setError('Failed to fetch schemas');
            }
        };

        fetchSchemas();
    }, []);

    return (
        <div className={styles.schemasContainer}>
            <h2>Schemas</h2>
            {error && <p className={styles.error}>{error}</p>}
            <ul>
                {schemas.map((schema) => (
                    <li key={schema.name}>
                        <h3>{schema.name}</h3>
                        <ul className={styles.fieldsList}>
                            {schema.fields.map((field) => (
                                <li key={field.name}>
                                    {field.name} (Type ID: {field.fieldTypeId})
                                </li>
                            ))}
                        </ul>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Schemas;
