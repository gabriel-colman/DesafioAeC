namespace DesafioAeC.Domain.Entities
{
    public class Course
    {
        // Propriedade que representa o t�tulo do curso
        public string Title { get; private set; }

        // Propriedade que representa o professor ou instrutor do curso
        public string Professor { get; private set; }

        // Propriedade que representa a carga hor�ria do curso
        public string Duration { get; private set; }

        // Propriedade que representa a descri��o do curso
        public string Description { get; private set; }

        // Construtor que inicializa todas as propriedades
        public Course(string title, string professor, string duration, string description)
        {
            Title = title;
            Professor = professor;
            Duration = duration;
            Description = description;
        }

        // M�todo est�tico de f�brica para criar uma inst�ncia da entidade Course
        public static Course Create(string title, string professor, string duration, string description)
        {
            return new Course(title, professor, duration, description);
        }

        // Override do m�todo ToString para facilitar a exibi��o dos dados do curso
        public override string ToString()
        {
            return $"Curso: {Title}, Professor: {Professor}, Carga Hor�ria: {Duration}, Descri��o: {Description}";
        }
    }
}
