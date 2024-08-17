import React, {useEffect, useState, FormEvent} from 'react';
import axiosInstance from '../api/axiosInstance'; // Import the configured axios instance
import {useNavigate} from 'react-router-dom';
import styles from './AddSchema.module.scss'; // Import CSS Module styles

export interface FieldType {
    id: string;
    fieldName: string;
    typeName: string;
}

const AddSchema: React.FC = () => {
    const [name, setName] = useState<string>('');
    const [fields, setFields] = useState<{ name: string; fieldTypeId: string }[]>([]);
    const [fieldTypes, setFieldTypes] = useState<FieldType[]>([]);
    const [error, setError] = useState<string | null>(null);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchFieldTypes = async () => {
            try {
                const response = await axiosInstance.get<[]>('/cms/fieldTypes');
                setFieldTypes(response.data);
            } catch (error) {
                setError('Failed to load field types');
            }
        };

        fetchFieldTypes();
    }, []);

    const handleAddField = () => {
        setFields([...fields, {name: '', fieldTypeId: ''}]);
    };

    const handleFieldChange = (index: number, key: string, value: string) => {
        const newFields = [...fields];
        newFields[index] = {...newFields[index], [key]: value};
        setFields(newFields);
    };

    const handleSubmit = async (e: FormEvent) => {
        e.preventDefault();
        try {
            await axiosInstance.post('/cms/schemas', {name, fields});
            navigate('/schemas');
        } catch (error) {
            setError('Failed to create schema');
        }
    };

    return (
        <div className={styles.addSchemaContainer}>
            <h1 className={styles.title}>Add Schema</h1>
            {error && <p className={styles.error}>{error}</p>}
            <form onSubmit={handleSubmit}>
                <div className={styles.formGroup}>
                    <label htmlFor="name">Schema Name:</label>
                    <input
                        type="text"
                        id="name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                    />
                </div>
                {fields.map((field, index) => (
                    <div key={index} className={styles.formGroup}>
                        <label>Field {index + 1}:</label>
                        <input
                            type="text"
                            placeholder="Field name"
                            value={field.name}
                            onChange={(e) => handleFieldChange(index, 'name', e.target.value)}
                            required
                        />
                        <select
                            value={field.fieldTypeId}
                            onChange={(e) => handleFieldChange(index, 'fieldTypeId', e.target.value)}
                            required
                        >
                            <option value="">Select Field Type</option>
                            {fieldTypes.map(fieldType => (
                                <option key={fieldType.id} value={fieldType.id}>
                                    {fieldType.fieldName}({fieldType.typeName})
                                </option>
                            ))}
                        </select>
                    </div>
                ))}
                <button type="button" onClick={handleAddField}>Add Field</button>
                <button type="submit">Create Schema</button>
            </form>
        </div>
    );
};

export default AddSchema;
