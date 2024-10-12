namespace DesafioAeC.Domain.Entities
{
    public class Course
    {
        // Propriedade que representa o título do curso
        public string Title { get; private set; }

        // Propriedade que representa o professor ou instrutor do curso
        public string Professor { get; private set; }

        // Propriedade que representa a carga horária do curso
        public string Duration { get; private set; }

        // Propriedade que representa a descrição do curso
        public string Description { get; private set; }

        // Construtor que inicializa todas as propriedades
        public Course(string title, string professor, string duration, string description)
        {
            Title = title;
            Professor = professor;
            Duration = duration;
            Description = description;
        }

        // Método estático de fábrica para criar uma instância da entidade Course
        public static Course Create(string title, string professor, string duration, string description)
        {
            return new Course(title, professor, duration, description);
        }

        // Override do método ToString para facilitar a exibição dos dados do curso
        public override string ToString()
        {
            return $"Curso: {Title}, Professor: {Professor}, Carga Horária: {Duration}, Descrição: {Description}";
        }
    }
}
