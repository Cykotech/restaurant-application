import {Link, useNavigate, useParams} from "react-router";
import {useEffect, useState} from "react";
import {type Table, tableService} from "@/services/tablesService.ts";

export function TableDetails() {
    const navigate = useNavigate();
    const params = useParams();
    const [table, setTable] = useState<Table>();

    async function closeTable() {
        await tableService.closeTable(Number(params.id))
            .then(() => navigate("../"));
    }

    useEffect(() => {
        tableService.getTableById(Number(params.id))
            .then(response => setTable(response));
    }, [params.id]);
    return (
        <>
            <p className="text-3xl">{table?.serverName}</p>
            <button onClick={closeTable}>Close</button>
            <Link to={"/tables"}>Back</Link>
        </>
    )
}