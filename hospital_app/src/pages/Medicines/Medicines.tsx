import React from "react";
import { Route, Routes } from "react-router-dom";

import { NotFound } from "pages/NotFound";
import { MainLayout } from "layouts/MainLayout";
import { innerLink } from "shared/types/InnerLink";

import { MedicinesTable } from "domain/MedicinesTable";
import { MedicineForm } from "domain/Forms/MedicineForm";
import { RefillMedicinesStock } from "domain/Forms/RefillMedicinesStock";

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
        <Route index element={<MedicinesTable />} />
        <Route path="/refillStock" element={<RefillMedicinesStock />} />
        <Route path="/addMedicine" element={<MedicineForm />} />
      </Route>

      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};
