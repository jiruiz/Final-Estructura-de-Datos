using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
/*
 Realizar un programa que por medio de una Pila permita el ingreso de elementos para un control de patentes.
Los elementos deberán ser una cadena de 6 caracteres, validar que los 3 primeros sean alfanuméricos y los 3 siguientes sean numéricos. 
Ejemplo de patente:  RVO 456

El menú del programa tendrá las siguientes opciones:

Crear Pila
Borrar Pila
Agregar patente
Borrar patente
Listar todas las patentes
Listar última patente.
Listar primera patente.
Cantidad de patentes.
Salir 

Estas son las opciones básicas del menú, se deberán agregar 2 opciones más.
Cada elemento que se liste debe aparecer con el formato “1 – elemento”.

 */
namespace Final_Juan_Ignacio_Ruiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack patente = null;
            Console.WriteLine("SISTEMA DE INGRESO DE PATENTES");

            Console.WriteLine("Ingrese la opcion:  ");
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n\t1.Crear Pila: \n\t2.Borrar Pila: \n\t3.Agregar Patente: \n\t4.Borrar Patente:\n\t5.Listar Patentes:  \n\t6.Listar Ultima Patente:  \n\t7.Listar Primera Patente:  \n\t8.Cantidad de Patentes:  \n\t9.Busqueda por Patente en la Pila:  \n\t10.Modificar Patente: \n\t11.Salir");

                Console.WriteLine("Ingrese la opcion");
                try
                {
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            patente = new Stack();
                            
                            patente.Push("AWF895");
                            patente.Push("PLS963");
                            patente.Push("RFG147");
                            Console.WriteLine("se creó la pila. Debes Cargarla en la opcion 3 del menú de opciones");
                            Console.WriteLine("\n\tPatentes cargadas a modo de prueba");
                            foreach (string pat in patente)
                            {
                                Console.WriteLine(pat);
                            }
                            break;
                        case 2:

                            if (patente == null)
                            {
                                Console.WriteLine("la Pila esta vacia, no tiene patentes para mostrar");
                            }
                            else
                            {
                                patente.Clear();
                                Console.WriteLine("se borro la pila");
                            }
                            break;
                        case 3:
                            AgregarPatente(patente);
                            break;
                        case 4:
                            BorrarPatente(patente);
                            break;
                        case 5:
                            ListarPatentes(patente);
                            break;
                        case 6:
                            ListarUltimaPatente(patente);
                            break;
                        case 7:
                            ListarPrimeraPatente(patente);
                            break;
                        case 8:
                            CantidadPatenes(patente);
                            break;
                        case 9:
                            BusquedaPatente(patente);
                            break;
                        case 10:
                            ModificarPatente(patente);
                            break;
                        case 11:
                            salir = true;
                            break;
                        default:
                            break;
                    }
                }
                catch (FormatException e)
                {

                    Console.WriteLine("debes introducir un numero");
                }
                

                
            }
        }

        
        public static void AgregarPatente(Stack patente)
        {
            string patenteCompleta = "";
            string alfanumerica = "";
            int numerica = 0;
            bool EsEntero = true;
            int salida = 0;
            bool esCadena = true;
            


            do
            {
                Console.WriteLine("ingrese parte Alfanumerica");
                alfanumerica = Convert.ToString(Console.ReadLine());
                esCadena = Int32.TryParse(alfanumerica, out salida);

            } while (esCadena || alfanumerica.Length != 3);
            do
            {
                Console.WriteLine("Ingrese parte Numerica:  ");
                
                EsEntero = Int32.TryParse(Console.ReadLine(), out numerica);

            } while (!EsEntero);
            
            string numerosAcadena = Convert.ToString(numerica);
            patenteCompleta = alfanumerica.ToUpper() + numerosAcadena;
            patente.Push(patenteCompleta);
            Console.WriteLine("Patente Guardada!");
        
        
        }
        







        
        public static void BorrarpPatente(Stack patente)
        {
            Console.WriteLine("se borró {0} de la pila", patente.Peek());
            patente.Pop();
        }
        
        public static void ListarPatentes(Stack patente)
        {

            if (patente != null)
            {
                int contador = patente.Count;

                foreach (string cadaPatente in patente)
                {
                    if (cadaPatente != null)
                    {
                        Console.WriteLine("{0}- {1}", contador, cadaPatente);
                        contador--;

                    }
                    
                }
            }
            else if (patente == null || patente.Count == 0)
            {
                Console.WriteLine("La pila esta vacia, no tiene patentes para listar, debes inicializarla en la opcion 1 del menu de opciones");
            }
            else if (patente.Count == 0)
            {
                Console.WriteLine("La pila esta vacia, no tiene patentes para listar");
            }
        }


        public static void ListarUltimaPatente(Stack patente)
        {

            if (patente == null)
            {
                Console.WriteLine("la Pila esta vacia, no tiene patentes para mostrar");
            }
            else
            {
                
                Console.WriteLine("ultima patente ingresada: {0}", patente.Peek());
                
            }
        }


        public static void CantidadPatenes(Stack patente)
        {
            if (patente == null)
            {
                Console.WriteLine("la Pila esta vacia, no tiene patente");
            }
            else
            {

                Console.WriteLine("cantidad de patentes: {0}", patente.Count);

            }
            
        }

        
        public static void ListarPrimeraPatente(Stack patente)
        {

            if (patente == null)
            {
                Console.WriteLine("debe inicializar la Pila en la opcion 1 y cargarla con la opcion 3 del menu de opciones");
            }
            else if (patente != null)
            {
                Console.WriteLine("Primera Patente {0}", patente.ToArray()[patente.Count - 1]);
            }

           
        }
        
        

        public static void ModificarPatente(Stack patente)
        {
            string patenteCompleta = "";
            string alfanumerica = "";
            int numerica = 0;
            int salida = 0;
            bool esCadena = true;
            bool EsEntero = true;
            Object[] nuevoArrayPatentes = patente.ToArray();
            Console.WriteLine("ingrese patente a modificar:  ");
            string patenteAModificar = Convert.ToString(Console.ReadLine());
            if (patente != null)
            {
                if (patente.Contains(patenteAModificar.ToUpper()))
                {
                    for (int i = 0; i < nuevoArrayPatentes.Length; i++)
                    {
                        if (nuevoArrayPatentes[i].ToString() == patenteAModificar.ToString().ToUpper())
                        {
                            do
                            {
                                Console.WriteLine("ingrese nueva parte Alfanumerica");
                                alfanumerica = Convert.ToString(Console.ReadLine());
                                esCadena = Int32.TryParse(alfanumerica, out salida);

                            } while (esCadena || alfanumerica.Length != 3);
                            do
                            {
                                Console.WriteLine("Ingrese nueva parte nueva Numerica:  ");

                                EsEntero = Int32.TryParse(Console.ReadLine(), out numerica);

                            } while (!EsEntero);

                            string numerosAcadena = Convert.ToString(numerica);
                            patenteCompleta = alfanumerica.ToUpper() + numerosAcadena;
                            nuevoArrayPatentes[i] = patenteCompleta;
                            Console.WriteLine("\telemento modificado");
                            patente.Clear();
                            Array.Reverse(nuevoArrayPatentes);
                            foreach (string item in nuevoArrayPatentes)
                            {
                                if (item != null)
                                {
                                    patente.Push(item);
                                    
                                }

                            }
                        }

                    }
                }
                else
                {
                    Console.WriteLine("no esta registrada la patente que intenta Modificar");
                }
            }
            

        }

        


        public static void BorrarPatente(Stack patente)
        {
            Object[] nuevoArrayPatentes = patente.ToArray();
            Console.WriteLine("ingrese patente a borrar:  ");
            string patenteABorrar = Convert.ToString(Console.ReadLine());
            if (patente != null)
            {
                if (patente.Contains(patenteABorrar.ToUpper()))
                {
                    for (int i = 0; i < nuevoArrayPatentes.Length; i++)
                    {
                        if (nuevoArrayPatentes[i].ToString() == patenteABorrar.ToString().ToUpper())
                        {
                            nuevoArrayPatentes[i] = null;
                            Console.WriteLine("elemento borrado");
                            Array.Reverse(nuevoArrayPatentes);
                            patente.Clear();

                            foreach (string item in nuevoArrayPatentes)
                            {
                                if (item != null)
                                {
                                    
                                    patente.Push(item);
                                }

                            }
                        }

                    }
                }
                else
                {
                    Console.WriteLine("no esta registrada la patente que intenta borrar");
                }
            }

        }

        public static void BusquedaPatente(Stack patente)
        {
            if (patente == null)
            {
                Console.WriteLine("la pila esta vacia actualmente, debes inicializarla en la opción 1 del menú de opciones");
            }
            else if (patente != null)
            {
                Console.WriteLine("ingrese patente a buscar:  ");
                string patenteABuscar = Convert.ToString(Console.ReadLine());


                if (patente.Contains(patenteABuscar.ToUpper()))
                {

                    Console.WriteLine("patente encontrada {0}", patenteABuscar.ToUpper());
                }
                else if (!patente.Contains(patenteABuscar.ToUpper()))
                {
                    Console.WriteLine("no se encuentra la patente cargada");
                }

            }


        }

    }
}
