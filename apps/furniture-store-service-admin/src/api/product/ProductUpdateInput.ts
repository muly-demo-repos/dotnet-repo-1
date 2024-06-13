import { CategoryWhereUniqueInput } from "../category/CategoryWhereUniqueInput";
import { OrderItemUpdateManyWithoutProductsInput } from "./OrderItemUpdateManyWithoutProductsInput";

export type ProductUpdateInput = {
  category?: CategoryWhereUniqueInput | null;
  description?: string | null;
  name?: string | null;
  orderItems?: OrderItemUpdateManyWithoutProductsInput;
  price?: number | null;
  sku?: string | null;
  stock?: number | null;
};
