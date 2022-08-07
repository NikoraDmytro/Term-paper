import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

import { BASE_URL } from "constants/routes";

export const hospitalApi = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
  tagTypes: ["Medicine", "Illnesses", "Doctors", "Patients"],
  endpoints: () => ({}),
});
