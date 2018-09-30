using System;


namespace Calculadoras
{
    public class MathOperations
    {

        /// <summary>
        /// Suma o resta dos números y dependiendo de la opción, resta o suma 42 o calcula el módulo
        /// </summary>
        /// <param name="number1">Primer número ingresado por el usuario</param>
        /// <param name="number2">Segundo número ingresado por el usuario</param>
        /// <param name="calculatorSelected">Elección de calculadora</param>
        /// <param name="subOptionSelected">Elección de suma o resta</param>
        /// <returns></returns>
        public float SumRestOperation(float number1, float number2, int calculatorSelected, int subOptionSelected)
        {
            float result = 0;
            if(subOptionSelected == 1)
            {
                //Si es casio se entrega la suma, si es kazio, la suma mas 42, si es FourModule se entrega el módulo de la suma
                result = calculatorSelected == 1 ? number1 + number2 : (calculatorSelected == 2 ? number1 + number2 + 42 : GetModuleFloat(number1 + number2));
                
            }else if(subOptionSelected == 2)
            {
                //Si es casio se entrega la resta, si es kazio, la resta menos 42, si es FourModule se entrega el módulo de la resta
                result = calculatorSelected == 1 ? number1 - number2 : (calculatorSelected == 2 ? number1 - number2 - 42 : GetModuleFloat(number1 - number2));
            }
            return result;
        }

        /// <summary>
        /// Fucnión que devuelve el  n-ésimo número de la serie fibonacci y en caso de ser calculadora Kazio, se divide en 2 
        /// </summary>
        /// <param name="n">Tope de la serie</param>
        /// /// <param name="calculatorSelected">Elección de calculadora</param>
        /// <returns></returns>
        public int Fibonacci(int position, int calculatorSelected)
        {

            int result = 0;
            int a = 0;
            int b = 1;
     
            for (int i = 0; i < position; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            result = a;

            if (calculatorSelected == 2)
                result = a / 2;

            return result;
        }

        /// <summary>
        /// Retorna el decimal en la posición ingresada 
        /// </summary>
        /// <param name="position"> posición del decimal a retornar</param>
        /// <param name="calculatorSelected">Elección de calculadora</param>
        /// <returns></returns>
        public int Pi(int position, int calculatorSelected)
        {

            //Se elimina el "3," para quedar solo con los decimales
            string pi = Math.PI.ToString().Substring(2);
            
            //recorre el string con todos los decimales
            for (int i = 0; i < pi.Length; i++)  
                //compara posición con la actual
                if (i + 1 == position)
                    //si la encuentra, evalua si es calculadora casio/fourmodule y devuelve el valor o kazio, en cuyo caso suma 2
                    return ((calculatorSelected == 1|| calculatorSelected == 3) ? int.Parse(pi.Substring(i, 1)) : int.Parse(pi.Substring(i, 1)) + 2) ;
                            
            return 0;
          
        }

        /// <summary>
        /// Calcula el módulo 4 de un número y devuelve un float
        /// </summary>
        /// <param name="n">número al que se le calculará el módulo</param>
        /// <returns></returns>
        public float GetModuleFloat(float number) 
        {
            return number % 4;
        }

        /// <summary>
        /// Calcula el módulo 4 de un número entero
        /// </summary>
        /// <param name="n">número al que se le calculará el módulo</param>
        /// <returns></returns>
        public int GetModuleInt(int number)
        {
            return number % 4;
        }
    }
}
