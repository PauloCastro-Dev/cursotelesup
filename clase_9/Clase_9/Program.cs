using System;
using System.Net.NetworkInformation;
using Clase_9.Models;
namespace Clase_9
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=== APLICACION ===");
			Console.WriteLine("");

			SistemaInventario sistema = new SistemaInventario();
			CargarDatosIniciales(sistema);

			bool salir = false;
			//int opcion = 0;
			while (!salir)
			{
				Console.WriteLine("Menu principal:");
				Console.WriteLine("1. Gestion de empleados");
				Console.WriteLine("2. Gestion de productos");
				Console.WriteLine("3. Movimientos de stock");
				Console.WriteLine("4. Reportes");
				Console.WriteLine("5. Salir");
				Console.WriteLine("");
				Console.WriteLine("Seleccione una opcion: ");
				try
				{
					int opcion = int.TryParse(Console.ReadLine(), out int parsedValue) ? parsedValue : 0;

					switch (opcion)
					{
						case 1:
							GestionEmpleados(sistema);
							break;
						case 2:
							GestionProductos(sistema);
							break;
						case 3:
							GestionMovimientosStock(sistema);
							break;
						case 4:
							Console.WriteLine("Reportes no disponibles en esta version.");
							break;
						case 5:
							Console.WriteLine("Saliendo de la aplicacion...");
							salir = true;
							break;
						default:
							Console.WriteLine("Opcion no valida, por favor intente nuevamente.");
							break;
					}

				}
				catch (Exception ex)
				{
					Console.WriteLine($"Ocurrio un error inesperado, por favor intente nuevamente. {ex.Message}");
					Console.WriteLine("Presione cualquier tecla para continuar...");
					Console.ReadKey();
				}
			}
		}

		static void GestionEmpleados(SistemaInventario sistema)
		{
			bool regresar = false;
			while (!regresar)
			{
				Console.WriteLine("\nGestion de Empleados: ");
				Console.WriteLine("\nSeleccione una opcion: ");
				Console.WriteLine("1. Agregar un empleado");
				Console.WriteLine("2. Ver lista de empleados");
				Console.WriteLine("3. Ver empleado por Id");
				Console.WriteLine("4. Mostrar lista de tipos de empleados");
				Console.WriteLine("0. Regresar al menu principal");

				string opcion = Console.ReadLine();

				switch (opcion)
				{
					case "1":
						AgregarEmpleado(sistema);
						break;
					case "2":
						MostrarEmpleados(sistema);
						break;
					case "3":
						MostrarEmpleadoPorId(sistema);
						break;
					case "4":
						// MostrarTipoEmpleados(sistema);
						break;
					case "0":
						regresar = true;
						break;
					default:
						Console.WriteLine("Opcion invalida.");
						break;
				}
			}
		}

		static void MostrarEmpleadoPorId(SistemaInventario sistema)
		{
			Console.WriteLine("\nMostrar Empleados por Id: ");
			Console.WriteLine("Ingresa el Id del Empleado: ");

			int id = int.Parse(Console.ReadLine());

			// Validar si el id existe

			var empleado = sistema.ObtenerEmpleadoPorId(id);

			Console.WriteLine("ID\tNombres\tTipo");
			Console.WriteLine("-------------------------------------");
			Console.WriteLine($"{empleado.Id}\t{empleado.Nombres}\t{empleado.TipoEmpleado.Nombre}\t{empleado.FechaIngreso}\t{empleado.Edad}\t{empleado.Genero}");
		}

		static void AgregarEmpleado(SistemaInventario sistema)
		{
			Console.WriteLine("\nAgregar un nuevo Empleado: ");

			Console.WriteLine("Nombre del empleado: ");
			string nombres = Console.ReadLine();

			Console.WriteLine("Tipo de Empleado: ");
			var tiposEmpleados = sistema.ObtenerTipoEmpleados();

			if (tiposEmpleados.Count == 0)
			{
				Console.WriteLine("No hay ningun tipo de Empleado");
				return;
			}

			Console.WriteLine("Tipos de empleados disponibles: ");

			for (int i = 0; i < tiposEmpleados.Count; i++)
			{
				Console.WriteLine("{0}. {1}", i + 1, tiposEmpleados[i].Nombre);
			}

			Console.WriteLine("Seleccionar el tipo de empleado:");
			if (!int.TryParse(Console.ReadLine(), out int tipoIndice) || tipoIndice < 0)
			{
				Console.WriteLine("Seleccion invalida.");
				return;
			}

			var tipoSeleccionado = tiposEmpleados[tipoIndice]; // Estoy agarrando una instancia de TipoEmpleado

			int edad = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Ingrese su genero con la palabra MASCULINO o FEMENINO");
			Genero genero = (Genero)Convert.ToInt32(Console.ReadLine()); // 1 = Masculino

			// Leeerlo con el tryParse

			// Agregar año, mes y fecha
			// Agregar usando el formato DD/MM/AAAA

			var empleado = new Empleado
			{
				Nombres = nombres,
				TipoEmpleado = tipoSeleccionado,
				Estado = EstadoEmpleado.ACTIVO,
				FechaIngreso = new DateTime(1900, 1, 1),
				Edad = edad,
				Genero = genero,
			};

			sistema.AgregarEmpleado(empleado);
			Console.WriteLine($"\n Empleado agregado con el ID: {empleado.Id}");
		}

		static void MostrarEmpleados(SistemaInventario sistema)
		{
			var empleados = sistema.ObtenerEmpleados();

			// Validar si no hay empleados
			if (empleados.Count == 0)
			{
				Console.WriteLine("No hay ningun Empleado");
				return;
			}

			Console.WriteLine("Lista de empleados");
			Console.WriteLine("ID\t\tNombres\t\tTipo\t");
			Console.WriteLine("-------------------------------------");
			foreach (var empleado in empleados)
			{
				Console.WriteLine($"{empleado.Id}\t{empleado.Nombres}\t{empleado.TipoEmpleado.Nombre}\t{empleado.FechaIngreso}\t{empleado.Edad}\t{empleado.Genero}");
			}
		}

		static void CargarDatosIniciales(SistemaInventario sistema)
		{
			// Agregar tipos de empleado
			var tipoAdmin = new TipoEmpleado { Nombre = "Administrador", Descripcion = "Acceso total al sistema" };
			var tipoAlmacen = new TipoEmpleado { Nombre = "Almacenero", Descripcion = "Gestion del almacen" };
			var tipoVendedor = new TipoEmpleado { Nombre = "Vendedor", Descripcion = "Reegistro de ventas" };

			sistema.AgregarTipoEmpleado(tipoAdmin);
			sistema.AgregarTipoEmpleado(tipoAlmacen);
			sistema.AgregarTipoEmpleado(tipoVendedor);

			// Agregar los empleados
			var empleado1 = new Empleado
			{
				Nombres = "Andre Antonio",
				TipoEmpleado = tipoAdmin,
				Estado = EstadoEmpleado.ACTIVO,
				FechaIngreso = new DateTime(1900, 1, 1),
				Edad = 29,
				Genero = Genero.MASCULINO,
				FechaCreacion = DateTime.Now,
				FechaModificacion = DateTime.Now
			};

			var empleado2 = new Empleado
			{
				Nombres = "Carlos Ramos",
				TipoEmpleado = tipoVendedor,
				Estado = EstadoEmpleado.ACTIVO,
				FechaIngreso = new DateTime(1987, 1, 1),
				Edad = 24,
				Genero = Genero.MASCULINO,
				FechaCreacion = DateTime.Now,
				FechaModificacion = DateTime.Now
			};

			sistema.AgregarEmpleado(empleado1);
			sistema.AgregarEmpleado(empleado2);

			// Agregar Productos


		}


		static void GestionProductos(SistemaInventario sistema)
		{
			bool regresar = false;
			while (!regresar)
			{
				Console.WriteLine("\nGestión de Productos:");
				Console.WriteLine("1. Agregar un producto");
				Console.WriteLine("2. Ver lista de productos");
				Console.WriteLine("3. Ver producto por Id");
				Console.WriteLine("0. Regresar al menú principal");

				string opcion = Console.ReadLine();

				switch (opcion)
				{
					case "1":
						AgregarProducto(sistema);
						break;
					case "2":
						MostrarProductos(sistema);
						break;
					case "3":
						MostrarProductoPorId(sistema);
						break;
					case "0":
						regresar = true;
						break;
					default:
						Console.WriteLine("Opción inválida.");
						break;
				}
			}
		}

		static void AgregarProducto(SistemaInventario sistema)
		{
			Console.WriteLine("\nAgregar un nuevo Producto:");

			Console.WriteLine("Nombre del producto:");
			string nombre = Console.ReadLine();

			Console.WriteLine("Descripción del producto:");
			string descripcion = Console.ReadLine();

			Console.WriteLine("Precio del producto:");
			if (!decimal.TryParse(Console.ReadLine(), out decimal precio) || precio <= 0)
			{
				Console.WriteLine("Precio inválido.");
				return;
			}

			Console.WriteLine("Cantidad inicial en stock:");
			if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad < 0)
			{
				Console.WriteLine("Cantidad inválida.");
				return;
			}

			var producto = new Producto
			{
				Nombre = nombre,
				Descripcion = descripcion,
				Precio = precio,
				Stock = cantidad,
				FechaCreacion = DateTime.Now,
				FechaModificacion = DateTime.Now
			};

			sistema.AgregarProducto(producto);
			Console.WriteLine($"\nProducto agregado con el ID: {producto.Id}");
		}

		static void MostrarProductos(SistemaInventario sistema)
		{
			var productos = sistema.ObtenerProductos();

			if (productos.Count == 0)
			{
				Console.WriteLine("No hay ningún producto.");
				return;
			}

			Console.WriteLine("Lista de productos:");
			Console.WriteLine("ID\tNombre\t\tDescripción\t\tPrecio\tCantidad");
			Console.WriteLine("------------------------------------------------------------");
			foreach (var producto in productos)
			{
				Console.WriteLine($"{producto.Id}\t{producto.Nombre}\t{producto.Descripcion}\t{producto.Precio}\t{producto.Stock}");
			}
		}

		static void MostrarProductoPorId(SistemaInventario sistema)
		{
			Console.WriteLine("\nMostrar Producto por Id:");
			Console.WriteLine("Ingresa el Id del Producto:");

			if (!int.TryParse(Console.ReadLine(), out int id))
			{
				Console.WriteLine("Id inválido.");
				return;
			}

			var producto = sistema.ObtenerProductoPorId(id);

			if (producto == null)
			{
				Console.WriteLine("Producto no encontrado.");
				return;
			}

			Console.WriteLine("ID\tNombre\t\tDescripción\t\tPrecio\tCantidad");
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine($"{producto.Id}\t{producto.Nombre}\t{producto.Descripcion}\t{producto.Precio}\t{producto.Stock}");
		}

		static void GestionMovimientosStock(SistemaInventario sistema)
		{
			bool regresar = false;
			while (!regresar)
			{
				Console.WriteLine("\nGestión de Movimientos de Stock:");
				Console.WriteLine("1. Registrar entrada de stock");
				Console.WriteLine("2. Registrar salida de stock");
				Console.WriteLine("3. Ver movimientos de stock");
				Console.WriteLine("0. Regresar al menú principal");

				string opcion = Console.ReadLine();

				switch (opcion)
				{
					case "1":
						RegistrarEntradaStock(sistema);
						break;
					case "2":
						RegistrarSalidaStock(sistema);
						break;
					case "3":
						MostrarMovimientosStock(sistema);
						break;
					case "0":
						regresar = true;
						break;
					default:
						Console.WriteLine("Opción inválida.");
						break;
				}
			}
		}

		static void RegistrarEntradaStock(SistemaInventario sistema)
		{
			Console.WriteLine("\nRegistrar entrada de stock:");

			Console.WriteLine("Ingresa el ID del producto:");
			if (!int.TryParse(Console.ReadLine(), out int idProducto))
			{
				Console.WriteLine("ID inválido.");
				return;
			}

			var producto = sistema.ObtenerProductoPorId(idProducto);
			if (producto == null)
			{
				Console.WriteLine("Producto no encontrado.");
				return;
			}

			Console.WriteLine("Cantidad a ingresar:");
			if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
			{
				Console.WriteLine("Cantidad inválida.");
				return;
			}

			producto.Stock += cantidad;

			var movimiento = new MovimientoStock
			{
				Producto = producto,
				TipoMovimiento = TipoMovimiento.ENTRADA,
				Cantidad = cantidad,
				Fecha = DateTime.Now
			};

			sistema.AgregarMovimientoStock(movimiento);
			Console.WriteLine("Entrada de stock registrada correctamente.");
		}

		static void RegistrarSalidaStock(SistemaInventario sistema)
		{
			Console.WriteLine("\nRegistrar salida de stock:");

			Console.WriteLine("Ingresa el ID del producto:");
			if (!int.TryParse(Console.ReadLine(), out int idProducto))
			{
				Console.WriteLine("ID inválido.");
				return;
			}

			var producto = sistema.ObtenerProductoPorId(idProducto);
			if (producto == null)
			{
				Console.WriteLine("Producto no encontrado.");
				return;
			}

			Console.WriteLine("Cantidad a retirar:");
			if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
			{
				Console.WriteLine("Cantidad inválida.");
				return;
			}

			if (producto.Stock < cantidad)
			{
				Console.WriteLine("No hay suficiente stock disponible.");
				return;
			}

			producto.Stock -= cantidad;

			var movimiento = new MovimientoStock
			{
				Producto = producto,
				TipoMovimiento = TipoMovimiento.SALIDA,
				Cantidad = cantidad,
				Fecha = DateTime.Now
			};

			sistema.AgregarMovimientoStock(movimiento);
			Console.WriteLine("Salida de stock registrada correctamente.");
		}

		static void MostrarMovimientosStock(SistemaInventario sistema)
		{
			var movimientos = sistema.ObtenerMovimientosStock();

			if (movimientos.Count == 0)
			{
				Console.WriteLine("No hay movimientos de stock registrados.");
				return;
			}

			Console.WriteLine("Movimientos de stock:");
			Console.WriteLine("Producto\tTipo\tCantidad\tFecha");
			Console.WriteLine("------------------------------------------------------------");
			foreach (var movimiento in movimientos)
			{
				Console.WriteLine($"{movimiento.Producto.Nombre}\t{movimiento.TipoMovimiento}\t{movimiento.Cantidad}\t{movimiento.Fecha}");
			}
		}
	}
}