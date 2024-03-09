import { useState } from "react";
import { TextField, FormControl, InputLabel, Select, MenuItem, Button } from "@mui/material"; 
import CrimeDataGrid from './CrimeDataGrid';
import { CrimeDataRequest } from "../types";

const CrimeDataForm = () => {
    const [latitude, setLatitude] = useState('51.5072');
    const [longitude, setLongitude] = useState('0.1276');
    const [month, setMonth] = useState('1');
    const [crimeData, setCrimeData] = useState<CrimeDataRequest>({
        Month: Number(month),
        Latitude: parseFloat(latitude),
        Longitude: parseFloat(longitude),
    });

    //Month: 1, Latitude: 51.5072, Longitude: 0.1276
    const [longitudeError, setLongitudeError] = useState(false)
    const [latitudeError, setLatitudeError] = useState(false)


    const isValidFloat = (value: string) => {
        if (value !== "-" && value !== "") {
            const floatValue = parseFloat(value);
            if (isNaN(floatValue)) {
                return false; // Invalid if not a valid number
            }
        }
        return true; // Valid if it's a valid number
    }
    // Validation function for UK coordinates
    const isValidUKCoordinate = (value: string, isLatitude: boolean) => {
        const floatValue = parseFloat(value);
        if (isNaN(floatValue)) {
            return false; // Invalid if not a valid number
        }

        if (isLatitude) {
            return floatValue >= 49.5 && floatValue <= 61.0; // Valid range for UK latitude: 49.5 to 61.0 degrees
        } else {
            return floatValue >= -7.5 && floatValue <= 1.8; // Valid range for UK longitude: -7.5 to 1.8 degrees
        }
    };

    const handleMonthChange = (event) => {
        setMonth(event.target.value);
    };
    const handleLatitudeChange = (event) => {
        const newValue = event.target.value;
        // Check if the new value is not "-" and not an empty string
        if (newValue !== "-" && newValue !== "") {
            // Check if the value is a valid float
            if (isValidFloat(newValue)) {
                // If the event type is "blur", perform additional checks
                if (event.type === "blur") {
                    // Check if the value is a valid UK coordinate
                    if (isValidUKCoordinate(newValue, true)) {
                        setLatitudeError(false);
                        setLatitude(parseFloat(newValue).toString());
                    }
                    else {
                        setLatitudeError(true);
                    }
                }
                else {
                    // If not a "blur" event, set latitude without additional checks
                    setLatitudeError(false);
                    setLatitude(parseFloat(newValue).toString());
                }
            }
            else {
                // If not a valid float, set latitude error
                setLatitudeError(true);
            }
        }
        else {
            // If the new value is "-" or an empty string, set latitude with errors
            setLatitude(newValue);
            setLatitudeError(true);
        }

    };

    const handleLongitudeChange = (event) => {
        const newValue = event.target.value;
        // Check if the new value is not "-" and not an empty string
        if (newValue !== "-" && newValue !== "") {
            // Check if the value is a valid float
            if (isValidFloat(newValue)) {
                // If the event type is "blur", perform additional checks
                if (event.type == "blur") {
                    // Check if the value is a valid UK coordinate
                    if (isValidUKCoordinate(newValue, false)) {
                        setLongitudeError(false);
                        setLongitude(parseFloat(newValue).toString());
                    }
                    else {
                        setLongitudeError(true);
                    }
                }
                else {
                    // If not a "blur" event, set longitude without additional checks
                    setLongitudeError(false);
                    setLongitude(parseFloat(newValue).toString());
                }
            }
            else {
                // If not a valid float, set longitude error
                setLongitudeError(true);
            }
        }
        else {
            // If the new value is "-" or an empty string, set Longitude with errors
            setLongitude(newValue);
            setLongitudeError(true);
        }

    };
    const handleSubmit = (event) => {
        event.preventDefault();
        if (isValidUKCoordinate(longitude, false) && isValidUKCoordinate(latitude, true)) {

            setCrimeData({
                Month: Number(month),
                Longitude: Number(longitude),
                Latitude: Number(latitude)
            });
        }
    };
    return (
        <form autoComplete="off" onSubmit={handleSubmit}>
            <h2>Crime Reporter</h2>

            <FormControl fullWidth variant="outlined" margin="normal">
                <InputLabel id="month-label">Select Month</InputLabel>
                <Select
                    labelId="month-label"
                    id="month-select"
                    value={month}
                    label="Select Month"
                    onChange={handleMonthChange}
                >
                    <MenuItem value="1">January</MenuItem>
                    <MenuItem value="2">February</MenuItem>
                    <MenuItem value="3">March</MenuItem>
                    <MenuItem value="4">April</MenuItem>
                    <MenuItem value="5">May</MenuItem>
                    <MenuItem value="6">June</MenuItem>
                    <MenuItem value="7">July</MenuItem>
                    <MenuItem value="8">August</MenuItem>
                    <MenuItem value="9">September</MenuItem>
                    <MenuItem value="10">October</MenuItem>
                    <MenuItem value="11">November</MenuItem>
                    <MenuItem value="12">December</MenuItem>
                </Select>
            </FormControl>
            <TextField
                label="Latitude"
                variant="outlined"
                value={latitude}
                onChange={handleLatitudeChange}
                onBlur={handleLatitudeChange}
                error={latitudeError}
                fullWidth
                margin="normal"
                helperText="Enter a valid latitude (49.5 to 61.0 degrees)"
            />
            <TextField
                label="Longitude"
                variant="outlined"
                value={longitude}
                onChange={handleLongitudeChange}
                onBlur={handleLongitudeChange}
                error={longitudeError}
                fullWidth
                margin="normal"
                helperText="Enter a valid longitude (-7.5 to 1.8 degrees)"
            />
            <Button disabled={latitudeError || longitudeError} variant="outlined" color="secondary" type="submit">Update</Button>
            <CrimeDataGrid crimeDataRequest={crimeData}></CrimeDataGrid>
        </form>
    )
}

export default CrimeDataForm;
