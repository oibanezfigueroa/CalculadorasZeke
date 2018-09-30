using System;


namespace Calculadoras
{
    class Program
    {

      
        static void Main(string[] args)
        {
            //Variable que indica la calculadora seleccionada
            int calculatorSelected = 0;
            
            MathOperations matOperations = new MathOperations();

            //Mostrará el menu principal hasta que presione la opción 4
            while (calculatorSelected != 4)
            {
                //Recibe opción validada
                calculatorSelected = ShowMenu();

                if (calculatorSelected > 0 && calculatorSelected < 4)
                {
                    //Variable que indica la operación que hará la calculadora
                    int operationSelected = 0;

                    ShowCalculatorSelected(calculatorSelected);

                    //variable para mostrar el resultado final
                    string strResult = string.Empty;

                    //Se muestra submenu con las operaciones de suma, resta, fibonacci, PI
                    operationSelected = ShowSubMenu();

                    if (operationSelected == 1 || operationSelected == 2)
                    {
                        //Eligió Sumar o Restar
                        //Se pide números Floats validados. Si es calculadora FourModule, se transforman antes de asignar
                        float number1 = calculatorSelected == 3 ? matOperations.GetModuleFloat(AskForNumberFloat(1)) : AskForNumberFloat(1);
                        float number2 = calculatorSelected == 3 ? matOperations.GetModuleFloat(AskForNumberFloat(2)) : AskForNumberFloat(2);

                        //Se envía a la función para que realice los cálculos
                        float result = matOperations.SumRestOperation(number1, number2, calculatorSelected, operationSelected);
                        strResult = GetMessageResult(result.ToString(), calculatorSelected, operationSelected);

                    }
                    else if (operationSelected == 3)
                    {
                        //Eligió fibonacci

                        //Se pide número entero validado. Si es calculadora FourModule, se transforma antes de asignar
                        int number = calculatorSelected == 3 ? matOperations.GetModuleInt(AskForNumberInt(0)) : AskForNumberInt(0);

                        //Se envía a la función para que realice los cáculos
                        int result = calculatorSelected == 3 ? matOperations.GetModuleInt(matOperations.Fibonacci(number, calculatorSelected))
                                                             : matOperations.Fibonacci(number, calculatorSelected);
                        strResult = GetMessageResult(result.ToString(), calculatorSelected, operationSelected);

                    }
                    else if (operationSelected == 4)
                    {
                        //Eligió Pi

                        //Se pide número entero validado.Si es calculadora FourModule, se transforma antes de asignar
                        int number = calculatorSelected == 3 ? matOperations.GetModuleInt(AskForNumberInt(0)) : AskForNumberInt(0);

                        //Se envía a la función para que realice los cáculos
                        int result = calculatorSelected == 3 ? matOperations.GetModuleInt(matOperations.Pi(number, calculatorSelected))
                                                             : matOperations.Pi(number, calculatorSelected);

                        strResult = GetMessageResult(result.ToString(), calculatorSelected, operationSelected);

                    }

                    Console.WriteLine(strResult);
                    if (operationSelected != 5)
                        Clear();
                }
                
            }
        }

        /// <summary>
        /// Muestra menu principal y pide opción
        /// </summary>
        /// <returns></returns>
        public static int ShowMenu() {

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" Seleccione Calculadora. Escriba el número y presione Enter.");
            Console.WriteLine("      _________________________________________");
            Console.WriteLine("     |                                         |");
            Console.WriteLine("     |    OPCIÓN      |       CALCULADORA      |");
            Console.WriteLine("     |      1         |          Casio         |");
            Console.WriteLine("     |      2         |          Kazio         |");
            Console.WriteLine("     |      3         |        FourModule      |");
            Console.WriteLine("     |      4         |           Salir        |");
            Console.WriteLine("     |_________________________________________|");
            Console.WriteLine();
            var option = Console.ReadLine();
            while (true)
            {
                //Valida que sea número y una de las opciones disponibles
                int outp;
                if (int.TryParse(option,out outp) && (Convert.ToInt32(option) > 0 && Convert.ToInt32(option) < 5))
                {
                    return Convert.ToInt32(option);
                }
                else{
                    Console.WriteLine("Ingrese una opción correcta");
                    option = Console.ReadLine();
                }

            }
        }
        
