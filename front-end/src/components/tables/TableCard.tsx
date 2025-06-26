import {Card, CardContent, CardHeader, CardTitle} from "@/components/ui/card.tsx";
import type {Table} from "@/services/tablesService.ts";
import {Link} from "react-router";

type Props = {
    table: Table;
}

export function TableCard({table}: Props) {
    return (
        <Link to={`${table.id}`}>
            <Card>
                <CardHeader>
                    <CardTitle>{table.id}</CardTitle>
                </CardHeader>
                <CardContent>
                    <p>{table.serverName}</p>
                    <p>{table.guests}</p>
                </CardContent>
            </Card>
        </Link>
    )
}