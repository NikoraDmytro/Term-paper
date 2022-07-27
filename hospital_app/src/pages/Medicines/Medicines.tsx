import React from "react";
import { Route, Routes } from "react-router-dom";

import { MainLayout } from "layouts/MainLayout";
import { RefillStock } from "./components/RefillStock";
import { MedicinesTable } from "./components/MedicinesTable";
import { innerLink } from "shared/types/InnerLink";

const MedicineLayout = () => {
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

  return <MainLayout innerLinks={innerLinks} />;
};

export const Medicines = () => {
  return (
    <Routes>
      <Route path="/" element={<MedicineLayout />}>
        <Route path="/" element={<MedicinesTable />} />
        <Route path="/refillStock" element={<RefillStock />} />
        <Route path="/addMedicine" />
      </Route>
    </Routes>
  );
};
