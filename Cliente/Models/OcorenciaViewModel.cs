namespace Cliente.Models
{
    public class OcorrenciaViewModel
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public int ResponsavelAberturaId { get; set; }
        public int ResponsavelOcorrenciaId { get; set; }
        public string Conclusao { get; set; }
    }
}
