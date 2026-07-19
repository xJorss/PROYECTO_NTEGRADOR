using System;
using System.Security.Cryptography;
class SistemaSeguros
{
    // Lista de clientes registrados
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

    // Ramos disponibles para emitir polizas
    static string[] JA_Ramos =
    {    "Incendio", "Robo", "Vehiculo", "Trasporte"
    };

    // Alertas reportadas por la UAF para cada cliente
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

    // Arreglos donde se guardan las pólizas emitidas
    const int Ja_MaxPolizas = 100;
    static int[] Ja_PolCliente = new int[Ja_MaxPolizas];
    static string[] Ja_PolRamo = new string[Ja_MaxPolizas];
    static double[] Ja_PolCapital = new double[Ja_MaxPolizas];
    static double[] Ja_PolCapRemte = new double[Ja_MaxPolizas];
    static double[] Ja_PolPrimaTotal = new double[Ja_MaxPolizas];
    static int Ja_TotalPolizas = 0;

    // Arreglos donde se guardan los siniestros registrados
    const int Ja_MaxSiniestros = 200;
    static int[] Ja_SinPoliza = new int[Ja_MaxSiniestros];
    static double[] Ja_SinMontoReclamo = new double[Ja_MaxSiniestros];
    static double[] Ja_SinDeducible = new double[Ja_MaxSiniestros];
    static double[] Ja_SinPagoNeto = new double[Ja_MaxSiniestros];
    static double[] Ja_SinCapConsumido = new double[Ja_MaxSiniestros];
    static int Ja_TotalSiniestros = 0;
    static string[] Ja_SinEstado = new string[Ja_MaxSiniestros];

    // Información de las reaseguradoras
    static int[] Ja_CodigoReaseguradora = { 1, 2, 3, 4, 5, 6, 7 };
    static string[] Ja_NombreReaseguradora = { "Seguros Pichincha", "Equinoccial Seguros", "Latina Seguros", "Hispana Re", "Confianza Seguros", "Continental Re", "Retencion" };
    static int[] Ja_TipoGrupo = { 1, 2, 1, 1, 2, 2, 3 };
    static string[] Ja_CodigoGeneral = { "0020", "0030", "0020", "0020", "0030", "0030", "0010" };
    static double[] Ja_LimitePorcentual = { 20, 0, 30, 35, 0, 0, 10 };
    static double[] Ja_LimiteValorativo = { 30000, 0, 20000, 50000, 0, 0, 500000 };


