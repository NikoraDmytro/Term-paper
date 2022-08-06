import {
  DOCTORS_ENDPOINT,
  HOSPITAL_UNITS_ENDPOINT,
  HOSPITAL_WARDS_ENDPOINT,
} from "constants/routes";

import { hospitalApi } from "service/HospitalService";
import { IHospitalUnit } from "models/HospitalUnit/IHospitalUnit";
import { IHospitalWard } from "models/HospitalWard/IHospitalWard";
import { IPagedList } from "models/IPagedList";
import { IDoctor } from "models/Doctor/IDoctor";

type GetDoctorsResponse = {
  pagesQuantity: number;
  doctors: IDoctor[];
};

type GetWardsResponse = {
  pagesQuantity: number;
  hospitalWards: IHospitalWard[];
};

type GetChildrenResourcesParams = {
  unitName: string;
  searchParams: Record<string, string>;
};

const ENDPOINT = HOSPITAL_UNITS_ENDPOINT;

export const hospitalUnitsApi = hospitalApi.injectEndpoints({
  endpoints: (builder) => ({
    getHospitalUnit: builder.query<IHospitalUnit, string>({
      query: (unitName) => ({
        url: ENDPOINT + unitName,
      }),
    }),
    getHospitalUnitDoctors: builder.query<
      IPagedList<IDoctor>,
      GetChildrenResourcesParams
    >({
      query: ({ unitName, searchParams }) => ({
        url: ENDPOINT + unitName + "/" + DOCTORS_ENDPOINT,
        params: searchParams,
      }),
      transformResponse: (response: GetDoctorsResponse) => {
        return {
          pagesQuantity: response.pagesQuantity,
          items: response.doctors,
        };
      },
    }),
    getHospitalUnitWards: builder.query<
      IPagedList<IHospitalWard>,
      GetChildrenResourcesParams
    >({
      query: ({ unitName, searchParams }) => ({
        url: ENDPOINT + unitName + "/" + HOSPITAL_WARDS_ENDPOINT,
        params: searchParams,
      }),
      transformResponse: (response: GetWardsResponse) => {
        return {
          pagesQuantity: response.pagesQuantity,
          items: response.hospitalWards,
        };
      },
    }),
  }),
});

export const {
  useGetHospitalUnitQuery,
  useGetHospitalUnitDoctorsQuery,
  useGetHospitalUnitWardsQuery,
} = hospitalUnitsApi;
