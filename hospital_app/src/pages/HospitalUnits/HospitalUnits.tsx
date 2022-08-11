import React from "react";
import { Route, Routes } from "react-router-dom";

import { MainLayout } from "layouts/MainLayout";

import { NotFound } from "pages/NotFound";
import { UnitWards } from "domain/PagedLists/UnitWards";
import { HospitalUnitsList } from "domain/HospitalUnitsList";
import { HospitalUnitInfo } from "domain/HospitalUnitInfo/HospitalUnitInfo";

export const HospitalUnits = () => {
  return (
    <Routes>
      <Route path="/" element={<MainLayout />}>
        <Route index element={<HospitalUnitsList />} />

        <Route path=":unitName" element={<HospitalUnitInfo />}>
          <Route path="wards" element={<UnitWards />} />
        </Route>
      </Route>

      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};
