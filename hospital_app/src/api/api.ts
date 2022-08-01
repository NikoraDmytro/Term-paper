import axios from "axios";
import { IMedicine } from "models/IMedicine";
import { BASE_URL, MEDICINES_ENDPOINT } from "constants/routes";

const instance = axios.create({
  baseURL: BASE_URL,
  timeout: 10000,
});

export const getMedicinesNames = async (search: string): Promise<string[]> => {
  const response = await instance.get<{ medicines: IMedicine[] }>(
    MEDICINES_ENDPOINT + `?SearchTerm=${search}`
  );

  const names = response.data.medicines.map((medicine) => medicine.name);

  return names;
};
