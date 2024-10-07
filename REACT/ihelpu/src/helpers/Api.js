import axios from "axios";

var urlBase =  "http://localhost:5042/api/"
    const Api = axios.create({baseUrl : urlBase})
    export default Api
    