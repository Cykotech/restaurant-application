const BASE_URL = 'http://localhost:5238/api';

type RequestOptions = {
    method?: "GET" | "POST" | "PUT" | "DELETE";
    body?: unknown;
    headers?: HeadersInit;
}
export async function apiFetch<TResponse>(endpoint: string, options: RequestOptions = {}): Promise<TResponse> {
    const {method = "GET", body, headers} = options;

    const res = await fetch(`${BASE_URL}${endpoint}`, {
        method,
        headers: {
            'Content-Type': 'application/json',
            ...headers,
        },
        body: body ? JSON.stringify(body) : undefined
    });

    if (!res.ok) {
        const errorText = await res.text();
        throw new Error(`Error ${res.status} ${errorText}`);
    }

    return res.json();
}