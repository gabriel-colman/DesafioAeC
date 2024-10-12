using DesafioAeC.Domain.Entities;

namespace DesafioAeC.Application.DTOs
{
    public class CourseDTO
    {
        // Propriedade para o título do curso
        public string Title { get; set; }

        // Propriedade para o nome do professor
        public string Professor { get; set; }

        // Propriedade para a carga horária
        public string Duration { get; set; }

        // Propriedade para a descrição do curso
        public string Description { get; set; }

        // Construtor que inicializa as propriedades
        public CourseDTO(string title, string professor, string duration, string description)
        {
            Title = title;
            Professor = professor;
            Duration = duration;
            Description = description;
        }

        // Método para converter o DTO em uma entidade Course
        public Course ToEntity()
        {
            return new Course(Title, Professor, Duration, Description);
        }
    }
}
