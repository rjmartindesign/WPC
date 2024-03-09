import axios from 'axios';

const CrimeReporterBaseURL = 'https://localhost:7247';

export const crimeReporter = axios.create({
    baseURL: CrimeReporterBaseURL,
    headers: {
        "accept": "*/*",
        "Content-Type": "application/json"
    }
});
