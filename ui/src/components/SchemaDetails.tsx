import React, { useEffect, useState } from 'react';
import axiosInstance from '../api/axiosInstance'; // Import the configured axios instance
import { useParams } from 'react-router-dom';
import styles from './SchemaDetails.module.scss';
import {Schema} from "../types"; // Import CSS Module styles

const SchemaDetails: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [schema, setSchema] = useState<Schema | null>(null);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchSchema = async () => {
            try {
                const response = await axiosInstance.get<Schema>(`/cms/schemas/${id}`);
                setSchema(response.data);
            } catch (error) {
                setError('Failed to load schema details');
            }
        };

        fetchSchema();
    }, [id]);

    return (
        <div className={styles.schemaDetailContainer}>
            <h1 className={styles.title}>Schema Details</h1>
            {error && <p className={styles.error}>{error}</p>}
            {schema ? (
                <div>
                    <h2>{schema.name}</h2>
                    <ul className={styles.fieldsList}>
                        {schema.fields.map(field => (
                            <li key={field.id}>
                                <strong>{field.name}:</strong> {field.fieldType}
                            </li>
                        ))}
                    </ul>
                </div>
            ) : (
                <p className={styles.loading}>Loading...</p>
            )}
        </div>
    );
};

export default SchemaDetails;
