import { crimeReporter } from "./config/axios";
import { CrimeDataRequest } from '../types';

export const CrimeReporterAPI = {
    CrimeReport: async (crimeDataRequest: CrimeDataRequest) => {
        const uri = `/CrimeData/?month=${crimeDataRequest.Month}&latitude=${crimeDataRequest.Latitude}&longitude=${crimeDataRequest.Longitude}`; 

        const response = await crimeReporter.get(uri);

        console.log(response);
        if(response.data.isSuccess)
            return response.data.result;
    }
}