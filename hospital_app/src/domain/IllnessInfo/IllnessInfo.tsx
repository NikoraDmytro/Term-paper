import React from "react";
import { useParams } from "react-router-dom";

export const IllnessInfo = () => {
  const { illnessName } = useParams();

  return <div>{illnessName}</div>;
};
