'use client'
import {useEffect, useState} from "react";

const TaskModal = ({taskModal, setTaskModal, updateTask}) => {
    const [data, setData] = useState({});
    const [loading, setLoading] = useState(true);
    const [newName, setName] = useState("");
    const [newDescriptrion, setDescription] = useState("");
    const [newDeadline, setDeadline] = useState("");
    const [newStatus, setStatus] = useState("")
    const onClose = () => {
        setTaskModal("0");
        console.log(taskModal)
    }

    const fetchTask = async () => {
        if (taskModal==="0") {
            return
        }

        setLoading(true)
        const response = await fetch(`http://localhost:5208/api/tasks/${taskModal}`, {
            method: "GET"
        })
        const data = await response.json()
        setData(data);
        setName(data.name);
        setDescription(data.description);
        setStatus(data.status)
        setLoading(false);
    }
    useEffect(() => {
        fetchTask(taskModal);
    }, [taskModal]);



    if (taskModal === "0") {
        return (<></>)
    } else {
        return (
            <>
                <div className={"h-screen w-screen absolute top-0 left-0 flex items-center justify-center"}>
                    <div onClick={() => onClose()}
                         className={"cursor-pointer bg-black opacity-50 h-screen w-screen absolute top-0 left-0 flex items-center justify-center"}></div>
                    <div className={"w-[500px] bg-white shadow-md rounded-lg opacity-100 relative p-6"}>
                        <button className={"absolute top-4 right-4"} onClick={() => onClose()}>X</button>
                        <h1 className={"w-full font-bold text-center mb-12"}>{loading ? "Loading..." : data.name}</h1>
                        <div className={"mb-5 flex flex-col gap-2"}>
                            <label>Name</label>
                            <input value={newName} className={"p-2 rounded-md border-2 border-gray-200"} placeholder={"Task name"} onChange={(event) => setName(event.target.value)}></input>
                        </div>
                        <div className={"mb-5 flex flex-col gap-2"}>
                            <label>Description</label>
                            <textarea value={newDescriptrion} className={"p-2 rounded-md border-2 border-gray-200"} placeholder={"Task description"} onChange={(event) => setDescription(event.target.value)}></textarea>
                        </div>
                        <div className={"mb-5 flex flex-col gap-2"}>
                            <label>Deadline</label>
                            <input type="datetime-local" value={newDeadline} className={"p-2 rounded-md border-2 border-gray-200"} placeholder={"Task name"} onChange={(event) => setDeadline(event.target.value)}></input>
                        </div>
                        <div className={"mb-5 flex flex-col gap-2"}>
                            <label>Status</label>
                            <select value={newStatus} onChange={(event) => setStatus(event.target.value)}>
                                <option value="Pending">Pending</option>
                                <option value="InProgress">InProgress</option>
                                <option value="Completed">Completed</option>
                                <option value="Canceled">Canceled</option>
                            </select>
                        </div>

                        <button className={"bg-green-500 text-white w-full p-3 rounded-md"} onClick={()=>updateTask({name: newName, status: newStatus, description: newDescriptrion, deadline:newDeadline})}>Save</button>

                    </div>

                </div>
            </>
        )
    }
}

export default TaskModal;