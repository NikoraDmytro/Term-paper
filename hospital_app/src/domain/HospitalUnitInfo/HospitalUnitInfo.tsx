import React from "react";
import { useParams } from "react-router-dom";

import { useGetHospitalUnitQuery } from "service/endpoints/HospitalUnitsEndpoints";

import { Loader } from "components/Loader/Loader";
import { ErrorComponent } from "./../../components/ErrorComponent/ErrorComponent";

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
        <div>
          <h1>{unit.name}</h1>

          <ul>
            <li>{unit.wardsQuantity} Палати</li>
            <li>{unit.doctorsQuantity} Лікарів</li>
            <li>{unit.totalOccupancy} Хворих</li>
          </ul>
        </div>
      )}
    </>
  );
};
