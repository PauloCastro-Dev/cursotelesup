using System;

namespace Clase_6;

public class Producto
{
	private string _nombre = string.Empty;
	private double _precio;
	private int _cantidad;
	private string _categoria = string.Empty;
	private string _codigo = string.Empty;
	private string _proveedor = string.Empty;

	public string Nombre
	{
		get => _nombre;
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("El nombre no puede estar vacío.");
			_nombre = value;
		}
	}

	public double Precio
	{
		get => _precio;
		set
		{
			if (value < 0)
				throw new ArgumentException("El precio no puede ser negativo.");
			_precio = value;
		}
	}

	public int Cantidad
	{
		get => _cantidad;
		set
		{
			if (value < 0)
				throw new ArgumentException("La cantidad no puede ser negativa.");
			_cantidad = value;
		}
	}

	public string Categoria
	{
		get => _categoria;
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("La categoría no puede estar vacía.");
			_categoria = value;
		}
	}

	public string Codigo
	{
		get => _codigo;
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("El código no puede estar vacío.");
			_codigo = value;
		}
	}

	public string Proveedor
	{
		get => _proveedor;
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("El proveedor no puede estar vacío.");
			_proveedor = value;
		}
	}

	public Producto(string nombre, double precio, int cantidad, string categoria, string codigo, string proveedor)
	{
		Nombre = nombre ?? string.Empty;
		Precio = precio;
		Cantidad = cantidad;
		Categoria = categoria ?? string.Empty;
		Codigo = codigo ?? string.Empty;
		Proveedor = proveedor ?? string.Empty;
	}
}
