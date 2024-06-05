type Debounced<A extends any[], R> = (...args: A) => Promise<R>;


/**
 * Función debounce
 * 
 * Crea una versión debounced de la función proporcionada, que se ejecutará
 * después del retraso especificado si no se invoca nuevamente durante ese tiempo.
 * 
 * @template A Tipo de los argumentos que acepta la función debounced
 * @template R Tipo del valor de retorno de la función debounced
 * @param fn Función original a la que se aplicará el debounce
 * @param delay Tiempo de espera en milisegundos antes de ejecutar la función
 * @returns Una función debounced que retorna una promesa que se resuelve con el valor de retorno de la función original
 * @example
 * // Ejemplo de uso:
 * const miFuncion = (mensaje: string) => {
 *   console.log(mensaje);
 * };
 * const miFuncionDebounced = debounce(miFuncion, 2000);
 * 
 * miFuncionDebounced("Hola"); // No se ejecuta inmediatamente
 * miFuncionDebounced("Hola de nuevo"); // Cancela la llamada anterior y programa una nueva
 * // Solo se ejecutará "Hola de nuevo" después de 2000ms
 */
export const debounce = <A extends any[], R>(
  fn: (...args: A) => R,
  delay: number
): Debounced<A, R> => {
  let timer: NodeJS.Timeout;
  return (...args: A) => {
    return new Promise<R>((resolve) => {
      if (timer) {
        clearTimeout(timer);
      }
      timer = setTimeout(() => {
        resolve(fn(...args));
      }, delay);
    });
  };
};

/**
 * Clase Debounce
 * @template A Tipo de los argumentos que acepta la función debounced
 * @template R Tipo del valor de retorno de la función debounced
 * @param fn Función original a la que se aplicará el debounce
 * @param delay Tiempo de espera en milisegundos antes de ejecutar la función
 * @returns Una instancia de la clase Debounce con el método execute debounced
 * @example
 * // Ejemplo de uso:
 * const miFuncion = (mensaje: string) => {
 *   console.log(mensaje);
 * };
 * const miDebounce = new Debounce(miFuncion, 2000);
 * 
 * miDebounce.execute("Hola"); // No se ejecuta inmediatamente
 * miDebounce.execute("Hola de nuevo"); // Cancela la llamada anterior y programa una nueva
 * // Solo se ejecutará "Hola de nuevo" después de 2000ms
 */
export class Debounce<A extends any[], R = void> {
  private timer: NodeJS.Timeout | null = null;

  /**
   * @param fn Función original a la que se aplicará el debounce
   * @param delay Tiempo de espera en milisegundos antes de ejecutar la función
   */
  constructor(private fn: (...args: A) => R, private delay: number) {}

  /**
   * Ejecuta la función debounced después del retraso especificado
   * @param args Argumentos que se pasarán a la función original
   * @returns Una promesa que se resuelve con el valor de retorno de la función original
   */
  public execute(...args: A): Promise<R> {
    return new Promise<R>((resolve) => {
      if (this.timer) {
        clearTimeout(this.timer);
      }
      this.timer = setTimeout(() => {
        resolve(this.fn(...args));
      }, this.delay);
    });
  }
}