import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/planning";

export async function getPlanningListAsync() {
    return await getAsync(endpoint);
}

export async function getPlanningAsync(teacherId) {
    return await getAsync(`${endpoint}/${teacherId}`);
}

export async function createPlanningAsync(model) {
    return await postAsync(endpoint, model);
}

export async function updatePlanningAsync(model) {
    return await putAsync(`${endpoint}/${model.PlanningId}`, model);
}

export async function deletePlanningAsync(PlanningId) {
    return await deleteAsync(`${endpoint}/${PlanningId}`);
}