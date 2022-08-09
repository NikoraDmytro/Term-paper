import { SortOption } from "shared/types/SortOption";

export const sortOptions: SortOption[] = [
  {
    name: "Ім'я [а-я]",
    value: "fullName",
  },
  {
    name: "Ім'я [я-а]",
    value: "fullName desc",
  },
  {
    name: "Вік (Зростання)",
    value: "age",
  },
  {
    name: "Вік (Спадання)",
    value: "age desc",
  },
  {
    name: "Дата запису (Раніше)",
    value: "admissionDate",
  },
  {
    name: "Дата запису (Пізніше)",
    value: "admissionDate desc",
  },
];
