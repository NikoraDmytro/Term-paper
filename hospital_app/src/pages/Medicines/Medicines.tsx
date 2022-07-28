import React from "react";
import { Route, Routes } from "react-router-dom";

import { MainLayout } from "layouts/MainLayout";
import { innerLink } from "shared/types/InnerLink";
import { RefillStock } from "./components/RefillStock";
import { MedicinesTable } from "./components/MedicinesTable";
import { AddMedicineForm } from "./components/AddMedicineForm";

const innerLinks: innerLink[] = [
  {
    to: "/medicines",
    text: "Ліки",
    searchParams: "?PageSize=10&PageNumber=1",
  },
  {
    to: "refillStock",
    text: "Корегування запасів",
  },
  {
    to: "addMedicine",
    text: "Реєстрація нових ліків",
  },
];

export const Medicines = () => {
  return (
    <Routes>
      <Route path="/" element={<MainLayout innerLinks={innerLinks} />}>
        <Route path="/" element={<MedicinesTable />} />
        <Route path="/refillStock" element={<RefillStock />} />
        <Route path="/addMedicine" element={<AddMedicineForm />} />
      </Route>
    </Routes>
  );
};
