import Api from "../helpers/Api";

export async function GetTipoServico(params) {
    return await Api.get("/TipoServico")
}

export async function GetTipoServico(id) {
    return await Api.get('/TipoServico/GetTipoServicoById/${id}');
}

