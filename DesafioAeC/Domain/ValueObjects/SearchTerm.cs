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
                throw new ArgumentException("O termo de busca n�o pode ser vazio ou nulo.", nameof(term));
            }
            Term = term;
        }

        // M�todo de f�brica para criar uma inst�ncia de SearchTerm
        public static SearchTerm Create(string term)
        {
            return new SearchTerm(term);
        }

        // Override do m�todo ToString para facilitar a exibi��o do termo de busca
        public override string ToString()
        {
            return Term;
        }
    }
}
