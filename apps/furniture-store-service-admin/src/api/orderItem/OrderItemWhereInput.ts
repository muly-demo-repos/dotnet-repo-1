import { StringFilter } from "../../util/StringFilter";
import { OrderWhereUniqueInput } from "../order/OrderWhereUniqueInput";
import { ProductWhereUniqueInput } from "../product/ProductWhereUniqueInput";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { FloatNullableFilter } from "../../util/FloatNullableFilter";

export type OrderItemWhereInput = {
  id?: StringFilter;
  order?: OrderWhereUniqueInput;
  product?: ProductWhereUniqueInput;
  quantity?: IntNullableFilter;
  unitPrice?: FloatNullableFilter;
};
