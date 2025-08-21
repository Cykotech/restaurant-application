import {Link, useNavigate, useParams} from "react-router";
import {useEffect, useState} from "react";
import {type MenuItem, menuService} from "@/services/menuService.ts";

export function MenuDetails() {
    const navigate = useNavigate();
    const params = useParams();
    const [item, setTable] = useState<MenuItem>();

    async function deleteMenuItem() {
        await menuService.deleteMenuItem(Number(params.id))
            .then(() => navigate("../"));
    }

    useEffect(() => {
        menuService.getMenuItemById(Number(params.id))
            .then(response => setTable(response));
    }, [params.id]);
    return (
        <>
            <p className="text-3xl">{item?.name}</p>
            <p>{item?.description}</p>
            <p>{item?.price}</p>
            <Link to={`../${item?.id}/edit`}>Edit</Link>
            <button onClick={deleteMenuItem}>Close</button>
            <Link to={"/tables"}>Back</Link>
        </>
    )
}