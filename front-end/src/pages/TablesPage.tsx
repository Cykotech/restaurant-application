import {tableService} from "@/services/tablesService.ts";
import {useState, useEffect} from "react";
import {TableCard} from "@/components/tables/TableCard.tsx";
import type {Table} from "@/services/tablesService.ts";
import {Link} from "react-router";

export default function TablesPage() {
    const [tables, setTables] = useState<Table[] | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    console.log("Component mounted.");

    useEffect(() => {
        let ignore = false;

        setIsLoading(true);
        tableService.getAllTables(false).then(response => {
            if (!ignore) {
                setTables(response);
                setIsLoading(false);
            }
        });

        return () => {
            ignore = true;
        }
    }, []);

    return (
        <>
            <Link to={"edit"}>Open Table</Link>
            {!isLoading ? tables?.map(table => {
                return (
                    <TableCard key={table.id} table={table}/>
                )
            }) : <p>Loading...</p>}
        </>
    )
}