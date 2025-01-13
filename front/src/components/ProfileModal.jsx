'use client'
import {useEffect, useState} from "react";

const ProfileModal = ({profileModal, onClose, createProfile}) => {
    const [data, setData] = useState({});
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    if (profileModal === false) {
        return (<></>)
    } else {
        return (
            <>
                <div className={"h-screen w-screen absolute top-0 left-0 flex items-center justify-center"}>
                    <div onClick={() => onClose()}
                         className={"cursor-pointer bg-black opacity-50 h-screen w-screen absolute top-0 left-0 flex items-center justify-center"}></div>
                    <div className={"w-[500px] bg-white shadow-md rounded-lg opacity-100 relative p-6"}>
                        <button className={"absolute top-4 right-4"} onClick={() => onClose()}>X</button>
                        <div className={"mb-5 flex flex-col gap-2"}>
                            <label>Name</label>
                            <input value={name} className={"p-2 rounded-md border-2 border-gray-200"} placeholder={"Name"} onChange={(event) => setName(event.target.value)}></input>
                        </div>
                        <div className={"mb-5 flex flex-col gap-2"}>
                            <label>Email</label>
                            <textarea value={email} className={"p-2 rounded-md border-2 border-gray-200"} placeholder={"Email"} onChange={(event) => setEmail(event.target.value)}></textarea>
                        </div>
                        <div className={"mb-5 flex flex-col gap-2"}>
                            <label>Password</label>
                            <input type="password" value={password} className={"p-2 rounded-md border-2 border-gray-200"} placeholder={"Password"} onChange={(event) => setPassword(event.target.value)}></input>
                        </div>

                        <button className={"bg-green-500 text-white w-full p-3 rounded-md"} onClick={()=>{createProfile(name, email, password); onClose(); setName(""); setEmail(""); setPassword("");}}>Save</button>

                    </div>

                </div>
            </>
        )
    }
}

export default ProfileModal;