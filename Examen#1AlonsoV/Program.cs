using System;

class Empleado
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public double Salario { get; set; }

    public Empleado(string cedula, string nombre, string direccion, string telefono, double salario)
    {
        Cedula = cedula;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Salario = salario;
    }
}

class Menu
{
    private Empleado[] empleados;

    public Menu(int capacidad)
    {
        empleados = new Empleado[capacidad];
    }

    public void AgregarEmpleado(string cedula, string nombre, string direccion, string telefono, double salario)
    {
        for (int i = 0; i < empleados.Length; i++)
        {
            if (empleados[i] == null)
            {
                empleados[i] = new Empleado(cedula, nombre, direccion, telefono, salario);
                Console.WriteLine("Empleado agregado exitosamente.");
                return;
            }
        }
        Console.WriteLine("No hay espacio para más empleados.");
    }

    public void ConsultarEmpleadoPorCedula(string cedula)
    {
        foreach (var empleado in empleados)
        {
            if (empleado != null && empleado.Cedula == cedula)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario}");
                return;
            }
        }
        Console.WriteLine("Empleado no encontrado.");
    }

    public void ModificarEmpleadoPorCedula(string cedula, string nombre, string direccion, string telefono, double salario)
    {
        for (int i = 0; i < empleados.Length; i++)
        {
            if (empleados[i] != null && empleados[i].Cedula == cedula)
            {
                empleados[i].Nombre = nombre;
                empleados[i].Direccion = direccion;
                empleados[i].Telefono = telefono;
                empleados[i].Salario = salario;
                Console.WriteLine("Empleado modificado exitosamente.");
                return;
            }
        }
        Console.WriteLine("Empleado no encontrado.");
    }

    public void MostrarMenu()
    {
        Console.WriteLine("Menú Principal:");
        Console.WriteLine("1. Agregar Empleado");
        Console.WriteLine("2. Consultar Empleado");
        Console.WriteLine("3. Modificar Empleado");
        // Agrega las demás opciones del menú según tus requerimientos
        Console.WriteLine("0. Salir");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu(100); // Capacidad para 100 empleados (puedes ajustarlo según tus necesidades)

        while (true)
        {
            menu.MostrarMenu();
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la cédula: ");
                    string cedula = Console.ReadLine();
                    Console.Write("Ingrese el nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese la dirección: ");
                    string direccion = Console.ReadLine();
                    Console.Write("Ingrese el teléfono: ");
                    string telefono = Console.ReadLine();
                    Console.Write("Ingrese el salario: ");
                    double salario = Convert.ToDouble(Console.ReadLine());
                    menu.AgregarEmpleado(cedula, nombre, direccion, telefono, salario);
                    break;
                case 2:
                    Console.Write("Ingrese la cédula del empleado a consultar: ");
                    string cedulaConsulta = Console.ReadLine();
                    menu.ConsultarEmpleadoPorCedula(cedulaConsulta);
                    break;
                case 3:
                    Console.Write("Ingrese la cédula del empleado a modificar: ");
                    string cedulaModificacion = Console.ReadLine();
                    Console.Write("Ingrese el nuevo nombre: ");
                    string nuevoNombre = Console.ReadLine();
                    Console.Write("Ingrese la nueva dirección: ");
                    string nuevaDireccion = Console.ReadLine();
                    Console.Write("Ingrese el nuevo teléfono: ");
                    string nuevoTelefono = Console.ReadLine();
                    Console.Write("Ingrese el nuevo salario: ");
                    double nuevoSalario = Convert.ToDouble(Console.ReadLine());
                    menu.ModificarEmpleadoPorCedula(cedulaModificacion, nuevoNombre, nuevaDireccion, nuevoTelefono, nuevoSalario);
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }
}
