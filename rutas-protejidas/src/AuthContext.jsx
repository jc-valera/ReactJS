//Manejara el estado de la autenticacion
import React, { createContext, useState, useEffect, useContext } from "react";

const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null); //null si no esta autenticado
    const [loading, setLoading] = useState(true); //Para simular la carga de la sesion

    useEffect(() => {
        //simula la verificacion de una sesion persistente (ejemplo: token, localstorage)
        const storedUser = localStorage.getItem("user");

        if (storedUser) {
        setUser(JSON.parse(storedUser));
        }

        setLoading(false);
    }, []);

    const login = (username, password) => {
        return new Promise((resolve, reject) => {
            setLoading(true)
            setTimeout(() => {
            if (username == 'user' && password == 'password' ){
                const newUser = {name: username, role: 'user'}
                setUser(newUser)
                localStorage.setItem('user', JSON.stringify(newUser))
                resolve(newUser)
            }
            else if (username == 'admin' &&  password == 'adminpass'){
                const newUser = { name: username, role: 'admin'}
                setUser(newUser)
                localStorage.setItem('admin', JSON.stringify(newUser))
                resolve(newUser)
            }
            else{
                reject(new Error('Credenciales incorrectas'))
            }

            setLoading(false)
            }, 1000);
        })
    }

    const logout =() =>{
        setUser(null)
        localStorage.removeItem('user')
    }

    const isAuthenticated = !! user
    const hasRole = (requiredRole) => isAuthenticated && user?.role === requiredRole

    return(
        <AuthContext.Provider value={{user, isAuthenticated, hasRole, login, logout, loading}} >
            {children}
        </AuthContext.Provider>
    )

};

export const useAuth = () => useContext(AuthContext)