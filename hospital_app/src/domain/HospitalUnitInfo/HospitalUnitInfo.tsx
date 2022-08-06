import React from "react";
import { useParams } from "react-router-dom";

import { useGetHospitalUnitQuery } from "service/endpoints/HospitalUnitsEndpoints";

import { Loader } from "components/Loader/Loader";
import { Statistics } from "./components/Statistics";
import { ErrorComponent } from "components/ErrorComponent/ErrorComponent";

import styles from "./styles.module.scss";

export const HospitalUnitInfo = () => {
  const { unitName } = useParams();
  const {
    data: unit,
    isLoading,
    error,
  } = useGetHospitalUnitQuery(unitName ?? "");

  return (
    <>
      {isLoading && <Loader />}
      {error && <ErrorComponent error={error} />}
      {unit && (
        <>
          <h1 className={styles.unitName}>{unit.name}</h1>

          <Statistics unit={unit} />

          <h2>Лікарі</h2>

          <h2>Палати</h2>
        </>
      )}
    </>
  );
};
