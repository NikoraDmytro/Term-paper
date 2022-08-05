import { HOSPITAL_UNITS_ENDPOINT } from "constants/routes";
import { IHospitalUnit } from "models/HospitalUnit/IHospitalUnit";
import { hospitalApi } from "service/HospitalService";

export const hospitalUnitsApi = hospitalApi.injectEndpoints({
  endpoints: (builder) => ({
    getHospitalUnits: builder.query<IHospitalUnit[], void>({
      query: () => ({
        url: HOSPITAL_UNITS_ENDPOINT,
      }),
    }),
  }),
});

export const { useGetHospitalUnitsQuery } = hospitalUnitsApi;
