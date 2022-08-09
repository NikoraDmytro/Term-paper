import React from "react";
import { Routes, Route } from "react-router-dom";

import { MainLayout } from "layouts/MainLayout";
import { innerLink } from "shared/types/InnerLink";

import { NotFound } from "pages/NotFound";
import { PatientsList } from "domain/PagedLists/PatientsList";
import { PatientForm } from "domain/Forms/PatientForm";

const innerLinks: innerLink[] = [
  {
    text: "Хворі",
    to: "/patients",
    searchParams: "?PageSize=5&PageNumber=1",
  },
  {
    to: "addPatient",
    text: "Зареєструвати пацієнта",
  },
];

export const Patients = () => {
  return (
    <Routes>
      <Route path="/" element={<MainLayout innerLinks={innerLinks} />}>
        <Route index element={<PatientsList />} />
        <Route path="addPatient" element={<PatientForm />} />
      </Route>

      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};
