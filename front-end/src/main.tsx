import {StrictMode} from 'react'
import {createRoot} from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import {BrowserRouter, Route, Routes} from "react-router";
import TablesPage from "@/pages/TablesPage.tsx";
import {DefaultLayout} from "@/layouts/DefaultLayout.tsx";
import {TableDetails} from "@/components/tables/TableDetails.tsx";
import {TablesLayout} from "@/layouts/TablesLayout.tsx";

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <BrowserRouter>
            <Routes>
                <Route element={<DefaultLayout/>}>
                    <Route path="/" element={<App/>}/>
                    <Route path="/tables" element={<TablesPage/>}>
                        <Route element={<TablesLayout/>}>
                            <Route path=":id" element={<TableDetails/>}/>
                        </Route>
                    </Route>
                </Route>
            </Routes>
        </BrowserRouter>
    </StrictMode>,
)
