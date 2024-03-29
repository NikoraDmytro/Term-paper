import React from "react";
import { useParams } from "react-router-dom";

import { useGetHospitalUnitQuery } from "service/endpoints/HospitalUnitsEndpoints";

import { Loader } from "components/Loader/Loader";
import { Statistics } from "./components/Statistics";
import { ErrorComponent } from "components/ErrorComponent/ErrorComponent";

import styles from "./styles.module.scss";
import { UnitWards } from "domain/PagedLists/UnitWards";

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

          <h2 className={styles.subTitle}>Палати</h2>

          <UnitWards />
        </>
      )}
    </>
  );
};
