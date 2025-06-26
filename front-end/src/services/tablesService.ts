import {axiosClient} from "@/services/apiFetch.ts";

export type Table = {
    id: number | undefined;
    serverName: string | undefined;
    guests: number | undefined;
}

class tablesService {
    async getAllTables(showClosed: boolean): Promise<Table[]> {
        return axiosClient.get(`/tables?ShowClosed=${showClosed}`)
            .then(response => response.data)
            .catch(error => console.error(error));
    }

    async getTableById(id: number): Promise<Table> {
        return axiosClient.get(`/tables/${id}`)
            .then(response => response.data)
            .catch(error => console.error(error));
    }

    async openTable(serverName: string, guests: number): Promise<number> {
        return axiosClient.post("tables/open", {serverName, guests})
            .then(response => response.data.tableId)
            .catch(error => console.error(error));
    }

    async closeTable(id: number): Promise<void> {
        axiosClient.put(`tables/${id}`)
            .catch(error => console.error(error));
    }
}

export const tableService = new tablesService();
