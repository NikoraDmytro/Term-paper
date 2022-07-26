import React from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter, Route, Routes } from "react-router-dom";

import "./index.css";
import App from "./App";
import { Doctors } from "./pages/Doctors";
import { Patients } from "./pages/Patients";
import { LandingPage } from "./pages/Landing";
import { Medicines } from "./pages/Medicines";
import { Illnesses } from "./pages/Illnesses";
import { NotFound } from "./pages/NotFound/NotFound";
import { HospitalUnits } from "./pages/HospitalUnits";

const container = document.getElementById("root")!;
const root = createRoot(container);

root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App />}>
          <Route index element={<LandingPage />} />

          <Route path="hospitalUnits" element={<HospitalUnits />} />
          <Route path="patients" element={<Patients />} />
          <Route path="doctors" element={<Doctors />} />
          <Route path="medicines" element={<Medicines />} />
          <Route path="illnesses" element={<Illnesses />} />
        </Route>

        <Route path="*" element={<NotFound />} />
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);
