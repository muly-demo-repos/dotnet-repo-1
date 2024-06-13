import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";
import { OrderItemCreateNestedManyWithoutOrdersInput } from "./OrderItemCreateNestedManyWithoutOrdersInput";

export type OrderCreateInput = {
  customer?: CustomerWhereUniqueInput | null;
  muly?: string | null;
  orderDate?: Date | null;
  orderItems?: OrderItemCreateNestedManyWithoutOrdersInput;
  status?: "Option1" | null;
  totalAmount?: number | null;
};