    static void Main(string[] args)
    {
        int ja_opcion;
        bool Ja_Continuar = true;

        while (Ja_Continuar)
        {
            // Menú principal del sistema
            Console.WriteLine("========================================");
            Console.WriteLine("SISTEMA INTEGRAL DE SEGUROS (SIS)");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Poliza");
            Console.WriteLine("2. Siniestro");
            Console.WriteLine("3. Contabilidad");
            Console.WriteLine("4. Salir");

            bool Ja_Vld = int.TryParse(Console.ReadLine(), out ja_opcion);

            if (Ja_Vld && (ja_opcion >= 1 && ja_opcion <= 4))
            {
                // Ejecuta la opción elegida por el usuario
                switch (ja_opcion)
                {
                    case 1:
                        bool Ja_Valdwyle = true;
                        while (Ja_Valdwyle)
                        {
                            Console.WriteLine("========================================");
                            Console.WriteLine("=============MENU POLIZAS===============");
                            Console.WriteLine("========================================");
                            Console.WriteLine("1. Emitir Poliza");
                            Console.WriteLine("2. Consultar Poliza");
                            Console.WriteLine("3. Modificar Poliza");
                            Console.WriteLine("4. Eliminar Poliza");
                            Console.WriteLine("5. Volver al Menú Principal");
                            bool Ja_ValdPoliza1 = int.TryParse(Console.ReadLine(), out int ja_opcion1);
                            if (Ja_ValdPoliza1 && (ja_opcion1 >= 1 && ja_opcion1 <= 5))
                            {
                                // Ejecuta la opción elegida por el usuario
                                switch (ja_opcion1)
                                {
                                    case 1: EmitirPoliza(); break;
                                    case 2: ConsultarPoliza(); break;
                                    case 3: ModificarPoliza(); break;
                                    case 4: EliminarPoliza(); break;
                                    case 5:
                                        Ja_Valdwyle = false;
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Opcion incorrecta, intente nuevamente");
                                Console.ResetColor();
                            }
                        }
                        break;
                    case 2:
                        bool Ja_Valdwyle2 = true;
                        while (Ja_Valdwyle2)
                        {
                            Console.WriteLine("========================================");
                            Console.WriteLine("=============MENU SINIESTROS============");
                            Console.WriteLine("========================================");
                            Console.WriteLine("1. Registrar Siniestro");
                            Console.WriteLine("2. Consultar Siniestro");
                            Console.WriteLine("3. Modificar Siniestro");
                            Console.WriteLine("4. Eliminar Siniestro");
                            Console.WriteLine("5. Volver al Menú Principal");
                            bool Ja_ValdSiniestro = int.TryParse(Console.ReadLine(), out int ja_opcion2);
                            if (Ja_ValdSiniestro && (ja_opcion2 >= 1 && ja_opcion2 <= 5))
                            {
                                // Ejecuta la opción elegida por el usuario
                                switch (ja_opcion2)
                                {
                                    case 1: RegistarSiniestro(); break;
                                    case 2: ConsultarSiniestro(); break;
                                    case 3: ModificarSiniestro(); break;
                                    case 4: EliminarSiniestro(); break;
                                    case 5:
                                        Ja_Valdwyle2 = false;
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Opcion incorrecta, intente nuevamente");
                                Console.ResetColor();
                            }
                        }


                        break;
                    case 3:
                        GenerarReporteContable();
                        break;
                    case 4:
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
    //=====================
    //MODULO DE POLIZAS
    //=====================
    //Metodo para emitir una poliza
    static void EmitirPoliza()
    {
        string Ja_cedula;
        bool Ja_ValdCedula = false;
        char Ja_Continuar;
        bool ja_ValdContinuar = false;
        int Ja_FilaCliente = 0;
        bool Ja_Bloqueo;
        bool Ja_PolizaRegistrada = false;
        //Revisa si hay espacio para emitir una poliza
        if (Ja_TotalPolizas >= Ja_MaxPolizas)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: Se alcanzó el límite máximo de {Ja_MaxPolizas} pólizas en memoria.");
            Console.WriteLine("No es posible registrar más pólizas en esta sesión.");
            Console.ResetColor();
        }
        ;

        do
        {
            Ja_ValdCedula = false;
            Console.WriteLine("Ingrese el numero de cedula:");
            Ja_cedula = Console.ReadLine();

            // Busca al cliente por número de cedula
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

        // Verifica que el cliente no tenga otra póliza
        bool Ja_PolDuplicada = false;
        for (int Ja_i = 0; Ja_i < Ja_TotalPolizas; Ja_i++)
        {
            if (Ja_Clientes[Ja_PolCliente[Ja_i], 0] == Ja_cedula)
            {
                Ja_PolDuplicada = true;
                break;
            }
        }
        ;

        if (Ja_PolDuplicada)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("AVISO: El cliente ya posee una póliza registrada.");
            Console.WriteLine("No es posible emitir una segunda póliza para el mismo cliente.");
            Console.ResetColor();
            return;
        };

        Ja_Bloqueo = false;

        // Revisa si el cliente tiene alertas
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
        ;

        if (Ja_Bloqueo) { return; }

        // Selección del ramo del seguro
        if (!Ja_Bloqueo)
        {
            Console.WriteLine("RAMOS DISPONIBLES");
            for (int Ja_i = 0; Ja_i < JA_Ramos.Length; Ja_i++)
                Console.WriteLine($"{Ja_i + 1}. {JA_Ramos[Ja_i]}");

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

            double Ja_Capital;
            bool Ja_ValdCapital;

            // Datos para calcular la prima
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

            // Cálculo de los valores de la póliza
            double Ja_PrimaBase = (Ja_Capital * Ja_Tasa) / 100;
            double Ja_SuperBancos = Ja_PrimaBase * 0.035;
            double Ja_SeguroCampesino = Ja_PrimaBase * 0.005;

            double Ja_DerechoEmision;
            if (Ja_Capital > 0 && Ja_Capital <= 10000) Ja_DerechoEmision = 0.50;
            else if (Ja_Capital <= 40000) Ja_DerechoEmision = 1.00;
            else Ja_DerechoEmision = 2.00;

            double Ja_Subtotal = Ja_PrimaBase + Ja_SuperBancos + Ja_SeguroCampesino + Ja_DerechoEmision;
            double Ja_IVA = Ja_Subtotal * 0.12;
            double Ja_Total = Ja_Subtotal + Ja_IVA;

            // Guarda la póliza en los arreglos
            Ja_PolCliente[Ja_TotalPolizas] = Ja_FilaCliente;
            Ja_PolRamo[Ja_TotalPolizas] = Ja_RamoSeleccionado;
            Ja_PolCapital[Ja_TotalPolizas] = Ja_Capital;
            Ja_PolCapRemte[Ja_TotalPolizas] = Ja_PolCapital[Ja_TotalPolizas];
            Ja_PolPrimaTotal[Ja_TotalPolizas] = Ja_Total;
            Ja_TotalPolizas++;
            Ja_PolizaRegistrada = true;

            int Ja_IdxGuardado = Ja_TotalPolizas - 1;

            // Muestra el comprobante de la póliza
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
            Console.WriteLine($"Pólizas en memoria: {Ja_TotalPolizas} / {Ja_MaxPolizas}");
        }


    }
    //Método para consultar pólizas
    static void ConsultarPoliza()
    {
        bool Ja_ValdConsPoliza = false;
        Console.WriteLine("Ingrese el número de cédula del cliente para consultar su póliza:");
        string Ja_cedulaConsulta = Console.ReadLine();
        for (int i = 0; i < Ja_TotalPolizas; i++)
        {
            if (Ja_Clientes[Ja_PolCliente[i], 0] == Ja_cedulaConsulta)
            {
                Console.Clear();
                Console.WriteLine("\n==============================================");
                Console.WriteLine("\t    FACTURA DE PÓLIZA");
                Console.WriteLine("==============================================");
                Console.WriteLine($"\nCliente:\t\t{Ja_Clientes[Ja_PolCliente[i], 1]}");
                Console.WriteLine($"Cédula:\t\t\t{Ja_Clientes[Ja_PolCliente[i], 0]}");
                Console.WriteLine($"Ramo:\t\t\t{Ja_PolRamo[i]}");
                Console.WriteLine($"Capital Asegurado:\t${Ja_PolCapital[i]:F2}");
                Console.WriteLine($"Capital Remanente:\t${Ja_PolCapRemte[i]:F2}");
                Console.WriteLine($"TOTAL:\t\t\t${Ja_PolPrimaTotal[i]:F2}");
                Ja_ValdConsPoliza = true;
                break;
            }
        }
        if (Ja_ValdConsPoliza == false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No se encontró una póliza para el cliente con la cédula proporcionada.");
            Console.ResetColor();
        }

    }

    static void ModificarPoliza()
    {
        Console.WriteLine("Ingrese el numero de cedula: ");
        string Ja_cedula = Console.ReadLine();
        bool ModificarPoliza = false;
        for (int i = 0; i < Ja_TotalPolizas; i++)
        {
            if (Ja_Clientes[Ja_PolCliente[i], 0] == Ja_cedula)
            {
                ModificarPoliza = true;
                Console.WriteLine($"Póliza encontrada para {Ja_Clientes[Ja_PolCliente[i], 1]}");
                Console.WriteLine($"Ramo actual: {Ja_PolRamo[i]}");
                Console.WriteLine($"Capital Asegurado actual: ${Ja_PolCapital[i]:F2}");
                Console.WriteLine("Ingrese el nuevo capital asegurado: ");
                double Ja_nuevoCapital;
                bool Ja_ValdNuevoCapital = double.TryParse(Console.ReadLine(), out Ja_nuevoCapital);
                double Ja_nuevaTasa;
                Console.WriteLine($"Ingrese la nueva tasa de riesgo: ");
                bool Ja_ValdNuevaTasa = double.TryParse(Console.ReadLine(), out Ja_nuevaTasa);
                if (Ja_ValdNuevoCapital && Ja_nuevoCapital > 0 && Ja_ValdNuevaTasa && (Ja_nuevaTasa > 0 && Ja_nuevaTasa <= 100))
                {
                    Ja_PolCapital[i] = Ja_nuevoCapital;
                    Ja_PolCapRemte[i] = Ja_nuevoCapital; // Actualiza el capital remanente también

                    // Recalcula la prima
                    double Ja_PrimaBase = (Ja_nuevoCapital * Ja_nuevaTasa) / 100;
                    double Ja_SuperBancos = Ja_PrimaBase * 0.035;
                    double Ja_SeguroCampesino = Ja_PrimaBase * 0.005;

                    // Derecho de emisión
                    double Ja_DerechoEmision;

                    if (Ja_nuevoCapital <= 10000)
                    {
                        Ja_DerechoEmision = 0.50;
                    }
                    else if (Ja_nuevoCapital <= 40000)
                    {
                        Ja_DerechoEmision = 1.00;
                    }
                    else
                    {
                        Ja_DerechoEmision = 2.00;
                    }

                    double Ja_Subtotal = Ja_PrimaBase +
                                         Ja_SuperBancos +
                                         Ja_SeguroCampesino +
                                         Ja_DerechoEmision;

                    double Ja_IVA = Ja_Subtotal * 0.12;

                    double Ja_Total = Ja_Subtotal + Ja_IVA;

                    // Guarda el nuevo total
                    Ja_PolPrimaTotal[i] = Ja_Total;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Póliza modificada exitosamente.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Valor de capital inválido o tasa de riesgo inválida. No se realizaron cambios.");
                    Console.ResetColor();
                }
                return;
            }
        }
        if (ModificarPoliza == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No se encontró una póliza para el cliente con la cédula proporcionada.");
            Console.ResetColor();
        }
    }

    static void EliminarPoliza()
    {
        int Ja_IdxPolizaEliminar = -1;
        bool Ja_PolizaConSiniestro = false;

        Console.WriteLine("Ingrese el número de cédula del cliente:");
        string Ja_CedulaEliminar = Console.ReadLine();

        //Buscar la póliza
        for (int i = 0; i < Ja_TotalPolizas; i++)
        {
            if (Ja_Clientes[Ja_PolCliente[i], 0] == Ja_CedulaEliminar)
            {
                Ja_IdxPolizaEliminar = i;
                break;
            }
        }

        //Si no existe la póliza
        if (Ja_IdxPolizaEliminar == -1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No existe una póliza registrada con esa cédula.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine($"Póliza encontrada para {Ja_Clientes[Ja_PolCliente[Ja_IdxPolizaEliminar], 1]}");

        //Verificar si tiene siniestros registrados
        for (int i = 0; i < Ja_TotalSiniestros; i++)
        {
            if (Ja_SinPoliza[i] == Ja_IdxPolizaEliminar)
            {
                Ja_PolizaConSiniestro = true;
                break;
            }
        }

        if (Ja_PolizaConSiniestro)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No se puede eliminar la póliza porque tiene siniestros registrados.");
            Console.ResetColor();
            return;
        }

        //Recorrer las pólizas una posición hacia atrás
        for (int i = Ja_IdxPolizaEliminar; i < Ja_TotalPolizas - 1; i++)
        {
            Ja_PolCliente[i] = Ja_PolCliente[i + 1];
            Ja_PolRamo[i] = Ja_PolRamo[i + 1];
            Ja_PolCapital[i] = Ja_PolCapital[i + 1];
            Ja_PolCapRemte[i] = Ja_PolCapRemte[i + 1];
            Ja_PolPrimaTotal[i] = Ja_PolPrimaTotal[i + 1];
        }

        //Limpiar la última posición
        Ja_PolCliente[Ja_TotalPolizas - 1] = 0;
        Ja_PolRamo[Ja_TotalPolizas - 1] = "";
        Ja_PolCapital[Ja_TotalPolizas - 1] = 0;
        Ja_PolCapRemte[Ja_TotalPolizas - 1] = 0;
        Ja_PolPrimaTotal[Ja_TotalPolizas - 1] = 0;

        Ja_TotalPolizas--;

        //Actualizar los índices de las pólizas en los siniestros
        for (int i = 0; i < Ja_TotalSiniestros; i++)
        {
            if (Ja_SinPoliza[i] > Ja_IdxPolizaEliminar)
            {
                Ja_SinPoliza[i]--;
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Póliza eliminada correctamente.");
        Console.ResetColor();
    }
    //=====================
    //MODULO DE SINIESTROS
    //=====================
    // Metodo para registrar un siniestro
    static void RegistarSiniestro()
    {
        char Ja_Continuar;
        bool ja_ValdContinuar = false;
        string Ja_cedula;
        int Ja_IdxPoliza = -1;
        bool Ja_PolEncontrada;

        //Revisa si hay espacio para registrar un siniestro
        if (Ja_TotalSiniestros >= Ja_MaxSiniestros)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: Se alcanzó el límite máximo de {Ja_MaxSiniestros} siniestros en memoria.");
            Console.WriteLine("No es posible registrar más siniestros en esta sesión.");
            Console.ResetColor();
        }
        ;

        //Pide numero de cedula
        Console.WriteLine("Ingrese el numero de cedula del cliente:");
        Ja_cedula = Console.ReadLine();
        Ja_PolEncontrada = false;
        Ja_IdxPoliza = -1;

        // Busca la póliza del cliente
        for (int Ja_i = 0; Ja_i < Ja_TotalPolizas; Ja_i++)
        {
            if (Ja_Clientes[Ja_PolCliente[Ja_i], 0] == Ja_cedula)
            {
                Ja_PolEncontrada = true;
                Ja_IdxPoliza = Ja_i;
                break;
            }
        }

        //Si no encuentra una poliza asociada a la cedula lo envia al menu
        if (!Ja_PolEncontrada)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No existe una póliza registrada para este cliente.");
            Console.ResetColor();
            return;
        }
        ;

        //Muestra la poliza
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Póliza encontrada");
        Console.ResetColor();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"Cliente:\t\t{Ja_Clientes[Ja_PolCliente[Ja_IdxPoliza], 1]}");
        Console.WriteLine($"Cédula:\t\t\t{Ja_Clientes[Ja_PolCliente[Ja_IdxPoliza], 0]}");
        Console.WriteLine($"Ramo:\t\t\t{Ja_PolRamo[Ja_IdxPoliza]}");
        Console.WriteLine($"Capital Asegurado:\t${Ja_PolCapital[Ja_IdxPoliza]:F2}");
        Console.WriteLine($"Capital Remanente:\t${Ja_PolCapRemte[Ja_IdxPoliza]:F2}");
        Console.WriteLine("----------------------------------------------");

        double Ja_MontoReclamo;
        bool Ja_ValdMonto;

        do
        {
            // Solicita el valor del reclamo
            Console.Write("Ingrese el monto del reclamo: ");
            Ja_ValdMonto = double.TryParse(Console.ReadLine(), out Ja_MontoReclamo);

            if (!Ja_ValdMonto || Ja_MontoReclamo <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Monto inválido. Debe ser un valor mayor a cero.");
                Console.ResetColor();
            }
        } while (!Ja_ValdMonto || Ja_MontoReclamo <= 0);

        // Si el reclamo supera el capital disponible, se rechaza
        if (Ja_MontoReclamo > Ja_PolCapRemte[Ja_IdxPoliza])
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: El reclamo excede el capital remanente disponible.");
            Console.WriteLine($"Capital Remanente disponible: ${Ja_PolCapRemte[Ja_IdxPoliza]:F2}");
            Console.ResetColor();

            Ja_SinPoliza[Ja_TotalSiniestros] = Ja_IdxPoliza;
            Ja_SinMontoReclamo[Ja_TotalSiniestros] = Ja_MontoReclamo;
            Ja_SinDeducible[Ja_TotalSiniestros] = 0;
            Ja_SinPagoNeto[Ja_TotalSiniestros] = 0;
            Ja_SinCapConsumido[Ja_TotalSiniestros] = 0;
            Ja_SinEstado[Ja_TotalSiniestros] = "Rechazado";

            Ja_TotalSiniestros++;

            int Ja_IdxRechazado = Ja_TotalSiniestros - 1;

            Console.Clear();
            Console.WriteLine("\n==============================================");
            Console.WriteLine("\t  COMPROBANTE DE SINIESTRO");
            Console.WriteLine("==============================================");
            Console.WriteLine($"\nCliente:\t\t{Ja_Clientes[Ja_PolCliente[Ja_IdxPoliza], 1]}");
            Console.WriteLine($"Cédula:\t\t\t{Ja_Clientes[Ja_PolCliente[Ja_IdxPoliza], 0]}");
            Console.WriteLine($"Ramo:\t\t\t{Ja_PolRamo[Ja_IdxPoliza]}");
            Console.WriteLine("\nDETALLE DEL SINIESTRO");
            Console.WriteLine($"Capital Original:\t${Ja_PolCapital[Ja_IdxPoliza]:F2}");
            Console.WriteLine($"Capital Remanente:\t${Ja_PolCapRemte[Ja_IdxPoliza]:F2}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Monto Reclamado:\t${Ja_SinMontoReclamo[Ja_IdxRechazado]:F2}");
            Console.WriteLine($"Deducible (%):\t\t{Ja_SinDeducible[Ja_IdxRechazado]:F2}%");
            Console.WriteLine($"Valor Deducible ($):\t${0:F2}");
            Console.WriteLine($"Monto Pagado:\t\t${Ja_SinPagoNeto[Ja_IdxRechazado]:F2}");
            Console.WriteLine("----------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Estado:\t\t\t{Ja_SinEstado[Ja_IdxRechazado]}");
            Console.ResetColor();
            return;
        };

        double Ja_PorcDeducible;
        bool Ja_ValdDeducible;

        do
        {
            // Solicita y calcula el deducible y el valor a pagar
            Console.Write("Ingrese el porcentaje de deducible (0 - 100): ");
            Ja_ValdDeducible = double.TryParse(Console.ReadLine(), out Ja_PorcDeducible);

            if (!Ja_ValdDeducible || Ja_PorcDeducible < 0 || Ja_PorcDeducible > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Deducible inválido. Debe estar entre 0 y 100.");
                Console.ResetColor();
            }
        } while (!Ja_ValdDeducible || Ja_PorcDeducible < 0 || Ja_PorcDeducible > 100);

        // Descuenta el monto utilizado del capital disponible
        double Ja_ValorDeducible = Ja_MontoReclamo * (Ja_PorcDeducible / 100);
        double Ja_MontoAPagar = Ja_MontoReclamo - Ja_ValorDeducible;
        double Ja_MontoConsumido = Ja_MontoReclamo;

        Ja_PolCapRemte[Ja_IdxPoliza] = Ja_PolCapRemte[Ja_IdxPoliza] - Ja_MontoConsumido;

        // Guarda el siniestro
        Ja_SinPoliza[Ja_TotalSiniestros] = Ja_IdxPoliza;
        Ja_SinMontoReclamo[Ja_TotalSiniestros] = Ja_MontoReclamo;
        Ja_SinDeducible[Ja_TotalSiniestros] = Ja_PorcDeducible;
        Ja_SinPagoNeto[Ja_TotalSiniestros] = Ja_MontoAPagar;
        Ja_SinCapConsumido[Ja_TotalSiniestros] = Ja_MontoConsumido;

        Ja_SinEstado[Ja_TotalSiniestros] = "Aprobado";

        Ja_TotalSiniestros++;
        int Ja_IdxGuardado = Ja_TotalSiniestros - 1;

        // Muestra el comprobante del siniestro
        Console.Clear();
        Console.WriteLine("\n==============================================");
        Console.WriteLine("\t  COMPROBANTE DE SINIESTRO");
        Console.WriteLine("==============================================");
        Console.WriteLine($"\nCliente:\t\t{Ja_Clientes[Ja_PolCliente[Ja_IdxPoliza], 1]}");
        Console.WriteLine($"Cédula:\t\t\t{Ja_Clientes[Ja_PolCliente[Ja_IdxPoliza], 0]}");
        Console.WriteLine($"Ramo:\t\t\t{Ja_PolRamo[Ja_IdxPoliza]}");
        Console.WriteLine("\nDETALLE DEL SINIESTRO");
        Console.WriteLine($"Capital Original:\t${Ja_PolCapital[Ja_IdxPoliza]:F2}");
        Console.WriteLine($"Capital Remanente:\t${Ja_PolCapRemte[Ja_IdxPoliza]:F2}");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"Monto Reclamado:\t${Ja_SinMontoReclamo[Ja_IdxGuardado]:F2}");
        Console.WriteLine($"Deducible (%):\t\t{Ja_SinDeducible[Ja_IdxGuardado]:F2}%");
        Console.WriteLine($"Valor Deducible ($):\t${Ja_ValorDeducible:F2}");
        Console.WriteLine($"Monto Pagado:\t\t${Ja_SinPagoNeto[Ja_IdxGuardado]:F2}");
        Console.WriteLine("----------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Estado:\t\t\t{Ja_SinEstado[Ja_IdxGuardado]}");
        Console.ResetColor();
        Console.WriteLine($"Siniestros en memoria: {Ja_TotalSiniestros} / {Ja_MaxSiniestros}");

        // Envía el monto consumido al módulo de reaseguro
        Contrato_Reaseguro(Ja_SinCapConsumido[Ja_IdxGuardado]);
    }

    static void ConsultarSiniestro()
    {
        Console.WriteLine("Ingrese el número de cédula del cliente para consultar su siniestro:");
        string Ja_cedulaConsulta = Console.ReadLine();
        bool Ja_ValdConsSiniestro = false;
        for (int i = 0; i < Ja_TotalSiniestros; i++)
        {
            if (Ja_Clientes[Ja_PolCliente[Ja_SinPoliza[i]], 0] == Ja_cedulaConsulta)
            {
                Ja_ValdConsSiniestro = true;
                Console.Clear();
                Console.WriteLine("\n==============================================");
                Console.WriteLine("\t  COMPROBANTE DE SINIESTRO");
                Console.WriteLine("==============================================");
                Console.WriteLine($"\nCliente:\t\t{Ja_Clientes[Ja_PolCliente[Ja_SinPoliza[i]], 1]}");
                Console.WriteLine($"Cédula:\t\t\t{Ja_Clientes[Ja_PolCliente[Ja_SinPoliza[i]], 0]}");
                Console.WriteLine($"Ramo:\t\t\t{Ja_PolRamo[Ja_SinPoliza[i]]}");
                Console.WriteLine("\nDETALLE DEL SINIESTRO");
                Console.WriteLine($"Capital Original:\t${Ja_PolCapital[Ja_SinPoliza[i]]:F2}");
                Console.WriteLine($"Capital Remanente:\t${Ja_PolCapRemte[Ja_SinPoliza[i]]:F2}");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"Monto Reclamado:\t${Ja_SinMontoReclamo[i]:F2}");
                Console.WriteLine($"Deducible (%):\t\t{Ja_SinDeducible[i]:F2}%");
                double Ja_ValorDeducible = Ja_SinMontoReclamo[i] * (Ja_SinDeducible[i] / 100);
                Console.WriteLine($"Valor Deducible ($):\t${Ja_ValorDeducible:F2}");
                Console.WriteLine($"Monto Pagado:\t\t${Ja_SinPagoNeto[i]:F2}");
                Console.WriteLine("----------------------------------------------");
            }
        }
        if (Ja_ValdConsSiniestro == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cedula Incorrecta");
            Console.ResetColor();
        }
    }


    static void ModificarSiniestro()
    {
        int Ja_idxSientro = -1;
        bool Ja_ValdCedula = false;
        bool Ja_ValdSiniestro = false;

        Console.WriteLine("Ingrese el número de cédula del cliente para modificar su siniestro:");
        string Ja_cedulaModificar = Console.ReadLine();

        // Buscar el siniestro mediante la cédula
        for (int i = 0; i < Ja_TotalSiniestros; i++)
        {
            if (Ja_Clientes[Ja_PolCliente[Ja_SinPoliza[i]], 0] == Ja_cedulaModificar)
            {
                Ja_ValdCedula = true;
                Ja_ValdSiniestro = true;
                Ja_idxSientro = i;
                break;
            }
        }

        if (!Ja_ValdCedula)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cédula incorrecta.");
            Console.ResetColor();
            return;
        }

        if (!Ja_ValdSiniestro)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No existe un siniestro registrado para este cliente.");
            Console.ResetColor();
            return;
        }

