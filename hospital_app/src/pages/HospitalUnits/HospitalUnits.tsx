import React from "react";
import { Route, Routes, useParams, Link } from "react-router-dom";

import { MainLayout } from "layouts/MainLayout";

import { Loader } from "components/Loader";
import { NotFound } from "pages/NotFound";
import { ErrorComponent } from "components/ErrorComponent";

import { useGetHospitalUnitsQuery } from "service/endpoints/HospitalUnitsEndpoints";

const HospitalUnitsList = () => {
  const { data, isLoading, error } = useGetHospitalUnitsQuery();

  return (
    <ul>
      {isLoading && <Loader />}
      {error && <ErrorComponent error={error} />}
      {data &&
        data.map((unit) => (
          <Link to={encodeURIComponent(unit.name)}>
            <li>{unit.name}</li>
          </Link>
        ))}
    </ul>
  );
};

const HospitalUnit = () => {
  const { unitName } = useParams();
  const { data, isLoading, error } = useGetHospitalUnitsQuery();

  return (
    <>
      {isLoading && <Loader />}
      {error && <ErrorComponent error={error} />}
      {data && data.map((unit) => unit.name === unitName && <p>{unit.name}</p>)}
    </>
  );
};

export const HospitalUnits = () => {
  return (
    <Routes>
      <Route path="/" element={<MainLayout />}>
        <Route index element={<HospitalUnitsList />} />
        <Route path=":unitName" element={<HospitalUnit />} />
      </Route>

      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};
