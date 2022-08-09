import * as Yup from "yup";

export const validationObject = Yup.object({
  name: Yup.string()
    .max(100, "Не більше 100 символів!")
    .required("Обов'язкове поле!"),

  symptoms: Yup.string()
    .max(5000, "Не більше 5000 символів!")
    .required("Обов'язкове поле!"),

  procedures: Yup.string()
    .max(5000, "Не більше 5000 символів!")
    .required("Обов'язкове поле!"),

  hospitalUnitName: Yup.string().required("Обов'язкове поле!"),

  treatments: Yup.array(
    Yup.object({
      medicineName: Yup.string().required("Обов'язкове поле!"),
      medicineQuantity: Yup.number()
        .min(1, "Не може бути нулем чи від'ємним!")
        .max(5000, "Надто велике число!")
        .required("Обов'язкове поле"),
    })
  ),
});
