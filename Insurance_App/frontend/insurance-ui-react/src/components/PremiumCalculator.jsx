import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { API } from "../api";

export default function PremiumCalculator() {
    const [form, setForm] = useState({ 
        name: '', ageNextBirthday: '', 
        dateOfBirth: '', 
        occupationId: '', 
        deathSumInsured: '' 
    });
    const [occupations, setOccupations] = useState([]);
    const [premium, setPremium] = useState(null);

    useEffect(() => { API.get('/occupations').then(r => setOccupations(r.data)); }, []);


    const handleChange = e => {
        const { name, value } = e.target;
        const updated = { ...form, [name]: value };
        setForm(updated);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const payload = { ...form, dateOfBirth: form.dateOfBirth.length === 7 ? `${form.dateOfBirth}-01` : form.dateOfBirth };
        const res = await API.post('/calculate', payload);
        setPremium(res.data.monthlyPremium);
    };

    return (
            <div className="container d-flex justify-content-center mt-5">
            <div className="card shadow p-4" style={{ width: "500px" }}>
                <h3 className="text-center mb-4">Premium Calculator</h3>

                <form onSubmit={handleSubmit}>
                    <div className='row'>
                            <div className='col-md-3'>
                                <label className="form-label fw-semibold">Name</label>
                        
                            </div>
                            <div className='col-md-3'>
                               <input
                                    name="name"
                                    className="form-control"
                                    placeholder="Enter name"
                                    onChange={handleChange}
                                />
                            </div>
                    </div>
                    
                    <div className='row'>
                            <div className='col-md-3'>
                                 <label className="form-label fw-semibold">Age Next Birthday</label>                        
                            </div>
                            <div className='col-md-3'>
                               <input
                                    name="ageNextBirthday"
                                    type="number"
                                    className="form-control"
                                    placeholder="Enter age"
                                    onChange={handleChange}
                                />
                            </div>
                    </div>
                    <div className='row'>
                            <div className='col-md-3'>
                                <label className="form-label fw-semibold">Date of Birth</label>                        
                            </div>
                            <div className='col-md-3'>
                               <input
                                    name="dateOfBirth"
                                    type="date"
                                    className="form-control"
                                    onChange={handleChange}
                                />
                            </div>
                    </div>
                    <div className='row'>
                            <div className='col-md-3'>
                                 <label className="form-label fw-semibold">Occupation</label>
                       
                            </div>
                            <div className='col-md-3'>
                                <select
                                    name="occupationId"
                                    className="form-select"
                                    onChange={handleChange}
                                >
                                    <option value="">Select Occupation</option>
                                    {occupations.map(o => (
                                        <option key={o.id} value={o.id}>
                                            {o.occupationName}
                                        </option>
                                    ))}
                                </select>
                            </div>
                    </div>
                    <div className='row'>
                            <div className='col-md-3'>
                                <label className="form-label fw-semibold">Death Sum Insured</label>
                       
                            </div>
                            <div className='col-md-3'>
                                <input
                                    name="deathSumInsured"
                                    type="number"
                                    className="form-control"
                                    placeholder="Enter amount"
                                    onChange={handleChange}
                                />
                            </div>
                    </div>
                  

                    <div className="d-grid">
                        <button className="btn btn-primary btn-lg" type="submit" >Calculate Premium</button>
                    </div>
                </form>

                {premium && (
                    <div className="alert alert-success text-center mt-4 fs-5 fw-semibold">
                        Monthly Premium: {premium}
                    </div>
                )}
            </div>
        </div>
    );
}