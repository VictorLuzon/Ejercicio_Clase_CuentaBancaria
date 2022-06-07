using System;

namespace Ejercicio_CuentaBancaria
{
    /*Crear un programa que simule una cuenta bancaria, con las siguientes características:

    Crear una clase "CuentaBancaria" con los campos y métodos correspondientes *ver diagrama UML adjunto en el programa*

    El primer método que vemos en el diagrama es el constructor de la clase, 
    que recibirá los argumentos que ahí se indican e inicializará a los campos de la clase.

    El método "Deposito" se encarga de recibir una suma de dinero desde el exterior y la agregará al campo "saldo".

    El método "Retiro" se encarga de extraer una suma de dinero del campo "saldo" dada desde el exterior 
    (verificar que sea posible retirar la cantidad de dinero a partir del saldo que ya se encuentra en la cuenta).

    El método "ConsultaSaldo" se encarga simplemente de mostrarnos el dinero que tenemos en nuestra cuenta bancaria.

    El método "ToString" se encarga de mostrarnos la información del cliente (objeto).

    En Main nos encargaremos de pedir los siguientes datos:

    nombre, apellidos, dirección, codigoSeguridad y saldo inicial.

    Todos esos datos serán enviados al constructor de la clase "CuentaBancaria" en el momento de instanciarla.

    Después crearemos un menú que aparecerá mientras el usuario no decida salir (apoyarse de un Do-While), y contendrá las siguiente opciones:

    Deposito

    Retiro

    Consultar Saldo

    Mostrar información de la cuenta

    Salir

    Dependiendo de la opción que se escoja, mandar a llamar al método correspondiente de la clase y crear su lógica para que se pueda depositar o retirar dinero.*/

    /*DIAGRAMA:
    ---------------------------------
    |          CuentaBancaria       |
    |-------------------------------|       
    |    - nombre : string          |
    |    - apellidos: string        |
    |    - direccion: string        |
    |    - codigoSeguridad: string  |
    |    - saldo: double            |
    ---------------------------------
    -------------------------------------------------
    |    + CuentaBancaria(nombrePa, apellidosPa,    |
    |      direccioPa, codigoSeguridadPa, saldoPa)  |
    |    + Deposito(montoPa): double                |
    |    + Retiro(montoPa): double                  |
    |    + ConsultaSaldo(): void                    |
    |    + ToString: string                         |
    -------------------------------------------------*/              
    class Program
    {
        static void Main(string[] args)
        {
            //Damos la bienvenida al programa y nos apoyamos con un salto de linea al ser un texto largo (\n).
            Console.WriteLine("Bienvenido al programa del Banco MikeBank."
                            + "\nA continuación, se le van a pedir una serie de datos para rellenar la cuenta de un cliente.");
            
            //Pedimos al usuario su nombre.
            Console.WriteLine("\nIntroduzca el nombre del cliente: ");
            string nombre = Console.ReadLine();

            //Pedimos al usuario sus apellidos.
            Console.WriteLine("\nIntroduzca los dos apellidos del cliente: ");
            string apellidos = Console.ReadLine();

            //Pedimos al usuario su dirección.
            Console.WriteLine("\nIntroduzca la dirección del cliente: ");
            string direccion = Console.ReadLine();

            //Pedimos al usuario su código de seguridad. Simulamos que se pide como una especie de nº "PIN" que acepta caracteres alfanumericos.
            //Controlamos la entrada del pin con un while, codificando que si la longitud del supuesto "PIN" es diferente a 4 caracteres,
            //imprimirá un mensaje de error y nos volverá a pedir dicho "PIN".
            //No saldrá del bucle, hasta que pongamos exactamente 4 caracteres.
            string codigoSeguridad = "";
            while(codigoSeguridad.Length != 4){
                Console.WriteLine("\nIntroduzca un código de seguridad de 4 caracteres");
                codigoSeguridad = Console.ReadLine();
                
                if(codigoSeguridad.Length != 4){
                    Console.WriteLine("\nEl código de seguridad debe tener sólo 4 caracteres alfanumericos"
                                    + "\nVuelva a intentarlo");
                }
            }

            //Pedimos al usuario el saldo inicial de la cuenta.
            Console.WriteLine("\nIntroduzca el saldo inicial del cliente en esta cuenta bancaria: ");
            double saldo = Double.Parse(Console.ReadLine());

            //Confirmamos los datos introducidos informando al usuario que lo ha hecho correctamente, y que debe
            //pulsar una tecla para continuar. En cuanto pulsa cualquier tecla, limpiamos la pantalla para que aparezca el menú de opciones.
            Console.WriteLine("Datos introducidos correctamente.\nPulse cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            //Creamos la cuentaBancaria "cuentaCliente1" con los parametros que nos pide el ejercicio.
            CuentaBancaria cuentaCliente1 = new CuentaBancaria(nombre, apellidos, direccion, codigoSeguridad, saldo);

            //Declaramos la variable "opción" para la selección en el menú.
            int opcion;

            //Como nos pide el ejercicio, creamos un menú apoyandonos en un Do-While. Como queremos que el programa se meta si o si en el menú,
            //la opción del Do-While es la mas correcta, puesto que al menos queremos meternos 1 vez en el menú.
            do{
                Console.WriteLine("\nSeleccione la opción con la que desea operar:"
                                + "\n1. Deposito"
                                + "\n2. Retiro"
                                + "\n3. Consultar Saldo"
                                + "\n4. Mostrar información de la cuenta"
                                + "\n5. Salir");
                
                opcion = Int32.Parse(Console.ReadLine());
                
                //Utilizamos un switch para controlar la opción seleccionada por el usuario. LLamamos a los metodos de la clase CuentaBancaria necesarios
                //según la opción tecleada por el usuario. 
                //Controlamos con un [default] la correcta entrada de la opción. Si no elige correctamente, el programa se cerrará.
                //No saldremos del bucle hasta que la opción elegida, sea mayor a 5.
                switch(opcion){
                    case 1:
                    //Llamamos al método Deposito pasandole el saldo para operar con el.
                    cuentaCliente1.Deposito(saldo);
                    break;
                    case 2:
                    //Llamamos al método Retiro pasandole el saldo para operar con el.
                    cuentaCliente1.Retiro(saldo);
                    break;
                    case 3:
                    //Llamamos al método ConsultaSaldo para mostrar el saldo actual.
                    //Mostrará el correcto incluso después de operar con los métodos Deposito y Retiro.
                    cuentaCliente1.ConsultaSaldo();
                    break;
                    case 4:
                    //Llamamos al método ToString para mostrar los datos de la cuenta.
                    Console.WriteLine(cuentaCliente1.ToString());
                    break;
                    case 5:
                    //Imprimimos mensaje de salida de la aplicación.
                    Console.WriteLine("Saliendo de Mike Bank...");
                    break;
                    default:
                    //Imprimimos mensaje de error y salida de la aplicación en caso de elección incorrecta.
                    Console.WriteLine("No ha seleccionado una opción correcta, saliendo de la aplicación...");
                    break;
                }
            }while(opcion < 5);
        }
    }

