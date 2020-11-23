using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesTP4;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Libreria libreria = new Libreria();
            Libreria libreria2 = new Libreria();
            Cuento c1 = new Cuento("Argonauta", "Pinocho", 525,"Incluye ilustraciones");
            Novela n1 = new Novela("Bajo la luna", "Poema del Mio Cid", 210, true);
            Investigacion i1 = new Investigacion("Apagogue", "Autonomia Cientifica", 460,4);            //Instancio libros
            Novela n2 = new Novela("Bajo la luna", "Poema del Mio Cid", 410, false);          
            Investigacion i2 = new Investigacion("Baltasara", "Fundamentos de la Economia", 1000,4);
            
            libreria += c1;
            libreria += n1;
            libreria += i1;          //agrego los libros a la libreria
            libreria += n2;          

            if(libreria.Xml(libreria, "TesteoLibreriaXml.xml"))
            {                                                                   
                Console.WriteLine("La libreria se serializo correctamente");        //testeo que se este guardando correctamente
                                                                                    //la libreria en un archivo xml
            }
           
            if(libreria.GuardarTexto("TesteoLibreriaTxt.txt"))
            {                                                                           
                Console.WriteLine("La libreria se guardo en txt correctamente");    //testeo que se este guardando correctamente
                                                                                    //la libreria en un archivo de texto
            }


            Console.WriteLine(libreria.ToString());            //muestro la libreria

           
            Console.ReadLine();
        }
    }
}
