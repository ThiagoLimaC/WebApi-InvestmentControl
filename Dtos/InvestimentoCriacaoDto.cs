namespace WebApi_InvestmentControl.Dtos
{
    public class InvestimentoCriacaoDto
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInvestimento { get; set; }
    }
}
