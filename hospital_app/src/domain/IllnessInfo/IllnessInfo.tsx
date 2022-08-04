import React from "react";
import { useNavigate, useParams } from "react-router-dom";

import { TreatmentTable } from "./TreatmentTable";
import { Loader } from "components/Loader/Loader";
import { ErrorComponent } from "components/ErrorComponent";

import {
  useDeleteIllnessMutation,
  useGetIllnessQuery,
} from "service/endpoints/IllnessesEndpoints";

import styles from "./styles.module.scss";

export const IllnessInfo = () => {
  const navigate = useNavigate();
  const { illnessName } = useParams();
  const { data, isLoading, error } = useGetIllnessQuery(illnessName ?? "");
  const [deleteIllness, { isLoading: isDeleting, isError }] =
    useDeleteIllnessMutation();

  const handleDelete = async () => {
    const confirmation = window.confirm(
      `Ви впевнені, що хочете видалити ${data?.name.toUpperCase()} з бази даних`
    );

    if (confirmation && data) {
      await deleteIllness(data.name);

      if (isError) {
        window.alert(`Через помилку не вдалося видалити хворобу!`);
      } else {
        window.alert(`${data.name} видалено!`);

        navigate(-1);
      }
    }
  };

  return (
    <div className={styles.illnessInfoBlock}>
      {isLoading && <Loader />}
      {error && <ErrorComponent error={error} />}
      {data && (
        <>
          <h1 className={styles.illnessName}>{data.name}</h1>

          <section className={styles.infoSection}>
            <h3>Симптоми</h3>
            <p>{data.symptoms}</p>
          </section>

          <section className={styles.infoSection}>
            <h3>Процедури</h3>
            <p>{data.procedures}</p>
          </section>

          <section className={styles.tableSection}>
            <h2>Необхідні ліки</h2>

            <TreatmentTable medicines={data.treatments} />
          </section>

          <button onClick={handleDelete} className={styles.deleteItemBtn}>
            {!isDeleting ? "Видалити" : <Loader small />}
          </button>
        </>
      )}
    </div>
  );
};
