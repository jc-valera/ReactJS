import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "./AuthContext";
import { Link } from "react-router-dom";

const Login = () => {

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

    const[username, setUsername] = useState('')
    const[password, setPassword] = useState('')
    const[error, setError] = useState('')
    const { login } = useAuth()
    const navigate = useNavigate()

    const handleSubmit = async(e) => {
        e.preventDefault()
        setError('')

        try{
            await login(username, password)
            navigate('/dashboard')
        }
        catch(err){
            setError(err.message)
        }
    }

    return(
        <div style={styles.container}>
            <h2>Iniciar Sesion</h2>
            <form onSubmit={handleSubmit} style={styles.form}>
                <div style={styles.formGroup}>
                    <label htmlFor="username"> Usuario: </label>
                    <input type="text" id="username" value={username} onChange={(e) => setUsername(e.target.value)} style={styles.input} />

                </div>

                <div style={styles.formGroup}>
                    <label htmlFor="password"> Password: </label>
                    <input type="text" id='password' value={password} onChange={(e) => setPassword(e.target.value)} style={styles.input}/>

                </div>

                {error && <p style={styles.errorText}> { error }</p>}

                <button type='submit' style={styles.button}>
                    Entrar
                </button>
            </form>

            <p>Prueba con: 'user'/password o 'admin'/'adminpass'</p>
            <Link to='/' style={styles.link} > Volver al inicio </Link>
            
        </div>
    )
}

export default Login

