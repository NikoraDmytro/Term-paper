import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

import { IMedicine } from "models/IMedicine";
import { IPagedList } from "models/IPagedList";
import { IUpdateMedicine } from "models/IUpdateMedicine";
import { BASE_URL, MEDICINES_ENDPOINT } from "constants/routes";

type Response = {
  pagesQuantity: number;
  medicines: IMedicine[];
};

export const hospitalApi = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
  tagTypes: ["Medicine"],
  endpoints: (builder) => ({
    getAllMedicines: builder.query<
      IPagedList<IMedicine>,
      Record<string, string>
    >({
      query: (params) => ({
        url: MEDICINES_ENDPOINT,
        params: params,
      }),
      transformResponse: (response: Response) => {
        return {
          pagesQuantity: response.pagesQuantity,
          items: response.medicines,
        };
      },

      providesTags: ["Medicine"],
    }),
    createMedicine: builder.mutation<void, IMedicine>({
      query: (medicine) => ({
        url: MEDICINES_ENDPOINT,
        method: "POST",
        body: medicine,
      }),

      invalidatesTags: ["Medicine"],
    }),
    updateMedicines: builder.mutation<void, IUpdateMedicine[]>({
      query: (medicines) => ({
        url: MEDICINES_ENDPOINT,
        method: "PUT",
        body: medicines,
      }),

      invalidatesTags: ["Medicine"],
    }),
    deleteMedicine: builder.mutation<void, string>({
      query: (name) => ({
        url: MEDICINES_ENDPOINT + name,
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
