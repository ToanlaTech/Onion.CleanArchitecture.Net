import moment from "moment";

export const formatDatetime = (value?: string) => {
  return value ? moment(value).format("DD/MM/YYYY") : "";
};
