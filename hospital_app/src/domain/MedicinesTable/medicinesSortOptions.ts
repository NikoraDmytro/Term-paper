import { SortOption } from "shared/types/SortOption";

export const medicinesSortOptions: SortOption[] = [
  {
    name: "Назва [а-я]",
    value: "name",
  },
  {
    name: "Назва [я-а]",
    value: "name desc",
  },
  {
    name: "Кількість (зростання)",
    value: "quantity",
  },
  {
    name: " Кількість (спадання)",
    value: "quantity desc",
  },
];
