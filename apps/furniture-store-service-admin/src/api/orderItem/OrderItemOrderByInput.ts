import { SortOrder } from "../../util/SortOrder";

export type OrderItemOrderByInput = {
  createdAt?: SortOrder;
  id?: SortOrder;
  orderId?: SortOrder;
  productId?: SortOrder;
  quantity?: SortOrder;
  unitPrice?: SortOrder;
  updatedAt?: SortOrder;
};
