'use client'
import Link from "next/link";
const ProfileCard = ({id, name, email, taskCount, onDelete}) => {
    return (
        <Link href={`/users/${id}`} className="rounded-md shadow-md p-4 flex-col gap-4 w-full">
            <div className="flex justify-between items-center">

            <p>{name}</p>
            <p className="text-gray-500 text-sm ">{email}</p>
            </div>
            <div className="flex justify-between items-center">
                <p>Tasks: {taskCount}</p>
                <button onClick={()=>onDelete(id)} className="bg-red-500 text-white font-bold p-1 rounded-md">Delete</button>
            </div>
        </Link>
    )
}

export default ProfileCard;