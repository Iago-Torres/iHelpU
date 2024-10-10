import React, { useState, useEffect } from "react";
//import '@fortawesome/fontawesome-free/css/all.min.css';
//import { GetTipoServico } from "./services/serviceTipoServico";
//import TipoServico from "./components/pages/TipoServico";
// import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
// import { faSearch, faStar, faHandshake } from '@fortawesome/free-solid-svg-icons';
// Importando a página HomePage
import HomePage from './components/pages/HomePage'; // Certifique-se de que o caminho está correto

const App = () => {
  useEffect(() => {
    // Se a função GetTipoServico estiver comentada ou não implementada, lembre-se de habilitá-la
    // GetTipoServico().then(res => { console.log(res.data) })
  }, []);

  return (
    <>
      {/* Renderizando a página HomePage */}
      <HomePage />
    </>
  );
};

export default App;
