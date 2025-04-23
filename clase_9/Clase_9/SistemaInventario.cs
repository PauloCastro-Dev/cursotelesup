using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Clase_9.Models;

namespace Clase_9
{
    public class SistemaInventario
    {
        private List<TipoEmpleado> _tiposEmpleados = [];
        private List<Empleado> _empleados = [];
        private List<Producto> _productos = [];
        private List<MovimientoStock> _movimientosStock = [];

        // Metodo para agregar un nuevo tipo de empleado
        public void AgregarTipoEmpleado(TipoEmpleado tipoEmpleado)
        {
            _tiposEmpleados.Add(tipoEmpleado);
        }

        // Metodo para listar todos los tipos de empleados
        public List<TipoEmpleado> ObtenerTipoEmpleados()
        {
            return _tiposEmpleados.ToList();
        }

        // Metodo para obtener un solo tipo empleado y quiero que sea por ID
        public TipoEmpleado ObtenerTipoEmpleadoPorId(int id)
        {
            return _tiposEmpleados.FirstOrDefault(e => e.Id == id);
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            _empleados.Add(empleado);
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return _empleados.ToList();
        }

        public Empleado ObtenerEmpleadoPorId(int id)
        {
            return _empleados.FirstOrDefault(t => t.Id == id);
        }

        public void AgregarProducto(Producto producto)
        {
            _productos.Add(producto);
        }
        public List<Producto> ObtenerProductos()
        {
            return _productos.ToList();
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public void AgregarMovimientoStock(MovimientoStock movimiento)
        {
            _movimientosStock.Add(movimiento);
        }

        public List<MovimientoStock> ObtenerMovimientosStock()
        {
            return _movimientosStock.ToList();
        }
    }
}