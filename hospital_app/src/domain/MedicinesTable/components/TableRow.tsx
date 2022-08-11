import { Loader } from "components/Loader";
import { IMedicine } from "models/Medicine/IMedicine";
import { useDeleteMedicineMutation } from "service/endpoints/MedicinesEndpoints";

import styles from "./TableRow.module.scss";

interface Props {
  medicine: IMedicine;
}

export const TableRow = ({ medicine }: Props) => {
  const [deleteMedicine, { isLoading }] = useDeleteMedicineMutation();

  const handleClick = async (medicineName: string) => {
    const confirmation = window.confirm(
      `Ви впевнені, що ${medicineName} не має більше числитися на складі!`
    );

    if (confirmation) {
      const response = await deleteMedicine(medicineName);

      if ("error" in response) {
        window.alert(`Через помилку не вдалося вилучити ліки зі складу`);
      } else {
        window.alert(`${medicineName} більше не числитися на складі!`);
      }
    }
  };

  return (
    <tr>
      <td>
        {medicine.name}{" "}
        <span className={styles.dosageForm}>{medicine.dosageForm}</span>
      </td>
      <td>
        {medicine.quantityInStock} {medicine.unitOfMeasure}
      </td>
      <td>
        <button
          className={styles.deleteMedicineBtn}
          onClick={() => handleClick(medicine.name)}
        >
          {!isLoading ? "Вилучити зі складу" : <Loader small />}
        </button>
      </td>
    </tr>
  );
};
