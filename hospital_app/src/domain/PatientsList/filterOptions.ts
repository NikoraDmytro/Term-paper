import {
  getDoctorsFullNames,
  getIllnessesNames,
  getWardsNumbers,
} from "api/api";

import { AsyncFilterSelectorProps } from "shared/types/AsyncFilterSelectorProps";

export const filterOptions: AsyncFilterSelectorProps[] = [
  {
    name: "HospitalWardNumber",
    label: "Номер палати",
    request: getWardsNumbers,
  },
  {
    name: "DoctorFullName",
    label: "ФІО персонального лікаря",
    request: getDoctorsFullNames,
  },
  {
    name: "Diagnosis",
    label: "Діагноз",
    request: getIllnessesNames,
  },
];
