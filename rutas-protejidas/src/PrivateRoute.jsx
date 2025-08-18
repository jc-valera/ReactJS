// src/PrivateRoute.jsx
import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { useAuth } from './AuthContext';
 
const PrivateRoute = ({ allowedRoles }) => {
  const { isAuthenticated, hasRole, loading } = useAuth();
 
  // 13.3 Redireccionamiento y rutas privadas.
  // Mientras se verifica la autenticación (ej. token en localStorage)
  if (loading) {
    return <div style={{ textAlign: 'center', padding: '50px' }}>Cargando sesión...</div>;
  }
 
  // 13.1 Protección de rutas para usuarios autenticados.
  if (!isAuthenticated) {
    // Redirige al login si no está autenticado
    return <Navigate to="/login" replace />;
  }
 
  // 13.2 Control de acceso y autorización en la aplicación.
  if (allowedRoles && !allowedRoles.some(role => hasRole(role))) {
    // Redirige a una página de no autorizado si no tiene el rol necesario
    return <Navigate to="/unauthorized" replace />;
  }
 
  // Si está autenticado y tiene el rol (si se requiere), renderiza el contenido de la ruta
  return <Outlet />;
};
 
export default PrivateRoute;