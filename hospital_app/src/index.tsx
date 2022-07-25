import React from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter, Route, Routes } from "react-router-dom";

import App from "./App";
import "./index.css";

const container = document.getElementById("root")!;
const root = createRoot(container);

root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App />} />
        <Route path="/a" element={<App />} />
        <Route path="/b" element={<App />} />
        <Route path="/c" element={<App />} />
        <Route path="/d" element={<App />} />
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);
