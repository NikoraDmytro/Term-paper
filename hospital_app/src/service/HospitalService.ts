import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

import { IMedicine } from "models/IMedicine";
import { IUpdateMedicine } from "models/IUpdateMedicine";

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
    createMedicine: builder.mutation<void, IMedicine>({
      query: (medicine) => ({
        url: "/medicines",
        method: "POST",
        body: medicine,
      }),

      invalidatesTags: ["Medicine"],
    }),
    updateMedicines: builder.mutation<void, IUpdateMedicine[]>({
      query: (medicines) => ({
        url: "/medicines",
        method: "PUT",
        body: medicines,
      }),

      invalidatesTags: ["Medicine"],
    }),
    deleteMedicine: builder.mutation<void, string>({
      query: (name) => ({
        url: `medicines/${name}`,
        method: "DELETE",
      }),

      invalidatesTags: ["Medicine"],
    }),
  }),
});

export const {
  useGetAllMedicinesQuery,
  useCreateMedicineMutation,
  useDeleteMedicineMutation,
  useUpdateMedicinesMutation,
} = hospitalApi;
