using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PracticaII.Pages
{
    public class NominaModel : PageModel
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public double DescAFP { get; set; }
        public double DescARS { get; set; }
        public double DescISR { get; set; }
        public double TotalDesc { get; set; }
        public double SalarioAnual { get; set; }
        public double SalarioNeto { get; set; }

        public NominaModel empleado;

        // Metodo para resultado AFP
        public double CalcularAFP()
        {
            DescAFP = this.Salario * 0.0287;
            if (DescAFP > 7738.67)
            {
                return 0;
            }

            return DescAFP;
        }

        // Metodo para resultado ARS
        public double CalcularARS()
        {
            DescARS = this.Salario * 0.0304;
            if (DescARS > 4098.53)
            {
                return 0;
            }

            return DescARS;
        }

        
        // Metodo para resultado ISR
        public double CalcularISR()
        {
            double excede = 0; // Variable que almacenara la diferencia del excedente
            SalarioAnual = (this.Salario - (DescAFP + DescARS)) * 12; 

            if (SalarioAnual >= 416220.01 && SalarioAnual <= 624329.00)
            {
                excede = SalarioAnual - 416220.01;
                DescISR = (excede * 0.15) / 12;
                return DescISR;
            }
            else if (SalarioAnual >= 624329.01 && SalarioAnual <= 867123.00)
            {
                excede = SalarioAnual - 624329.01;
                DescISR = ((excede * 0.2) + 31216.00) / 12;
                return DescISR;
            }
            else if (SalarioAnual >= 867123.01)
            {
                excede = SalarioAnual - 867123.01;
                DescISR = ((excede * 0.25) + 79776.00) / 12;
                return DescISR;
            }
            else
            {
                DescISR = 0;
                return DescISR;
            }
                      

        }

        // Metodo para resultado del total de los descuentos

        public double CalcularTotDesc()
        {
            return TotalDesc = CalcularAFP() + CalcularARS() + CalcularISR();
        }

        // Metodo para resultado del sueldo neto

        public double CalcularNeto()
        {
            return SalarioNeto = Salario - CalcularTotDesc();
        }

        public void OnGet()
        {

        }
    }
}
