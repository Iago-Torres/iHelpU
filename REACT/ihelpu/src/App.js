import React,{useState, useEffect} from "react";
import { GetCompetencia } from "./services/serviceCompetencia";

const App = () =>{
  useEffect(() => {
    GetCompetencia().then(res => {console.log(res.data)})

  },[])
  return (
    <>
    <h1>Hello Worldzada</h1>
    </>
  )
}