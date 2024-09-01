/**
 * Generate from url: https://localhost:44345/swagger/v1/swagger.json
 * It is recommended not to modify the document
 * Total count: 1
 **/
// @ts-ignore
/* eslint-disable */
import type { API } from "./typings";
import { request } from 'umi';

/**
 * *TODO* POST /api/account/dynamic-claims/refresh 
 **/
export async function dynamicClaimsRefresh(
    options?: { [key: string]: any }
) {
    return request<any>(`/api/account/dynamic-claims/refresh`, {
        method: 'POST',
        getResponse: true,
        ...(options || {}),
    });
}
