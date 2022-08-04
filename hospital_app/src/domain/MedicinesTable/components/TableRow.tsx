import { Loader } from "components/Loader";
import { IMedicine } from "models/IMedicine";
import { useDeleteMedicineMutation } from "service/endpoints/MedicinesEndpoint";

import styles from "./TableRow.module.scss";

interface Props {
  medicine: IMedicine;
}

export const TableRow = ({ medicine }: Props) => {
  const [deleteMedicine, { isLoading, isError }] = useDeleteMedicineMutation();

  const handleClick = async (medicineName: string) => {
    const confirmation = window.confirm(
      `Ви впевнені, що ${medicineName} не має більше числитися на складі!`
    );

    if (confirmation) {
      await deleteMedicine(medicineName);

      if (isError) {
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
