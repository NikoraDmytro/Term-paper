import React, { FocusEvent, InputHTMLAttributes, useState } from "react";

import classNames from "classnames";
import styles from "./DropDown.module.scss";

interface Props extends InputHTMLAttributes<HTMLInputElement> {
  children: React.ReactNode;
}

export const DropDown = ({ children, ...props }: Props) => {
  const [active, setActive] = useState(false);

  const onFocus = () => {
    setActive(true);
  };

  const handleBlur = (e: FocusEvent<HTMLDivElement>) => {
    const target = e.relatedTarget;
    const container = e.currentTarget;

    if (!container.contains(target)) {
      setActive(false);
    }
  };

  const className = classNames({
    [styles.dropDownMenu]: true,
    [styles.active]: active,
  });

  return (
    <div
      tabIndex={5}
      className={styles.dropDown}
      onFocus={onFocus}
      onBlur={handleBlur}
    >
      <input {...props} />

      <ul className={className}>{children}</ul>
    </div>
  );
};
