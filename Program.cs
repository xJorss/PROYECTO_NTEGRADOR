using System;

class SistemaSeguros
{
    static string[,] Ja_Clientes =
    {
        { "0942091391", "Josh Falcones"  },
        { "0942091392", "Maria Moreira"  },
        { "0942091393", "Carlos Ruiz"    },
        { "0942091394", "Ana Torres"     },
        { "0942091395", "Luis Vera"      },
        { "0942091396", "Sofia Mora"     },
        { "0942091397", "Pedro Fajardo"  },
        { "0942091398", "Laura Diaz"     },
        { "0942091399", "Miguel Flores"  },
        { "0942091390", "Diana Arreaga"  }
    };
    static string[] JA_Ramos =
    {
        "Incendio",
        "Robo",
        "Vehiculo",
        "Trasporte"
    };

    static int[][] Ja_AlertasUAF =
    {
        new int[] { 200, 404, 200 },
        new int[] { 200, 200      },
        new int[] { 999           },
        new int[] { 200, 500      },
        new int[] { 404, 200      },
        new int[] { 200           },
        new int[] { 500, 200, 404 },
        new int[] { 200, 200, 200 },
        new int[] { 999, 404      },
        new int[] { 200, 500, 200 }
    };
    const int Ja_MaxPolizas = 100;
    static int[] Ja_PolCliente = new int[Ja_MaxPolizas];
    static string[] Ja_PolRamo = new string[Ja_MaxPolizas];
    static double[] Ja_PolCapital = new double[Ja_MaxPolizas];
    static double[] Ja_PolCapRemte = new double[Ja_MaxPolizas];
    static double[] Ja_PolPrimaTotal = new double[Ja_MaxPolizas];
    static int Ja_TotalPolizas = 0;
    const int Ja_MaxSiniestros = 200;
    static int[] Ja_SinPoliza = new int[Ja_MaxSiniestros];
    static double[] Ja_SinMontoReclamo = new double[Ja_MaxSiniestros];
    static double[] Ja_SinDeducible = new double[Ja_MaxSiniestros];
    static double[] Ja_SinPagoNeto = new double[Ja_MaxSiniestros];
    static double[] Ja_SinCapConsumido = new double[Ja_MaxSiniestros];
    static int Ja_TotalSiniestros = 0;

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

