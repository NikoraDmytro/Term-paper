import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

import { IMedicine } from "models/IMedicine";

interface IPagedMedicinesList {
  pagesQuantity: number;
  medicines: IMedicine[];
}

const BASE_URL = "https://localhost:5001/api";

export const hospitalApi = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
  tagTypes: ["Medicine"],
  endpoints: (builder) => ({
    getAllMedicines: builder.query<IPagedMedicinesList, Record<string, string>>(
      {
        query: (params) => ({
          url: "/medicines",
          params: params,
        }),

        providesTags: ["Medicine"],
      }
    ),
  }),
});

export const { useGetAllMedicinesQuery } = hospitalApi;
