import React from "react";
import * as data from './constants'

export default function Logs() {
  return( 
  
    <div className = "Logs">
      <table> 
        <tr> 
          <th>Action</th>
          <th>People</th>
          <th>Week Completed</th>
        </tr>
        {data.DevLog.map((val, key) => {
          return (
            <tr key={key}>
              <td>{val.Action}</td>
              <td>{val.People}</td>
              <td>{val.Week}</td>
            </tr>
          )
        })}
      </table>
    </div>
   
  )
}