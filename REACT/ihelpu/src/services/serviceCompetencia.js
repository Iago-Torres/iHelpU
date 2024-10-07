import Api from "../helpers/Api";

export async function GetCompetencia(params) {
    return await Api.get("/TipoServico")
}

export async function GetCompetenciaById(id) {
    return await Api.get('/Competencia/GetCompetenciaById/${id}');
}

