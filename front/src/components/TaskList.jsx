'use client'
import ProfileCard from "@/components/ProfileCard";
import {useEffect, useState} from "react";
import TaskCard from "@/components/TaskCard";
import TaskModal from "@/components/TaskModal";

const TaskList = ({userId}) => {
    const [tasks, setTasks] = useState()
    const [tasksLoading, setTasksLoading] = useState(true);
    const [taskModal, setTaskModal] = useState("0");
    const fetchUserTasks = async () => {
        setTasksLoading(true)
        const res = await fetch(`http://localhost:5208/api/tasks/user/${userId}`, {
            method: "GET",
        });
        const data = await res.json();
        setTasks(data);
        setTasksLoading(false);
    };
    useEffect(() => {
        fetchUserTasks();
    }, []);


    const CreateTask = async () => {
        console.log('creating')
        const response = await fetch("http://localhost:5208/api/tasks/", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                "name": "string",
                "description": "string",
                "deadLine": "2025-01-12T15:26:22.642Z",
                "userId": userId
            })
        })
        fetchUserTasks();
    }

    const DeleteTask = async (id) => {
        const response = await fetch(`http://localhost:5208/api/tasks/${id}`, {
            method: "DELETE"
        })
        fetchUserTasks();
    }
    const UpdateTask = async (data) => {
        const response = await fetch(`http://localhost:5208/api/tasks/${taskModal}`, {
            method: "PUT",
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        })
        setTaskModal("0");
        fetchUserTasks(userId);
    }
    return (
        <div className="w-full">
            <div className="flex justify-between items-center my-10">
                <h3 className="text-lg">Task List</h3>
                <button onClick={() => CreateTask()}
                        className="bg-green-400 text-white font-bold text-lg p-2 rounded-xl">Add +
                </button>
            </div>
            <div className="flex flex-col gap-2 bg-white shadow-md rounded-md">
                {tasksLoading ? 'Loading...' : tasks ? tasks.map(t => <TaskCard key={t.id} id={t.id} name={t.name} deadline={t.deadLine}  description={t.description} status={t.status} setTaskModal={setTaskModal} onDelete={DeleteTask}/>): "No tasks"}
            </div>
            <TaskModal taskModal={taskModal} updateTask={UpdateTask} setTaskModal={setTaskModal} />
        </div>

    )
}

export default TaskList;