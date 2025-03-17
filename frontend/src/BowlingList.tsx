import React, { useEffect } from "react";
import { bowler } from "./types/bowler";
import { useState } from "react";

function BowlingList() {
  const [bowlers, setBowlers] = useState<bowler[]>([]);

  useEffect(() => {
    const fetchBowlers = async () => {
      const response = await fetch("https://localhost:5000/api/Bowler");
      const data = await response.json();

      // Map API response to match the expected TypeScript type
      const formattedBowlers = data.map((b: any) => ({
        ...b,
        teamName: b.teamName ? b.teamName : "No Team",
      }));

      setBowlers(formattedBowlers);
    };

    fetchBowlers();
  }, []);

  return (
    <>
      <h2>Bowler List</h2>
      <table>
        <thead>
          <tr>
            <th>Last Name</th>
            <th>First Name</th>
            <th>M. Initial</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((b) => (
            <tr key={b.bowlerId}>
              <td>{b.bowlerLastName}</td>
              <td>{b.bowlerFirstName}</td>
              <td>{b.bowlerMiddleInit}</td>
              <td>{b.teamName}</td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlingList;