        int Ja_IdxPoliza = Ja_SinPoliza[Ja_idxSientro];

        Console.WriteLine("=======================================");
        Console.WriteLine("      SINIESTRO ENCONTRADO");
        Console.WriteLine("=======================================");
        Console.WriteLine($"Cliente: {Ja_Clientes[Ja_PolCliente[Ja_IdxPoliza], 1]}");
        Console.WriteLine($"Monto Reclamado: ${Ja_SinMontoReclamo[Ja_idxSientro]:F2}");
        Console.WriteLine($"Porcentaje Deducible: {Ja_SinDeducible[Ja_idxSientro]:F2}%");
        Console.WriteLine($"Capital Consumido: ${Ja_SinCapConsumido[Ja_idxSientro]:F2}");
        Console.WriteLine($"Capital Remanente: ${Ja_PolCapRemte[Ja_IdxPoliza]:F2}");

        double Ja_nuevoMonto;
        bool Ja_ValdNuevoMonto;

        do
        {
            Console.Write("Ingrese el nuevo monto reclamado: ");
            Ja_ValdNuevoMonto = double.TryParse(Console.ReadLine(), out Ja_nuevoMonto);

            if (!Ja_ValdNuevoMonto || Ja_nuevoMonto <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Monto inválido.");
                Console.ResetColor();
            }

        } while (!Ja_ValdNuevoMonto || Ja_nuevoMonto <= 0);

