import { Order as TOrder } from "../api/order/Order";

export const ORDER_TITLE_FIELD = "muly";

export const OrderTitle = (record: TOrder): string => {
  return record.muly?.toString() || String(record.id);
};
