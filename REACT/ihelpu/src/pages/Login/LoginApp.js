import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./Login"; // Importe o componente de Login corretamente
import Signup from "./Signup"; // Importe o componente Signup

function LoginApp() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} /> 
        <Route path="/signup" element={<Signup />} /> 
      </Routes>
    </BrowserRouter>
  );
}

export default LoginApp;
