//PAra usuario no autorizados
import React from "react";
import { Link } from "react-router-dom";

const Unauthorized = () => {

    const styles = {
        container: {
            padding: '20px',
            maxWidth: '600px',
            margin: '30px auto',
            border: '1px solid #ccc',
            borderRadius: '8px',
            boxShadow: '0 2px 4px rgba(0,0,0,0.1)',
            backgroundColor: '#f9f9f9',
            textAlign: 'center'
        },
        form:{
            display: 'flex',
            flexDirection: 'column',
            gap: '15px',
            marginTop: '20px'
        },
        formGroup:{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'flex-start',
        },
        input:{
            width: '100%',
            padding: '10px',
            borderRadius: '4ppx',
            border: '1px solid #ddd',
            boxSizing: 'border-box'
        },
        button: {
            padding: '10px 20px',
            backgroundColor: '#007bff',
            color: 'white',
            border: 'none',
            borderRadius: '4px',
            cursor: 'pointer',
            fontSize: '1em',
            marginTop: '10px'
        },
        link:{
            display: 'block',
            marginTop: '15px',
            color: '#007bff',
            textDecoration: 'none'
        },
        errorText:{
            color: 'red',
            marginBottom: '10px'
        }
    }

    return (
        <div style={styles.container}>
            <h2>Acceso Denegado</h2>
            <p>No tienes permisos necesarios para ver esta pagina</p>
            <Link to='/' style={styles.link}>Volver al inicio</Link>
            <Link to='/login' style={styles.link}>Iniciar sesion con otra cuenta</Link>
        </div>
    )
}

export default Unauthorized