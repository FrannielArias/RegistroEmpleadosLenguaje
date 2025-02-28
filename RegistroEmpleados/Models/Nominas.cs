using System.ComponentModel.DataAnnotations;

namespace RegistroEmpleados.Models;

public class Nominas{

    [Key]
    public int NominaId { get; set; }

    [Required(ErrorMessage = "Salario Obligatorio")]
    [Range(20000, 300000, ErrorMessage = "ingrese un valor mayor a $20,000 y menor a $300,000")]
    public double SalarioBruto { get; set; }

    public double SalarioNeto { get; set; }

    public double AFP { get; set; } = 2.87;

    public double SeguroMedico { get; set; } = 3.04;

    public double ImpuestoSobreRenta { get; set; } = 0.15;

    public double Prestamo { get; set; } = 0;

    public int HorasExtras { get; set; } = 0;


    public void CalcularSalarioNeto(){

        double salarioHora = SalarioBruto / 160; // 160 horas al mes (promedio)
        double pagoHorasExtras = salarioHora * 1.5 * HorasExtras;

        double descuentoAFP = SalarioBruto * (AFP / 100);
        double descuentoSeguro = SalarioBruto * (SeguroMedico / 100);
        double descuentoISR = SalarioBruto * ImpuestoSobreRenta; // Tramo simplificado

        double totalDescuentos = descuentoAFP + descuentoSeguro + descuentoISR + Prestamo;
        SalarioNeto = SalarioBruto + pagoHorasExtras - totalDescuentos;
    }
}