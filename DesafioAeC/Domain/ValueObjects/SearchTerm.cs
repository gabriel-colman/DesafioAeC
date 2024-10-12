namespace DesafioAeC.Domain.ValueObjects
{
    public class SearchTerm
    {
        // Propriedade para armazenar o termo de busca
        public string Term { get; private set; }

        // Construtor que inicializa o termo de busca
        public SearchTerm(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                throw new ArgumentException("O termo de busca não pode ser vazio ou nulo.", nameof(term));
            }
            Term = term;
        }

        // Método de fábrica para criar uma instância de SearchTerm
        public static SearchTerm Create(string term)
        {
            return new SearchTerm(term);
        }

        // Override do método ToString para facilitar a exibição do termo de busca
        public override string ToString()
        {
            return Term;
        }
    }
}
