import React, { FocusEvent, InputHTMLAttributes, useState } from "react";
import classNames from "classnames";

import styles from "./DropDown.module.scss";

interface Props extends InputHTMLAttributes<HTMLInputElement> {
  children: React.ReactNode;
}

export const DropDown = ({ children, ...props }: Props) => {
  const [active, setActive] = useState(false);

  const onClick = () => {
    setActive(!active);
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
      onClick={onClick}
      onBlur={handleBlur}
    >
      <input autoComplete="off" {...props} />

      <ul onFocus={() => setActive(false)} className={className}>
        {children}
      </ul>
    </div>
  );
};
