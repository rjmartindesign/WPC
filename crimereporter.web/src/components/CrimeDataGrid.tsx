import { useEffect, useState } from "react";
import { DataGrid, GridColDef, GridValueGetterParams } from '@mui/x-data-grid';
import { CrimeReporterAPI } from '../api/CrimeReporterAPI';

const CrimeDataGrid = ({ crimeDataRequest }) => {

    const [gridData, setGridData] = useState([])
    useEffect(() => {

        const fetchData = async () => {
            try {
                const result = await CrimeReporterAPI.CrimeReport(crimeDataRequest);
                setGridData(result);
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        };

        fetchData();
    }, [crimeDataRequest]);

    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 90 },
        {
            field: 'category',
            headerName: 'Category',
            width: 180,
            editable: true,
        },
        {
            field: 'location_type',
            headerName: 'Location Type',
            width: 150,
            editable: true,
        },
        {
            field: 'location',
            headerName: 'Location',
            sortable: false,
            width: 260,
            valueGetter: (params: GridValueGetterParams) =>
                `${params.row.location.street.name }`
        },
    ];
    console.log(gridData);
    return (
        <>
            <DataGrid
                rows={gridData}
                columns={columns}
                initialState={{
                    pagination: {
                        paginationModel: {
                            pageSize: 5,
                        },
                    },
                }}
                pageSizeOptions={[5]}
                checkboxSelection
                disableRowSelectionOnClick
            />
        </>
    )
}

export default CrimeDataGrid;