    //Creamos la clase CuentaBancaria.
    class CuentaBancaria
    {   
        //Declaramos los campos que nos pide el ejercicio.
        private string nombre;
        private string apellidos;
        private string direccion;
        private string codigoSeguridad;
        private double saldo;

        //Cremos el constructor de la clase con los parámetros que nos pide el ejercicio. En este caso nombrePa significa nombreParametro.
        public CuentaBancaria(string nombrePa, string apellidosPa, string direccionPa, string codigoSeguridadPa, double saldoPa)
        {
            //Utilizamos la paralabra clave this con los campos declarados, haciendo referencia a los parámetros del constructor.
            this.nombre = nombrePa;
            this.apellidos = apellidosPa;
            this.direccion = direccionPa;
            this.codigoSeguridad = codigoSeguridadPa;
            this.saldo = saldoPa;
        }

        //Generemos un getter y un setter como descriptores de acceso de "Saldo", puesto que es el valor que vamos a ir pidiendo y modificando.
        public double Saldo
        {
            get {return saldo;}
            set {Saldo = value;}
        }

        //Creamos el método Deposito como nos pide el ejercicio, pasando por parámtro un "montoPa" montón de saldo en este caso, que irá sumando
        //el saldo que introduzca el usuario, al saldo inicial que ya habrá introducido.
        //Además, imprimimos el saldo después de hacer el desposito para ver si lo ha sumado correctamente.
        public double Deposito(double montoPa)
        {
            Console.WriteLine("Introduzca el saldo que quiera depositar en la cuenta");
            montoPa = Double.Parse(Console.ReadLine());

            saldo += montoPa;

            Console.WriteLine($"El saldo actual después de este deposito es de: {Saldo}");

            return saldo;
        }

        //Mismo método que Deposito pero en este caso para restar (Retirar) dinero del saldo.
        //Controlamos la retirada de Saldo de tal forma que, si la retirada especificada es mayor al saldo actual, 
        //nos imprimirá un error llevandonos de nuevo al menú principal.
        //Además, si la operación que realizamos dejara el saldo en negativo, nos aseguramos que el saldo sea el anterior a la retirada,
        //con la operación [saldo += montoPa] dentro del condicional.
        //En caso que la operación sea válida, dejando un saldo en positivo después de la retirada, imprimimos el saldo después de la operación,
        //para ver que la ha realizado correctamente.
        public double Retiro(double montoPa)
        {
            Console.WriteLine("Introduzca el dinero que quiere retirar");
            montoPa = Double.Parse(Console.ReadLine());

            saldo -= montoPa;

            if(saldo < 0){
                Console.WriteLine("Operación cancelada por saldo insuficiente"
                                + "\nVolviendo al menú principal...");
                saldo += montoPa;
            }
            else{
                Console.WriteLine($"El saldo actual después de este retiro es de: {Saldo}");
            }
            return saldo;
        }

        //Método sencillo dónde imprimios el saldo actual de la cuenta.
        public void ConsultaSaldo()
        {
            Console.WriteLine($"El saldo de la cuenta es de: {Saldo}");
        }

        //Invalidamos el método ToString tal y como nos pide el ejercicio, y mostramos todos los datos de la cuenta.
        public override string ToString() => $"Datos de la cuenta:" 
                                            +$"\nNombre: {nombre}"
                                            +$"\nApellido: {apellidos}" 
                                            +$"\nDirección: {direccion}"
                                            +$"\nRFC: {codigoSeguridad}" 
                                            +$"\nSaldo: {saldo}";

    }
}
