import React, { useState, useEffect } from "react";
import { API } from "../api";

export default function PremiumCalculator() {
  const [form, setForm] = useState({
    name: "",
    ageNextBirthday: "",
    dateOfBirth: "",
    occupationId: "",
    deathSumInsured: ""
  });
  const [occupations, setOccupations] = useState([]);
  const [premium, setPremium] = useState(null);

  useEffect(() => {
    API.get("/occupations").then((res) => setOccupations(res.data));
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    const updated = { ...form, [name]: value };
    setForm(updated);

    if (name === "occupationId" && value && form.name && form.ageNextBirthday && form.dateOfBirth && form.deathSumInsured) {
      calculatePremium(updated);
    }
  };

  const calculatePremium = async (data) => {
    try {
        console.log(data);
      const res = await API.post("/calculate", data);
      console.log(res);
      setPremium(res.data.monthlyPremium.toFixed(2));
    } catch (err) {
      alert("Error calculating premium");
    }
  };

  return (
    <div className="container mx-auto p-6 max-w-md shadow-md rounded-2xl bg-white">
      <h2 className="text-xl font-bold mb-4">Monthly Premium Calculator</h2>
      <input type="text" name="name" placeholder="Name" className="input mb-2" onChange={handleChange} />
      <input type="number" name="ageNextBirthday" placeholder="Age Next Birthday" className="input mb-2" onChange={handleChange} />
      <input type="date" name="dateOfBirth" placeholder="Date of Birth" className="input mb-2" onChange={handleChange} />
      <input type="number" name="deathSumInsured" placeholder="Death – Sum Insured" className="input mb-2" onChange={handleChange} />

      <select name="occupationId" className="input mb-4" onChange={handleChange}>
        <option value="">Select Occupation</option>
        {occupations.map((o) => (
          <option key={o.id} value={o.id}>{o.occupationName}</option>
        ))}
      </select>

      {premium && <div className="text-lg font-semibold text-green-600">Monthly Premium: ${premium}</div>}
    </div>
  );
}
