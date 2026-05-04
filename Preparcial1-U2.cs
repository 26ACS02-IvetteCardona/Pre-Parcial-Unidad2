internal class Program
{
    private static void Main(string[] args)
    {
        //variables
        double saldo = 1000;
        int intentos = 0;
        int pinCorrecto = 1234;
        int pin;

        //validar el pin /acceso
        while (intentos < 3)
        {
            Console.Write("Ingrese su PIN: ");
            if (int.TryParse(Console.ReadLine(), out pin))
            {
                if (pin == pinCorrecto)
                {
                    Console.WriteLine("Acceso Concedido....");

                    int opcion = 0;
                    //Menu del cajero
                    while (opcion!=4)
                    {
                        Console.WriteLine("==========CAJERO AUTOMÁTICO BI==========");
                        Console.WriteLine("1. Consultar saldo");
                        Console.WriteLine("2. Depositar Dinero");
                        Console.WriteLine("3. Retirar Dinero");
                        Console.WriteLine("4. Salir");
                        Console.Write("Seleccione un opción: ");

                        int.TryParse(Console.ReadLine(), out opcion);

                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine("CONSULTAR SALDO");
                                Console.WriteLine("Saldo Actual: Q." + saldo);
                                break;
                            case 2:
                                Console.WriteLine("DEPOSITAR DINERO");
                                Console.WriteLine("Ingresar el Monto a Depositar: ");
                                double depositar;
                                if (double.TryParse(Console.ReadLine(), out depositar) && depositar >0)
                                {
                                    saldo += depositar;
                                    Console.WriteLine("Deposito realizado con éxito\nNuevo Saldo: Q."+saldo);
                                }
                                else
                                {
                                    Console.WriteLine("Monto Inválido");
                                }
                                break;
                            case 3:
                                Console.WriteLine("RETIRAR DINERO");
                                Console.WriteLine("Ingrese el monto a retirar: Q.");
                                double retirar;
                                if (double.TryParse(Console.ReadLine(), out retirar) && retirar>0)
                                {
                                    if (retirar<=saldo)
                                    {
                                        saldo -= retirar;
                                        Console.WriteLine("Retiro Exitoso - Saldo Nuevo: Q." + saldo);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Fondos Insuficientes....");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Valor inválido.....");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Gracias por usar el cajero");
                                break;
                            default:
                                Console.WriteLine("Opción Inválida");
                                break;
                        }
                        Console.WriteLine(); //Salto de línea
                    }
                    return; //retornar al programa
                }
                else
                {
                    intentos++;
                    Console.WriteLine("PIN Incorrecto, intento "+intentos+"de 3\n");
                }
            }
            else
            {
                Console.WriteLine("Ingrese un PIN válido\n");
            }
        }

        //Bloqueo de la tarjeta
        Console.WriteLine("Tarjeta Bloqueada\nDemasiados intentos fallidos.");
        Console.ReadKey();
    }
}