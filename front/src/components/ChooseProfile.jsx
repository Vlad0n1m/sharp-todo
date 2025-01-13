'use client'
import ProfileCard from "@/components/ProfileCard";
import {useEffect, useState} from "react";
import ProfileModal from "@/components/ProfileModal";

const ChooseProfile = () => {
    const [profiles, setProfiles] = useState([{id: 1, name: 'ase'}])
    const [profilesLoading, setProfileLoading] = useState(true);
    const [isOpen, setOpen ] = useState(false);

    const fetchUsers = async () => {
        setProfileLoading(true)
        const res = await fetch('http://localhost:5208/api/users/', {
            method: "GET",
        });
        const data = await res.json();
        setProfiles(data);
        setProfileLoading(false);
    };
    useEffect(() => {

        fetchUsers();
    }, []);

    const createProfile = async (name, email, password) => {
        console.log('creating')
        const response = await fetch("http://localhost:5208/api/users/", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                "name": name,
                "email": email,
                "passwordHash": password
            })
        })
        fetchUsers();
    }

    const OnDelete = async (id) => {
        const response = await fetch(`http://localhost:5208/api/users/${id}`, {
            method: "DELETE"
        })
        fetchUsers();
    }

    return (
        <div className="w-full">
            <div className="flex justify-between items-center my-10">
                <h3 className="text-lg">Choose Profile</h3>
                <button onClick={() => setOpen(true)}
                        className="bg-green-400 text-white font-bold text-lg p-2 rounded-xl">Add +
                </button>
            </div>
            <div className="flex flex-col gap-2 bg-white shadow-md rounded-md">
                {profilesLoading ? <p>Loading...</p> : profiles.map(profile => (
                    <ProfileCard key={profile.id} id={profile.id} name={profile.name} email={profile.email}
                                 taskCount={profile.todoItems.length} onDelete={OnDelete}/>))}
            </div>
            <ProfileModal createProfile={createProfile} profileModal={isOpen} onClose={() => setOpen(false)} />
        </div>

    )
}

export default ChooseProfile;