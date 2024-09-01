/**
 * Generate from url: https://localhost:44345/swagger/v1/swagger.json
 * It is recommended not to modify the document
 * Total count: 3
 **/
// @ts-ignore
/* eslint-disable */
import type { API } from "./typings";
import { request } from 'umi';

/**
 * *TODO* GET /api/setting-management/timezone 
 **/
export async function getTimeZoneSettings(
    options?: { [key: string]: any }
) {
    return request<any>(`/api/setting-management/timezone`, {
        method: 'GET',
        getResponse: true,
        ...(options || {}),
    });
}

/**
 * *TODO* GET /api/setting-management/timezone/timezones 
 **/
export async function getTimeZoneSettingsTimezones(
    options?: { [key: string]: any }
) {
    return request<any>(`/api/setting-management/timezone/timezones`, {
        method: 'GET',
        getResponse: true,
        ...(options || {}),
    });
}

/**
 * *TODO* POST /api/setting-management/timezone 
 **/
export async function updateTimeZoneSettings(
    params: {
        timezone?: string | undefined
    },
    options?: { [key: string]: any }
) {
    return request<any>(`/api/setting-management/timezone`, {
        method: 'POST',
        params: params,
        getResponse: true,
        ...(options || {}),
    });
}
