import React from "react";
import { Route, Routes } from "react-router-dom";

import { MedicinesTable } from "./components/MedicinesTable";
import { MainLayout } from "../../layouts/MainLayout";

export const Medicines = () => {
  return (
    <Routes>
      <Route path="/" element={<MainLayout />}>
        <Route index element={<MedicinesTable />} />
        <Route path="/refillStock" />
        <Route path="/addMedicine" />
      </Route>
    </Routes>
  );
};
