import {CustomerViewModel} from "../ViewModels/CustomerViewModel";
import React from "react";

interface TableProps {
    customers: CustomerViewModel[],
}

const Table = ({customers}: TableProps) => {
    if(customers==null || customers.length==0) return null;

    return (
        <>
            <table className="table">
                <thead>
                <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Phone</th>
                </tr>
                </thead>
                <tbody>
                {customers.map((data, index) => {
                    return (
                        <tr key={index}>
                            <td>{data.name}</td>
                            <td>{data.email}</td>
                            <td>{data.phone}</td>
                        </tr>
                    )
                })}
                </tbody>
            </table>
        </>
    )
};

export default Table;