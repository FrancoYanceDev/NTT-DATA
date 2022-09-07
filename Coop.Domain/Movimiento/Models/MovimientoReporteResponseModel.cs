﻿ 
namespace Coop.Domain.Movimiento.Models
{
    public class MovimientoReporteResponseModel
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }

        public Guid NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }

        public decimal Movimiento { get; set; }
        public decimal SaldoDsiponible { get; set; }
    }
}
