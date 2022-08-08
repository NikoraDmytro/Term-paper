import * as Yup from "yup";

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

  birthDate: Yup.date()
    .min(getMinBirthDate(), "Не вірне значення!")
    .max(new Date(), "Не вірне значення!"),

  diagnosis: Yup.string()
    .max(100, "Не більше 100 символів!")
    .required("Обов'язкове поле!"),

  attendingDoctor: Yup.string()
    .max(160, "Не більше 160 символів!")
    .required("Обов'язкове поле!"),

  hospitalWardNumber: Yup.number()
    .min(100, "Нумерація палат починається з 100!")
    .max(10000, "Завелике число!")
    .required("Обов'язкове поле!"),
});
