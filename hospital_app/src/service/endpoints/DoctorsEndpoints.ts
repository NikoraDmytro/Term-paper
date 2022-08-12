import { DOCTORS_ENDPOINT } from "constants/routes";
import { IDoctor } from "models/Doctor/IDoctor";
import { IPagedList } from "models/IPagedList";
import { hospitalApi } from "service/HospitalService";
import { ICreateDoctor } from "models/Doctor/ICreateDoctor";
import { ISingleDoctor } from "models/Doctor/ISingleDoctor";

type GetDoctorsResponse = {
  pagesQuantity: number;
  doctors: IDoctor[];
};

const ENDPOINT = DOCTORS_ENDPOINT;

export const doctorsApi = hospitalApi.injectEndpoints({
  endpoints: (builder) => ({
    getAllDoctors: builder.query<IPagedList<IDoctor>, Record<string, string>>({
      query: (params) => ({
        url: ENDPOINT,
        params: params,
      }),
      transformResponse: (response: GetDoctorsResponse) => {
        return {
          pagesQuantity: response.pagesQuantity,
          items: response.doctors,
        };
      },

      providesTags: ["Doctors"],
    }),
    getDoctor: builder.query<ISingleDoctor, string>({
      query: (fullName) => ENDPOINT + fullName,
    }),
    createDoctor: builder.mutation<void, ICreateDoctor>({
      query: (doctor) => ({
        url: ENDPOINT,
        method: "POST",
        body: doctor,
      }),

      invalidatesTags: ["Doctors"],
    }),
    deleteDoctor: builder.mutation<void, string>({
      query: (fullName) => ({
        url: ENDPOINT + fullName,
        method: "DELETE",
      }),

      invalidatesTags: ["Doctors"],
    }),
  }),
});

export const {
  useGetDoctorQuery,
  useGetAllDoctorsQuery,
  useCreateDoctorMutation,
  useDeleteDoctorMutation,
} = doctorsApi;
