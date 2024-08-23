using System.Text.Json.Serialization;

namespace CheckList.Api.Models
{
    public class ItemChecklist
    {
        public int Id { get; set; }
        public int ChecklistId { get; set; }
        public string Descricao { get; set; }
        public bool Conforme { get; set; }
    }
}