import * as Yup from "yup";

export const validationObject = Yup.object({
  medicines: Yup.array(
    Yup.object({
      name: Yup.string().required("Обов'язкове поле!"),
      quantity: Yup.number()
        .min(1, "Не може бути нулем чи від'ємним!")
        .max(5000, "Надто велике число!")
        .required("Обов'язкове поле"),
    })
  ),
});
