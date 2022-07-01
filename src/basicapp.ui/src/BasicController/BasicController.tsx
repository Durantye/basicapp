import React, {useState} from "react";
import {CustomerViewModel} from "../ViewModels/CustomerViewModel";
import {ApiStatusReportViewModel} from "../ViewModels/ApiStatusReport";
import './../index.css'
import Table from "../Components/Table";
import './../Components/button.css'

const BasicController = () => {
    const [customers, setCustomers] = useState([] as CustomerViewModel[]);
    const [apiHealth, setApiHealth] = useState(null as ApiStatusReportViewModel | null);

    const handleCustomersClick = async () => {
        try {
            const response = await fetch('api/loadCustomers', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },
            });

            if (response.ok) {
                const result = await response.json();
                setCustomers(prevState => [
                    ...result
                ]);
            } else {
                throw new Error(response.statusText)
            }
        } catch (e: any) {
            console.log(e.message);
        }
    };

    const handleApiStatusClick = async () => {
        try {
            const response = await fetch('api/healthStatus', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },
            });

            if (!response.ok) {
                throw new Error(response.statusText)
            }

            const result = await response.json();
            setApiHealth(prevState => result);
        } catch (e: any) {
            console.log(e.message);
        }
    }

    return (
        <>
            <div className="row mb-2">
                <div className="col-md-6 m-auto">
                    <div className="card">
                        <div className="card-body">
                            <p>Welcome to the DevOps Test.
                                If your backend is configured properly, you should be able to select 
                                <b> Check Health Status</b>. If your database is configured correctly,
                                you should be able to select <b>Load Customers</b>.  If you haven't 
                                built the database using swagger yet, navigate to swagger, and click <b>Build Database</b>.</p>
                        </div>
                    </div>
                </div>
            </div>
            <div className="row mb-2">
                <div className="col-md-6 m-auto">
                    <div className="card">
                        <div className="card-title">
                            Options
                        </div>
                        <div className="card-body">
                            <button className="btn btn-primary" onClick={handleApiStatusClick}>Check Health Status</button>
                            <button className="btn btn-primary" onClick={handleCustomersClick}>Load Customers</button>
                        </div>
                    </div>
                </div>
            </div>
            <div className="row mb-2">
                <div className="col-md-6 m-auto">
                    <div className="card">
                        <div className="card-title">
                            Results
                        </div>
                        <div className="card-body">
                            {apiHealth && JSON.stringify(apiHealth)}
                            <hr/>
                            <Table customers={customers}/>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
};

export default BasicController;