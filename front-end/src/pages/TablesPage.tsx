import {tableService} from "@/services/tablesService.ts";
import {useState, useEffect} from "react";
import {TableCard} from "@/components/tables/TableCard.tsx";
import type {Table} from "@/services/tablesService.ts";

export default function TablesPage() {
    const [tables, setTables] = useState<Table[]>(new Array<Table>());

    useEffect(() => {
        tableService.getAllTables(false)
            .then(response => {
                setTables(response)
            });
    }, []);

    return (
        <>
            <h2>Tables</h2>
            {tables.map(table => {
                return (
                    <TableCard key={table.id} table={table}/>
                )
            })}
        </>
    )
}