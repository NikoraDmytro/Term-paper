import React from "react";
import { Route, Routes } from "react-router-dom";

import { Doctors } from "pages/Doctors";
import { NotFound } from "pages/NotFound";
import { Patients } from "pages/Patients";
import { Illnesses } from "pages/Illnesses";
import { Medicines } from "pages/Medicines";
import { LandingPage } from "pages/Landing";
import { HospitalUnits } from "pages/HospitalUnits";

import { AppLayout } from "layouts/AppLayout";

function App() {
  return (
    <Routes>
      <Route path="/" element={<AppLayout />}>
        <Route index element={<LandingPage />} />

        <Route path="doctors" element={<Doctors />} />
        <Route path="patients" element={<Patients />} />
        <Route path="medicines" element={<Medicines />} />
        <Route path="illnesses" element={<Illnesses />} />
        <Route path="hospitalUnits" element={<HospitalUnits />} />
      </Route>

      <Route path="*" element={<NotFound />} />
    </Routes>
  );
}

export default App;
