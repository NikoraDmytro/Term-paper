import axios from "axios";
import {
  BASE_URL,
  DOCTORS_ENDPOINT,
  HOSPITAL_UNITS_ENDPOINT,
  HOSPITAL_WARDS_ENDPOINT,
  ILLNESSES_ENDPOINT,
  MEDICINES_ENDPOINT,
} from "constants/routes";

import { IDoctor } from "models/Doctor/IDoctor";
import { IMedicine } from "models/Medicine/IMedicine";
import { IHospitalUnit } from "models/HospitalUnit/IHospitalUnit";
import { IHospitalWard } from "models/HospitalWard/IHospitalWard";

const instance = axios.create({
  baseURL: BASE_URL,
  timeout: 10000,
});

export const getHospitalUnitsNames = async (): Promise<string[]> => {
  const response = await instance.get<IHospitalUnit[]>(HOSPITAL_UNITS_ENDPOINT);

  const names = response.data.map((unit) => unit.name);

  return names;
};

export const getMedicinesNames = async (search: string): Promise<string[]> => {
  const response = await instance.get<{ medicines: IMedicine[] }>(
    MEDICINES_ENDPOINT + `?SearchTerm=${search}`
  );

  const names = response.data.medicines.map((medicine) => medicine.name);

  return names;
};

export const getIllnessesNames = async (search: string): Promise<string[]> => {
  const response = await instance.get<{ illnesses: string[] }>(
    ILLNESSES_ENDPOINT + `?SearchTerm=${search}`
  );

  return response.data.illnesses;
};

export const getDoctorsFullNames = async (
  search: string
): Promise<string[]> => {
  const response = await instance.get<{ doctors: IDoctor[] }>(
    DOCTORS_ENDPOINT + `?SearchTerm=${search}`
  );

  const fullNames = response.data.doctors.map((doctor) => doctor.fullName);

  return fullNames;
};

export const getWardsNumbers = async (search: string): Promise<string[]> => {
  const response = await instance.get<{
    hospitalWards: IHospitalWard[];
  }>(HOSPITAL_WARDS_ENDPOINT + `?SearchTerm=${search}`);

  const wardsNumbers = response.data.hospitalWards.map((ward) =>
    ward.number.toString()
  );
  console.log(wardsNumbers);

  return wardsNumbers;
};
