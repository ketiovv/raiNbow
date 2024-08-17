import React, { useEffect, useState } from 'react';
import axiosInstance from '../api/axiosInstance'; // Import the configured axios instance
import { Link } from 'react-router-dom';
import styles from './SchemasOverview.module.scss';
import {Schema} from "../types"; // Import CSS Module styles

const SchemasOverview: React.FC = () => {
    const [schemas, setSchemas] = useState<Schema[]>([]);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchSchemas = async () => {
            try {
                const response = await axiosInstance.get<Schema[]>('/cms/schemas');
                setSchemas(response.data);
            } catch (error) {
                setError('Failed to load schemas');
            }
        };

        fetchSchemas();
    }, []);

    return (
        <div className={styles.schemasOverviewContainer}>
            <h1 className={styles.title}>Schemas Overview</h1>
            {error && <p className={styles.error}>{error}</p>}
            <ul className={styles.schemasList}>
                {schemas.map(schema => (
                    <li key={schema.id} className={styles.schemaItem}>
                        <Link to={`/schemas/${schema.id}`}>{schema.name}</Link>
                    </li>
                ))}
            </ul>
            <Link to="/schemas/add" className={styles.addSchemaLink}>Add Schema</Link>
        </div>
    );
};

export default SchemasOverview;
