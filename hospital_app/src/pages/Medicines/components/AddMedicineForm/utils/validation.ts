import * as Yup from "yup";

export const validationObject = Yup.object({
  name: Yup.string()
    .max(30, "Не більше 30 символів!")
    .required("Обов'язкове поле!"),
  dosageForm: Yup.string().max(50, "Не більше 50 символів"),
  unitOfMeasure: Yup.string()
    .max(10, "Не більше 10 символів. Використовуйте скорочену назву!")
    .required("Обов'язкове поле!"),
  quantityInStock: Yup.number()
    .min(1, "Не може бути нулем чи від'ємним!")
    .max(5000, "Надто велике число!")
    .required("Обов'язкове поле"),
});
