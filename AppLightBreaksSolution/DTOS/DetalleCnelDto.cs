namespace AppLightBreaksSolution.DTOS
{
    public class DetalleCnelDto
    {
        public int IdUnidadNegocios { get; set; }
        public string CuentaContrato { get; set; }
        public string CodigoUnico { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public IEnumerable<DetallePlanificacionCnelDto> DetallePlanificacion { get; set; }
     }

}
