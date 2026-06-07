using System;

namespace CalculadoraConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║        CALCULADORA DE CONSOLA        ║");
            Console.WriteLine("╚══════════════════════════════════════╝");

            while (continuar)
            {
                Console.WriteLine("\nClaves disponibles:");
                Console.WriteLine("  +  → Suma");
                Console.WriteLine("  -  → Resta");
                Console.WriteLine("  *  → Multiplicación");
                Console.WriteLine("  /  → División");
                Console.WriteLine("  R  → Raíz cuadrada de ambos números");
                Console.WriteLine("  E  → Elevar primer número al segundo");
                Console.WriteLine("─────────────────────────────────────");

                double numero1 = LeerNumero("Ingrese el primer número: ");
                double numero2 = LeerNumero("Ingrese el segundo número: ");
                string clave = LeerClave("Ingrese la clave de operación (+, -, *, /, R, E): ");

                try
                {
                    double resultado;

                    switch (clave.ToUpper())
                    {
                        case "+":
                            resultado = numero1 + numero2;
                            Console.WriteLine($"\n  Resultado: {numero1} + {numero2} = {resultado}");
                            break;

                        case "-":
                            resultado = numero1 - numero2;
                            Console.WriteLine($"\n  Resultado: {numero1} - {numero2} = {resultado}");
                            break;

                        case "*":
                            resultado = numero1 * numero2;
                            Console.WriteLine($"\n  Resultado: {numero1} * {numero2} = {resultado}");
                            break;

                        case "/":
                            if (numero2 == 0)
                                throw new DivideByZeroException("No se puede dividir entre 0.");
                            resultado = numero1 / numero2;
                            Console.WriteLine($"\n  Resultado: {numero1} / {numero2} = {resultado}");
                            break;

                        case "R":
                            double raiz1 = Math.Sqrt(numero1);
                            double raiz2 = Math.Sqrt(numero2);
                            if (numero1 < 0 || numero2 < 0)
                                throw new ArithmeticException("No se puede calcular la raíz cuadrada de un número negativo.");
                            Console.WriteLine($"\n  √{numero1} = {raiz1}");
                            Console.WriteLine($"  √{numero2} = {raiz2}");
                            break;

                        case "E":
                            resultado = Math.Round(Math.Pow(numero1, numero2), 3);
                            Console.WriteLine($"\n  Resultado: {numero1} ^ {numero2} = {resultado}");
                            break;

                        default:
                            Console.WriteLine("\n  ⚠ Clave no reconocida. Use: +, -, *, /, R, E");
                            break;
                    }
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"\n  ⚠ Error: {ex.Message}");
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine($"\n  ⚠ Error aritmético: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n  ⚠ Error inesperado: {ex.Message}");
                }

                Console.WriteLine("\n─────────────────────────────────────");
                Console.Write("¿Desea realizar otra operación? (S/N): ");
                string respuesta = Console.ReadLine();

                if (respuesta == null || respuesta.Trim().ToUpper() != "S")
                    continuar = false;

            } // ← cierre correcto del while

            Console.WriteLine("\n¡Hasta luego! Programa finalizado.");
            Console.ReadKey();
        }

        static double LeerNumero(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("  El campo no puede estar vacío. Debe colocar un dato correcto.");
                    continue;
                }

                try
                {
                    double numero = double.Parse(entrada);
                    return numero;
                }
                catch (FormatException)
                {
                    Console.WriteLine("  Dato incorrecto: debe ingresar un número real (ej. 3.14). Intente de nuevo.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("  El número ingresado es demasiado grande. Intente de nuevo.");
                }
            }
        }

        static string LeerClave(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("  La clave no puede estar vacía. Debe colocar un dato correcto.");
                    continue;
                }

                string clave = entrada.Trim().ToUpper();
                string[] clavesValidas = { "+", "-", "*", "/", "R", "E" };

                bool valida = false;
                foreach (string c in clavesValidas)
                    if (clave == c) { valida = true; break; }

                if (!valida)
                    Console.WriteLine("  Clave no válida. Debe ingresar: +, -, *, /, R o E.");
                else
                    return clave;
            }
        }
    }
}
