using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
namespace Proyecto_1
{
    internal class Program
    {

        static void Main(string[] args)
        {



            Pagos pagos = new Pagos();
            int contador = 0;
            bool omitir = false;
            int[] _numeroPago = new int[10];
            string[] _fecha = new string[10];
            string[] _hora = new string[10];
            string[] _cedula = new string[10];
            string[] _nombre = new string[10];
            string[] _apellido1 = new string[10];
            string[] _apellido2 = new string[10];
            int[] _numeroDeCaja = new int[10];
            int[] _tipoServicio = new int[10];
            int[] _numeroFactura = new int[10];
            float[] _montoPagar = new float[10];
            float[] _montoComision = new float[10];
            float[] _montoDeducido = new float[10];
            float[] _montoPagaCliente = new float[10];
            float[] _vuelto = new float[10];




            int opcion = 0;
            while (opcion != 7)
            {
                Console.Clear();
                if (!omitir)
                {
                    Console.WriteLine("Menú Principal");
                    Console.WriteLine("Elija una opcion: ");
                    Console.WriteLine("1.Inicializar Vectores");
                    Console.WriteLine("2.Realizar Pagos");
                    Console.WriteLine("3.Consultar Pagos: ");
                    Console.WriteLine("4.Modificar Pagos");
                    Console.WriteLine("5.Eliminar Pagos");
                    Console.WriteLine("6.Submenú Reportes");
                    Console.WriteLine("7.Salir");
                    if (!int.TryParse(Console.ReadLine(), out opcion))
                    {
                        Console.WriteLine("Digite una opcion valida");
                    }
                }

                switch (opcion)
                {
                    case 1:
                        _numeroPago = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        _fecha = new string[10] { "", "", "", "", "", "", "", "", "", "" };
                        _hora = new string[10] { "", "", "", "", "", "", "", "", "", "" };
                        _cedula = new string[10] { "", "", "", "", "", "", "", "", "", "" };
                        _nombre = new string[10] { "", "", "", "", "", "", "", "", "", "" };
                        _apellido1 = new string[10] { "", "", "", "", "", "", "", "", "", "" };
                        _apellido2 = new string[10] { "", "", "", "", "", "", "", "", "", "" };
                        _numeroDeCaja = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        _tipoServicio = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        _numeroFactura = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        _montoPagar = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        _montoComision = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        _montoDeducido = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        _montoPagaCliente = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        _vuelto = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                        break;
                    case 2:
                        if (contador > 10)
                        {
                            Console.Clear();
                            Console.WriteLine("Pila de datos llena, por favor inicializar vectores");
                            Console.Write("Presione enter para continuar");
                            if (Console.ReadKey().Key == ConsoleKey.Enter)
                            {
                                break;
                            }

                        }
                        Console.Clear();
                        Console.WriteLine("Elija el tipo de servicio: ");
                        Console.WriteLine("1.Recibo de luz");
                        Console.WriteLine("2.Recibo telefono");
                        Console.WriteLine("3.Recibo de agua");
                        Console.WriteLine("4.Atras");
                        int tipoServicio = 0;
                        bool esNumerico = int.TryParse(Console.ReadLine(), out tipoServicio);
                        bool esValido = tipoServicio > 0 && tipoServicio < 5;
                        if (esNumerico && esValido)
                        {
                            if (tipoServicio == 4)
                            {
                                break;
                            }

                            int numeroPago = contador + 1;
                            DateTime date = DateTime.Now;
                            string fecha = date.ToString("dd/MM/yy");
                            string hora = date.ToString("hh:mm tt");
                            Console.WriteLine("Digite su numero de cedula: ");
                            string cedula = Console.ReadLine();
                            Console.WriteLine("Digite su nombre ");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Digite su primer apellido ");
                            string apellido1 = Console.ReadLine();
                            Console.WriteLine("Digite su segundo apellido ");
                            string apellido2 = Console.ReadLine();
                            Random rnd = new Random();
                            int numeroDeCaja = rnd.Next(1, 4);
                            Console.WriteLine("Digite su numero de factura");
                            int numeroFactura = 0;
                            int.TryParse(Console.ReadLine(), out numeroFactura);
                            Console.WriteLine("Digite el monto a pagar: ");
                            float montoPagar = 0;
                            float.TryParse(Console.ReadLine(), out montoPagar);
                            float montoComision = 0;
                            switch (tipoServicio)
                            {
                                case 1:
                                    montoComision = montoPagar * 0.04F;
                                    break;
                                case 2:
                                    montoComision = montoPagar * 0.055F;
                                    break;
                                case 3:
                                    montoComision = montoPagar * 0.065F;
                                    break;
                            }
                            float montoDeducido = montoPagar - montoComision;
                            Console.WriteLine("Digite su monto paga cliente: ");
                            float montoPagaCliente = 0;
                            float.TryParse(Console.ReadLine(), out montoPagaCliente);
                            float vuelto = montoPagaCliente - montoPagar;

                            pagos.imprimrEncabezado("Ingresar Datos");

                            pagos.imprimirReporte(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2, tipoServicio, numeroFactura, montoPagar, montoComision, montoPagaCliente, montoDeducido, vuelto);

                            Console.WriteLine("Desea continuar S/N? ");
                            if (Console.ReadLine().ToLower().Equals("s"))
                            {
                                _numeroPago[contador] = numeroPago;
                                _fecha[contador] = fecha;
                                _hora[contador] = hora;
                                _cedula[contador] = cedula;
                                _nombre[contador] = nombre;
                                _apellido1[contador] = apellido1;
                                _apellido2[contador] = apellido2;
                                _numeroDeCaja[contador] = numeroDeCaja;
                                _tipoServicio[contador] = tipoServicio;
                                _numeroFactura[contador] = numeroFactura;
                                _montoPagar[contador] = montoPagar;
                                _montoComision[contador] = montoComision;
                                _montoDeducido[contador] = montoDeducido;
                                _montoPagaCliente[contador] = montoPagaCliente;
                                _vuelto[contador] = vuelto;
                                contador++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Digite una opcion valida");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        pagos.imprimrEncabezado("Consultar Datos");
                        Console.WriteLine("Numero de Pago: ");
                        int numeroDePago3 = 0;
                        int posicion3 = -1;
                        bool esNumero3 = int.TryParse(Console.ReadLine(), out numeroDePago3);

                        for (int i = 0; i < _numeroPago.Length; i++)
                        {
                            if (_numeroPago[i] == numeroDePago3)
                            {

                                posicion3 = 1;
                                Console.Clear();
                                pagos.imprimrEncabezado("Consultar Datos");
                                pagos.imprimirReporte(_numeroPago[i], _fecha[i], _hora[i], _cedula[i], _nombre[i], _apellido1[i], _apellido2[i], _tipoServicio[i], _numeroFactura[i], _montoPagar[i], _montoComision[i], _montoPagaCliente[i], _montoDeducido[i], _vuelto[i]);




                                break;
                            }
                        }

                        if (posicion3 == -1)
                        {
                            Console.WriteLine("Dato no encontrado Posicion B vector " + numeroDePago3);
                        }

                        Console.WriteLine("Elija una opcion?");
                        Console.WriteLine("1. Regresar al menu principal");
                        Console.WriteLine("2. Realizar otra consulta");
                        int seleccion = 0;
                        if (int.TryParse(Console.ReadLine(), out seleccion))
                        {
                            if (seleccion == 2)
                            {
                                omitir = true;
                                opcion = 3;
                            }
                            else
                            {
                                omitir = false;
                                opcion = 0;
                            }
                        }

                        break;
                    case 4:
                        Console.Clear();
                        pagos.imprimrEncabezado("Modificar Datos");
                        Console.WriteLine("Numero de Pago: ");
                        int numeroDePago4 = 0;
                        int posicion4 = -1;
                        bool esNumero4 = int.TryParse(Console.ReadLine(), out numeroDePago4);

                        for (int i = 0; i < _numeroPago.Length; i++)
                        {
                            if (_numeroPago[i] == numeroDePago4)
                            {
                                string continuar = "s";
                                while (continuar.ToLower().Equals("s"))
                                {
                                    posicion4 = i;
                                    Console.Clear();
                                    pagos.imprimrEncabezado("Modificar Datos");
                                    pagos.imprimirReporteModificar(_numeroPago[i], _fecha[i], _hora[i], _cedula[i], _nombre[i], _apellido1[i], _apellido2[i], _tipoServicio[i], _numeroFactura[i], _montoPagar[i], _montoComision[i], _montoPagaCliente[i], _montoDeducido[i], _vuelto[i]);
                                    Console.WriteLine("Seleccione la opcion a modificar?");
                                    string opcionModificar = Console.ReadLine();
                                    Console.WriteLine("Nuevo Dato");
                                    switch (opcionModificar)
                                    {
                                        case "A":

                                            _fecha[i] = Console.ReadLine();
                                            break;
                                        case "B":
                                            _hora[i] = Console.ReadLine();
                                            break;
                                        case "C":
                                            _cedula[i] = Console.ReadLine();
                                            break;
                                        case "D":
                                            _nombre[i] = Console.ReadLine();
                                            break;
                                        case "E":
                                            _apellido1[i] = Console.ReadLine();
                                            break;
                                        case "F":
                                            _apellido2[i] = Console.ReadLine();
                                            break;
                                        case "G":
                                            int.TryParse(Console.ReadLine(), out _tipoServicio[i]);
                                            switch (_tipoServicio[i])
                                            {
                                                case 1:
                                                    _montoComision[i] = 0.04F;
                                                    break;
                                                case 2:
                                                    _montoComision[i] = 0.055F;
                                                    break;
                                                case 3:
                                                    _montoComision[i] = 0.065F;
                                                    break;
                                            }

                                            _montoDeducido[i] = _montoPagar[i] * _montoComision[i];

                                            break;
                                        case "H":
                                            int.TryParse(Console.ReadLine(), out _numeroFactura[i]);
                                            break;
                                        case "I":
                                            float.TryParse(Console.ReadLine(), out _montoPagaCliente[i]);
                                            _vuelto[i] = _montoPagaCliente[i] - _montoPagar[i];
                                            break;

                                    }
                                    Console.WriteLine("Desea continuar S/N? ");
                                    continuar = Console.ReadLine();
                                }


                            }
                        }

                        if (posicion4 == -1)
                        {
                            Console.WriteLine("Dato no encontrado Posicion A vector " + numeroDePago4);
                        }

                        Console.WriteLine("Elija una opcion?");
                        Console.WriteLine("1. Regresar al menu principal");
                        Console.WriteLine("2. Realizar otra consulta");
                        int seleccion4 = 0;
                        if (int.TryParse(Console.ReadLine(), out seleccion4))
                        {
                            if (seleccion4 == 2)
                            {
                                omitir = true;
                                opcion = 4;
                            }
                            else
                            {
                                omitir = false;
                                opcion = 0;
                            }
                        }

                        break;

                    case 5:
                        Console.Clear();
                        pagos.imprimrEncabezado("Eliminar Datos");
                        Console.WriteLine("Numero de Pago: ");
                        int numeroDePago5 = 0;
                        int posicion5 = -1;
                        bool esNumero5 = int.TryParse(Console.ReadLine(), out numeroDePago5);

                        for (int i = 0; i < _numeroPago.Length && esNumero5; i++)
                        {
                            if (_numeroPago[i] == numeroDePago5)
                            {

                                posicion5 = i;
                                Console.Clear();
                                pagos.imprimrEncabezado("Eliminar Datos");
                                pagos.imprimirReporte(_numeroPago[i], _fecha[i], _hora[i], _cedula[i], _nombre[i], _apellido1[i], _apellido2[i], _tipoServicio[i], _numeroFactura[i], _montoPagar[i], _montoComision[i], _montoPagaCliente[i], _montoDeducido[i], _vuelto[i]);
                                Console.WriteLine("Esta seguro de eliminar el dato S/N?");
                                if (Console.ReadLine().ToUpper().Equals("S"))
                                {
                                    _numeroPago[i] = 0;
                                    _fecha[i] = "";
                                    _hora[i] = "";
                                    _cedula[i] = "";
                                    _nombre[i] = "";
                                    _apellido1[i] = "";
                                    _apellido2[i] = "";
                                    _tipoServicio[i] = 0;
                                    _numeroFactura[i] = 0;
                                    _montoPagar[i] = 0;
                                    _montoComision[i] = 0;
                                    _montoPagaCliente[i] = 0;
                                    _montoDeducido[i] = 0;
                                    _vuelto[i] = 0;

                                    Console.WriteLine("La información ya fue eliminada");
                                }
                                else
                                {
                                    Console.WriteLine("La información no fue eliminada");

                                }



                                break;
                            }
                        }

                        if (posicion5 == -1)
                        {
                            Console.WriteLine("Pago no se encuentra Registrado");
                        }

                        Console.WriteLine("Elija una opcion?");
                        Console.WriteLine("1. Regresar al menu principal");
                        Console.WriteLine("2. Realizar otra consulta");
                        int seleccion5 = 0;
                        if (int.TryParse(Console.ReadLine(), out seleccion5))
                        {
                            if (seleccion5 == 2)
                            {
                                omitir = true;
                                opcion = 5;
                            }
                            else
                            {
                                omitir = false;
                                opcion = 0;
                            }
                        }

                        break;

                    case 6:

                        int submenu = 0;
                        Console.Clear();
                        Console.WriteLine("1. Ver todos los Pagos");
                        Console.WriteLine("2. Ver Pagos por tipo de Servicio");
                        Console.WriteLine("3. Ver Pagos por código de caja");
                        Console.WriteLine("4. Ver Dinero Comisionado por servicios");
                        Console.WriteLine("5. Regresar Menú Principal");
                        if (!int.TryParse(Console.ReadLine(), out submenu))
                        {
                            Console.WriteLine("Digite una opcion valida");
                        }
                        switch (submenu)
                        {
                            case 1:
                                pagos.imprimirTablaReporte(0, 0, _numeroPago, _fecha, _hora, _cedula, _nombre, _apellido1, _apellido2, _numeroDeCaja, _tipoServicio, _numeroFactura, _montoPagar);
                                Console.ReadLine();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Elija el tipo de servicio: ");
                                Console.WriteLine("1.Recibo de luz");
                                Console.WriteLine("2.Recibo telefono");
                                Console.WriteLine("3.Recibo de agua");
                                Console.WriteLine("4.Atras");
                                int tipoServicio6 = 0;
                                int.TryParse(Console.ReadLine(), out tipoServicio6);
                                if (tipoServicio6 == 4)
                                {
                                    break;
                                }
                                pagos.imprimirTablaReporte(tipoServicio6, 0, _numeroPago, _fecha, _hora, _cedula, _nombre, _apellido1, _apellido2, _numeroDeCaja, _tipoServicio, _numeroFactura, _montoPagar);
                                Console.ReadLine();
                                break;
                            case 3:

                                Console.Clear();
                                Console.WriteLine("Ingrese el numero de Caja: ");
                                int numeroCaja = 0;
                                int.TryParse(Console.ReadLine(), out numeroCaja);
                                pagos.imprimirTablaReporte(0, numeroCaja, _numeroPago, _fecha, _hora, _cedula, _nombre, _apellido1, _apellido2, _numeroDeCaja, _tipoServicio, _numeroFactura, _montoPagar);
                                Console.ReadLine();
                                break;
                            case 4:
                                pagos.imprimirReporteDineroComisionado(_tipoServicio, _montoPagar);
                                Console.ReadLine();
                                break;

                        }




                        break;
                }

            }









        }


    }

    internal class Pagos
    {
        public void imprimrEncabezado(string ventana)
        {
            Console.Clear();
            Console.WriteLine("Sistema Pago de Servicios Publicos");
            Console.WriteLine("Multiservicios - " + ventana);
        }

        public void imprimirReporte(int numeroPago, string fecha, string hora, string cedula, string nombre, string apellido1, string apellido2, int tipoServicio, int numeroFactura, float montoPagar, float montoComision, float montoPagaCliente, float montoDeducido, float vuelto)
        {
            Console.WriteLine("Numero de Pago" + numeroPago);
            Console.WriteLine("fecha:" + fecha + "            hora: " + hora);
            Console.WriteLine("Cedula: " + cedula + "           Nombre: " + nombre);
            Console.WriteLine("Apellido1: " + apellido1 + "     Apellido2: " + apellido2);
            Console.WriteLine("Tipo de Servicio: " + tipoServicio + "           [1.Electricidad  2.Telefono  3.Agua]");
            Console.WriteLine("Numero de Factura: " + numeroFactura + "         Monto a Pagar: " + montoPagar);
            Console.WriteLine("Comision autorizada: " + montoComision + "       Paga con: " + montoPagaCliente);
            Console.WriteLine("Monto deducido: " + montoDeducido + "       Vuelto: " + vuelto);
        }

        public void imprimirReporteModificar(int numeroPago, string fecha, string hora, string cedula, string nombre, string apellido1, string apellido2, int tipoServicio, int numeroFactura, float montoPagar, float montoComision, float montoPagaCliente, float montoDeducido, float vuelto)
        {
            Console.WriteLine("Numero de Pago" + numeroPago);
            Console.WriteLine("A-fecha:" + fecha + "                        B-hora: " + hora);
            Console.WriteLine("C-Cedula: " + cedula + "                     D-Nombre: " + nombre);
            Console.WriteLine("E-Apellido1: " + apellido1 + "               F-Apellido2: " + apellido2);
            Console.WriteLine("G-Tipo de Servicio: " + tipoServicio + "           [1.Electricidad  2.Telefono  3.Agua]");
            Console.WriteLine("H-Numero de Factura: " + numeroFactura + "   Monto a Pagar: " + montoPagar);
            Console.WriteLine("Comision autorizada: " + montoComision + "   I-Paga con: " + montoPagaCliente);
            Console.WriteLine("Monto deducido: " + montoDeducido + "        Vuelto: " + vuelto);
        }

        public void imprimirTablaReporte(int tipoServicio, int numeroDeCaja, int[] _numeroPago, string[] _fecha, string[] _hora, string[] _cedula, string[] _nombre, string[] _apellido1, string[] _apellido2, int[] _numeroDeCaja, int[] _tipoServicio, int[] _numeroFactura, float[] _montoPagar)
        {

            Console.WriteLine("Numero de Pago: ");
            imprimrEncabezado("Reporte Todos los Pagos");
            Console.WriteLine("#Pago  Fecha/HoraPago    Cedula     Nombre   Apellido1    Apellido2    Monto Recibido");
            Console.WriteLine("=======================================================================================================");
            int totalRegistros = 0;
            float montoTotal = 0;

            for (int i = 0; i < _numeroPago.Length; i++)
            {
                if (_numeroPago[i] != 0)
                {
                    bool xTipoServicio = tipoServicio != 0 && tipoServicio == _tipoServicio[i];
                    bool xNumeroCaja = numeroDeCaja != 0 && numeroDeCaja == _numeroDeCaja[i];
                    bool mostrarTodos = tipoServicio == 0 && numeroDeCaja == 0;

                    if (xTipoServicio || xNumeroCaja || mostrarTodos)
                    {
                        Console.WriteLine(_numeroPago[i] + "      " + _fecha[i] + " " + _hora[i] + "  " + _cedula[i] + "  " + _nombre[i] + "  " + _apellido1[i] + "       " + _apellido2[i] + "        " + _montoPagar[i]);
                        totalRegistros++;
                        montoTotal = montoTotal + _montoPagar[i];
                    }


                }

            }
            Console.WriteLine("\n \n \n Total de Registros: " + totalRegistros + "              Monto Total: " + montoTotal);
        }
        public void imprimirReporteDineroComisionado(int[] _tipoServicio, float[] _montoPagar)
        {
         
            int electricidad = 0;
            int telefono = 0;
            int agua = 0;
            float montoElectricidad = 0;
            float montoTelefono = 0;
            float montoAgua = 0;


            int totalRegistros = 0;
            float montoTotal = 0;

            for (int i = 0; i < _tipoServicio.Length; i++)
            {
                switch (_tipoServicio[i])
                {
                    case 1:
                        electricidad++;
                        montoElectricidad = montoElectricidad + _montoPagar[i];
                        break;

                    case 2:
                        telefono++;
                        montoTelefono = montoTelefono + _montoPagar[i];
                        break;

                    case 3:
                        agua++;
                        montoAgua = montoAgua + _montoPagar[i];
                        break;

                }
                totalRegistros++;
                montoTotal = montoTotal + _montoPagar[i];

            }
            Console.WriteLine("Reporte Dinero Comisionado - Desgloce por Tipo de Servicio");
            Console.WriteLine("ITEM             Cant.Transacciones              Total Comisionado");
            Console.WriteLine("==================================================================");
            Console.WriteLine("1-Electricidad       " + electricidad + "                            " + montoElectricidad);
            Console.WriteLine("2-Telefono           " + telefono     + "                            " + montoTelefono);
            Console.WriteLine("3-Agua               " + agua         + "                            " + montoAgua);
            Console.WriteLine("==================================================================");
            Console.WriteLine("\n \n \n Total:      " + totalRegistros + "                          " + montoTotal);
        }
    }


}
