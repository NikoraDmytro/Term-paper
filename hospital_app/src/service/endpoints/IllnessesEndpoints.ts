import { ILLNESSES_ENDPOINT } from "constants/routes";
import { IIllness } from "models/IIllness";
import { IPagedList } from "models/IPagedList";
import { hospitalApi } from "service/HospitalService";
import { ICreateIllness } from "./../../models/ICreateIllness";

type GetIllnessesResponse = {
  pagesQuantity: number;
  illnesses: string[];
};

export const illnessesApi = hospitalApi.injectEndpoints({
  endpoints: (builder) => ({
    getIllnessesNames: builder.query<
      IPagedList<string>,
      Record<string, string>
    >({
      query: (params) => ({
        url: ILLNESSES_ENDPOINT,
        params: params,
      }),
      transformResponse: (response: GetIllnessesResponse) => {
        return {
          items: response.illnesses,
          pagesQuantity: response.pagesQuantity,
        };
      },

      providesTags: ["Illnesses"],
    }),
    getIllness: builder.query<IIllness, string>({
      query: (name) => ILLNESSES_ENDPOINT + name,
    }),
    createIllness: builder.mutation<void, ICreateIllness>({
      query: (illness) => ({
        url: ILLNESSES_ENDPOINT,
        method: "POST",
        body: illness,
      }),

      invalidatesTags: ["Illnesses"],
    }),
    deleteIllness: builder.mutation<void, string>({
      query: (name) => ({
        url: ILLNESSES_ENDPOINT + name,
        method: "DELETE",
      }),

      invalidatesTags: ["Illnesses"],
    }),
  }),
});

export const {
  useCreateIllnessMutation,
  useDeleteIllnessMutation,
  useGetIllnessQuery,
  useGetIllnessesNamesQuery,
} = illnessesApi;
