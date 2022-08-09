import { SortOption } from "shared/types/SortOption";

export const sortingOptions: SortOption[] = [
  {
    name: "ФІО [а-я]",
    value: "fullName",
  },
  {
    name: "ФІО [я-а]",
    value: "fullName desc",
  },
  {
    name: "Вік (зростання)",
    value: "age",
  },
  {
    name: "Вік (спадання)",
    value: "age desc",
  },
  {
    name: "Досвід (зростання)",
    value: "experience",
  },
  {
    name: "Досвід (спадання)",
    value: "experience desc",
  },
];
