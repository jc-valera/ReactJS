//Pagina inicial
import React from "react";
import { Link } from "react-router-dom";
import { useAuth } from "./AuthContext";

const Home = () => {
    const { isAuthenticated, user, logout } = useAuth()

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

    return(
        <div style={styles.container} >
            <h2>Pagina de inicio (Publica) </h2>
            {isAuthenticated ? (
                <>
                    <p>Hola, {user?.name} ({user?.role}) ! </p>
                    <button onClick={logout} style={styles.button} > Cerrar Sesion </button>
                    <Link to='/dashboard' style={styles.link} > Ir al Dashboard (Privado) </Link>
                    {user?.role === 'admin' && (
                        <Link to='/admin' style={styles.link}> Ir al Panel de Administrador (Solo Admin) </Link>
                    )}
                </>
            ) : (
                <>
                    <p>No has iniciado sesion</p>
                    <Link to='/login' style={styles.link}>Ir a iniciar Sesion</Link>
                    <Link to='/dashboard' style={styles.link}>Intentar ir al DashBoard (te redirigira)</Link>
                </>
            )}
        </div>
    )
}

export default Home