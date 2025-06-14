namespace WebApi_InvestmentControl.Models
{
    public class InvestimentoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInvestimento { get; set; }
    }
}
