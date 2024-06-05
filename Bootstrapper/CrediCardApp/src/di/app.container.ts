import { Container } from "inversify";
import { userModule } from "@infrastructure/users/index";
import { httpClientModule } from "@core/index";
import { cardModule } from "@infrastructure/cards/card.module";

// Crear contenedor de Inversify
const di = new Container();
//Transversales
di.load(httpClientModule)
// Cargar módulos en el contenedor
di.load(cardModule);
di.load(userModule);

export { di };