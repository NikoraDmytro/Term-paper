import * as Yup from "yup";

const getMaxBirthDate = () => {
  const now = new Date();

  const EighteenYearsAgo = new Date(now.setFullYear(now.getFullYear() - 18));

  return EighteenYearsAgo;
};

const getMinBirthDate = () => {
  const now = new Date();

  const HundredYearsAgo = new Date(now.setFullYear(now.getFullYear() - 100));

  return HundredYearsAgo;
};

export const validationObject = Yup.object({
  name: Yup.string()
    .max(50, "Не більше 50 символів!")
    .required("Обов'язкове поле!"),

  surname: Yup.string()
    .max(50, "Не більше 50 символів!")
    .required("Обов'язкове поле!"),

  patronymic: Yup.string()
    .max(50, "Не більше 50 символів!")
    .required("Обов'язкове поле!"),

  experience: Yup.number()
    .max(70, "Завелике значення!")
    .min(0, "Не може бути від'ємним!")
    .required("Обов'язкове поле!"),

  birthDate: Yup.date()
    .min(getMinBirthDate(), "Не вірне значення!")
    .max(getMaxBirthDate(), "Лікарю повинно бути більше 18 років!"),

  hospitalUnitName: Yup.string().required("Обов'язкове поле!"),
});
