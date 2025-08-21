import {Link} from "react-router";
import {Card, CardContent, CardHeader, CardTitle} from "@/components/ui/card.tsx";
import type {MenuItem} from "@/services/menuService.ts";

type Props = {
    menuItem: MenuItem;
}

export function ItemCard({menuItem}: Props) {
    return (
        <Link to={`${menuItem.id}`}>
            <Card>
                <CardHeader>
                    <CardTitle>{menuItem.id}</CardTitle>
                </CardHeader>
                <CardContent>
                    <p>{menuItem.name}</p>
                </CardContent>
            </Card>
        </Link>
    )
}