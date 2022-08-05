import React from "react";
import { ITreatment } from "models/Illness/ITreatment";

interface Props {
  medicines: ITreatment[];
}

export const TreatmentTable = ({ medicines }: Props) => (
  <table>
    <thead>
      <tr>
        <th>Назва</th>
        <th>Кількість</th>
      </tr>
    </thead>

    <tbody>
      {medicines.map((medicine) => (
        <tr key={medicine.medicineName}>
          <td>
            {medicine.medicineName} <span>{medicine.dosageForm}</span>
          </td>
          <td>
            {medicine.quantity} {medicine.unitOfMeasure}
          </td>
        </tr>
      ))}
    </tbody>
  </table>
);
