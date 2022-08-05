import { HOSPITAL_UNITS_ENDPOINT } from "constants/routes";
import { IHospitalUnit } from "models/HospitalUnit/IHospitalUnit";
import { hospitalApi } from "service/HospitalService";

export const hospitalUnitsApi = hospitalApi.injectEndpoints({
  endpoints: (builder) => ({
    getHospitalUnit: builder.query<IHospitalUnit, string>({
      query: (unitName) => ({
        url: HOSPITAL_UNITS_ENDPOINT + unitName,
      }),
    }),
  }),
});

export const { useGetHospitalUnitQuery } = hospitalUnitsApi;
