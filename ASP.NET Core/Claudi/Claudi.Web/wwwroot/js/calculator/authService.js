import constants from "./constants.js";
import { jsonRequest } from "./httpService.js";

async function get() {
    try {
        let result = await jsonRequest(constants.options, 'get');
        return result;
    } catch (err){
        alert(err);
    }
}
async function getModelsWithId(id) {
    try {
        let result = await jsonRequest(`${constants.productModels}/${id}`, 'get');
        return result;
    } catch (err){
        alert(err);
    }
}

async function getColorsWithId(id) {
    try {
        let result = await jsonRequest(`${constants.productColors}/${id}`, 'get');
        return result;
    } catch (err) {
        alert(err);
    }
}



let auth = {
    get,
    getModelsWithId,
    getColorsWithId,
};

export default auth;