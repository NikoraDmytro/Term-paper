import React, { InputHTMLAttributes } from "react";
import { useField, useFormikContext } from "formik";

import { DropDown } from "./DropDown";
import { useAxios } from "hooks/useAxios";
import { Loader } from "components/Loader";

import styles from "./InputField.module.scss";

interface Props extends InputHTMLAttributes<HTMLInputElement> {
  name: string;
  label: string;
  loadOptions: (input: string) => Promise<string[]>;
}

export const AsyncDropDownField = ({
  name,
  label,
  loadOptions,
  ...props
}: Props) => {
  const { setFieldValue } = useFormikContext();
  const [field, meta] = useField(name);

  const { data, loading, error } = useAxios<string[]>(
    loadOptions,
    field.value ?? ""
  );

  const renderOption = (option: string) => (
    <li key={option} onClick={() => setFieldValue(name, option)}>
      {option}
    </li>
  );

  return (
    <div className={styles.inputField}>
      <label htmlFor={name}>{label}</label>

      <DropDown {...field} {...props}>
        {!loading && data && data.length ? (
          data.map(renderOption)
        ) : (
          <li>
            {loading && <Loader small />}
            {error && <p style={{ color: "red" }}>{error}</p>}
            {!data?.length && <p>Нічого не знайдено!</p>}
          </li>
        )}
      </DropDown>

      {meta.touched && meta.error ? (
        <div className={styles.inputError}>{meta.error}</div>
      ) : null}
    </div>
  );
};
