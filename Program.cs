using System;
class SistemaSeguros
{
    static void Main(string[] args)
    {
        int ja_opcion;
        bool Ja_Continuar = true;
        while (Ja_Continuar)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("SISTEMA INTEGRAL DE SEGUROS (xJorsCorp)");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Emitir nueva póliza");
            Console.WriteLine("2. Registrar siniestro");
            Console.WriteLine("3. Listar pólizas");
            Console.WriteLine("4. Listar siniestros");
            Console.WriteLine("5. Salir");
            bool Ja_Vld = int.TryParse(Console.ReadLine(), out ja_opcion);
            if (Ja_Vld || (ja_opcion >= 1 && ja_opcion <= 5))
            {
                switch (ja_opcion)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del sistema de xJorsCorp...");
                        Ja_Continuar = false;
                        break;

                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opcion incorrecta, Intente nuevamente");
                Console.ResetColor();

            }
        }
    }
}