        double Ja_nuevoDeducible;
        bool Ja_ValdNuevoDeducible;

        do
        {
            Console.Write("Ingrese el nuevo porcentaje de deducible: ");
            Ja_ValdNuevoDeducible = double.TryParse(Console.ReadLine(), out Ja_nuevoDeducible);

            if (!Ja_ValdNuevoDeducible || Ja_nuevoDeducible < 0 || Ja_nuevoDeducible > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Porcentaje inválido.");
                Console.ResetColor();
            }

        } while (!Ja_ValdNuevoDeducible || Ja_nuevoDeducible < 0 || Ja_nuevoDeducible > 100);

        // Devuelve el capital que consumía el siniestro anterior
        Ja_PolCapRemte[Ja_IdxPoliza] += Ja_SinCapConsumido[Ja_idxSientro];

        // Verifica que el nuevo reclamo no exceda el capital disponible
        if (Ja_nuevoMonto > Ja_PolCapRemte[Ja_IdxPoliza])
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El nuevo monto supera el capital remanente disponible.");
            Console.ResetColor();

            // Se vuelve a dejar el capital como estaba
            Ja_PolCapRemte[Ja_IdxPoliza] -= Ja_SinCapConsumido[Ja_idxSientro];
            return;
        }

        double Ja_ValorDeducible = Ja_nuevoMonto * (Ja_nuevoDeducible / 100);
        double Ja_MontoPagar = Ja_nuevoMonto - Ja_ValorDeducible;

        // Descuenta nuevamente el capital
        Ja_PolCapRemte[Ja_IdxPoliza] -= Ja_nuevoMonto;

        // Actualiza la información del siniestro
        Ja_SinMontoReclamo[Ja_idxSientro] = Ja_nuevoMonto;
        Ja_SinDeducible[Ja_idxSientro] = Ja_nuevoDeducible;
        Ja_SinPagoNeto[Ja_idxSientro] = Ja_MontoPagar;
        Ja_SinCapConsumido[Ja_idxSientro] = Ja_nuevoMonto;

        Console.Clear();
        Console.WriteLine("=======================================");
        Console.WriteLine("      SINIESTRO MODIFICADO");
        Console.WriteLine("=======================================");
        Console.WriteLine($"Cliente: {Ja_Clientes[Ja_PolCliente[Ja_IdxPoliza], 1]}");
        Console.WriteLine($"Monto Reclamado: ${Ja_SinMontoReclamo[Ja_idxSientro]:F2}");
        Console.WriteLine($"Porcentaje Deducible: {Ja_SinDeducible[Ja_idxSientro]:F2}%");
        Console.WriteLine($"Valor Deducible: ${Ja_ValorDeducible:F2}");
        Console.WriteLine($"Pago Neto: ${Ja_SinPagoNeto[Ja_idxSientro]:F2}");
        Console.WriteLine($"Capital Consumido: ${Ja_SinCapConsumido[Ja_idxSientro]:F2}");
        Console.WriteLine($"Capital Remanente: ${Ja_PolCapRemte[Ja_IdxPoliza]:F2}");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nSiniestro modificado correctamente.");
        Console.ResetColor();

        // Recalcula el reparto del reaseguro
        Contrato_Reaseguro(Ja_SinCapConsumido[Ja_idxSientro]);
    }
    static void EliminarSiniestro()
    {
        int Ja_IdxSiniestro = -1;
        bool Ja_Encontrado = false;

        Console.WriteLine("Ingrese el número de cédula del cliente para eliminar su siniestro:");
        string Ja_cedulaEliminar = Console.ReadLine();

        // Buscar el siniestro
        for (int i = 0; i < Ja_TotalSiniestros; i++)
        {
            if (Ja_Clientes[Ja_PolCliente[Ja_SinPoliza[i]], 0] == Ja_cedulaEliminar)
            {
                Ja_Encontrado = true;
                Ja_IdxSiniestro = i;
                break;
            }
        }

        if (!Ja_Encontrado)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No existe un siniestro registrado para esta cédula.");
            Console.ResetColor();
            return;
        }

        int Ja_IdxPoliza = Ja_SinPoliza[Ja_IdxSiniestro];

        // Devolver el capital consumido a la póliza
        Ja_PolCapRemte[Ja_IdxPoliza] += Ja_SinCapConsumido[Ja_IdxSiniestro];

        // Recorrer los arreglos una posición hacia atrás
        for (int i = Ja_IdxSiniestro; i < Ja_TotalSiniestros - 1; i++)
        {
            Ja_SinPoliza[i] = Ja_SinPoliza[i + 1];
            Ja_SinMontoReclamo[i] = Ja_SinMontoReclamo[i + 1];
            Ja_SinDeducible[i] = Ja_SinDeducible[i + 1];
            Ja_SinPagoNeto[i] = Ja_SinPagoNeto[i + 1];
            Ja_SinCapConsumido[i] = Ja_SinCapConsumido[i + 1];
            Ja_SinEstado[i] = Ja_SinEstado[i + 1];
        }

        // Limpiar la última posición
        Ja_SinPoliza[Ja_TotalSiniestros - 1] = 0;
        Ja_SinMontoReclamo[Ja_TotalSiniestros - 1] = 0;
        Ja_SinDeducible[Ja_TotalSiniestros - 1] = 0;
        Ja_SinPagoNeto[Ja_TotalSiniestros - 1] = 0;
        Ja_SinCapConsumido[Ja_TotalSiniestros - 1] = 0;
        Ja_SinEstado[Ja_TotalSiniestros - 1] = "";

        Ja_TotalSiniestros--;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Siniestro eliminado correctamente.");
        Console.ResetColor();
    }
    //=====================
    //MODULO DE REASEGURO
    //=====================
    //Metodo del reaseguro
    //Calcula cómo se reparte el capital entre las reaseguradoras
    static void Contrato_Reaseguro(double Ja_Capital)
    {

        // Variables para guardar los montos del reparto
        double Ja_MontoRetencion = 0;
        double Ja_MontoContrato = 0;
        double Ja_MontoFacultativo = 0;

        bool Ja_AlertaRetencion = false;
        bool Ja_AlertaContrato = false;
        bool Ja_AlertaFacultativo = false;

        int Ja_IndiceRetencion = -1;
        int Ja_IndiceContrato = -1;
        int Ja_IndiceFacultativo = -1;

        double Ja_MayorLimite = 0;

        // Busca la posición de cada tipo de reaseguro
        for (int Ja_i = 0; Ja_i < Ja_CodigoGeneral.Length; Ja_i++)
        {
            if (Ja_CodigoGeneral[Ja_i] == "0010")
            {
                Ja_IndiceRetencion = Ja_i;
                break;
            }
        }

        // Busca el contrato con el mayor límite permitido
        Ja_MayorLimite = 0;
        for (int Ja_i = 0; Ja_i < Ja_CodigoGeneral.Length; Ja_i++)
        {
            if (Ja_CodigoGeneral[Ja_i] == "0020")
            {
                if (Ja_LimiteValorativo[Ja_i] > Ja_MayorLimite)
                {
                    Ja_MayorLimite = Ja_LimiteValorativo[Ja_i];
                    Ja_IndiceContrato = Ja_i;
                }
            }
        }

        for (int Ja_i = 0; Ja_i < Ja_CodigoGeneral.Length; Ja_i++)
        {
            if (Ja_CodigoGeneral[Ja_i] == "0030")
            {
                Ja_IndiceFacultativo = Ja_i;
                break;
            }
        }

        // Verifica si todo el capital entra en retención
        if (Ja_Capital <= Ja_LimiteValorativo[Ja_IndiceRetencion])
        {
            Ja_MontoRetencion = Ja_Capital;
        }
        else
        {
            // El capital supera la retención
            Ja_AlertaRetencion = true;

            Ja_MontoRetencion = Ja_LimiteValorativo[Ja_IndiceRetencion];
            double Ja_CapitalRestante = Ja_Capital - Ja_MontoRetencion;

            // Calcula el monto para el contrato automático
            Ja_MontoContrato = (Ja_Capital * Ja_LimitePorcentual[Ja_IndiceContrato]) / 100;

            // Verifica que no pase el límite del contrato
            if (Ja_MontoContrato > Ja_LimiteValorativo[Ja_IndiceContrato])
            {
                Ja_MontoContrato = Ja_LimiteValorativo[Ja_IndiceContrato];
                Ja_AlertaContrato = true;
            }

            // Evita repartir más dinero del disponible
            if (Ja_MontoContrato > Ja_CapitalRestante)
            {
                Ja_MontoContrato = Ja_CapitalRestante;
            }

            Ja_CapitalRestante = Ja_CapitalRestante - Ja_MontoContrato;

            // Si queda dinero, pasa al facultativo
            if (Ja_CapitalRestante > 0)
            {
                Ja_MontoFacultativo = Ja_CapitalRestante;
                Ja_AlertaFacultativo = true;
            }
        }

        double Ja_TotalRepartido = 0;

        // Muestra el resultado del reparto
        MostrarReaseguro(Ja_Capital, Ja_MontoRetencion, Ja_MontoContrato, Ja_MontoFacultativo,
            Ja_AlertaRetencion, Ja_AlertaContrato, Ja_AlertaFacultativo,
            Ja_IndiceRetencion, Ja_IndiceContrato, Ja_IndiceFacultativo, ref Ja_TotalRepartido);
    }

    //Presenta el reparto realizado
    static void MostrarReaseguro(double Ja_Capital, double Ja_MontoRetencion, double Ja_MontoContrato, double Ja_MontoFacultativo,
    bool Ja_AlertaRetencion, bool Ja_AlertaContrato, bool Ja_AlertaFacultativo,
    int Ja_IndiceRetencion, int Ja_IndiceContrato, int Ja_IndiceFacultativo, ref double Ja_Total)
    {
        Console.WriteLine();
        Console.WriteLine("===================================================");
        Console.WriteLine("\t\tREPARTO DE REASEGURO");
        Console.WriteLine("===================================================");

        // Muestra las alertas generadas
        if (Ja_AlertaRetencion)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ALERTA: Capital supera el limite de retencion.");
            Console.ResetColor();
        }
        if (Ja_AlertaContrato)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ALERTA: Capital supera el limite del contrato.");
            Console.ResetColor();
        }
        if (Ja_AlertaFacultativo)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ALERTA: El capital restante pasa a Facultativo.");
            Console.ResetColor();
        }
        // Encabezado de la tabla
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Codigo\tNombre\t\tPorcentaje\tMonto");
        Console.WriteLine("-----------------------------------------------");
        // Muestra la parte de retención
        double Ja_PorcentajeRetencion = (Ja_MontoRetencion / Ja_Capital) * 100;
        Console.WriteLine(
            $"{Ja_CodigoGeneral[Ja_IndiceRetencion]}\t{Ja_NombreReaseguradora[Ja_IndiceRetencion]}\t{Ja_PorcentajeRetencion:F0}%\t\t${Ja_MontoRetencion:F2}"
        );

        // Muestra el contrato automático
        if (Ja_MontoContrato > 0)
        {
            double Ja_Porcentaje;
            Ja_Porcentaje = (Ja_MontoContrato * 100) / Ja_Capital;
            Console.WriteLine($"{Ja_CodigoGeneral[Ja_IndiceContrato]}\t{Ja_NombreReaseguradora[Ja_IndiceContrato]}\t{Ja_Porcentaje:F0}%\t\t${Ja_MontoContrato:F2}");
        }

        // Muestra el facultativo
        if (Ja_MontoFacultativo > 0)
        {
            double Ja_Porcentaje;
            Ja_Porcentaje = (Ja_MontoFacultativo * 100) / Ja_Capital;
            Console.WriteLine($"{Ja_CodigoGeneral[Ja_IndiceFacultativo]}\t {Ja_NombreReaseguradora[Ja_IndiceFacultativo]}\t{Ja_Porcentaje:F0}%\t\t${Ja_MontoFacultativo:F2}");
        }

        Console.WriteLine("-----------------------------------------------");

        // Calcula el total repartido
        Ja_Total = Ja_MontoRetencion + Ja_MontoContrato + Ja_MontoFacultativo;

        Console.WriteLine($"Capital: ${Ja_Capital:F2}");
        Console.WriteLine($"Total Repartido: ${Ja_Total:F2}");

        // Comprueba que todo el capital fue repartido
        if (Math.Abs(Ja_Total - Ja_Capital) < 0.01)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reparto realizado correctamente.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error en el reparto del capital.");
            Console.ResetColor();
        }
    }

    //=========================
    //MODULO DE CONTAVBILIDAD
    //=========================

    static void GenerarReporteContable()
    {
        Console.Clear();
        double Ja_TotalDebe = 0;
        double Ja_TotalHaber = 0;

        Console.WriteLine("\n=======================================================");
        Console.WriteLine("          ASIENTOS CONTABLES");
        Console.WriteLine("=======================================================");

        // ==========================
        // EMISION DE POLIZAS
        // ==========================
        for (int i = 0; i < Ja_TotalPolizas; i++)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("EMISION DE POLIZA");
            Console.WriteLine("Cliente : " + Ja_Clientes[Ja_PolCliente[i], 1]);
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("DEBE");
            Console.WriteLine("  Cuentas por Cobrar............. $" + Ja_PolPrimaTotal[i].ToString("F2"));

            Console.WriteLine("HABER");
            Console.WriteLine("  Ingresos por Primas............ $" + Ja_PolPrimaTotal[i].ToString("F2"));

            Ja_TotalDebe += Ja_PolPrimaTotal[i];
            Ja_TotalHaber += Ja_PolPrimaTotal[i];
        }

        // ==========================
        // SINIESTROS
        // ==========================
        for (int i = 0; i < Ja_TotalSiniestros; i++)
        {
            if (Ja_SinEstado[i] == "Aprobado")
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("PAGO DE SINIESTRO");
                Console.WriteLine("Cliente : " + Ja_Clientes[Ja_PolCliente[Ja_SinPoliza[i]], 1]);
                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine("DEBE");
                Console.WriteLine("  Gastos por Siniestros......... $" + Ja_SinPagoNeto[i].ToString("F2"));

                Console.WriteLine("HABER");
                Console.WriteLine("  Caja / Bancos................. $" + Ja_SinPagoNeto[i].ToString("F2"));

                Ja_TotalDebe += Ja_SinPagoNeto[i];
                Ja_TotalHaber += Ja_SinPagoNeto[i];
            }
        }

        // ==========================
        // REASEGURO
        // ==========================

        for (int i = 0; i < Ja_TotalSiniestros; i++)
        {
            if (Ja_SinEstado[i] == "Aprobado")
            {
                double Ja_GastoReaseguro = Ja_SinCapConsumido[i] * 0.20;

                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("CESION DE REASEGURO");
                Console.WriteLine("Cliente : " + Ja_Clientes[Ja_PolCliente[Ja_SinPoliza[i]], 1]);
                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine("DEBE");
                Console.WriteLine("  Gastos por Reaseguro.......... $" + Ja_GastoReaseguro.ToString("F2"));

                Console.WriteLine("HABER");
                Console.WriteLine("  Reaseguradores por Pagar...... $" + Ja_GastoReaseguro.ToString("F2"));

                Ja_TotalDebe += Ja_GastoReaseguro;
                Ja_TotalHaber += Ja_GastoReaseguro;
            }
        }

        Console.WriteLine();
        Console.WriteLine("=======================================================");
        Console.WriteLine("              RESUMEN GENERAL");
        Console.WriteLine("=======================================================");
        Console.WriteLine("Total Debe : $" + Ja_TotalDebe.ToString("F2"));
        Console.WriteLine("Total Haber: $" + Ja_TotalHaber.ToString("F2"));

        if (Ja_TotalDebe == Ja_TotalHaber)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPARTIDA DOBLE CORRECTA");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR CONTABLE: Debe y Haber no coinciden.");
        }

        Console.ResetColor();
    }
}