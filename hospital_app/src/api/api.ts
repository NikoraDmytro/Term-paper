import axios from "axios";
import { IMedicine } from "models/Medicine/IMedicine";
import {
  BASE_URL,
  HOSPITAL_UNITS_ENDPOINT,
  MEDICINES_ENDPOINT,
} from "constants/routes";
import { IHospitalUnit } from "models/HospitalUnit/IHospitalUnit";

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
