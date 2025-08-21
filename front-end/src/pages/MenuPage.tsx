import {useEffect, useState} from "react";
import {type MenuItem, menuService} from "@/services/menuService.ts";
import {ItemCard} from "@/components/menu/ItemCard.tsx";

export default function MenuPage() {
    const [menuItems, setMenuItems] = useState<MenuItem[] | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    useEffect(() => {
        let ignore = false;

        setIsLoading(true);
        menuService.getAllMenuItems().then(response => {
            if (!ignore) {
                setMenuItems(response);
                setIsLoading(false);
            }
        });

        return () => {
            ignore = true;
        }
    }, []);

    return (
        <>
            {!isLoading ? menuItems?.map(item => {
                return (
                    <ItemCard key={item.id} menuItem={item}/>
                )
            }) : <p>Loading...</p>}
        </>
    )
}