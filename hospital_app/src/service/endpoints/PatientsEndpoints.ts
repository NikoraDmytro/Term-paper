import { PATIENTS_ENDPOINT } from "constants/routes";
import { IPagedList } from "models/IPagedList";
import { hospitalApi } from "service/HospitalService";
import { IPatient } from "models/Patient/IPatient";
import { ICreatePatient } from "models/Patient/ICreatePatient";

type GetPatientsResponse = {
  pagesQuantity: number;
  patients: IPatient[];
};

const ENDPOINT = PATIENTS_ENDPOINT;

export const patientsApi = hospitalApi.injectEndpoints({
  endpoints: (builder) => ({
    getAllPatients: builder.query<IPagedList<IPatient>, Record<string, string>>(
      {
        query: (params) => ({
          url: ENDPOINT,
          params: params,
        }),
        transformResponse: (response: GetPatientsResponse) => {
          return {
            pagesQuantity: response.pagesQuantity,
            items: response.patients,
          };
        },

        providesTags: ["Patients"],
      }
    ),
    createPatient: builder.mutation<void, ICreatePatient>({
      query: (patient) => ({
        url: ENDPOINT,
        method: "POST",
        body: patient,
      }),

      invalidatesTags: ["Patients"],
    }),
    deletePatient: builder.mutation<void, string>({
      query: (fullName) => ({
        url: ENDPOINT + fullName,
        method: "DELETE",
      }),

      invalidatesTags: ["Patients"],
    }),
  }),
});

export const {
  useGetAllPatientsQuery,
  useCreatePatientMutation,
  useDeletePatientMutation,
} = patientsApi;
