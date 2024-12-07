using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using ConsoleApp20;
using InfCar;    


namespace ConsolApp20
{
    class Program
    { 
        static void Main()
        {
            try
            {
                Menu menu = new Menu();
                menu.ShowMenu();
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);  
            }
         

        }
    }
}