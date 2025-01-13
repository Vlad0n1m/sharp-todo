import ProfileCard from "@/components/ProfileCard";
import TaskList from "@/components/TaskList";

export default async function Page({params}){
    const id = (await params).id
    return (
        <TaskList userId={id}/>
    )
}