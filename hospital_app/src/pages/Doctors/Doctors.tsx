import React from "react";
import { Routes, Route } from "react-router-dom";

import { MainLayout } from "layouts/MainLayout";
import { innerLink } from "shared/types/InnerLink";

import { NotFound } from "pages/NotFound";
import { DoctorForm } from "domain/Forms/DoctorForm";
import { DoctorsList } from "domain/PagedLists/DoctorsList";

const innerLinks: innerLink[] = [
  {
    text: "Лікарі",
    to: "/doctors",
    searchParams: "?PageSize=6&PageNumber=1",
  },
  {
    to: "hireDoctor",
    text: "Взяти на роботу",
  },
];

export const Doctors = () => {
  return (
    <Routes>
      <Route path="/" element={<MainLayout innerLinks={innerLinks} />}>
        <Route index element={<DoctorsList />} />
        <Route path="hireDoctor" element={<DoctorForm />} />
      </Route>

      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};
