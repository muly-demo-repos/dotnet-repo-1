import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { OrderItemModuleBase } from "./base/orderItem.module.base";
import { OrderItemService } from "./orderItem.service";
import { OrderItemController } from "./orderItem.controller";
import { OrderItemResolver } from "./orderItem.resolver";

@Module({
  imports: [OrderItemModuleBase, forwardRef(() => AuthModule)],
  controllers: [OrderItemController],
  providers: [OrderItemService, OrderItemResolver],
  exports: [OrderItemService],
})
export class OrderItemModule {}
