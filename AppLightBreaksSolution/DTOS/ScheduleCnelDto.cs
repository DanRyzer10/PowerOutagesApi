namespace AppLightBreaksSolution.DTOS
{
    public class ScheduleCnelDto
    {
        public string resp  { get; set; }
        public IEnumerable<DetalleCnelDto> notificaciones { get; set; }
    }
}
