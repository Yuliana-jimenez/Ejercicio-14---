using System;

Console.WriteLine("SISTEMA DE MONITOREO DE SENSORES INDUSTRIALES");
Console.WriteLine();

// CREAR LOS OBJETOS
SensorTemperatura sensorTemp = new SensorTemperatura();
SensorPresion sensorPresion = new SensorPresion();
SensorDistancia sensorDistancia = new SensorDistancia();


// 1. CAPTURAR DATOS DEL SENSOR DE TEMPERATURA
Console.WriteLine("--- SENSOR DE TEMPERATURA ---");

Console.Write("Ingrese el identificador del sensor: ");
sensorTemp.Identificador = Console.ReadLine() ?? "Sin identificador";

Console.Write("Ingrese el valor de temperatura en °C: ");
sensorTemp.Valormedio = Convert.ToDouble(Console.ReadLine());

Console.Write("¿El sensor está activo? (true/false): ");
sensorTemp.Activo = Convert.ToBoolean(Console.ReadLine());


// 2. CAPTURAR DATOS DEL SENSOR DE PRESIÓN
Console.WriteLine();
Console.WriteLine("--- SENSOR DE PRESIÓN ---");

Console.Write("Ingrese el identificador del sensor: ");
sensorPresion.Identificador = Console.ReadLine() ?? "Sin identificador";

Console.Write("Ingrese el valor de presión en bar: ");
sensorPresion.Valormedio = Convert.ToDouble(Console.ReadLine());

Console.Write("¿El sensor está activo? (true/false): ");
sensorPresion.Activo = Convert.ToBoolean(Console.ReadLine());


// 3. CAPTURAR DATOS DEL SENSOR DE DISTANCIA
Console.WriteLine();
Console.WriteLine("--- SENSOR DE DISTANCIA ---");

Console.Write("Ingrese el identificador del sensor: ");
sensorDistancia.Identificador = Console.ReadLine() ?? "Sin identificador";

Console.Write("Ingrese la distancia del objeto en cm: ");
sensorDistancia.Valormedio = Convert.ToDouble(Console.ReadLine());

Console.Write("¿El sensor está activo? (true/false): ");
sensorDistancia.Activo = Convert.ToBoolean(Console.ReadLine());


// MOSTRAR TODOS LOS RESULTADOS AL FINAL
Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine(" RESULTADOS DEL MONITOREO DE SENSORES");
Console.WriteLine("========================================");


// RESULTADOS DEL SENSOR DE TEMPERATURA
Console.WriteLine();
Console.WriteLine("--- SENSOR DE TEMPERATURA ---");
sensorTemp.MostrarDatos();
Console.WriteLine($"Evaluación: {sensorTemp.EvaluarTemperatura()}");


// RESULTADOS DEL SENSOR DE PRESIÓN
Console.WriteLine();
Console.WriteLine("--- SENSOR DE PRESIÓN ---");
sensorPresion.MostrarDatos();
Console.WriteLine($"Evaluación: {sensorPresion.EvaluarPresion()}");


// RESULTADOS DEL SENSOR DE DISTANCIA
Console.WriteLine();
Console.WriteLine("--- SENSOR DE DISTANCIA ---");
sensorDistancia.MostrarDatos();
Console.WriteLine($"Evaluación: {sensorDistancia.EvaluarDistancia()}");

Console.WriteLine();
Console.WriteLine("FIN DEL SISTEMA DE MONITOREO");


// CLASE BASE
class Sensor
{
    // Propiedades comunes
    public string Identificador { get; set; } = "";
    public double Valormedio { get; set; }
    public bool Activo { get; set; }

    // Método para determinar el estado del sensor
    public string ObtenerEstado()
    {
        if (Activo)
            return "Sensor activo y funcionando";

        return "Sensor inactivo";
    }

    // Método para mostrar los datos del sensor
    public void MostrarDatos()
    {
        Console.WriteLine($"Identificador: {Identificador}");
        Console.WriteLine($"Valor medido: {Valormedio}");
        Console.WriteLine($"Estado: {ObtenerEstado()}");
    }
}


// CLASE DERIVADA: SENSOR DE TEMPERATURA
class SensorTemperatura : Sensor
{
    public string EvaluarTemperatura()
    {
        if (!Activo)
            return "ATENCIÓN: El sensor está inactivo";

        if (Valormedio > 80)
            return "ALERTA: Temperatura mayor a 80 °C";

        return "Temperatura dentro del límite permitido";
    }
}


// CLASE DERIVADA: SENSOR DE PRESIÓN
class SensorPresion : Sensor
{
    public string EvaluarPresion()
    {
        if (!Activo)
            return "ATENCIÓN: El sensor está inactivo";

        if (Valormedio > 10)
            return "ALERTA: Presión superior a 10 bar";

        return "Presión dentro del límite permitido";
    }
}


// CLASE DERIVADA: SENSOR DE DISTANCIA
class SensorDistancia : Sensor
{
    public string EvaluarDistancia()
    {
        if (!Activo)
            return "ATENCIÓN: El sensor está inactivo";

        if (Valormedio < 0)
            return "ATENCIÓN: Distancia no válida";

        if (Valormedio < 20)
            return "ALERTA: El objeto está a menos de 20 cm";

        return "Distancia dentro del criterio establecido";
    }
}