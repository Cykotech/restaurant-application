import {axiosClient} from "@/services/apiFetch.ts";

export type MenuItem = {
    id: number;
    name: string;
    description: string;
    price: number;
}

class MenuService {
    async getAllMenuItems(): Promise<MenuItem[]> {
        return axiosClient.get("menuItems")
            .then(response => response.data)
            .catch(error => console.error(error));
    }

    async getMenuItemById(id: number): Promise<MenuItem> {
        return axiosClient.get(`menuItems/${id}`)
            .then(response => response.data)
            .catch(error => console.error(error));
    }

    async createNewMenuItem(name: string, description: string, price: number): Promise<number> {
        return axiosClient.post(`menuItems/create`, {name, description, price})
            .then(response => response.data)
            .catch(error => console.error(error));
    }

    async updateMenuItem(id: number, name?: string, description?: string, price?: number): Promise<number> {
        return axiosClient.put(`menuItems/${id}`, {name, description, price})
            .then(response => response.data)
            .catch(error => console.error(error));
    }

    async deleteMenuItem(id: number): Promise<void> {
        axiosClient.delete(`menuItems/${id}`)
            .catch(error => console.error(error));
    }
}

export const menuService = new MenuService();