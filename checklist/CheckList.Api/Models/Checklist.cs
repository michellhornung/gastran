namespace CheckList.Api.Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public int SupervisorId { get; set; }
        public string Observacoes { get; set; }
        public bool Aprovado { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public List<ItemChecklist> Itens { get; set; } = new List<ItemChecklist>();
    }
}