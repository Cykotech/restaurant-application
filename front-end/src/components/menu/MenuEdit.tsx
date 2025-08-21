import {useNavigate, useParams} from "react-router";
import {useEffect, useState} from "react";
import {type MenuItem, menuService} from "@/services/menuService.ts";

export function MenuEdit() {
    const navigate = useNavigate();
    const params = useParams();
    const [item, setItem] = useState<MenuItem | null>();

    useEffect(() => {
        menuService.getMenuItemById(Number(params.id))
            .then(response => setItem(response));
    }, [params.id]);

    async function createMenuItem(formData: FormData) {
        const itemName = formData.get('name') as string;
        const description = formData.get('description') as string;
        const price = formData.get('price');

        const newMenuItem = await menuService.createNewMenuItem(itemName, description, Number(price));
        navigate(`../${newMenuItem}`);
    }

    async function updateMenuItem(formData: FormData) {
        const itemName = formData.get('name') as string;
        const description = formData.get('description') as string;
        const price = formData.get('price');

        const updatedMenuItem = await menuService.updateMenuItem(Number(params.id), itemName, description, Number(price));
        navigate(`../${updatedMenuItem}`);
    }
    return (
        <form action={item ? updateMenuItem : createMenuItem}>
            <input name="name" type="text" value={item?.name}/>
            <input name="description" type="text" value={item?.description} />
            <input name="price" type="number" value={item?.price} />
            <button type="submit">{item ? "Modify Item" : "Create Menu Item"}</button>
        </form>
    )
}