        /// <summary>
        /// Muestra sub menu con operaciones de las calculadoras
        /// </summary>
        /// <returns></returns>
        public static int ShowSubMenu()
        {
           
            Console.WriteLine();
            Console.WriteLine(" Seleccione opción. Escriba el número y presione Enter.");
            Console.WriteLine("      ___________________________________________");
            Console.WriteLine("     |                                           |");
            Console.WriteLine("     |    OPCIÓN      |        Operación         |");
            Console.WriteLine("     |      1         |          Sumar           |");
            Console.WriteLine("     |      2         |          Restar          |");
            Console.WriteLine("     |      3         |         Fibonacci        |");
            Console.WriteLine("     |      4         |    Mostrar decimal de Pi |");
            Console.WriteLine("     |      5         |          Volver          |");
            Console.WriteLine("     |___________________________________________|");
            Console.WriteLine();



            var option = Console.ReadLine();
            while (true)
            {
                //Valida que sea número y una de las opciones disponibles
                int outp;
                if (int.TryParse(option, out outp) && (Convert.ToInt32(option) > 0 && Convert.ToInt32(option) < 6))
                {
                    return Convert.ToInt32(option);
                }
                else
                {
                    Console.WriteLine("Ingrese una opción correcta");
                    option = Console.ReadLine();
                }

            }
           
        }

        /// <summary>
        /// Pide número float para realizar operaciones
        /// </summary>
        /// <param name="opt">Es para indicar primer número o segundo o por default nada</param>
        /// <returns></returns>
        public static float AskForNumberFloat(int opt)
        {
            Console.WriteLine("Ingrese " + (opt == 1 ? "primer" : (opt == 2 ? "segundo" : "" )) +  " número");

            var option = Console.ReadLine();

            while (true)
            {
                //Valida que sea float
                float outp;
                if (float.TryParse(option, out outp))
                {
                    //se remplaza . por , en caso de que decimal lo use con punto
                    return float.Parse(option.Replace(".",","));
                }
                else
                {
                    Console.WriteLine("Ingrese un número float correcto");
                    option = Console.ReadLine();
                }

            }


        }

        /// <summary>
        /// Pide número entero para realizar operaciones
        /// </summary>
        /// <param name="opt">Es para indicar primer número o segundo o por default nada</param>
        /// <returns></returns>
        public static int AskForNumberInt(int opt)
        {
            Console.WriteLine("Ingrese " + (opt == 1 ? "primer" : (opt == 2 ? "segundo" : "")) + " número");

            var option = Console.ReadLine();
            while (true)
            {
                //Valida que sea número entero
                int outp;
                if (int.TryParse(option, out outp))
                {
                    return Convert.ToInt32(option);
                }
                else
                {
                    Console.WriteLine("Ingrese un número entero correcto");
                    option = Console.ReadLine();
                }

            }
        }

        /// <summary>
        /// Limpia pantalla
        /// </summary>
        public static void Clear()
        {
            Console.WriteLine("");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
        }

        /// <summary>
        /// Muestra un mensaje de la calculadora selccionada
        /// </summary>
        /// <param name="option"></param>
        public static void ShowCalculatorSelected(int option)
        {
            Console.Clear();
            switch (option)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("     ########## CALCULADORA CASIO ##########");
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("     ########## CALCULADORA KAZIO ##########");
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("     ########## CALCULADORA FOURMODULE ##########");
                    Console.WriteLine();
                    break;
            }
        }

        /// <summary>
        /// Obtiene el mensaje que será mostrado terminando la operacion
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static string GetMessageResult(string result, int calculatorSelected, int operationSelected)
        {
            if (calculatorSelected == 1)
            {
                switch (operationSelected)
                {
                    case 1:
                        return "El resultado de la suma de los dos números es: " + result;
                    case 2:
                        return "El resultado de la resta de los dos números es: " + result;
                    case 3:
                        return "El número de la serie fibonacci es: " + result;
                    case 4:
                        return "El decimal de pi en la posición ingresada es: " + result;
                }

            } else if (calculatorSelected == 2)
            {
                switch (operationSelected)
                {
                    case 1:
                        return "El resultado de la suma de los dos números mas 42 es: " + result;
                    case 2:
                        return "El resultado de la resta de los dos números menos 42 es: " + result;
                    case 3:
                        return "El número de la serie fibonacci dividido en 2 es: " + result;
                    case 4:
                        return "El decimal de pi en la posición ingresada mas 2 es: " + result;
                }
            } else if (calculatorSelected == 3)
            {
                switch (operationSelected)
                {

                    case 1:
                        return "El resultado en módulo 4 de la suma de los dos números en base a su módulo 4 es: " + result;
                    case 2:
                        return "El resultado en módulo 4 de la resta de los dos números en base a su módulo 4 es: " + result;
                    case 3:
                        return "El número de la serie fibonacci en base al módulo 4 de la posición en base a su módulo 4 ingresado es: " + result;
                    case 4:
                        return "El decimal de pi en base al módulo 4 de la posición en base a su módulo 4 ingresado es: " + result;
                }
            }
            return string.Empty;
        }
    }
}
