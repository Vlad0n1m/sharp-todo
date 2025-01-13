'use client'
import Link from "next/link";
const TaskCard = ({id, name, deadline, status, description, setTaskModal, onDelete}) => {
    const onEdit = () => {
        console.log(id)

    }
    return (
        <div className="rounded-md shadow-md p-4 flex-col gap-4 w-full">
            <div className="flex justify-between items-center">

            <p>{name}</p>
            <div className="text-gray-500 text-sm flex items-center gap-1">{status==="Pending" ? <div className={"w-[6px] h-[6px] bg-yellow-500 rounded-full"} /> : status==="Canceled" ? <div className={"w-[6px] h-[6px] bg-red-500 rounded-full"} /> : <div className={"w-[6px] h-[6px] bg-green-500 rounded-full"} />}{status}</div>
            </div>
            <p className={"text-gray-500 text-sm"}>Description: {description ? description : "no description"}</p>
            <div className="flex justify-between items-center">
                <p>Deadline: {deadline}</p>
                <div className={"flex gap-2 items-center"}>
                    <button onClick={()=>setTaskModal(id)} className="bg-yellow-500 text-white font-bold p-1 rounded-md">Edit</button>
                    <button onClick={()=>onDelete(id)} className="bg-red-500 text-white font-bold p-1 rounded-md">Delete</button>
                </div>
            </div>
        </div>
    )
}

export default TaskCard;