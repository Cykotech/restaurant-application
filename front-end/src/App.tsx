import './App.css'
import {Card, CardContent, CardDescription, CardHeader, CardTitle} from "@/components/ui/card.tsx";

function App() {

    return (
        <>
            <p>Home</p>
            <Card>
                <CardHeader>
                    <CardTitle>Data Card</CardTitle>
                    <CardDescription>Placeholder for data</CardDescription>
                </CardHeader>
                <CardContent>
                    <p>Data...</p>
                </CardContent>
            </Card>
        </>)
}

export default App
