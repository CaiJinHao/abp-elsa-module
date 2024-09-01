/**
 * Generate from url: https://localhost:44345/swagger/v1/swagger.json
 * It is recommended not to modify the document
 * Total count: 2
 **/
// @ts-ignore
/* eslint-disable */
import type { API } from "./typings";
import { request } from 'umi';

/**
 * *TODO* GET /api/elsa/workflow/settings/cleanup 
 **/
export async function getWorkflowSettingsCleanup(
    options?: { [key: string]: any }
) {
    return request<API.CleanupSettings>(`/api/elsa/workflow/settings/cleanup`, {
        method: 'GET',
        ...(options || {}),
    });
}

/**
 * *TODO* POST /api/elsa/workflow/settings/cleanup 
 **/
export async function updateWorkflowSettingsCleanup(
    payload: API.CleanupSettings,
    options?: { [key: string]: any }
) {
    return request<any>(`/api/elsa/workflow/settings/cleanup`, {
        method: 'POST',
        data: payload,
        getResponse: true,
        ...(options || {}),
    });
}