            if (Ja_Vld && (ja_opcion >= 1 && ja_opcion <= 5))
            {
                switch (ja_opcion)
                {
                    case 1:
                        EmitirPoliza();
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


    static void EmitirPoliza()
    {
        string Ja_cedula;
        bool Ja_ValdCedula = false;
        char Ja_Continuar;
        bool ja_ValdContinuar = false;
        int Ja_FilaCliente = 0;
        bool Ja_Bloqueo;

        do
        {
            Console.WriteLine("Desea generar una poliza (s/n):");
            bool ja_ValdSN = char.TryParse(Console.ReadLine().ToLower(), out Ja_Continuar);

            if (ja_ValdSN == false || (Ja_Continuar != 's' && Ja_Continuar != 'n'))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opcion incorrecta, intente nuevamente");
                Console.ResetColor();
                ja_ValdContinuar = true;
            }
            else if (Ja_Continuar == 's')
            {
                ja_ValdContinuar = true;
            }
            else
            {
                ja_ValdContinuar = false;
            }

            if (Ja_Continuar == 's')
            {
                if (Ja_TotalPolizas >= Ja_MaxPolizas)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: Se alcanzó el límite máximo de {Ja_MaxPolizas} pólizas en memoria.");
                    Console.WriteLine("No es posible registrar más pólizas en esta sesión.");
                    Console.ResetColor();
                    continue;
                }

                do
                {
                    Ja_ValdCedula = false;
                    Console.WriteLine("Ingrese el numero de cedula:");
                    Ja_cedula = Console.ReadLine();

                    for (int Ja_i = 0; Ja_i < Ja_Clientes.GetLength(0); Ja_i++)
                    {
                        if (Ja_Clientes[Ja_i, 0] == Ja_cedula)
                        {
                            Ja_ValdCedula = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Usuario Cargado");
                            Console.ResetColor();
                            Ja_FilaCliente = Ja_i;
                            Console.WriteLine($"Nombre: {Ja_Clientes[Ja_i, 1]}");
                            break;
                        }
                    }

                    if (Ja_ValdCedula == false)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cliente no encontrado");
                        Console.ResetColor();
                    }

                } while (!Ja_ValdCedula);

                bool Ja_PolDuplicada = false;
                for (int Ja_i = 0; Ja_i < Ja_TotalPolizas; Ja_i++)
                {
                    if (Ja_Clientes[Ja_PolCliente[Ja_i], 0] == Ja_cedula)
                    {
                        Ja_PolDuplicada = true;
                        break;
                    }
                }

                if (Ja_PolDuplicada)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("AVISO: El cliente ya posee una póliza registrada.");
                    Console.WriteLine("No es posible emitir una segunda póliza para el mismo cliente.");
                    Console.ResetColor();
                    continue;   
                }

                Ja_Bloqueo = false;

                foreach (int Ja_codigo in Ja_AlertasUAF[Ja_FilaCliente])
                {
                    if (Ja_codigo == 404)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Error documental detectado");
                        Console.ResetColor();
                        continue;
                    }

                    if (Ja_codigo == 999)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("CLIENTE BLOQUEADO POR LA UAF");
                        Console.ResetColor();
                        Ja_Bloqueo = true;
                        break;
                    }
                }

                if (Ja_Bloqueo)
                {
                    continue;
                }

                if (!Ja_Bloqueo)
                {
                    Console.WriteLine("RAMOS DISPONIBLES");
                    for (int Ja_i = 0; Ja_i < JA_Ramos.Length; Ja_i++)
                    {
                        Console.WriteLine($"{Ja_i + 1}. {JA_Ramos[Ja_i]}");
                    }

                    int Ja_OpcionRamo;
                    bool Ja_ValdRamo;

                    do
                    {
                        Console.Write("\nSeleccione un ramo (1-4): ");
                        Ja_ValdRamo = int.TryParse(Console.ReadLine(), out Ja_OpcionRamo);

                        if (!Ja_ValdRamo || Ja_OpcionRamo < 1 || Ja_OpcionRamo > 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opción inválida.");
                            Console.ResetColor();
                        }
                    } while (!Ja_ValdRamo || Ja_OpcionRamo < 1 || Ja_OpcionRamo > 4);

                    string Ja_RamoSeleccionado = JA_Ramos[Ja_OpcionRamo - 1];

                    // ── Capital asegurado ─────────────────────────────────────
                    double Ja_Capital;
                    bool Ja_ValdCapital;

                    do
                    {
                        Console.Write("Ingrese el Capital Asegurado: ");
                        Ja_ValdCapital = double.TryParse(Console.ReadLine(), out Ja_Capital);

                        if (!Ja_ValdCapital || Ja_Capital <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Capital inválido.");
                            Console.ResetColor();
                        }
                    } while (!Ja_ValdCapital || Ja_Capital <= 0);

                    // ── Tasa de riesgo ────────────────────────────────────────
                    double Ja_Tasa;
                    bool Ja_ValdTasa;

                    do
                    {
                        Console.Write("Ingrese la Tasa de Riesgo: ");
                        Ja_ValdTasa = double.TryParse(Console.ReadLine(), out Ja_Tasa);

                        if (!Ja_ValdTasa || Ja_Tasa <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Tasa inválida.");
                            Console.ResetColor();
                        }
                    } while (!Ja_ValdTasa || Ja_Tasa <= 0);

                    double Ja_PrimaBase = (Ja_Capital * Ja_Tasa) / 100;
                    double Ja_SuperBancos = Ja_PrimaBase * 0.035;
                    double Ja_SeguroCampesino = Ja_PrimaBase * 0.005;

                    double Ja_DerechoEmision;
                    if (Ja_Capital > 0 && Ja_Capital <= 10000)
                        Ja_DerechoEmision = 0.50;
                    else if (Ja_Capital <= 40000)
                        Ja_DerechoEmision = 1.00;
                    else
                        Ja_DerechoEmision = 2.00;

                    double Ja_Subtotal = Ja_PrimaBase + Ja_SuperBancos +
                                         Ja_SeguroCampesino + Ja_DerechoEmision;
                    double Ja_IVA = Ja_Subtotal * 0.12;
                    double Ja_Total = Ja_Subtotal + Ja_IVA;

                    Ja_PolCliente[Ja_TotalPolizas] = Ja_FilaCliente;

                    Ja_PolRamo[Ja_TotalPolizas] = Ja_RamoSeleccionado;
                    Ja_PolCapital[Ja_TotalPolizas] = Ja_Capital;

                    Ja_PolCapRemte[Ja_TotalPolizas] = Ja_PolCapital[Ja_TotalPolizas];

                    Ja_PolPrimaTotal[Ja_TotalPolizas] = Ja_Total;

                    Ja_TotalPolizas++;   

                    int Ja_IdxGuardado = Ja_TotalPolizas - 1;

                    Console.Clear();
                    Console.WriteLine("\n==============================================");
                    Console.WriteLine("\t    FACTURA DE PÓLIZA");
                    Console.WriteLine("==============================================");
                    Console.WriteLine($"\nCliente:\t\t{Ja_Clientes[Ja_PolCliente[Ja_IdxGuardado], 1]}");
                    Console.WriteLine($"Cédula:\t\t\t{Ja_Clientes[Ja_PolCliente[Ja_IdxGuardado], 0]}");
                    Console.WriteLine($"Ramo:\t\t\t{Ja_PolRamo[Ja_IdxGuardado]}");
                    Console.WriteLine("\nDESGLOSE FINANCIERO");
                    Console.WriteLine($"Prima Base:\t\t${Ja_PrimaBase:F2}");
                    Console.WriteLine($"Super Bancos:\t\t${Ja_SuperBancos:F2}");
                    Console.WriteLine($"Seguro Campesino:\t${Ja_SeguroCampesino:F2}");
                    Console.WriteLine($"Derecho Emisión:\t${Ja_DerechoEmision:F2}");
                    Console.WriteLine($"IVA:\t\t\t${Ja_IVA:F2}");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine($"Capital Asegurado:\t${Ja_PolCapital[Ja_IdxGuardado]:F2}");
                    Console.WriteLine($"Capital Remanente:\t${Ja_PolCapRemte[Ja_IdxGuardado]:F2}");
                    Console.WriteLine($"TOTAL:\t\t\t${Ja_PolPrimaTotal[Ja_IdxGuardado]:F2}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPÓLIZA GENERADA CON ÉXITO");
                    Console.ResetColor();
                }
            }

        } while (ja_ValdContinuar);
    }
}