import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import { AuthProvider, useAuth } from "./AuthContext";
import PrivateRoute from './PrivateRoute'

//componentes de vista
import Home from "./Home";
import Dashboard from "./Dashboard";
import AdminPanel from "./AdminPanel";
import Login from "./Login";
import Unauthorized from "./Unauthorized";

const navStyles = {
  display: 'flex',
  justifyContent: 'center',
  gap: '20px',
  padding: '20px',
  backgroundColor: '#eee',
  borderBottom: '1px solid #ccc',
};
 
const navLinkStyles = {
  textDecoration: 'none',
  color: '#007bff',
  fontWeight: 'bold',
};

const Header = () => {
  const {isAuthenticated, user, logout} = useAuth()

  return(
    <nav style={navStyles}>
      <Link to='/' style={navLinkStyles}> Inicio </Link>
      <Link to='/dashboard' style={navLinkStyles}> Dashboard (Privado) </Link>
      <Link to='/admin' style={navLinkStyles}> Admin (Solo Admin) </Link>

      {!isAuthenticated && <Link to="/login" style={navLinkStyles}>Login</Link>}
      {isAuthenticated && <button onClick={logout} style={{ ...navLinkStyles, border: 'none', background: 'none', cursor: 'pointer' }}>Logout ({user?.name})</button>}
    </nav>
  )
}

function App(){
  return(
    <Router>
      <AuthProvider>
        <Header />
        <Routes>
          {/* Rutas Públicas */}
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/unauthorized" element={<Unauthorized />} />
 
          {/* 13.1 Protección de Rutas para Usuarios Autenticados */}
          {/* 13.3 Redireccionamiento y Rutas Privadas */}
          <Route element={<PrivateRoute />}>
            <Route path="/dashboard" element={<Dashboard />} />
          </Route>
 
          {/* 13.2 Control de Acceso y Autorización */}
          {/* Ruta solo accesible para usuarios con rol 'admin' */}
          <Route element={<PrivateRoute allowedRoles={['admin']} />}>
            <Route path="/admin" element={<AdminPanel />} />
          </Route>
 
          {/* Ruta para cualquier otra URL no definida */}
          <Route path="*" element={<div>404 - Página no encontrada</div>} />
        </Routes>
      </AuthProvider>
    </Router>
  )
}

export default App