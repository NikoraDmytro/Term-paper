import { MouseEvent, useEffect, useState } from "react";
import { FieldArray } from "formik";
import classNames from "classnames";

import { v4 as uuidv4 } from "uuid";

import styles from "./DynamicInputsArray.module.scss";

type BtnClickEvent = MouseEvent<HTMLButtonElement>;

interface Props {
  name: string;
  count: number;
  initialValue: any;
  children: (index: number) => React.ReactNode;
}

const generateIds = (count: number) => {
  const ids = [];

  for (let i = 0; i < count; i++) {
    const id = uuidv4();

    ids.push(id);
  }

  return ids;
};

export const DynamicInputsArray = (props: Props) => {
  const [ids, setIds] = useState<string[]>([]);

  useEffect(() => {
    setIds(generateIds(props.count));
  }, [props.count]);

  const [newElementIndex, setNewElementIndex] = useState(-1);

  return (
    <FieldArray name={props.name}>
      {(arrayHelpers) => {
        const addElement = (index: number) => () => {
          arrayHelpers.insert(index + 1, props.initialValue);

          setNewElementIndex(index + 1);
        };

        const removeElement = (index: number) => (e: BtnClickEvent) => {
          if (ids.length < 2) return;

          const parent = e.currentTarget.parentElement;

          if (!parent) return;

          parent.classList.add(styles.shrink);

          parent.onanimationend = () => {
            arrayHelpers.remove(index);
          };
        };

        return ids.map((id, index) => {
          const className = classNames({
            [styles.inputsBlock]: true,
            [styles.grow]: index === newElementIndex,
          });

          let onAnimationEnd;

          if (index === newElementIndex) {
            onAnimationEnd = () => setNewElementIndex(-1);
          }

          return (
            <div key={id} className={className} onAnimationEnd={onAnimationEnd}>
              {props.children(index)}

              <button
                type="button"
                className={styles.addBlockBtn}
                onClick={addElement(index)}
              />

              <button
                type="button"
                className={styles.removeBlockBtn}
                onClick={removeElement(index)}
              />
            </div>
          );
        });
      }}
    </FieldArray>
  );
};
