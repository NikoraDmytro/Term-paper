import React, { InputHTMLAttributes } from "react";
import { useField } from "formik";
import classNames from "classnames";

import styles from "./InputField.module.scss";

interface Props
  extends InputHTMLAttributes<HTMLInputElement | HTMLTextAreaElement> {
  name: string;
  label: string;
  isTextArea?: boolean;
}

export const InputField = ({ label, name, isTextArea, ...props }: Props) => {
  const [field, meta] = useField(name);

  const className = classNames(styles.inputField, {
    [styles.areaField]: isTextArea,
  });

  return (
    <div className={className}>
      <label htmlFor={name}>{label}</label>

      {!isTextArea ? (
        <input {...field} {...props} />
      ) : (
        <textarea {...field} {...props} />
      )}

      {meta.touched && meta.error ? (
        <div className={styles.inputError}>{meta.error}</div>
      ) : null}
    </div>
  );
};
