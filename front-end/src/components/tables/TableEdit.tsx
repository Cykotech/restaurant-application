import {tableService} from "@/services/tablesService.ts";
import {useNavigate} from "react-router";

export function TableEdit() {
    const navigate = useNavigate();
    async function openTable(formData: FormData) {
        const serverName = formData.get('serverName') as string;
        const guests = formData.get('guests');

        const newTable = await tableService.openTable(serverName, Number(guests));
        navigate(`../${newTable}`);
    }
    return (
        <form action={openTable}>
            <input name="serverName" type="text"/>
            <input name="guests" type="number"/>
            <button type="submit">Open Table</button>
        </form>
    )
}