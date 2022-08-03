import React from "react";
import { Routes, Route } from "react-router-dom";

import { MainLayout } from "layouts/MainLayout";
import { innerLink } from "shared/types/InnerLink";

import { NotFound } from "pages/NotFound";
import { IllnessInfo } from "domain/IllnessInfo";
import { IllnessesList } from "domain/IllnessesList";

const innerLinks: innerLink[] = [
  {
    text: "Хвороби",
    to: "/illnesses",
    searchParams: "?PageSize=50&PageNumber=1",
  },
  {
    to: "addIllness",
    text: "Додати хворобу",
  },
];

export const Illnesses = () => {
  return (
    <Routes>
      <Route path="/" element={<MainLayout innerLinks={innerLinks} />}>
        <Route index element={<IllnessesList />} />
        <Route path=":illnessName" element={<IllnessInfo />} />
        <Route path="/addIllness" element={<IllnessesList />} />
      </Route>

      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};
